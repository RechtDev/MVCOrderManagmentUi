using MVCOrderManagmentUi.Models;
using Newtonsoft.Json;

namespace Bookstore.Models
{
    public class ProductGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Author { get; set; } = DefaultFilter;
        public string Genre { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
    }
}