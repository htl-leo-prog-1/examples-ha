using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        private string _author;
        private string _title;
        private string _publisher;
        private string _isbn;

        public void SetAuthor(string author)
        {
            _author = author;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetPublisher(string publisher)
        {
            _publisher = publisher;
        }

        public string GetPublisher()
        {
            return _publisher;
        }

        public void SetISBN(string isbn)
        {
            _isbn = isbn;
        }

        public string GetISBN()
        {
            return _isbn;
        }



    }
}
