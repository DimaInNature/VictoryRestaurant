namespace API.Services.Authorization;

public class TokenService : ITokenService
{
    private readonly TimeSpan _expiryDuration = new(0, minutes: 30, 0);

    public string GetToken(string key, string issuer, UserEntity user)
    {
        var claims = new[]
        {
            new Claim(type: ClaimTypes.Name, value: user.Login),
            new Claim(type: ClaimTypes.NameIdentifier, value: Guid.NewGuid().ToString()),
        };

        var securityKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            key: securityKey,
            algorithm: SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.Add(_expiryDuration), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}