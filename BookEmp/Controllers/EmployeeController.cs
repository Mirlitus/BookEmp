//Класс EmployeeController обрабатывает запросы от клиента на получение данных о сотрудниках и функциях работы с ними
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookEmp.Models;

namespace BookEmp.Controllers
{
    public class EmployeeController : Controller
    {
        //Объект EmployeeContext для взаимодействия с базой данных
        private readonly EmployeeContext _Db;

        //Конструктор для инициализации _Db данным экземпляром EmployeeContext
        public EmployeeController(EmployeeContext Db)
        {
            _Db = Db;
        }

        //Метод действия EmployeesList получает список сотрудников и их отделов из базы данных,
        //затем создает новый объект Employee с необходимыми данными и возвращает представление для отображения данных
        public IActionResult EmployeesList()
        {
            try
            {

                var stdList = from a in _Db.Employees
                              join b in _Db.Departments
                              on a.DepID equals b.ID
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Employee
                              {
                                  ID=a.ID,
                                  FIO=a.FIO,
                                  DepName=a.DepName,
                                  Phone=a.Phone,
                                  PhotoURL=a.PhotoURL,
                                  DepID=a.DepID,
                                  Department=b==null?"":b.DepName

                              };
            

                return View(stdList);
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        //Метод действия Create создает новый объект Employee и возвращает представление для его отображения
        public IActionResult Create(Employee obj)
        {
            loadDDL();
            return View(obj);
        }

        //Метод действия Edit загружает объект Employee из базы данных и возвращает представление для его отображения
        public IActionResult Edit(Employee obj)
        {
            loadDDL();
            return View(obj);
        }

        //Метод действия AddEmployee добавляет в базу данных новый объект Employee,
        //затем возвращает представление для отображения списка сотрудников
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.Employees.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                   
                    return RedirectToAction("EmployeesList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {

                return RedirectToAction("EmployeesList");
            }
        }

        //Метод действия DeleteStd удаляет объект Employee из базы данных и возвращает представление для отображения списка сотрудников
        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std =await _Db.Employees.FindAsync(id);
                if (std!=null)
                {
                    _Db.Employees.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("EmployeesList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("EmployeesList");
            }
        }

        //Метод действия Search ищет в базе данных сотрудников, соответствующих заданным fullnameFilter и phoneFilter,
        //затем возвращает JsonResult со списком подходящих сотрудников
        public IActionResult Search(string fullnameFilter, string phoneFilter)
        {
            var employees = _Db.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(fullnameFilter))
            {
                employees = employees.Where(e => e.FIO.ToLower().Contains(fullnameFilter));
            }

            if (!string.IsNullOrEmpty(phoneFilter))
            {
                employees = employees.Where(e => e.Phone.ToLower().Contains(phoneFilter));
            }

            return Json(new { employees = employees.ToList() });
        }

        //Этот метод загружает раскрывающийся список для отделов, получая его из базы данных
        //и вставляет опцию «Выбрать из списка», устанавливает полученный список как ViewBag.DepList
        //Если во время выполнения метода возникает исключение, оно перехватывается и обрабатывается молча, без каких-либо действий
        private void loadDDL()
        {
            try
            {
                List<Departments> depList=new List<Departments>();
                depList = _Db.Departments.ToList();

                depList.Insert(0, new Departments { ID = 0, DepName = "Выбрать из списка" });

                ViewBag.DepList = depList;

            }
            catch (Exception ex)
            {

            }
        }
    }
}