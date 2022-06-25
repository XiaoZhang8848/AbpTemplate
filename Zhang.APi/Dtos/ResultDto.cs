namespace Zhang.APi.Dtos;

public class ResultDto
{
    public ResultDto(bool status, string message, dynamic? data)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public bool Status { get; set; }
    public string Message { get; set; } = null!;
    public dynamic? Data { get; set; }
}