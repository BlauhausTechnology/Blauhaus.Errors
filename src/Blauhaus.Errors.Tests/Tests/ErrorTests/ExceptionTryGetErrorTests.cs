using System;
using Blauhaus.Errors.Extensions;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class ExceptionTryGetErrorTests
    {
        [Test]
        public void IF_Exception_Is_ErrorException_SHOULD_return_Error()
        {
            //Arrange
            var errorException = new ErrorException(TestErrors.TestErrorTwo);

            //Act
            var result = errorException.TryGetError(out var error);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(error.Value, Is.EqualTo(TestErrors.TestErrorTwo));
        } 

        [Test]
        public void IF_Exception_Is_not_ErrorException_SHOULD_return_fnull()
        {
            //Arrange
            var ex = new Exception(TestErrors.TestErrorTwo.ToString());

            //Act
            var result = ex.TryGetError(out var error);

            //Assert
            Assert.That(result, Is.False);
            Assert.That(error, Is.Null);
             
        }
    }
}