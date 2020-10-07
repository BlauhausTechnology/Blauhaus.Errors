using System;
using Blauhaus.Errors.Extensions;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class ExceptionIsErrorExtensionTests
    {
        [Test]
        public void IF_Exception_Is_ErrorException_and_Error_is_same_SHOULD_return_TRUE()
        {
            //Arrange
            var errorException = new ErrorException(TestErrors.TestErrorTwo);

            //Act
            var result = errorException.IsErrorException(TestErrors.TestErrorTwo);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IF_Exception_Is_ErrorException_and_Error_is_different_SHOULD_return_FALSE()
        {
            //Arrange
            var errorException = new ErrorException(TestErrors.TestErrorTwo);

            //Act
            var result = errorException.IsErrorException(TestErrors.TestErrorOne);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IF_Exception_Is_not_ErrorException_SHOULD_return_FALSE()
        {
            //Arrange
            var errorException = new Exception(TestErrors.TestErrorTwo.ToString());

            //Act
            var result = errorException.IsErrorException(TestErrors.TestErrorTwo);

            //Assert
            Assert.IsFalse(result);
        }
         
    }
}