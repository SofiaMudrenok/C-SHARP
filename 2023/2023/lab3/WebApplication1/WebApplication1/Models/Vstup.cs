using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Vstup
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z][a-z]*([ ][A-Z][a-z]*)*$", ErrorMessage = "The FullName must start with an uppercase letter and contain only letters with one space between words")]
        public string? FullName { get; set; }
        [RegularExpression(@"^(200[0-9]|20[1-9][0-9]|2[1-9][0-9]{2}|[3-9][0-9]{3})$", ErrorMessage = "The Year must be a positive integer between 2000 and the current year")]
        [Range(2000, int.MaxValue, ErrorMessage = "The Year must be a positive integer between 2000 and the current year")]
        public int? Year { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "The ZNO must be a positive decimal value")]
        public decimal ZNO { get; set; }
        [RegularExpression("^[чж]$", ErrorMessage = "The Sex must be either 'ч' or 'ж'")]
        public string? Sex { get; set; }

    }
}
