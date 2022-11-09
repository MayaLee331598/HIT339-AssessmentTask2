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

    public class Letter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Letter()
        {
            this.Lessons = new HashSet<Lesson>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LetterId { get; set; }
        public string LetterRef //Generates a string for a letter based on the current year, student name and the ID of the letter
        {
            get
            {
                return CurrentYear + "" + Student.Lastname + "" + LetterId;
            }
        }

        public bool Paid { get; set; }
        [Display(Name = "Beginng Comment")]
        public string Beginning_Comment { get; set; }
        public string Signiture { get; set; }
        public string Bank { get; set; }
        [Display(Name = "Account Name")]
        public string Account_Name { get; set; }
        public string BSB { get; set; }
        [Display(Name = "Account Number")]
        public string Account_Number { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start of Term")]
        public System.DateTime Term_Start_Date { get; set; }
        [Display(Name = "End of Term")]
        [DataType(DataType.Date)]
        public System.DateTime Term_End_Date { get; set; }
        public string Current_Term
        {
            get
            {
                if (Term_Start_Date.Month == 02 || Term_End_Date.Month == 04) //if the terms start month is Feb and end month April then it is term 1
                {
                    return "Term 1";
                }
                else if (Term_Start_Date.Month == 04 || Term_End_Date.Month == 06) //if the terms start month is april and end month is june then it is term 2
                {
                    return "Term 2";
                }
                else if (Term_Start_Date.Month == 07 || Term_End_Date.Month == 09) //if the terms start month is July and end month is September then it is term 3
                {
                    return "Term 3";
                }
                else if (Term_Start_Date.Month == 10 || Term_End_Date.Month == 12) //if the terms start month is October and the end month is December then it is term 4 
                {
                    return "Term 4";
                }
                else
                {
                    return "Outside of teaching period"; //anything else is outside of the teaching period
                }
            }
        }

        public string Current_Semester
        {
            get
            {
                if (Current_Term == "Term 1" || Current_Term == "Term 2")
                {
                    return "Semester 1";
                }
                else if (Current_Term == "Term 3" || Current_Term == "Term 4")
                {
                    return "Semester 2";
                }
                else
                {
                    return "Outside of teaching period";
                }
            }
        }

        [DataType(DataType.Date)] //changes the datatype to date
        public System.DateTime Payment_Date
        {
            get
            {
                return Term_Start_Date.AddDays(10); //adds 10 days to the term start date and returns the date
            }
        }

        public int CurrentYear
        {
            get
            {
                return DateTime.Now.Year; //looks at what the current year is and returns it
            }
        }

        public int StudentId { get; set; }
        public int LessonId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
    }
}