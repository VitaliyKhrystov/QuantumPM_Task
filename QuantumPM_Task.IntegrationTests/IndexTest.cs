using AutoMapper;
using Bunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using QuantumPM_Task.Domain.Repository.Abstract;
using System.Net;
using Index = QuantumPM_Task.Pages.Index;

namespace QuantumPM_Task.IntegrationTests
{
    public class IndexTest:TestContext, IDisposable
    {
        private WebApplicationFactory<Program> factory;
        private Mock<INoteRepository> noteRepositoryMock;
        private Mock<IMapper> mapperMock;
        private Index indexComponent;
        private HttpClient client;

        public IndexTest()
        {
            noteRepositoryMock= new Mock<INoteRepository>();
            mapperMock= new Mock<IMapper>();
            factory = new WebApplicationFactory<Program>();
            client = factory.CreateClient();
            indexComponent = new Index();
        }
        [Fact]
        public async Task CheckStatusResponse_StatusOk()
        {
            // Arrange

            // Act
            var response = await client.GetAsync("/");
            var response2 = await client.GetAsync("/index");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async Task CheckStatusResponseAndHtmlTextResponse_ResultStatusOkAndHTMLcontainsExpectedText()
        {
            // Arrange
            var expectedTextResponse = "Sorry, there's nothing at this address";

            // Act
            var response = await client.GetAsync("/index/5");
            string result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Contains(expectedTextResponse));
        }
   
        public void Dispose()
        {
            client.Dispose();
            factory.Dispose();
        }
   
    }

}