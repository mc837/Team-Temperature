using System.Net;
using System.Net.Http;
using Models;
using NUnit.Framework;
using Rhino.Mocks;
using Team_Temperature.Controllers.API;
using Team_Temperature.Infrastructure.Commands;

namespace API.Tests.Controllers.API
{
    [TestFixture]
    class UserControllerTests
    {
        private UserController _controller;
        private IAddUserCommand _mockedCommand;

        [SetUp]
        public void Setup()
        {
            _mockedCommand = MockRepository.GenerateMock<IAddUserCommand>();
            _controller = new UserController(_mockedCommand);
        }

        [Test]
        public void should_ReturnCreatedStatus_When_AUserIsAddedSuccessfully()
        {
            var user = new UserModel {FirstName = "FirstName"};
            var expectedStatusCode = new HttpResponseMessage(HttpStatusCode.Created);
            _mockedCommand.Stub(c => c.Execute(user)).Return(true);


            var result = _controller.Add(user);

           Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode.StatusCode));
        }

        [Test]
        public void should_ReturnCreatedStatus_When_AUserIsNotAdded()
        {
            var user = new UserModel { FirstName = "FirstName" };
            var expectedStatusCode = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            _mockedCommand.Stub(c => c.Execute(user)).Return(false);


            var result = _controller.Add(user);

            Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode.StatusCode));
        }
    }
}
