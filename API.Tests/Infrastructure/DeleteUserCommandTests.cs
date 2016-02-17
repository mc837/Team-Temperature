using Models;
using NUnit.Framework;
using Repository;
using Rhino.Mocks;
using Team_Temperature.Infrastructure.Commands;

namespace API.Tests.Infrastructure
{
    public class DeleteUserCommandTests
    {
        private IUserRepository _mockedRepo;
        private DeleteUserCommand _command;

        [SetUp]
        public void Setup()
        {
            _mockedRepo = MockRepository.GenerateMock<IUserRepository>();
            _command = new DeleteUserCommand(_mockedRepo);
        }
        [Test]
        public void should_CallIntoUserRepositry_When_Invoked()
        {
            var user = new UserModel { FirstName = "FirstName" };
            _command.Execute(user);
            _mockedRepo.AssertWasCalled(r => r.DeleteUser(Arg<UserModel>.Is.Equal(user)));
        }
    }
}
