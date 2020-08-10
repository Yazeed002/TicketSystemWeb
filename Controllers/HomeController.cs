using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {

        List<SupportTicket> supportTickets = new List<SupportTicket>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SupportTickets()
        {

            #region Contents

            #region Values

            

            Department softDep = new Department("Software Department");
            Department techDep = new Department("Technical Department");
            Department servDep = new Department("Customer Service Department");
            Department hrDep = new Department("HR Department");

            Employee yazeed = new Employee("Yazeed", new DateTime(2018, 4, 1), "77440", "Software Engineer",
                "109266", softDep);

            Employee ahmed = new Employee("Ahmed", new DateTime(2017, 6, 23), "95511", "Busnies Analysis",
                "108542", techDep);

            Employee rahman = new Employee("Rahman", new DateTime(2019, 10, 16), "63320", "Customer Engineer",
                "111256", servDep);

            Employee hammad = new Employee("Hammad", new DateTime(2011, 12, 31), "110010", "HR Engineer",
                "111256", hrDep);

            Priority normal = new Priority()
            {
                Name = "Normal",

                MaxDays = 10,

                Order = 1
            };

            Priority urgent = new Priority()
            {
                Name = "Urgent",

                MaxDays = 5,

                Order = 2
            };

            Priority asap = new Priority()
            {
                Name = "ASAP",

                MaxDays = 2,

                Order = 9
            };


            #endregion



            List<string> attachments1 = new List<string>()
            {
                "img1.png"
                ,
                "img2.png"
            };

            SupportTicket ticket1 = new SupportTicket("Bug in the Technical Department.", rahman,
                attachments1, techDep);
            ticket1.Action(ahmed, TicketSupportStatus.Closed, TicketSupportLevel.Level3, asap);

            List<string> attachments2 = new List<string>()
            {
                "img3.png"
                ,
                "img4.png"
                ,
                "img5.png"
            };

            ticket1.AddAttachments(attachments2);
            supportTickets.Add(ticket1);


            List<string> attachments3 = new List<string>()
            {
                "401.png"
                ,
                "402.png"
                ,
                "403.png"
            };

            SupportTicket ticket2 = new SupportTicket("Bug in the HR Department.", yazeed,
                attachments3, hrDep);

            ticket2.Action(hammad, TicketSupportStatus.Pending, TicketSupportLevel.Level1, normal);
            supportTickets.Add(ticket2);


            List<string> attachments4 = new List<string>()
            {
                "991.png"
            };

            SupportTicket ticket3 = new SupportTicket("Bug in Customer Service Department.", ahmed,
                attachments4, servDep);

            ticket3.Action(rahman, TicketSupportStatus.Canceled, TicketSupportLevel.Level2, urgent);
            supportTickets.Add(ticket3);



            supportTickets.OrderByDescending(a => a.Priority.Order).ToList();

            #endregion

            return View(supportTickets);

        }

        public IActionResult TicketDetails()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
