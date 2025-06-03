using Core.Interface;
using Core.Models;
using FiapCloudGamesAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class GamesControllerTests
{
    private readonly Mock<IGameRepository> _gameRepoMock;
    private readonly GamesController _controller;

    public GamesControllerTests()
    {
        _gameRepoMock = new Mock<IGameRepository>();
        _controller = new GamesController(_gameRepoMock.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsListOfGames()
    {
        // Arrange
        var games = new List<Game>
        {
            new Game { Id = 1, Nome = "Jogo 1", Preco = 99.99m },
            new Game { Id = 2, Nome = "Jogo 2", Preco = 49.99m }
        };

        _gameRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(games);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnGames = Assert.IsAssignableFrom<IEnumerable<Game>>(okResult.Value);
        Assert.Equal(2, returnGames.Count());
    }
}
