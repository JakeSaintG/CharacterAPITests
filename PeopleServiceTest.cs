
using System.Collections.Generic;
using PeopleAPI.Services;
using PeopleAPI.Models;
using Xunit;

namespace PeopleAPITests
{
    public class PeopleServiceTest
    {   
        [Fact]
        public void GetAllLists_PassTest()
        {
            //Act
            var actual = PeopleService.GetAll();
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("john"));
            //Assert
            Assert.IsType<List<Person>>(actual);
            Assert.True(doesReturnContainExpected);
        }

        [Fact]
        public void GetImageServicePass_Test()
        {
            //Arrange
            string testUrl = "john";

            //Act
            var actual = PeopleService.Get(testUrl);
            foreach (var item in actual)
            {
                item.Image = null;
            }
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("john"));
            
            //Assert
            Assert.NotEmpty(actual);
            Assert.True(doesReturnContainExpected);
        }

        [Fact]
        public void GetArrayFail_Test()
        {
            //Arrange
            string testUrl = "jon";

            //Act
            var actual = PeopleService.Get(testUrl);
            foreach (var item in actual)
            {
                item.Image = null;
            }
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("jon"));
            
            //Assert
            Assert.Empty(actual);
            Assert.False(doesReturnContainExpected);
        }

        [Fact]
        public void AddPerson_Test()
        {
            //Arrange
            Person person = new Person {Name = "Janis Joplin"};
            //Act
            PeopleService.Add(person);
            string retrive = "Janis";
            var actual = PeopleService.Get(retrive);
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("Janis"));
            //Assert
            Assert.True(doesReturnContainExpected);
        }
    }
}
