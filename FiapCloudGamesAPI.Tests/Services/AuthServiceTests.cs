using Core.Interface;
using Core.Models;
using FiapCloudGamesAPI.DTOs.Auth;
using FiapCloudGamesAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace FiapCloudGamesAPI.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();

            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Key", "supersecretkeyforsigningjwtthatislongenough"},
                {"Jwt:Issuer", "FiapCloudGamesAPI"},
                {"Jwt:Audience", "FiapCloudGamesAPIUser"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _authService = new AuthService(_userRepoMock.Object, _configuration);
            _passwordHasher = new PasswordHasher<User>();
        }



        [Fact]
        public async Task LoginAsync_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "João",
                Email = "joao@example.com",
                Role = UserRole.Usuario,
                Password = BCrypt.Net.BCrypt.HashPassword("Test@123")
            };

            _userRepoMock.Setup(repo => repo.GetByEmailAsync(user.Email)).ReturnsAsync(user);

            var loginDto = new LoginDto
            {
                Email = user.Email,
                Password = "Test@123"
            };

            // Act
            var token = await _authService.LoginAsync(loginDto);

            // Assert
            Assert.NotNull(token);
        }


        [Fact]
        public async Task LoginAsync_WithInvalidPassword_ReturnsNull()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "João",
                Email = "joao@example.com",
                Role = UserRole.Usuario,
                Password = BCrypt.Net.BCrypt.HashPassword("Test@123")
            };

            _userRepoMock.Setup(repo => repo.GetByEmailAsync(user.Email)).ReturnsAsync(user);

            var loginDto = new LoginDto
            {
                Email = user.Email,
                Password = "WrongPassword"
            };

            // Act
            var token = await _authService.LoginAsync(loginDto);

            // Assert
            Assert.Null(token);
        }


        [Fact]
        public async Task RegisterAsync_CreatesUserWithHashedPassword()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                Name = "Maria",
                Email = "maria@example.com",
                Password = "Test@123"
            };

            _userRepoMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            // Act
            var result = await _authService.RegisterAsync(registerDto);

            // Assert
            _userRepoMock.Verify(r => r.AddAsync(It.Is<User>(u =>
                u.Email == registerDto.Email &&
                u.Name == registerDto.Name &&
                u.Role == UserRole.Usuario &&
                u.Password != registerDto.Password
            )), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(registerDto.Email, result.Email);
        }

    }
}
