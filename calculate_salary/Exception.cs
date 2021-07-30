using System;
using System.Collections.Generic;
using System.Text;

namespace calculateSalary
{
    class wrongUserName : Exception
    {
        public wrongUserName()
        {
            Console.Write("You entered wrong username");
        }
    }
    class wrongDate : Exception
    {
        public wrongDate()
        {
            Console.Write("You entered wrong date");
        }
    }
    class emptyText : Exception
    {
        public emptyText()
        {
            Console.WriteLine("We don't have a subject");
        }
    }
    class notExistText : Exception
    {
        public notExistText()
        {
            Console.WriteLine("We don't have a text with this id");
        }
    }
    class emptyReport : Exception
    {
        public emptyReport()
        {
            Console.WriteLine("We don't have a report");
        }
    }
    class DuplicateId : Exception
    {
        public DuplicateId()
        {
            Console.WriteLine("You eneterd a duplicate id. Please try again");
        }
    }
    class wrongCommand : Exception
    {
        public wrongCommand()
        {
            Console.WriteLine("You eneterd a wrong command. Please try again");
        }
    }
}
