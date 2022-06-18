namespace Zhang.APi.Options;

public class JwtOption
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int Expires { get; set; }
    public string Key { get; set; } = null!;
}