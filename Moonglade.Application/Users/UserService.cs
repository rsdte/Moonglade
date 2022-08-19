using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moonglade.Application.Contracts;
using Moonglade.Application.Contracts.Dtos;
using Moonglade.Application.Contracts.Users.Dtos;
using Moonglade.Domain;
using Moonglade.Domain.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace Moonglade.Application
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly JwtConfig jwtConfig;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, IOptions<JwtConfig> options)
        {
            this.unitOfWork = unitOfWork;
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

        public Task<UserEntity?> GetAsync(int id)
        {
            return this.userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<UserEntity>> GetUsersAsync(IList<int> userIds)
        {
            return this.userRepository.GetAllAsync(x => userIds.Contains(x.Id));
        }

        public Task<IPage<UserEntity>> SearchUserAsync(SearchUserDto model)
        {
            var whereExp = ExpressionHelper.True<UserEntity>();
            if (!model.UserName.IsNullOrWhiteSpace())
            {
                whereExp.And(x => x.UserName.Contains(model.UserName));
            }

            if (model.StartTime != default)
            {
                whereExp.And(x => x.CreatedTime >= model.StartTime);
            }

            if (model.EndTime != default)
            {
                whereExp.And(x => x.CreatedTime <= model.EndTime);
            }

            if (model.Status == 0)
            {
                whereExp.And(x => x.Deleted);
            }
            else
            {
                whereExp.And(x => !x.Deleted);
            }

            return this.userRepository.GetPageAsync(whereExp, x => x.CreatedTime, true, model.PageIndex, model.PageSize);
        }

        public async Task<bool> UpdatePwdAsync(UpdatePwdDto model, int updatedUserId)
        {
            var user = await this.userRepository.GetByIdAsync(model.UserId);
            if (user is null)
                throw new Exception("用户不存在!");
            if (model.NewPassword1 != model.NewPassword2)
                throw new Exception("两次新密码不相同！");
            if (user.Password != model.OldPassword)
                throw new Exception("密码不正确!");
            user.Password = model.NewPassword1;
            user.UpdatedTime = DateTime.Now;
            user.UpdatedUserId = updatedUserId;
            await this.userRepository.UpdateableAsync(user);
            return this.unitOfWork.SaveChanges() > 0;
        }
    }
}