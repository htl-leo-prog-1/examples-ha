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
        public string Date       { get; set; }
        public string HomeTeam   { get; set; }
        public string GuestTeam  { get; set; }
        public int    GoalsHome  { get; set; }
        public int    GoalsGuest { get; set; }

        public bool IsGameOfTeam(string teamName)
        {
            return IsGameOfHomeTeam(teamName) || IsGameOfGuestTeam(teamName);
        }

        public bool IsGameOfHomeTeam(string teamName)
        {
            return IsGameOfTeam(HomeTeam, teamName);
        }

        public bool IsGameOfGuestTeam(string teamName)
        {
            return IsGameOfTeam(GuestTeam, teamName);
        }

        private bool IsGameOfTeam(string teamName, string lookForTeamName)
        {
            return teamName.ToUpper().Contains(lookForTeamName.ToUpper());
        }
    }
}