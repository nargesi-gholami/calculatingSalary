using System;
using System.Collections.Generic;
using System.Text;

namespace calculateSalary
{
    class Date
    {
        private int _day;
        private int _month;
        private int _year;
        public int Year => _year;
        public int Month => _month;
        public int Day => _day;
        public Date(string date)
        {
            string[] tokens = date.Split("/");
            int year_ = Int32.Parse(tokens[0]);
            int month_ = Int32.Parse(tokens[1]);
            int day_ = Int32.Parse(tokens[2]);

            if (day_ > 0 && day_ <= 31 &&
                month_ <= 12 && month_ >= 1 &&
                year_ < 2025 && year_ > 2000)
            {
                _day = day_;
                _month = month_;
                _year = year_;
            }
            else
                throw new wrongDate();
        }
        public void show()
        {
            Console.Write(_year);
            Console.Write("/");
            Console.Write(_month);
            Console.Write("/");
            Console.Write(_day + "\n");
        }
        public int calculateDiffDays(Date secondDay)
        {
            int numOfDay = 0;
            const int NUM_OF_DAY_IN_YEAR = 365;
            const int NUM_OF_MONTH_IN_YEAR = 12;
            const int NUM_OF_DAY_IN_MONTH = 30;

            numOfDay += (secondDay.Year - Year) * NUM_OF_DAY_IN_YEAR;
            int x = secondDay.Month - Month;
            int y = (NUM_OF_MONTH_IN_YEAR - secondDay.Month + Month);
            numOfDay += (secondDay.Month - Month >= 0) ? ((secondDay.Month - Month) * NUM_OF_DAY_IN_MONTH) :
                                                                ((NUM_OF_MONTH_IN_YEAR - secondDay.Month + Month) * NUM_OF_DAY_IN_MONTH - NUM_OF_DAY_IN_YEAR);
            numOfDay += (secondDay.Day - Day >= 0) ? (secondDay.Day - Day) :
                                                            (NUM_OF_DAY_IN_MONTH - (secondDay.Day - Day));
            return numOfDay;
        }
        public bool compareDays(Date smallerDay)
        {
            if (smallerDay.Year < Year ||
                smallerDay.Year == Year && smallerDay.Month < Month ||
                smallerDay.Year == Year && smallerDay.Month == Month && smallerDay.Day < Day)
                return true;
            else
                return false;
        }
    }
}
