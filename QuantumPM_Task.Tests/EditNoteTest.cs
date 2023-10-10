using AutoMapper;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using QuantumPM_Task.Domain.Repository.Abstract;
using QuantumPM_Task.Pages;
using System.Reflection;

namespace QuantumPM_Task.Tests
{
    public class EditNoteTest : TestContext
    {
        private IConfiguration config;
        private Mock<INoteRepository> noteRepositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<CreateNote>> loggerMock;

        public EditNoteTest()
        {
            config = CustomConfig.Get();
            noteRepositoryMock = new Mock<INoteRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<CreateNote>>();

            Services.AddScoped<IConfiguration>((p) => config);
            Services.AddScoped<INoteRepository>(((p) => noteRepositoryMock.Object));
            Services.AddScoped<ILogger<CreateNote>>((p) => loggerMock.Object);
            Services.AddScoped<IMapper>((r) => mapperMock.Object);
            Services.AddScoped<NavigationManager>((p) => new TestNav());
        }

        [Fact]
        public void SetParameter_CheckValuePropertyNodeId()
        {
            //Arrange
            var testId = "156";
            var editComponent = RenderComponent<EditNote>(parameters => parameters.Add(p => p.NoteId, testId));

            //Act
            var id = editComponent.Instance.NoteId;

            //Assert
            Assert.True(id == testId);
        }

        [Fact]
        public void SetValuesForTitleAndContent_ClickButtonUpdate_GetNewValues()
        {
            //Arrange
            var editComponent = RenderComponent<EditNote>();
            var note = typeof(EditNote).GetField("currentNote", BindingFlags.NonPublic | BindingFlags.Instance);
            editComponent.Find("#note-title").Change("Hello");
            editComponent.Find("#note-content").Change("world");

            //Act
            editComponent.Find("#button-submit").Click();

            //Assert
            var expectedHtml = @$"<div class=""card"">
              <form class=""card-header"" >
                <div class=""mb-3"">
                  <label>Title</label>
                  <input id=""note-title""  maxlength=""0"" class=""form-control modified valid"" value=""Hello""  >
                  <div class=""d-flex justify-content-end opacity-75 align-items-center"">
                    <input class=""text-end border border-0 opacity-75"" value=""0"" >
                    <p>/ 0</p>
                  </div>
                </div>
                <div class=""mb-3"">
                  <label for=""content"" class=""form-label"">Content</label>
                  <textarea id=""note-content"" rows=""3""  maxlength=""0"" class=""form-control modified valid"" value=""world""  ></textarea>
                  <div class=""d-flex justify-content-end opacity-75 align-items-center"">
                    <input class=""text-end border border-0 opacity-75"" value=""0"" >
                    <p>/ 0</p>
                  </div>
                </div>
                <div class=""mb-3"">
                  <label for=""content"" class=""form-label"">Created</label>
                  <input class=""form-control"" rows=""3"" disabled="""" value=""01/01/0001 00:00:00"" >
                </div>
                <button type=""submit"" id=""button-submit"" class=""btn btn-success"">Update</button>
                <button type=""button"" class=""btn btn-danger ms-3"" >Delete</button>
                <a href=""/"" class=""btn btn-secondary ms-3 active"">Back</a>
              </form>
            </div>";

            editComponent.MarkupMatches(expectedHtml);
        }



    }
}

