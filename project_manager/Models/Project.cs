using Contentful.Core.Models;
using System;
using System.Collections.Generic;

namespace project_manager.Models
{
    public class Project
    {
        public Asset bannerImg { get; set; }

        public string projectTitle { get; set; }
        public DateTimeOffset deadline { get; set; }
        public string toDoList { get; set; }

        
        public string FormattedDeadline => deadline.ToString("HH:mm dd/MM/yyyy");

        public string DeadlineStatus
        {
            get
            {
                TimeSpan timeLeft = deadline - DateTimeOffset.Now;
                double totalDays = timeLeft.TotalDays;

                string borderClass;

                switch (totalDays)
                {
                    case var days when days > 14: // More than 2 weeks
                        borderClass = "border-success"; // Apply green border class
                        break;
                    case var days when days > 7: // More than 1 week
                        borderClass = "border-warning"; // Apply orange border class
                        break;
                    case var days when days > 0: // Less than 1 week
                        borderClass = "border-danger"; // Apply red border class
                        break;
                    default: // Deadline passed or today is the deadline
                        borderClass = "border-dark"; // Apply gray border class or any other appropriate style
                        break;
                }

                return borderClass;
            }
        }

        public List<string> ToDoItems
        {
            get
            {
                if (string.IsNullOrEmpty(toDoList))
                    return new List<string>();

                // Split the to-do list at each dash ('-') and trim any whitespace
                string[] items = toDoList.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = items[i].Trim(); // Trim any leading/trailing whitespace
                }

                return new List<string>(items);
            }
        }
    }

}

