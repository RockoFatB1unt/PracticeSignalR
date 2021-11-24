using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiAndSignalRApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("GuardianOne")]
        public int GuardianOneId { get; set; }

        [ForeignKey("GuardianTwo")]
        public int GuardianTwoId { get; set; }
        public virtual Guardian GuardianOne { get; set; }
        public virtual Guardian GuardianTwo { get; set; }

    }
}
