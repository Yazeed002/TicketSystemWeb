using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Number { get; set; }

        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                if (value == null || value.Length < 10)

                    throw new Exception("Content is required and must be more than 10 letters.");

                _content = value;

            }
        }
        public Employee Requester { get; set; }
        public TicketSupportStatus Status { get; set; }
        public Employee AssignedTo { get; set; }
        public TicketSupportLevel? Level { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
        public Priority Priority { get; set; }
        public Department Department { get; set; }


        public SupportTicket(string content, Employee requester, List<string> attachments, Department department)
        {
            CreatedDate = DateTime.Now;
            Id = DateTime.Now.Millisecond;
            
            Status = TicketSupportStatus.Open;
            Content = content;

            if (requester == null)
                throw new Exception("Ticket must have a requster.");

            Requester = requester;

            if (department == null)
                throw new Exception("Ticket must have a Department");

            Department = department;

            AddAttachments(attachments, false);
            
        }


        public void Action(Employee assignedTo, TicketSupportStatus status, TicketSupportLevel level, Priority priority)

        {
            if (Status == TicketSupportStatus.Closed)
                throw new Exception("You can not Assign the Ticket while it's Closed.");


            if (assignedTo == null)
                throw new Exception("You must Assign Ticket to an Employee.");

            if (assignedTo.Department != Department)
                throw new Exception("You must Assign an Employee with the same Department as the Ticket origin.");

            AssignedTo = assignedTo;


            if (Level == null)
                Level = level;

            else
            {
                int currentLevel = (int)Level;
                int newLevel = (int)level;

                if (Math.Abs(newLevel - currentLevel) == 1 || Math.Abs(newLevel - currentLevel) == 0)
                    Level = level;

                else
                    throw new Exception("You can't Upgrade or Downgrade more then One Level at a time.");

            }




            if (priority == null)
                throw new Exception("You must select a Priority to the Ticket.");

            Priority = priority;


            ModifiedDate = DateTime.Now;
        }
   
    public void ChangeStatus(TicketSupportStatus status)
        {
            if (Status != TicketSupportStatus.Closed)
                throw new Exception("You can't change status for closed Tickets.");

            if(Level != TicketSupportLevel.Level1)
                throw new Exception("You can't change status for Tickets with Level > 1.");

            Status = status;

            ModifiedDate = DateTime.Now;
        }

        public void AddAttachments(List<string> attachments, bool modify = true)
        {
            if(Attachments == null)
                Attachments = new List<string>();

            if (attachments == null)
                throw new Exception("Not Allowed to add Empty Attachments.");

            if ((Attachments.Count + attachments.Count) > 10)
                throw new Exception("You can not Add more than 10 Attachments.");

            Attachments.AddRange(attachments);

            if(modify)
            ModifiedDate = DateTime.Now;
        }
    
    }
}
