using System.Text.Json;
using Blauhaus.Errors.Extensions;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class StringIsErrorTests
    {
        [Test]
        public void IsError_SHOULD_return_TRUE_if_Error_same()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorTwo.ToString();

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorTwo);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsError_SHOULD_return_TRUE_if_ErrorCode_same_but_Description_different()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorThree("one example").ToString();

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorThree(""));

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsError_SHOULD_return_FALSE_if_Error_different()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorTwo.ToString();

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorOne);

            //Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void IsError_SHOULD_return_FALSE_if_Error_invalid()
        {
            //Arrange
            var serializedError = "fake new error";

            //Act
            var result = serializedError.IsError(TestErrors.TestErrorOne);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IF_No_error_is_provided_SHOULD_return_true_if_string_is_in_error_format()
        {
            //Arrange
            var serializedError = TestErrors.TestErrorThree("one example").ToString();

            //Act
            var result = serializedError.IsError();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IF_No_error_is_provided_SHOULD_return_false_if_string_is_not_in_error_format()
        {
            //Arrange
            var serializedError = "error";

            //Act
            var result = serializedError.IsError();

            //Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void IF_is_serialized_Json_Error_SHOULD_deserialize()
        {
            //Arrange
            var serializedError = JsonSerializer.Serialize(TestErrors.TestErrorTwo);

            //Act
            var result = serializedError.IsError(out var error);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(error, Is.EqualTo(TestErrors.TestErrorTwo));
        }
        
        [Test]
        public void IF_is_serialized_Json_Error_case_insensitive_SHOULD_deserialize()
        {
            //Arrange
            var serializedError = "{\"code\":\"TestErrorTwo\",\"description\":\"Description Two\"}";

            //Act
            var result = serializedError.IsError(out var error);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(error, Is.EqualTo(TestErrors.TestErrorTwo));
        }
    }
}