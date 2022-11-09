using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssessmentTask2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Lessons = new HashSet<Lesson>();
            this.Letters = new HashSet<Letter>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
        [Display(Name = "Date Of Birth")] // changes display name
        [DataType(DataType.Date)]
        public System.DateTime DoB { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.DoB.Year;
            }
        }
        public string Gender { get; set; }
        [Display(Name = "Parent or Gaurdian")]
        public string ParentOrGaurdian { get; set; }
        [Display(Name = "Payment Email")]
        [DataType(DataType.EmailAddress)]
        public string PaymentEmail { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Letter> Letters { get; set; }
    }
}