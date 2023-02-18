using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookEmp.Models
{
    //Класс, описывающий сотрудника
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Обязательное поле")]
        [Display(Name = "ФИО:")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Если отдел не найден в списке, введите его вручную")]
        [Display(Name = "Отдел:")]
        public string DepName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон:")]
        public string Phone { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Фото:")]
        public string PhotoURL { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int DepID { get; set; }

        [NotMapped]
        [Display(Name = "Отдел:")]
        public string Department { get; set; }

    }
}