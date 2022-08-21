namespace Moonglade.Application.Contracts.Users.Dtos
{
    public class UpdatePwdDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword1 { get; set; }
        public string NewPassword2 { get; set; }
    }
}
