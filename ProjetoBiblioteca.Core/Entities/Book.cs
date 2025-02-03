using ProjetoBiblioteca.Core.Enums;



namespace ProjetoBiblioteca.Core.Entities
{

    public class Book : BaseEntity
    {
        protected Book()
        {
        }

        public Book(string title, string author, string isbn, int yearOfPublication, BookStatusEnum status)
            : base()
        {
            
            Title = title;
            Author = author;
            ISBN = isbn;
            YearOfPublication = yearOfPublication;
            Status = BookStatusEnum.Available;
        }

       

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public int YearOfPublication { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public List<Loan> Loans { get; private set; }

        public void Loaned()
        {
            if (Status == BookStatusEnum.Available && Status != BookStatusEnum.Reserved)
            {
                Status = BookStatusEnum.Loaned;

            }
        }

        public void MakesAvailable()
        {
            if (Status == BookStatusEnum.Loaned || Status == BookStatusEnum.Reserved)
            {
                Status = BookStatusEnum.Available;

            }
        }

        public void Reserved()
        {
            if (Status == BookStatusEnum.Available)
            {
                Status = BookStatusEnum.Reserved;

            }
        }

        public void MarkAsUnavailable()
        {
            if (Status != BookStatusEnum.Loaned)
            {
                Status = BookStatusEnum.Unavailable;

            }
        }

    }
}