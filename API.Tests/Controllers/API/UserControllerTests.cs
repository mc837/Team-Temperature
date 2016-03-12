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
        private IAddUserCommand _mockedAddUserCommand;
        private IEditUserCommand _mockedEditUserCommand ;
        private IDeleteUserCommand _mockedDeleteUserCommand;

        [SetUp]
        public void Setup()
        {
            _mockedAddUserCommand = MockRepository.GenerateMock<IAddUserCommand>();
            _mockedEditUserCommand = MockRepository.GenerateMock<IEditUserCommand>();
            _mockedDeleteUserCommand = MockRepository.GenerateMock<IDeleteUserCommand>();
            _controller = new UserController(_mockedAddUserCommand, _mockedEditUserCommand, _mockedDeleteUserCommand, );
        }

        [Test]
        public void should_ReturnCreatedStatus_When_AUserIsAddedSuccessfully()
        {
            var user = new UserModel {FirstName = "FirstName"};
            var expectedStatusCode = new HttpResponseMessage(HttpStatusCode.Created);
            _mockedAddUserCommand.Stub(c => c.Execute(user)).Return(true);


            var result = _controller.Add(user);

           Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode.StatusCode));
        }

        [Test]
        public void should_ReturnNotImplementedStatus_When_AUserIsNotAdded()
        {
            var user = new UserModel { FirstName = "FirstName" };
            var expectedStatusCode = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            _mockedAddUserCommand.Stub(c => c.Execute(user)).Return(false);
            
            var result = _controller.Add(user);

            Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode.StatusCode));
        }

        [Test]
        public void should_ReturnSuccessStatus_When_AUserIsUpdated()
        {
            var user = new UserModel { FirstName = "FirstName" };
            var expectedStatusCode = new HttpResponseMessage(HttpStatusCode.OK);
            _mockedEditUserCommand.Stub(c => c.Execute(user)).Return(true);
            
            var result = _controller.Edit(user);

            Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode.StatusCode));
        }

        [Test]
        public void should_ReturnNotImplementedStatus_When_AUserIsNotUpdated()
        {
            var user = new UserModel { FirstName = "FirstName" };
            var expectedStatusCode = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            _mockedEditUserCommand.Stub(c => c.Execute(user)).Return(false);

            var result = _controller.Edit(user);

            Assert.That(result.StatusCode, Is.EqualTo(expectedStatusCode.StatusCode));
        }
    }
}
