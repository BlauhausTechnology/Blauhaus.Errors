using System;
using Blauhaus.Errors.Extensions;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class ExceptionToErrorTests
    {
        [Test]
        public void IF_Exception_Is_ErrorException_SHOULD_return_Error()
        {
            //Arrange
            var errorException = new ErrorException(TestErrors.TestErrorTwo);

            //Act
            var result = errorException.ToError();

            //Assert
            Assert.That(result, Is.EqualTo(TestErrors.TestErrorTwo));
        } 

        [Test]
        public void IF_Exception_Is_not_ErrorException_SHOULD_throw()
        {
            //Arrange
            var ex = new Exception(TestErrors.TestErrorTwo.ToString());

            //Act
            Assert.Throws<ArgumentException>(() => ex.ToError());
             
        }
    }
}