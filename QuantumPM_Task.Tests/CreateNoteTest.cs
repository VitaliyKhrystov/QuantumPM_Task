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
    public class CreateNoteTest : TestContext
    {
        private IConfiguration config;
        private Mock<INoteRepository> noteRepositoryMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<CreateNote>> loggerMock;
        private CreateNote createNote;

        public CreateNoteTest()
        {
            config = CustomConfig.Get();
            noteRepositoryMock = new Mock<INoteRepository>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<CreateNote>>();
            createNote= new CreateNote();
        }

        [Fact]
        public void ClickButton_CallMethodAddNote_ResultsCompletedSuccessfully()
        {
            //Arrange
            Services.AddScoped<IConfiguration>((p) => config);
            Services.AddScoped<INoteRepository>(((p) => noteRepositoryMock.Object));
            Services.AddScoped<ILogger<CreateNote>>((p) => loggerMock.Object);
            Services.AddScoped<IMapper>((r) => mapperMock.Object);
            Services.AddScoped<NavigationManager>((p) => new TestNav());

            var cut = RenderComponent<CreateNote>();

            //Act
            cut.Find("button").Click();
            var result = cut.Instance.AddNote();

            //Assert
            Assert.Equal(result.IsCompletedSuccessfully, true);
        }

        [Fact]
        public void CallMethodGetLength_CompareTitleCounter()
        {
            //Arrange
            string testString = "Title";
            int length = testString.Length;
            int titleCounter = 0;
            ChangeEventArgs eventArgs = new ChangeEventArgs() { Value = testString };
            var counter = typeof(CreateNote).GetProperty("TitleCounter", BindingFlags.NonPublic | BindingFlags.Instance);

            //Act
            counter.SetValue(createNote, titleCounter);
            createNote.GetLength(eventArgs, "title");
            var retrievedTitleCounter = (int)counter.GetValue(createNote);

            //Assert
            Assert.True(retrievedTitleCounter == length);
        }
    }

}
