namespace Moonglade.Application.Contracts.Users.Dtos
{
    public class SearchUserDto
    {
        public string UserName { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
