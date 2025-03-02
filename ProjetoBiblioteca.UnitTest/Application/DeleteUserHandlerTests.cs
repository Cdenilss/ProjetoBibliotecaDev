using Moq;
using ProjetoBiblioteca.Application.Commands.UserCommands.DeleteUser;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;
using Xunit;
using FluentAssertions;

namespace TestProject2.Application;

public class DeleteUserHandlerTests
{
    [Fact]
    public async Task UserExists_Delete_Sucess()
    {
        // Arrange
        var user = new User("UserTest", "user@gmail.com");

        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock.Setup(r => r.GetById(It.IsAny<int>()))
            .ReturnsAsync(user); // Retorna o usuário encontrado

        repositoryMock.Setup(r => r.Update(It.IsAny<User>()))
            .Returns(Task.CompletedTask); // Simula a atualização bem-sucedida

        var repository = repositoryMock.Object;
        var handler = new DeleteUserCommandHandler(repository);
        var command = new DeleteUserCommand(1);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        result.IsSucess.Should().BeTrue();
        repositoryMock.Verify(r => r.GetById(1), Times.Once);
        repositoryMock.Verify(r => r.Update(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task UserDoesNotExist_Delete_Error()
    {
        // Arrange
        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock.Setup(r => r.GetById(It.IsAny<int>()))
            .ReturnsAsync((User?)null); 

        repositoryMock.Setup(r => r.Update(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        var repository = repositoryMock.Object;
        var handler = new DeleteUserCommandHandler(repository);
        var command = new DeleteUserCommand(1);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        result.IsSucess.Should().BeFalse();
        repositoryMock.Verify(r => r.GetById(1), Times.Once);
        repositoryMock.Verify(r => r.Update(It.IsAny<User>()), Times.Never);
    }
}
