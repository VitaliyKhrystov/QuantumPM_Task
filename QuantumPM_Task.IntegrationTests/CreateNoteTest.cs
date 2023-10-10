using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace QuantumPM_Task.IntegrationTests
{
    public class CreateNoteTest
    {
        private WebApplicationFactory<Program> factory;
      
        public CreateNoteTest()
        {
            factory = new WebApplicationFactory<Program>();
            
        }

        [Fact]
        public async Task CheckStatusResponse_StatusOk()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/create");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/create");

            // Assert
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
