namespace ProjetoBiblioteca.Entites;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreateAt = DateTime.Now;
        IsDeleted = false;
    }
    public int Id { get; private set; }
    public DateTime CreateAt { get; private set; }
    public bool  IsDeleted { get; private set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
}