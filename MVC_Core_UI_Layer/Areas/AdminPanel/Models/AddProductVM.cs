namespace MVC_Core_UI_Layer.Areas.AdminPanel.Models
{
    public class AddProductVM
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public IFormFile PictureFile { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
    }
}
