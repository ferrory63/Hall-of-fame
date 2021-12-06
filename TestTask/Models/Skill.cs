using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Skill: BaseId
    {
        [Required]
        public string Name { get; set; }
        [Range (1, 10)]
        public byte Level { get; set; }

        [Required]
        public long PersonId { get; set; }
    }
}
