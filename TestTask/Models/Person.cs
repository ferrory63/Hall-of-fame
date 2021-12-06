using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Person: BaseId
    {
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Вывод имени
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}
