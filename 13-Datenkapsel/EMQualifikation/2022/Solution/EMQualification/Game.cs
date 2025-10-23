/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: EMQualification
*--------------------------------------------------------------
*/

namespace EMQualification
{
    public class Game
    {
        private string _date;
        private string _homeTeam;
        private string _guestTeam;
        private int _goalsHome;
        private int _goalsGuest;

        public string GetDate()
        {
            return _date;
        }

        public string GetHomeTeam()
        {
            return _homeTeam;
        }

        public string GetGuestTeam()
        {
            return _guestTeam;
        }

        public int GetGoalsHome()
        {
            return _goalsHome;
        }

        public int GetGoalsGuest()
        {
            return _goalsGuest;
        }

        public void SetDate(string value)
        {
            _date = value;
        }

        public void SetHomeTeam(string value)
        {
            _homeTeam = value;
        }

        public void SetGuestTeam(string value)
        {
            _guestTeam = value;
        }

        public void SetGoalsHome(int value)
        {
            _goalsHome = value;
        }

        public void SetGoalsGuest(int value)
        {
            _goalsGuest = value;
        }
    }
}
