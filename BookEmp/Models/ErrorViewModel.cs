//���� ���� �������� ����������� ������ ErrorViewModel, ������� ������������ HomeController ��� �������� ������������� �� �������
using System;

namespace BookEmp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}