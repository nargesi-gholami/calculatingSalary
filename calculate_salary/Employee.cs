using System;
using System.Collections.Generic;
using System.Text;

namespace calculateSalary
{
    class Employee
    {
        private List<Content> _content;
        private List<Report> _reports;
        private int _salary;
        private int _numberOfContent;

        const int IS_NOT_CALCULATED = -1;
        public int numberOfContent => _numberOfContent;
        public string Salary
        {
            get => _salary.ToString();
            set => _salary = Int32.Parse(value);
        }
        public Employee()
        {
            _salary = IS_NOT_CALCULATED;
            _content = new List<Content>();
            _reports = new List<Report>();
            _numberOfContent = 0;
        }
        public void doTask()
        {
            const string QUIT = "quit";
            const string ADD_TEXT = "addText";
            const string ADD_REPORT = "addReport";
            const string REPORT_SALARY = "reportSalary";

            Console.WriteLine("Hi employee. What do you want to do? If you want to quit write \"quit\"  ");
            Console.WriteLine("There is a list I can do for you \n\n"
                + "addtext --> addText - id - text. For example, addText 4 \"Hi. We should study hard\" \n"
                + "add report --> addReport - id - start date - End date. For example, addReport 2 2021/5/5 2021/6/10\n"
                + "report salary --> reportSalary\n");

            string command = "";
            while (command != QUIT)
            {
                try
                {
                    command = Console.ReadLine();
                    string[] commands = command.Split();

                    if (commands[0] == ADD_TEXT)
                        setTextForContent(commands);
                    else if (commands[0] == ADD_REPORT)
                        setReportDay(commands);
                    else if (commands[0] == REPORT_SALARY)
                        reportSalary();
                    else if (commands[0] == QUIT)
                        return;
                    else
                        throw new wrongCommand();
                    Console.WriteLine("Your task is done.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void setTextForContent(string[] commands)
        {
            int id = Int32.Parse(commands[1]);
            string text = "";
            for (int i = 3; i < commands.Length; i++)
                text += commands[i];
            //
            if (_content.Count == 0)
                throw new emptyText();

            bool idFound = false;
            foreach (Content content in _content)
                if (content.getId == id)
                {
                    content.setText(text);
                    _numberOfContent ++;
                    idFound = true;
                }
            if (!idFound)
                throw new notExistText();
        }      
        public void addContent(Content newText)
        {
            foreach (Content text in _content)
                if (text.getId == newText.getId)
                    throw new DuplicateId();

            _content.Add(newText);
        }
        public void addReport(Report report_)
        {
            foreach (Report report in _reports)
                if (report.getId == report_.getId)
                    throw new DuplicateId();
            _reports.Add(report_);
        }
        private void setReportDay(string[] commands)
        {
            int id = Int32.Parse(commands[1]);
            Date startDate = new Date(commands[2]);
            Date endDate = new Date(commands[3]);
            
            if (_reports.Count == 0)
                throw new emptyReport();

            foreach (Report report in _reports)
                if (report.getId == id)
                    report.setDataForReport(startDate, endDate);            
        }       
        private void reportSalary()
        {
            if (_salary != IS_NOT_CALCULATED)
                Console.WriteLine($"Your salary is {_salary}");
            else
                Console.WriteLine("Sorry. Your salary isn't caculated");
        }
        public void viewReport()
        {
            if (_reports.Count == 0)
                throw new emptyReport();

            foreach (Report report in _reports)        
                report.printInfo();
        }
    }
    
}
