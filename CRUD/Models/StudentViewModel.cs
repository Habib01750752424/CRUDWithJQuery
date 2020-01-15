using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Student> Students { get; set; }
    }
}