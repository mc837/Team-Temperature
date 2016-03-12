using Models;
using NUnit.Framework;
using Repository;
using Rhino.Mocks;
using Team_Temperature.Infrastructure.Commands;

namespace API.Tests.Infrastructure.Commands
{
    [TestFixture]
    public class AddUserCommandTests
    {
        private IUserRepository _mockedRepo;
        private AddUserCommand _command;

        [SetUp]
        public void Setup()
        {
            _mockedRepo = MockRepository.GenerateMock<IUserRepository>();
            _command = new AddUserCommand(_mockedRepo);
        }
        [Test]
        public void should_CallIntoUserRepositry_When_Invoked()
        {
            var user = new UserModel { FirstName = "FirstName" };
            _command.Execute(user);
            _mockedRepo.AssertWasCalled(r=>r.AddUser(Arg<UserModel>.Is.Equal(user)));
        }	
    }
}
