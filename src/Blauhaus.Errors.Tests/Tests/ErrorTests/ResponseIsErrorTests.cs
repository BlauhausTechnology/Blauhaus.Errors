using Blauhaus.Errors.Extensions;
using Blauhaus.Responses;
using Blauhaus.Responses.Extensions;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class ResponseIsErrorTests
    {
        [Test]
        public void IF_Result_is_success_SHOULD_return_false()
        {
            //Arrange
            var successOne = Response.Success();
            var successTwo = Response.Success<int>(1);

            //Act
            var resultOne = successOne.IsError(TestErrors.TestErrorOne);
            var resultTwo = successTwo.IsError(TestErrors.TestErrorOne);

            //Assert
            Assert.IsFalse(resultOne);
            Assert.IsFalse(resultTwo);
        }

        [Test]
        public void IF_Result_failure_is_same_serialized_Error_SHOULD_return_true()
        {
            //Arrange
            var failOne = Response.Failure(TestErrors.TestErrorOne);
            var failTwo = Response.Failure<int>(TestErrors.TestErrorTwo);
            var failThree = Response.Failure(TestErrors.TestErrorThree("three"));
            var failFour = Response.Failure(TestErrors.TestErrorThree("four"));

            //Act
            var resultOne = failOne.IsError(TestErrors.TestErrorOne);
            var resultTwo = failTwo.IsError(TestErrors.TestErrorTwo);
            var resultThree = failThree.IsError(TestErrors.TestErrorThree("three"));
            var resultFour = failThree.IsError(TestErrors.TestErrorThree("four"));

            //Assert
            Assert.IsTrue(resultOne);
            Assert.IsTrue(resultTwo);
            Assert.IsTrue(resultThree);
            Assert.IsTrue(resultFour);
        }
        
        [Test]
        public void IF_Result_failure_is_different_serialized_Error_SHOULD_return_false()
        {
            //Arrange
            var failOne = Response.Failure(TestErrors.TestErrorOne.ToString());
            var failTwo = Response.Failure<int>(TestErrors.TestErrorTwo.ToString());
            var failThree = Response.Failure(TestErrors.TestErrorThree("three").ToString());
            var failFour = Response.Failure(TestErrors.TestErrorThree("four").ToString());

            //Act
            var resultOne = failOne.IsError(TestErrors.TestErrorTwo);
            var resultTwo = failTwo.IsError(TestErrors.TestErrorThree("four"));
            var resultThree = failThree.IsError(TestErrors.TestErrorTwo);
            var resultFour = failThree.IsError(TestErrors.TestErrorOne);

            //Assert
            Assert.IsFalse(resultOne);
            Assert.IsFalse(resultTwo);
            Assert.IsFalse(resultThree);
            Assert.IsFalse(resultFour);
        }
    }
}