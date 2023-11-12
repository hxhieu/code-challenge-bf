using MemoryPack;
using System.ComponentModel.DataAnnotations;

namespace CodeChallengeBF.Service.Models
{
    [MemoryPackable]
    public partial class TestFormModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [MemoryPackIgnore]
        public string Id => string.Format( "{0}_{1}", FirstName ?? "", LastName ?? "" ).ToLower();
    }
}