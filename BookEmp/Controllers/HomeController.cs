using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookEmp.Models;

namespace BookEmp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Конструктор, который устанавливает используемый Logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Метод действия для обработки запроса страницы Index
        public IActionResult Index()
        {
            return View();
        }

        //Метод действия для обработки запроса страницы Privacy (Политика)
        public IActionResult Privacy()
        {
            return View();
        }

        //Метод действия для обработки запроса об ошибке
        //Устанавливает значения для свойства ResponseCache:
        //Свойство Duration имеет значение 0, что означает, что ответ вообще не должен кэшироваться
        //Свойству Location присвоено значение ResponseCacheLocation.None, что указывает на то, что ответ не должен храниться ни в каком расположении кэша
        //Свойство NoStore имеет значение true, что указывает на то, что ответ вообще не должен храниться ни в каком кэше, включая кэш браузера клиента.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}