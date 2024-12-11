using BookingAppApi.Model;
using BookingShop.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> rolemanage, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = rolemanage;
            _configuration = configuration;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, "employee");
                return Ok(new { Message = "User created successfully!" });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var token = GenerateJwtTokenAsync(user);
                return Ok(new { Token = token , user.Id });
            }
            return Unauthorized();
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }


        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    return Ok(new { Message = "Role created successfully!" });
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(new { Message = "Role already exists." });
        }

        [HttpGet("users/{userId}/roles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [HttpPost("users/{userId}/roles/{roleName}")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Role assigned to user successfully!" });
            }
            return BadRequest(result.Errors);
        }


        [HttpDelete("xoá role{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound(new { Message = "role not found." });
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Role deleted successfully!" });
            }
            return BadRequest(result.Errors);
        }


        private async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("message1")]
        [Authorize(Roles = "admin")]
        public IActionResult Message1()
        {
            return Ok(new { mes = "Đây là chức năng của admin" });
        }
        [HttpGet("message2")]
        public IActionResult Message2()
        {
            return Ok(new { mes = "Đây là chức năng của Manager" });
        }


    }
}

