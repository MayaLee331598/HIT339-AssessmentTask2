using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssessmentTask2.Models
{
    using Antlr.Runtime;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Lesson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            this.Letters = new HashSet<Letter>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public int InstrumentId { get; set; }
        public int TutorId { get; set; }
        [Display(Name = "Lesson d")]
        [DataType(DataType.Date)]
        public System.DateTime LessonDate { get; set; }
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public System.DateTime LessonTime { get; set; }
        public int DurationId { get; set; }
        public string Term
        {
            get
            {
                if (LessonDate.Month >= Letter.Term_Start_Date.Month && LessonDate.Month <= Letter.Term_End_Date.Month)
                {
                    return Letter.Current_Term;
                }
                else
                {
                    return "Try again";
                }
            }
        }


        public Nullable<int> LetterId { get; set; }

        public virtual Duration Duration { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual Letter Letter { get; set; }
        public virtual Student Student { get; set; }
        public virtual Tutor Tutor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Letter> Letters { get; set; }
    }
}