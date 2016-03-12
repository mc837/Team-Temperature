using Models;
using NUnit.Framework;
using Repository;
using Rhino.Mocks;
using Team_Temperature.Infrastructure.Commands;
using Team_Temperature.Infrastructure.Queries;

namespace API.Tests.Infrastructure.Queries
{
    public class GetAllUsersQueryTests
    {
        private IUserRepository _mockedRepo;
        private GetAllUsersQuery _query;

        [SetUp]
        public void Setup()
        {
            _mockedRepo = MockRepository.GenerateMock<IUserRepository>();
            _query = new GetAllUsersQuery(_mockedRepo);
        }
        [Test]
        public void should_CallIntoUserRepositry_When_Invoked()
        {
            _query.Execute();
            _mockedRepo.AssertWasCalled(r => r.GetAllUsers());
        }
    }
}
