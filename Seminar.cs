using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCCoreWebApp.Models
{
    public class Seminar
    {
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string?  Name { get; set; }

        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage = "Invalid email format")]
        [Required]
        public string?  Email { get; set; }

        [Required(ErrorMessage ="Phonr number is required")]
        public string? PhoneNo { get; set; }
        [Required(ErrorMessage ="Please select the confirmation")]
        public bool Confirmation { get; set; }

        
    }
}
