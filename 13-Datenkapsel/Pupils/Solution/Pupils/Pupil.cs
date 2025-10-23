using System;

namespace PupilsArray
{
    public class Pupil
    {
        int _catalogNumber;
        string _firstName;
        string _lastName;
        DateTime _birthDate;

        public int CatalogNumber
        {
            get { return _catalogNumber; }
            set { _catalogNumber = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string FullName
        {
            get { return $"{_firstName} {_lastName}"; }
        }

        public int Age
        {
            get
            {
                return (int) ((DateTime.Now - _birthDate).TotalDays / 365);
            }
        }

/*
        public int GetCatalogNumber()
        {
            return _catalogNumber;
        }

        public void SetCatalogNumber(int value)
        {
            _catalogNumber = value;
        }
*/
/*
        public void SetFirstName(string value)
        {
            _firstName = value;
        }
        public string GetFirstName()
        {
            return _firstName;
        }
*/
        public void SetLastName(string value)
        {
            _lastName = value;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetBirthDate(DateTime value)
        {
            _birthDate = value;
        }

        public DateTime GetBirthDate()
        {
            return _birthDate;
        }
    }
}