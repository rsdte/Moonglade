namespace Moonglade.Web.Areas.Admin.ViewModels
{
    public class ResourceTreeViewModel
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int Type { get; set; }
        public bool HasChildren => Children.Count > 0;
        public List<ResourceTreeViewModel> Children { get; set; } = new List<ResourceTreeViewModel>();
    }
}
