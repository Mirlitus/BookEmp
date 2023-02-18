using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEmp.Models
{
    //Класс DbContext, представляющий сеанс с базой данных
    //Он используется для запроса, вставки, обновления и удаления данных из базы данных
    public class EmployeeContext : DbContext
    {
        //Конструктор, который принимает объект DbContextOptions для указания параметров
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
                
        }
        //Представляет коллекции всех сотрудников и отделов в базе данных
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }

    }
}