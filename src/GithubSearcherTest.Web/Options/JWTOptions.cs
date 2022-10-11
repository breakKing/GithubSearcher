namespace GithubSearcherTest.Web.Options;

public class JWTOptions
{
    public const string SectionName = "JWT";

    public string SigningKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
}
