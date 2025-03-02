using Bogus;
using Moq;
using ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Core.Repositories;
using TestProject2.Fakes;
using Xunit;

namespace TestProject2.Application;

public class DeleteBookHandlerTests 
{
    [Fact]
    public async Task BookExists_Delete_Success()
    {
        // Arrange
        var book = FakesDataHelper.CreateFakeBook;
        var repository = new Mock<IBookRepository>();

        repository.Setup(r => r.GetById(It.IsAny<int>()))
            .ReturnsAsync(book);

        repository.Setup(r => r.Update(It.IsAny<Book>()))
            .Returns(Task.CompletedTask);

        var handler = new DeleteBookCommandHandler(repository.Object);
        var command = new DeleteBookCommand(1);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.IsSucess, "O livro deveria ter sido deletado com sucesso, mas não foi.");
        repository.Verify(r => r.GetById(1), Times.Once);
        repository.Verify(r => r.Update(It.IsAny<Book>()), Times.Once);
    }

    [Fact]
    public async Task BookDoesNotExist_Delete_Error()
    {
        // Arrange
        var repository = new Mock<IBookRepository>();

        repository.Setup(r => r.GetById(It.IsAny<int>()))
            .ReturnsAsync((Book?)null); 

        var handler = new DeleteBookCommandHandler(repository.Object);
        var command = new DeleteBookCommand(1);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.IsSucess, "O livro não existe, mas o sistema não retornou erro.");
        repository.Verify(r => r.GetById(1), Times.Once);
        repository.Verify(r => r.Update(It.IsAny<Book>()), Times.Never); 
    }
}