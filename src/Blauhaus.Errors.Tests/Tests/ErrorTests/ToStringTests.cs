using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class ToStringTests
    {
        [Test]
        public void SHOULD_concatenate_code_and_description()
        {
            //Arrange
            var sut = TestErrors.TestErrorTwo;

            //Act
            var result = sut.ToString();

            //Assert
            Assert.AreEqual("TestErrorTwo ::: Description Two", result.ToString());
        }
    }
}