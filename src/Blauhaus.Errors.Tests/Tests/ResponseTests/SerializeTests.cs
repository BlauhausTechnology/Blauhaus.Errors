using System.Runtime.InteropServices.ComTypes;
using Blauhaus.Responses;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ResponseTests
{
    public class SerializeTests
    {

        private static Error TestError => Error.Create("Test");

        [Test]
        public void SHOULD_serialize_and_desrialize_success_Response()
        {
            //Arrange
            var response = Response.Success();

            //Act
            var serialized = JsonConvert.SerializeObject(response);
            var deserialized = JsonConvert.DeserializeObject<Response>(serialized);

            //Assert
            Assert.That(deserialized.IsSuccess);
        }

        [Test]
        public void SHOULD_serialize_and_desrialize_failure_Response()
        {
            //Arrange
            var response = Response.Failure(TestError);

            //Act
            var serialized = JsonConvert.SerializeObject(response);
            var deserialized = JsonConvert.DeserializeObject<Response>(serialized);

            //Assert
            Assert.That(deserialized.IsFailure);
            Assert.That(deserialized.Error.Code, Is.EqualTo(TestError.Code));
            Assert.That(deserialized.Error.Description, Is.EqualTo(TestError.Description));
        }

        [Test]
        public void SHOULD_serialize_and_desrialize_success_Response_of_T()
        {
            //Arrange
            var value = "Hello World";
            var response = Response.Success(value);

            //Act
            var serialized = JsonConvert.SerializeObject(response);
            var deserialized = JsonConvert.DeserializeObject<Response<string>>(serialized);

            //Assert
            Assert.That(deserialized.IsSuccess);
            Assert.That(deserialized.Value, Is.EqualTo("Hello World"));
        }

        [Test]
        public void SHOULD_serialize_and_desrialize_failure_Response_of_T()
        {
            //Arrange
            var response = Response.Failure<string>(TestError);

            //Act
            var serialized = JsonConvert.SerializeObject(response);
            var deserialized = JsonConvert.DeserializeObject<Response<string>>(serialized);

            //Assert
            Assert.That(deserialized.IsFailure);
            Assert.That(deserialized.Error.Code, Is.EqualTo(TestError.Code));
            Assert.That(deserialized.Error.Description, Is.EqualTo(TestError.Description));
        }
    }
}