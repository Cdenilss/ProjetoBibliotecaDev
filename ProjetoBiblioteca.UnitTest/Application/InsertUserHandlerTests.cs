using FluentAssertions;
using Moq;
using ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;
using TestProject2.Fakes;

namespace TestProject2.Application;

public class InsertUserHandlerTests
{
    [Fact]
    public async Task InputDatasAreOk_Insert_Sucess_Moq()
    {
        // Arrange
        const int ID = 1;
        User? insertedUser = null;

        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock.Setup(r => r.Add(It.IsAny<User>()))
            .Callback<User>(u => insertedUser = u) 
            .ReturnsAsync(ID);

        var repository = repositoryMock.Object;

        var command = FakesDataHelper.CreateFakeInsertUserCommand();
        var handler = new InsertUserCommandHandler(repository);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.IsSucess);
        Assert.Equal(ID, result.Data);
        repositoryMock.Verify(m => m.Add(It.IsAny<User>()), Times.Once);
        
        insertedUser.Should().NotBeNull();
        insertedUser!.Name.Should().Be(command.Name);
        insertedUser.Email.Should().Be(command.Email);
    }
}
