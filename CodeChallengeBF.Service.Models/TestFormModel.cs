using MemoryPack;

namespace CodeChallengeBF.Service.Models
{
    [MemoryPackable]
    public partial class TestFormModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}