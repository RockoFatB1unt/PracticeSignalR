using System.Collections.Generic;

namespace DiAndSignalRApp.Models
{
    public class Guardian
    {
        public Guardian()
        {
            StudentsForGuardianOne = new List<Student>();
            StudentsForGuardianTwo = new List<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> StudentsForGuardianOne { get; set; }
        public virtual ICollection<Student> StudentsForGuardianTwo { get; set; }


    }
}