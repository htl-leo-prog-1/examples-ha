using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManagement
{
    public class CalendarDate
    {
        private int _day;
        private int _month;
        private int _year;
        private string _description;

        public void SetDay(int day)
        {
            _day = day;
        }

        public int GetDay()
        {
            return _day;
        }
        public void SetMonth(int month)
        {
            _month = month;
        }

        public int GetMonth()
        {
            return _month;
        }
        public void SetYear(int year)
        {
            _year = year;
        }

        public int GetYear()
        {
            return _year;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }

        public string GetDescription()
        {
            return _description;
        }

    }
}
