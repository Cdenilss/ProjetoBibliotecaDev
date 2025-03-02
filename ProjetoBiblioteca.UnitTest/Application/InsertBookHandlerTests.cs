using FluentAssertions;
using Moq;
using FluentAssertions;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;
using TestProject2.Fakes;
using Xunit;

namespace TestProject2.Application;

public class InsertBookHandlerTests
{
    [Fact]
    public async Task InputDataAreOk_Insert_Success()
    {
        // Arrange
        const int ID = 1;
        var repository = new Mock<IBookRepository>();

        Book? insertedBook = null;

        repository.Setup(r => r.Add(It.IsAny<Book>()))
            .Callback<Book>(b => insertedBook = b) // Captura o livro inserido
            .ReturnsAsync(ID);

        var command = FakesDataHelper.CreateFakeInsertBookCommand();
        var handler = new InsertBookCommandHandler(repository.Object);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        result.IsSucess.Should().BeTrue("O livro deveria ter sido inserido com sucesso.");
        result.Data.Should().Be(ID);

        insertedBook.Should().NotBeNull();
        insertedBook.Title.Should().Be(command.Title);
        insertedBook.Author.Should().Be(command.Author);
        insertedBook.ISBN.Should().Be(command.ISBN);
        insertedBook.YearOfPublication.Should().Be(command.YearOfPublication);

        repository.Verify(r => r.Add(It.IsAny<Book>()), Times.Once);
    }
}
