using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEmp.Models
{
    //Класс, описывающий отдел
    public class Departments
    {
        [Key]
        public int ID { get; set; }

        public string DepName { get; set; }

    }
}