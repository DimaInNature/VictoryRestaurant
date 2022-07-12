namespace Victory.Services.API.Controllers;

[ApiController]
[Route(template: "[controller]")]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _config;

    private readonly IUserRepositoryService _userFacadeService;

    public LoginController(
        IConfiguration config,
        IUserRepositoryService userFacadeService) =>
        (_config, _userFacadeService) = (config, userFacadeService);

    [AllowAnonymous]
    [Route(template: "")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
    {
        UserEntity? user = await Authenticate(userLogin);

        if (user is not null)
        {
            var token = Generate(user);

            return Ok(token);
        }

        return NotFound("User not found");
    }

    private string Generate(UserEntity user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _config[key: "Jwt:Key"]));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Login),
            new Claim(ClaimTypes.Role, user.UserRole?.Name ?? "None")
        };

        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<UserEntity?> Authenticate(UserLogin userLogin)
    {
        var currentUser = await _userFacadeService.GetUserAsync(userLogin);

        return currentUser is not null ? currentUser : null;
    }
}