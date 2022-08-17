using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moonglade.Application.Contracts;
using Moonglade.Application.Contracts.Dtos;
using Moonglade.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Moonglade.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly JwtConfig jwtConfig;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, IOptions<JwtConfig> options)
        {
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
            this.roleRepository = roleRepository;
            this.jwtConfig = options.Value;
        }

        public async Task<string> GenerateTokenAsync(LoginDto model)
        {
            var user = await this.userRepository.FindAsync(p => !p.Deleted && p.UserName == model.UserName && p.Password == model.Password);
            if (user is null)
                throw new Exception("未找到用户，请确认相关信息！");
            var urs = await this.userRoleRepository.GetAllAsync(p => p.UserId == user.Id);
            var roleIds = urs.Select(p => p.RoleId).ToList();
            var roles = await this.roleRepository.GetAllAsync(r => roleIds.Contains(r.Id));

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Id", user.Id.ToString()),
                new Claim("RoleIds", String.Join(",",roles.Select(r=> r.Id))),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(jwtConfig.Issuer, jwtConfig.Audience, claims, expires: DateTime.Now.AddMinutes(jwtConfig.AccessExpiration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}