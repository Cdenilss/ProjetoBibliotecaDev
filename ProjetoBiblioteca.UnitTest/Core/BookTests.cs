using FluentAssertions;
using ProjetoBiblioteca.Core.Enums;
using TestProject2.Fakes;

namespace TestProject2.Core;

public class BookTests
{
    [Fact]
    public void BookIsLoaned()
    {

        // Arrange
        var book = FakesDataHelper.CreateFakeBook();
        //new Book("Denil o heroi", "Denil", "1234", 2024, BookStatusEnum.Loaned);

        //Act
        book.Loaned();

        //Assert -- valor esquerda esperado, valor real da direita

        Assert.Equal(BookStatusEnum.Loaned, book.Status);

        book.Status.Should().Be(BookStatusEnum.Loaned);
        book.Title.Should().NotBeNullOrEmpty();
        //Assert.NotEmpty(book.Title);
        book.YearOfPublication.Should().BeLessThanOrEqualTo(DateTime.Now.Year);
        //Assert.False(book.YearOfPublication > DateTime.Now.Year);

    }
}