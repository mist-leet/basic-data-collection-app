using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraineeDataCollection.Models
{
    public class TraineeForm
    {
        public int Id{ get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        //public User User { get; set; }
        //public int TraineeFormId { get; set; }
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Университет")]
        public string NameOfTheUniversity { get; set; }
        [Display(Name = "Курс")] 
        public string UniversityCourse { get; set; }
        [Display(Name = "Факультет")]
        public string Faculty { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Информация")]
        public string Info { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime ChangeDate { get; set; }
        [Display(Name = "Создатель")]
        public string FormCreater{ get; set; }
        [Display(Name = "Последний раз изменено")]
        public string AuthorOfLastChange { get; set; }

        public TraineeForm()
        {
            ChangeDate = DateTime.Now;
            CreateDate = DateTime.Now;
        }
    }
}