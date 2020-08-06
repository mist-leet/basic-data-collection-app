using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TraineeDataCollection.Models;

namespace TraineeDataCollection.Models
{
    public class User
    {
        public int Id { get; set; }
        //[Display(Name = "Электронная почта")]
        public string Email { get; set; }
        //[Display(Name = "Пароль")]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        
        public ICollection<TraineeForm> TraineeForms { get; set; }

        public User()
        {
            TraineeForms = new List<TraineeForm>();
        }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}