namespace MyWatchList.Account.Domain.Domain.ViewModels;

public class ResultViewModel<T>
{
    public T Data { get; private set; }
    public List<string> Errors { get; private set; } = new();
    
    public ResultViewModel(T data, List<String> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(T data)
    {
        Data = data;
    }

    public ResultViewModel(List<String> errors)
    {
        Errors = errors;
    }

    public ResultViewModel(string error)
    {
        Errors.Add(error);
    }
}