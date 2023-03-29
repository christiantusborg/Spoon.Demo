namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using Helpers;
using MediatR;
using SharedSpecification;

/// <summary>
/// A MediatR command handler that adds an email address for a user in the administration context.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global - instantiated by MediatR
public sealed class AdministrationAddUserEmailCommandHandler : IRequestHandler<AdministrationAddUserEmailCommand, Either<AdministrationAddUserEmailCommandResult>>
{
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly IHashService _hashService;


    /// <summary>
    /// Initializes a new instance of the <see cref="AdministrationAddUserEmailCommandHandler"/> class.
    /// </summary>
    /// <param name="mockbleGuidGenerator">The mockable GUID generator.</param>
    /// <param name="mockbleDateTime">The mockable date/time service.</param>
    /// <param name="repository">The repository for accessing data.</param>
    /// <param name="encryptionService">The service for encrypting data.</param>
    /// <param name="hashService">The service for hashing data.</param>

    public AdministrationAddUserEmailCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator,
        IMockbleDateTime mockbleDateTime,
        ISecureRemotePasswordRepository repository,
        IEncryptionService encryptionService,
        IHashService hashService)
    {
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
        this._repository = repository;
        this._encryptionService = encryptionService;
        this._hashService = hashService;
    }

    /// <summary>
    /// Handles the specified request to add an email address for a user.
    /// </summary>
    /// <param name="request">The command to add an email address for a user.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>An Either instance indicating either the success or failure of the operation, and containing additional information if it succeeded.</returns>
    public async Task<Either<AdministrationAddUserEmailCommandResult>> Handle(
        AdministrationAddUserEmailCommand request,
        CancellationToken cancellationToken)
    {
        // Get the user by their ID from the repository
        var user = await this._repository.Users.Get(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (user == null)
            return EitherHelper<AdministrationAddUserEmailCommandResult>.EntityNotFound(typeof(User));

        // Hash the email address
        var emailAddressHash = this._hashService.Hash(request.Email);

        // Check if the email address already exists. If it does, return an error.
        var emailExists = await this._repository.UserEmails.Get(new GetEmailByHashSpecification(emailAddressHash), cancellationToken);
        if (emailExists != null)
            return EitherHelper<AdministrationAddUserEmailCommandResult>.EntityAlreadyExists(typeof(UserEmail));

        // Generate a new ID and encrypt the email address
        var emailId = this._mockbleGuidGenerator.NewGuid();
        var emailAddressEncrypted = this._encryptionService.Encrypt(request.Email);

        // Create a new UserEmail object with the provided information
        var userEmail = new UserEmail
        {
            EmailId = emailId,
            IsPrimary = 0,
            UserId = request.UserId,
            EmailAddressEncrypted = emailAddressEncrypted,
            EmailAddressHash = emailAddressHash,
            EmailAddressVerifiedAt = null,
            CreatedAt = this._mockbleDateTime.UtcNow,
            UpdatedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        // Add the new UserEmail object to the repository and save the changes
        this._repository.UserEmails.Add(userEmail);
        await this._repository.SaveChangesAsync(cancellationToken);

        // Return a new AdministrationAddUserEmailCommandResult with the generated email ID
        var result = new Either<AdministrationAddUserEmailCommandResult>(new AdministrationAddUserEmailCommandResult
        {
            EmailId = emailId,
        });
        return result;
    }
}