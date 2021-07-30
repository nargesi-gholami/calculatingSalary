using System;

namespace calculateSalary
{
    class Report
    {
        private int _uniqueId;
        private string _studentName;
        private Date _shouldStartDay;
        private Date _shouldEndDate;
        private Date _startDate;
        private Date _endDate;
        private int _numOfWorkingDay;
        private bool _dateReported;
        public int getId => _uniqueId;
        public int numOfWorkingDay
        {
            get => _numOfWorkingDay;
            set => _numOfWorkingDay = value;
        }
        public Date shouldStartDay => _shouldStartDay;
        public Date shouldEndDate => _shouldEndDate;
        public Date startDate => _startDate;
        public Date endDate => _endDate;
        public Report(int uniqueId_, string studentName_, Date start, Date end)
        {
            _uniqueId = uniqueId_;
            _studentName = studentName_;
            _shouldStartDay = start;
            _shouldEndDate = end;
            _dateReported = false;
        }
        public void printInfo()
        {
            if (_dateReported)
            {
                Console.WriteLine($"unique id is {_uniqueId}. Name of student is {_studentName}.\nstart day is: ");
                _startDate.show();
                Console.WriteLine("end day is: ");
                _endDate.show();
            }
        }
        public void setDataForReport(Date startDate, Date endDate)
        {
            if (endDate.Year < startDate.Year ||
                endDate.Year == startDate.Year && endDate.Month < startDate.Month ||
                endDate.Year == startDate.Year && endDate.Month == startDate.Month && endDate.Day < startDate.Day)
                throw new wrongDate();

            _startDate = startDate;
            _endDate = endDate;
            _dateReported = true;
        }
        
    }
}
