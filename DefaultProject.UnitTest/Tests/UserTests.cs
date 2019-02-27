using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Repositories.UserRepository;
using DefaultProject.Domain.Services.UserService;
using DefaultProject.Domain.ValueObjects;
using DefaultProject.UnitTest.FakeRepositories;
using Moq;
using SimpleInjector;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DefaultProject.UnitTest.Tests
{
    public class UserTests
    {
        private readonly IUserService _userService;
        private readonly Container container;

        public List<User> users = new List<User>()
        {
            new User(){
                Id = 1,
                Name = new Name(){ FirstName = "Jairo", LastName = "Bionez" },
                Address = new Address() {
                    City = "Crav",
                    Country = "Br",
                    Neighborhood = "Aca",
                    Number = "656",
                    State = "SP",
                    Street = "Manoel",
                    ZipCode = "14140"
                }
            },
            new User(){
                Id = 2,
                Name = new Name(){ FirstName = "Lucas", LastName = "Fiuza" },
                Address = new Address() {
                    City = "Serr",
                    Country = "Br",
                    Neighborhood = "Aca",
                    Number = "656",
                    State = "SP",
                    Street = "xxx",
                    ZipCode = "5988"
                }
            },
        };

        public UserTests()
        {
            container = new Container();
            container.Register<IUserRepository, UserRepositoryFake>();
            container.Register<IUserService, UserService>();

            container.Verify();

            var userRepositoryFake = new Mock<UserRepositoryFake>();            

            userRepositoryFake.Object.list = users;

            _userService = new UserService(userRepositoryFake.Object);
        }

        [Fact(DisplayName = "Should get all users")]       
        public void ShouldGetAllUsers()
        {
            // Act
            var result = _userService.Get();

            //Assert
            Assert.Equal(2, result.Count());
        }

        [Theory(DisplayName = "Should get user by id")]
        [InlineData(1, "Jairo")]
        [InlineData(2, "Lucas")]        
        public void ShouldGetUserById(long id, string expected)
        {
            // Act
            var result = _userService.GetById(id);

            //Assert
            Assert.Equal(expected, result.Name.FirstName);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should get user by id")]
        public void ShouldBeInvalid()
        {
            // Arrange
            long id = 0;

            // Act
            var result = _userService.GetById(id);

            //Assert
            Assert.True(_userService.Invalid);            
        }

        [Fact(DisplayName = "Should delete user")]       
        public void ShouldDeleteUser()
        {
            // Arrange
            long id = 3;

            // Act
            var result = _userService.Delete(id);

            //Assert
            Assert.True(_userService.Invalid);
        }
    }
}
