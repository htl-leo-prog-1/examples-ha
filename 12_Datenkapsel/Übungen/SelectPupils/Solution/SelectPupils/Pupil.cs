/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: SelectPupil
*--------------------------------------------------------------
*/

namespace SelectPupils
{
    public class Pupil
    {
        private string _firstName;
        private string _lastName;

        private int _gradeGerman;
        private int _gradeEnglish;
        private int _gradeMath;


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int GradeGerman
        {
            get { return _gradeGerman; }
            set { _gradeGerman = value; }
        }

        public int GradeEnglish
        {
            get { return _gradeEnglish; }
            set { _gradeEnglish = value; }
        }

        public int GradeMath
        {
            get { return _gradeMath; }
            set { _gradeMath = value; }
        }
    }
}