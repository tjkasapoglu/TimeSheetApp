using ConsoleApplication1;
using System;
using Xunit;

namespace UnitTestProject1 : 
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
        public void SelectUsers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateDriver();
            bool option = true;

            // Act
            unitUnderTest.SelectUsers(
                option);

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void CreateUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateDriver();

            // Act
            unitUnderTest.CreateUser();

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void AddHours_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateDriver();
            Users currentUser = TODO;
            Users allUsers = TODO;

            // Act
            unitUnderTest.AddHours(
                currentUser,
                allUsers);

            // Assert
            Assert.Fail();
        }
    }

    internal class Driver
    {
    }
}
