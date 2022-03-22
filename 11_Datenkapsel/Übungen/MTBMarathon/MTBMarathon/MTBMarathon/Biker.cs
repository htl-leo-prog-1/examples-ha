using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBMarathon
{
    public class Biker
    {

        private int _number;
        private string _name;
        private string _country;
        private string _year;
        private int _rank;
        private string _time;
        private int _timeInSeconds;

        public void SetNumber(int number)
        {
            _number = number;
        }

        public int GetNumber()
        {
            return _number;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetCountry(string country)
        {
            _country = country;
        }

        public string GetCountry()
        {
            return _country;
        }

        public void SetYear(string year)
        {
            _year = year;
        }

        public string GetYear()
        {
            return _year;
        }

        public void SetRank(int rank)
        {
            _rank = rank;
        }

        public int GetRank()
        {
            return _rank;
        }

        public void SetTime(string time)
        {
            _time = time;
        }

        public string GetTime()
        {
            return _time;
        }

        public void SetTimeInSeconds(int time)
        {
            _timeInSeconds = time;
        }

        public int GetTimeInSeconds()
        {
            return _timeInSeconds;
        }
    }
}
