namespace Spoon.Demo.Root.Swagger;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

// using Swashbuckle.Swagger;

/// <summary>
///   Class SwaggerExamplesFilter.
/// </summary>
public class SwaggerExamplesFilter : ISchemaFilter
{

    /// <summary>
    ///  Applies the specified schema.
    /// </summary>
    /// <param name="schema"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)//== typeof(Operation))
        {
            //schema.Example = new OpenApiString(JsonSerializer.Serialize(
            //new Filter
            //{
            //    Operation = Operation.GreaterThan,
            //    PropertyName= "Name",
            //    Value = "Hej"
            //}));
            var type = context.Type;
            //var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);
            var desc = "";

            foreach (var value in values)
            {
                var intValue = Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()));
                desc += $"{intValue}={value},";
            }
            desc = desc.TrimEnd(',');
            schema.Description = desc;
            // c.MapType<SimpelVauleCreateRequest>(() => new OpenApiSchema
            // {
            //     Type = "SimpelVauleCreateRequest",
            //     Format = "json",
            //     Example = //new OpenApiDate(new DateTime(2020, 1, 1))
            //new OpenApiString(JsonSerializer.Serialize(
            // new SimpelVauleCreateRequest
            // {
            //     SimpelVauleId = Guid.Empty,
            //     Name = "Skriv Navn her",
            //     Tal = 28
            // })),

            // });
        }
        //if (context.Type == typeof(SearchRequest))
        //{
        //    schema.Example = new OpenApiString(JsonSerializer.Serialize(
        //   new SearchRequest
        //   {
        //       Filters = new List<Filter>
        //       {
        //       },
        //       Page = 1,
        //       PageLength = 10,
        //       IncludeDeletedSoft = false
        //   }
        //    ));

        //}
        //if (context.Type == typeof(FilterList))
        //{
        //    schema.Example = new OpenApiString(JsonSerializer.Serialize(
        //   new FilterList
        //   {

        //   }
        //    ));

        //}




        //if (context.Type == typeof(Server.Jobs.Presentation.V86_0.JobMetadataDbs.Commands.Create.JobMetadataDbCreateRequest))
        //{
        //    schema.Example = new OpenApiString(JsonSerializer.Serialize(
        //   new Server.Jobs.Presentation.V86_0.JobMetadataDbs.Commands.Create.JobMetadataDbCreateRequest
        //   {
        //       ClassName = "JobTransfereAsReceiverTransferAsReceiver",
        //       ExecuteAtUTC = DateTime.MinValue,
        //       JobMetadataDbId = Guid.Empty,
        //       JobStatus = JobStatus.Ready,
        //       ParametersName1 = "ReceiverEquipmentId",
        //       ParametersValue1 = "21",
        //   }
        //    ));


        //if (context.Type == typeof(Devices.Shared.Device.Presentation.V86_0.EquipmentConfigurations.Commands.Create.EquipmentConfigurationCreateRequest))
        //{
        //    schema.Example = new OpenApiString(JsonSerializer.Serialize(
        //   new EquipmentConfiguration
        //   {
        //       Number = "GPD83",
        //       EquipmentType = "GPD",
        //       IpAddress = "127.0.0.1",
        //       Port = 3481,
        //       Name = "GPD 83",
        //       Certificates = "GetIngeClientCertificate.hemlig;5e2f346cc27068fabfeef47f8bd60903ae8c5e46"
        //   }
        //    ));

        //}
        //if (context.Type == typeof(Filter))
        //{
        //    schema.Example = new OpenApiString(JsonSerializer.Serialize(
        //    new Filter
        //    {
        //        Operation = Operation.Equals,
        //        PropertyName = "Tal",
        //        Value = 1
        //    }));


        //    // c.MapType<SimpelVauleCreateRequest>(() => new OpenApiSchema
        //    // {
        //    //     Type = "SimpelVauleCreateRequest",
        //    //     Format = "json",
        //    //     Example = //new OpenApiDate(new DateTime(2020, 1, 1))
        //    //new OpenApiString(JsonSerializer.Serialize(
        //    // new SimpelVauleCreateRequest
        //    // {
        //    //     SimpelVauleId = Guid.Empty,
        //    //     Name = "Skriv Navn her",
        //    //     Tal = 28
        //    // })),

        //    // });
        //}
    }
}
