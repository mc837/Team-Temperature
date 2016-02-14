using Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace Repository.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IMongoProvider _mockMongoProvider;
        private UserRepository _repo;

        [SetUp]
        public void Setup()
        {
            _mockMongoProvider = MockRepository.GenerateMock<IMongoProvider>();
            _mockMongoProvider.Stub(p => p.ForCollection(Arg<string>.Is.Anything)).Return(_mockMongoProvider);
            _repo = new UserRepository(_mockMongoProvider);
        }

        [Test]
        public void should_CallIntoProvider_When_AddUserIsCalled()
        {
            var user = new UserModel { FirstName = "FirstName" };

            _mockMongoProvider.Stub(p => p.Insert(user)).Return(true);

            var result = _repo.AddUser(user);

            _mockMongoProvider.AssertWasCalled(p=>p.Insert(Arg<UserModel>.Is.Equal(user)));
            Assert.That(result, Is.True);
        }
    }
}
