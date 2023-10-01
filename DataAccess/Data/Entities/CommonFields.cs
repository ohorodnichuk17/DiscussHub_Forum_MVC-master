using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class CommonFields
    {
        //[Required]
        //[StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        //[Required]
        public string VisibilityStatus { get; set; }
        //[MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string? ImageUrl { get; set; }
    }
}
