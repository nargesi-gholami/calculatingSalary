using System;
using System.Collections.Generic;
using System.Text;

namespace calculateSalary
{
    class Admin
    {
        private Employee _employee;
        private List<Report> _students;
        public Admin(Employee employee)
        {
            _employee = employee;
            _students = new List<Report>();
        }
        public void doTask()
        {
            const string QUIT = "quit";
            const string ADD_CONTENT = "addContent";
            const string ADD_STUDENT = "addStudent";
            const string CALCULATE_SALARY = "calculateSalary";
            const string VIEW_REPORT = "viewReport";

            Console.WriteLine("\nHi admin. What do you want to do? If you want to quit write \"quit\"  ");
            Console.WriteLine("There is a list I can do for you:) \n\n"
                + "add content for employee --> \"addContent - id - subject - date. For example, AddText 1 \"ways to study\" 2020/6/25\n"
                + "add student --> addStudent - id - student_name - start_date - end_date. For example, addStudent 1 Narges 2021/6/30 2022/6/30\n"
                + "calculate salary --> calculateSalary\n"
                + "view employee's report --> viewReport\n" );

            string command = "";
            while(command != QUIT)
            {
                try
                {
                    command = Console.ReadLine();
                    string[] commands = command.Split();
                    if (commands[0] == ADD_CONTENT)
                        addContent(commands);
                    else if (commands[0] == ADD_STUDENT)
                        addStudent(commands);
                    else if (commands[0] == CALCULATE_SALARY)
                        calculateSalary();
                    else if (commands[0] == VIEW_REPORT)
                        _employee.viewReport();
                    else if (commands[0] == QUIT)
                        return;
                    else
                        throw new wrongCommand();
                    Console.WriteLine("Your task is done.");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void addContent(string[] commands)
        {
            int uniqueId = Int32.Parse(commands[1]);
            string subject = commands[2];
            Date sendDate = new Date(commands[3]);
            Content text = new Content(uniqueId, subject, sendDate);
            _employee.addContent(text);
        }
        private void addStudent(string[] commands)
        {
            int id = Int32.Parse(commands[1]);
            string studentName = commands[2];
            Date startDate = new Date(commands[3]);
            Date endDate = new Date(commands[4]);

            Report student = new Report(id, studentName, startDate, endDate);
            _employee.addReport(student);
            _students.Add(student);
        }
        private void calculateSalary()
        {
            int salary = 0;
            const int PRICE_OF_CONTENT = 25000;
            const int PRICE_OF_STUDENT = 10000;
            const int FINE_OF_STUDENT = 5000;

            salary += _employee.numberOfContent * PRICE_OF_CONTENT;
            foreach (Report report in _students)
            {
                int supportDate = calWorkingDay(report);
                int notSupportDate = calNoneWorkingDay(report);
                salary += PRICE_OF_STUDENT * supportDate;
                salary -= FINE_OF_STUDENT * notSupportDate;
            }
            _employee.Salary = salary.ToString();
        }
        private int calWorkingDay(Report report)
        {
            if (report.shouldEndDate.compareDays(report.endDate) && report.startDate.compareDays(report.shouldStartDay))
                report.numOfWorkingDay = report.startDate.calculateDiffDays(report.endDate);
            else if (!report.shouldEndDate.compareDays(report.endDate) && !report.startDate.compareDays(report.shouldStartDay))
                report.numOfWorkingDay = report.shouldStartDay.calculateDiffDays(report.shouldEndDate);
            else if (!report.shouldEndDate.compareDays(report.endDate) && report.startDate.compareDays(report.shouldStartDay))
                report.numOfWorkingDay = report.startDate.calculateDiffDays(report.shouldEndDate);
            else if (report.shouldEndDate.compareDays(report.endDate) && !report.startDate.compareDays(report.shouldStartDay))
                report.numOfWorkingDay = report.shouldStartDay.calculateDiffDays(report.endDate);

            return report.numOfWorkingDay;
        }
        private int calNoneWorkingDay(Report report)
        {
            return report.shouldStartDay.calculateDiffDays(report.shouldEndDate) - report.numOfWorkingDay;
        }

    }
}
