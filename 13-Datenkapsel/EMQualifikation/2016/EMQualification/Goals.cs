using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMQualification
{
    public class Goals
    {
        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private int _goals;

        public int NrOfGoals
        {
            get { return _goals; }
            set { _goals = value; }
        }

    }
}
