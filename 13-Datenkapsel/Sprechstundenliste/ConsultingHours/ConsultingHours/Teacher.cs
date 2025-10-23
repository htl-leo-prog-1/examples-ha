using System;

namespace ConsultingHours
{
    public class Teacher
    {
        private string _title;
        private string _name;
        private string _day;
        private string _time;
        private string _room;

        public void SetTitle(string title)
        {
            _title = title;
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetDay(string day)
        {
            _day = day;
        }

        public string GetDay()
        {
            return _day;
        }


        public void SetTime(string time)
        {
            _time = time;
        }

        public string GetTime()
        {
            return _time;
        }

        public void SetRoom(string room)
        {
            _room = room;
        }

        public string GetRoom()
        {
            return _room;
        }

    }
}
