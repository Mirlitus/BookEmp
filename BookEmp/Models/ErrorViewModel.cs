//Этот файл содержит определение класса ErrorViewModel, который используется HomeController для создания представлений об ошибках
using System;

namespace BookEmp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}