using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Models;
using Models.Enums;
using NUnit.Framework;
using Rhino.Mocks;
using Team_Temperature.Controllers.API;
using Team_Temperature.Infrastructure.Commands;
using Team_Temperature.Infrastructure.Queries;

namespace API.Tests.Controllers.API
{
    [TestFixture]
    class UserControllerTests
    {
        private UserController _controller;
        private IAddUserCommand _mockedAddUserCommand;
        private IEditUserCommand _mockedEditUserCommand ;
        private IDeleteUserCommand _mockedDeleteUserCommand;
        private IGetAllUsersQuery _mockedGetAllUsersQuery;

        [SetUp]
        public void Setup()
        {
            _mockedAddUserCommand = MockRepository.GenerateMock<IAddUserCommand>();
            _mockedEditUserCommand = MockRepository.GenerateMock<IEditUserCommand>();
            _mockedDeleteUserCommand = MockRepository.GenerateMock<IDeleteUserCommand>();
            _mockedGetAllUsersQuery = MockRepository.GenerateMock<IGetAllUsersQuery>();
            _controller = new UserController(_mockedAddUserCommand, _mockedEditUserCommand, _mockedDeleteUserCommand, _mockedGetAllUsersQuery);
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

        [Test]
        public void should_ReturnAllValidUsers_When_GetCurrentUsersIsCalled()
        {
            var userId = Guid.NewGuid();
            var getAllUsersResponse = new List<UserModel>
            {
                new UserModel {Id=userId, FirstName = "Firstname1", Surname = "Surname1", Email="email@email.com1", Deleted = false, Priviledge = Priviledge.Normal},
                new UserModel {Id=userId, FirstName = "Firstname2", Surname = "Surname2", Email="email@email.com2", Deleted = true, Priviledge = Priviledge.Normal},
                new UserModel {Id=userId, FirstName = "Firstname3", Surname = "Surname3", Email="email@email.com3", Deleted = false, Priviledge = Priviledge.Normal}
            };

            _mockedGetAllUsersQuery.Stub(q => q.Execute()).Return(getAllUsersResponse);

            var result = _controller.AllValidUsers();

            Assert.That(result.UserCount, Is.EqualTo(2));
        }
    }
}
