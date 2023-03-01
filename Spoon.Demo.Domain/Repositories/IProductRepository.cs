﻿namespace Spoon.Demo.Domain.Repositories;

using Entities;
using NuGet.Core.Domain;

/// <summary>
/// Interface IProductRepository.
/// </summary>
public interface IProductRepository : IRootRepository<Product>
{
}