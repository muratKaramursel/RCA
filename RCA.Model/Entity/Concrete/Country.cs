using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RCA.Model
{
    [Index(nameof(Name), Name = "IX_Name", IsUnique = true)]
    public class Country : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter \"Country Name\"!")]
        [StringLength(100, ErrorMessage = @"""Country Name"" must be max 100 characters!")]
        public string Name { get; set; }
    }
}