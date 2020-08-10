using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string EmploymentNumber { get; set; }
        public Department Department { get; set; }


        public Employee(string name, DateTime joinDate, string phone, string jobTitle, string employmentNumber,
            Department department)
        {
            Name = name;
            JoinDate = joinDate;
            Phone = phone;
            JobTitle = jobTitle;
            EmploymentNumber = employmentNumber;
            Department = department;
        }

    }
}
