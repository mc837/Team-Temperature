using Models;
using NUnit.Framework;
using Repository;
using Rhino.Mocks;
using Team_Temperature.Infrastructure.Commands;

namespace API.Tests.Infrastructure.Commands
{
    public class EditUserCommandTests
    {
        private IUserRepository _mockedRepo;
        private EditUserCommand _command;

        [SetUp]
        public void Setup()
        {
            _mockedRepo = MockRepository.GenerateMock<IUserRepository>();
            _command = new EditUserCommand(_mockedRepo);
        }
        [Test]
        public void should_CallIntoUserRepositry_When_Invoked()
        {
            var user = new UserModel { FirstName = "FirstName" };
            _command.Execute(user);
            _mockedRepo.AssertWasCalled(r => r.UpdateUser(Arg<UserModel>.Is.Equal(user)));
        }
    }
}
