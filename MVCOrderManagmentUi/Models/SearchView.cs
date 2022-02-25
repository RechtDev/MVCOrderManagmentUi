using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCOrderManagmentUi.Models
{
    public class SearchView
    {
        public IEnumerable<Product> Products { get; set; }
        [Required(ErrorMessage = "Please enter a search term.")]
        public string SearchTerm { get; set; }
        public string Type { get; set; }
        public string Header { get; set; }
    }
}
