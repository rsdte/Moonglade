namespace Moonglade.WebApi.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedUserName { get; set; }
    }
}
