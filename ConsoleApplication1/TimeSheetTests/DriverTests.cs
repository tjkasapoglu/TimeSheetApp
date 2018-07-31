using ConsoleApplication1;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace TimeSheetTests
{
    public class DriverTests
    {


        public DriverTests()
        {

        }


        private Driver CreateDriver()
        {
            return new Driver();
        }

        [Fact]
        public void CreateUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateDriver();

            // Act
            Driver.CreateUser();

            // Assert
            Assert.True(false, "Test has failed");
        }

        [Fact]
        public void AddHours_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateDriver();
            Users currentUser = null;
            currentUser = new Users(fName: "test", lName: "testlast", title: "testlead");
            Users allUsers = currentUser;

            // Act
            Driver.AddHours(
                currentUser,
                allUsers);

            // Assert
           Assert.True(false, "Test has failed");
        }
    }
}
