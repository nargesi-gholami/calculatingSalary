using System;

namespace calculateSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            const string EMPLOYEE = "employee";
            const string ADMIN = "admin";
            const string QUIT = "quit";

            Employee employee = new Employee();
            Admin admin = new Admin(employee);

            Console.WriteLine("Hello. Welcome to the calculation system");

            string userName = "";
            while (userName != QUIT)
            {
                try
                {
                    Console.WriteLine("Please enter you username to enter. If you want to quit write \"quit\"");
                    userName = Console.ReadLine();

                    if (userName == EMPLOYEE)
                        employee.doTask();
                    else if (userName == ADMIN)
                        admin.doTask();
                    else if (userName == QUIT)
                        break;
                    else
                        throw new wrongUserName();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("I hope you enjoyed the app");
        }
    }    
}
