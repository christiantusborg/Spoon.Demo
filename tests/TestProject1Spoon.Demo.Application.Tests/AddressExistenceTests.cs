namespace TestProject1Spoon.Demo.Application.Tests;

using System.Reflection;
using System.Reflection.Emit;
using Spoon.Demo.Application;

public class AddressExistenceTests
{



        [Theory]
        [InlineData("Create","CommandV1Validator")]
        [InlineData("Create","CommandV1Handler")]
        [InlineData("Create","CommandV1Result")]
        [InlineData("Create","CommandV1")]
        [InlineData("Create","EndpointV1")]
        [InlineData("Create","EndpointV1Request")]
        [InlineData("Create","EndpointV1RequestExample")]
        [InlineData("Create","EndpointV1Response")]            
        
        [InlineData("Delete","CommandV1Validator")]
        [InlineData("Delete","CommandV1Handler")]
        [InlineData("Delete","CommandV1Result")]
        [InlineData("Delete","CommandV1")]
        [InlineData("Delete","EndpointV1")]
        
        [InlineData("Get","CommandV1Validator")]
        [InlineData("Get","CommandV1Handler")]
        [InlineData("Get","CommandV1Result")]
        [InlineData("Get","CommandV1")]
        [InlineData("Get","EndpointV1")]
        [InlineData("Get","EndpointV1Response")]            
        [InlineData("Get","EndpointV1ResponseExample")]
        
        [InlineData("GetAll","CommandV1Validator")]
        [InlineData("GetAll","CommandV1Handler")]
        [InlineData("GetAll","CommandV1Result")]
        [InlineData("GetAll","CommandV1")]
        [InlineData("GetAll","EndpointV1")]
        [InlineData("GetAll","EndpointV1Request")]
        [InlineData("GetAll","EndpointV1RequestExample")]        
        [InlineData("GetAll","EndpointV1Response")]            
        [InlineData("GetAll","EndpointV1ResponseExample")]
        
        [InlineData("UnDelete","CommandV1Validator")]
        [InlineData("UnDelete","CommandV1Handler")]
        [InlineData("UnDelete","CommandV1Result")]
        [InlineData("UnDelete","CommandV1")]
        [InlineData("UnDelete","EndpointV1")] 
        
        [InlineData("Update","CommandV1Validator")]
        [InlineData("Update","CommandV1Handler")]
        [InlineData("Update","CommandV1Result")]
        [InlineData("Update","CommandV1")]
        [InlineData("Update","EndpointV1")]
        [InlineData("Update","EndpointV1Request")]
        [InlineData("Update","EndpointV1RequestExample")]        
   
        public void CommandClass_ShouldExist(string classPartNameOne,string classPartNameTwo )
        {
            var x = typeof(IApplicationAssemblyMarker); 
            // Arrange
            string testClassName = GetType().Name;
            string className = $"{testClassName.Split("Existence")[0]}" + classPartNameOne + classPartNameTwo;
            Type classType = ClassType.GetClassType(className);

            // Assert
            Assert.NotNull(classType);
        }
}