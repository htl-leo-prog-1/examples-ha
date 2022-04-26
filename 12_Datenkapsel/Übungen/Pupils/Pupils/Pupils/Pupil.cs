namespace PupilsArray
{
    public class Pupil
    {
        int _catalogNumber;
        string _firstName;
        string _lastName;
        string _birthDate;

        public int GetCatalogNumber()
        {
            return _catalogNumber;
        }

        public void SetCatalogNumber(int catalogNumber)
        {
            _catalogNumber = catalogNumber;
        }

        public void SetFirstName(string firstname)
        {
            _firstName = firstname;
        }
        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }
        public string GetLastName()
        {
            return _lastName;
        }

        public void SetBirthDate(string birthDate)
        {
            _birthDate = birthDate;
        }
        public string GetBirthDate()
        {
            return _birthDate;
        }

    }
}
