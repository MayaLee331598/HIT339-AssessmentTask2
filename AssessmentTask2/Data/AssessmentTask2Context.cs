using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssessmentTask2.Data
{
    public class AssessmentTask2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AssessmentTask2Context() : base("name=AssessmentTask2Context")
        {
        }

        public System.Data.Entity.DbSet<AssessmentTask2.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<AssessmentTask2.Models.Duration> Durations { get; set; }

        public System.Data.Entity.DbSet<AssessmentTask2.Models.Instrument> Instruments { get; set; }

        public System.Data.Entity.DbSet<AssessmentTask2.Models.Lesson> Lessons { get; set; }

        public System.Data.Entity.DbSet<AssessmentTask2.Models.Tutor> Tutors { get; set; }

        public System.Data.Entity.DbSet<AssessmentTask2.Models.Letter> Letters { get; set; }
    }
}
