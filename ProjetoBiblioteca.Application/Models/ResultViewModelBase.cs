public abstract class ResultViewModelBase
{
    public bool IsSuccess { get; protected set; }
    public string[] Errors { get; protected set; } // Array de erros

    protected ResultViewModelBase(bool isSuccess, string[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }
}