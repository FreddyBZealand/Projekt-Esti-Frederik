using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt_Esti_Frederik.Models
{
    public partial class Student
    {
      
        
            [Key]
            [Column("StudentID")]
            public int StudentId { get; set; }

            [Required]
            [StringLength(100)]
            [Unicode(false)]
            public string Name { get; set; }

            // Many students <> Many classes
            [InverseProperty("Students")]
            public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

            // One student > many designations
            [InverseProperty("Student")]
            public virtual ICollection<Designation> Designations { get; set; } = new List<Designation>();
        

    }
}
