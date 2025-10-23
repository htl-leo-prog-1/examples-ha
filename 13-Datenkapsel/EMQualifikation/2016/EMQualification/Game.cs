using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMQualification
{
    public class Game
    {
        private string _home;

        public string Home
        {
            get { return _home; }
            set { _home = value; }
        }
        private string _guest;

        public string Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }
        private int _shotHome;

        public int ShotHome
        {
            get { return _shotHome; }
            set { _shotHome = value; }
        }
        private int _shotGuest;

        public int ShotGuest
        {
            get { return _shotGuest; }
            set { _shotGuest = value; }
        }


    }
}
