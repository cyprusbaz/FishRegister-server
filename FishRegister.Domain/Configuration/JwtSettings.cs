namespace FishRegister.Domain.Configuration;

public class JwtSettings
{
    public string Secret { get; set; } = "My_super_secret_really_actuallySecretKeySiuuuuuu";
    public string Issuer { get; set; } = "MyApp";
    public string Audience { get; set; } = "AppUsers";
    public int AccessTokenLifetime { get; set; } = 60;
}