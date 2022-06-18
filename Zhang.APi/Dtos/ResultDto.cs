namespace Zhang.APi.Bases;

public class ResultDto<T>
{
    public ResultDto(bool status, string message, T? data)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public bool Status { get; set; }
    public string Message { get; set; } = null!;
    public T? Data { get; set; }
}