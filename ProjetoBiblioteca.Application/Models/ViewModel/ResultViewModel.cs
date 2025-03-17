public class ResultViewModel : ResultViewModelBase
{
    public ResultViewModel(bool isSuccess, string[] errors) 
        : base(isSuccess, errors) { }

    public static ResultViewModel Success() 
        => new ResultViewModel(true, Array.Empty<string>());

    public static ResultViewModel Error(params string[] errors) 
        => new ResultViewModel(false, errors);
}
public class ResultViewModel<T> : ResultViewModelBase
{
    public T? Data { get; private set; }

    public ResultViewModel(T data, string[] errors = null!) 
        : base(true, errors ?? Array.Empty<string>())
    {
        Data = data;
    }

    public ResultViewModel(bool isSuccess, string[] errors) 
        : base(isSuccess, errors)
    {
        Data = default;
    }

    public static ResultViewModel<T> Success(T data)
        => new ResultViewModel<T>(data);

    public static ResultViewModel<T> Error(params string[] errors)
        => new ResultViewModel<T>(false, errors);
}