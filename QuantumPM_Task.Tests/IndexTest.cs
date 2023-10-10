using Bunit;
using Microsoft.AspNetCore.Components;
using QuantumPM_Task.Models;
using System.Reflection;
using Index = QuantumPM_Task.Pages.Index;

namespace QuantumPM_Task.Tests
{
    public class IndexTest
    {
        private Index index;
        private List<NoteModel> allNotesList;
        private List<NoteModel> notesAfterSearch;
        public IndexTest()
        {
            index = new Index();
            allNotesList = GetNotesList();
            notesAfterSearch = new();
        }
        [Fact]
        public void TestMethodSearchNote_GetEqualCountItems()
        {
            //Arrange
            string searchItem = "Title";
            ChangeEventArgs eventArgs = new ChangeEventArgs() { Value = searchItem };
            Type type = typeof(Index);
            var allNotesListField = type.GetProperty("AllNotesList", BindingFlags.NonPublic | BindingFlags.Instance);
            var notesAfterSearchField = type.GetProperty("NotesAfterSearch", BindingFlags.NonPublic | BindingFlags.Instance);
           
            //Act
            allNotesListField.SetValue(index, allNotesList);
            notesAfterSearchField.SetValue(index, notesAfterSearch);
            index.SearchNote(eventArgs);
            var retrievedNotesAfterSearch = notesAfterSearchField.GetValue(index) as List<NoteModel>;

            //Assert
            Assert.Equal(retrievedNotesAfterSearch.Count(), allNotesList.Count());       
        }

        [Fact]
        public void TestMethodSearchNote_CheckFilter_GetSecondListElementWithTitle2()
        {
            //Arrange
            string searchItem = "Some text2";
            ChangeEventArgs eventArgs = new ChangeEventArgs() { Value = searchItem };
            Type type = typeof(Index);
            var allNotesListField = type.GetProperty("AllNotesList", BindingFlags.NonPublic | BindingFlags.Instance);
            var notesAfterSearchField = type.GetProperty("NotesAfterSearch", BindingFlags.NonPublic | BindingFlags.Instance);

            //Act
            allNotesListField.SetValue(index, allNotesList);
            notesAfterSearchField.SetValue(index, notesAfterSearch);
            index.SearchNote(eventArgs);
            var retrievedNotesAfterSearch = notesAfterSearchField.GetValue(index) as List<NoteModel>;

            //Assert
            var secondItem = allNotesList.First(n => n.Content == searchItem);
            Assert.Equal(retrievedNotesAfterSearch.First(), secondItem);
        }

        static List<NoteModel> GetNotesList()
    {
       return new List<NoteModel>() { 
            new NoteModel(){ 
                Id = Guid.NewGuid(),
                Title = "Title1",
                Content = "Some text"
            },
             new NoteModel(){
                Id = Guid.NewGuid(),
                Title = "Title2",
                Content = "Some text2"
            },
                new NoteModel(){
                Id = Guid.NewGuid(),
                Title = "Title2",
                Content = "Some text3"
            },
       };
    }
    }
}