using Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Services;
using Xunit;
using Moq;
using Domain;

namespace Test;
public class UserControllerTest
{
    [Fact]
    public async Task GetAllAsync_Success_RetornaStatusCode200()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var userController = new UserController(mockUserService.Object);
        
        mockUserService.Setup(userService => userService.GetAllAsync()).ReturnsAsync(new List<User>());

        // Act
        var result = await userController.GetAllAsync();
        
        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetAllAsync_Success_ChamaUserServiceApenasUmaVez()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var userController = new UserController(mockUserService.Object);

        mockUserService.Setup(userService => userService.GetAllAsync()).ReturnsAsync(new List<User>());
        
        // Act
        var result = await userController.GetAllAsync();
        
        // Assert
        mockUserService.Verify(userService => userService.GetAllAsync(), Times.Once());
    }

    [Fact]
    public async Task GetAllAsync_Success_RetornaUmaListaDeUser()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var userController = new UserController(mockUserService.Object);

        mockUserService.Setup(userService => userService.GetAllAsync()).ReturnsAsync(new List<User>());

        // Act
        var result = await userController.GetAllAsync() as OkObjectResult;

        // Assert
        result.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task GetAllAsync_UsuariosNaoEncontrado_RetornaNotFound()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var userController = new UserController(mockUserService.Object);

        mockUserService.Setup(userService => userService.GetAllAsync()).ReturnsAsync(new List<User>());

        // Act
        var result = await userController.GetAllAsync();

        // Assert
        
    }
    
    
}