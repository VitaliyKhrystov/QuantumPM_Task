using Bunit;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using System.Net;


namespace QuantumPM_Task.IntegrationTests
{
    public class EditNoteTest:TestContext
    {

        [Fact]
        public async Task CheckStatusResponse_StatusOk_CompareResponseJsonData()
        {
            // Arrange
            var noteid = "235";
            var title = "Title1";
            var content = "Some Text";
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://localhost//edit//*").Respond("application/json", "{'Id' : '235', 'Title' : 'Title1', 'Content' : 'Some Text'}");
            var client = new HttpClient(mockHttp);


            // Act
            var response = await client.GetAsync($"http://localhost//edit//{noteid}");
            var json = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TestNote>(json);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(noteid, obj.Id);
            Assert.Equal(title, obj.Title);
            Assert.Equal(content, obj.Content);
        }

        class TestNote
        {
            [JsonProperty("Id")]
            public string Id { get; set; }
            [JsonProperty("Title")]
            public string Title { get; set; }
            [JsonProperty("Content")]
            public string Content { get; set; }
        }
    }
}
