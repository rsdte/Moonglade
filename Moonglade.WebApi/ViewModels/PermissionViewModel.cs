namespace Moonglade.WebApi.ViewModels
{
    public class PermissionViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Link { get; set; }
        public bool HasChildren => Children != null || Children.Count > 0;
        public List<PermissionViewModel> Children { get; set; }

        public PermissionViewModel()
        {
            Children = new List<PermissionViewModel>();
        }
    }
}
