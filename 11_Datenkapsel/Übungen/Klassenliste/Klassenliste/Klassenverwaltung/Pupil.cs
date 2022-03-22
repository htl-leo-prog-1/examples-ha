using System;

namespace Klassenverwaltung
{
    public class Pupil
    {
        private int _catalogNumber;
        private string _firstName;
        private string _lastName;
        private int _zipCode;

        public void SetCatalogNumber(int catalogNumber)
        {
            _catalogNumber = catalogNumber;
        }

        public int GetCatalogNumber()
        {
             return _catalogNumber;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
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

        public void SetZipCode(int zipCode)
        {
            _zipCode = zipCode;
        }

        public int GetZipCode()
        {
            return _zipCode;
        }
    }
}
