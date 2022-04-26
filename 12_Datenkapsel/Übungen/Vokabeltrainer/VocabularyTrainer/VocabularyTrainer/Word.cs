using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer
{
    public class Word
    {
        private string _german;
        private string _english;
        private int _nrFails;
        private int _nrHits;

        public void SetGerman(string german)
        {
            _german = german;
        }

        public string GetGerman()
        {
            return _german;
        }

        public void SetEnglish(string english)
        {
            _english = english;
        }

        public string GetEnglish()
        {
            return _english;
        }

        public void AddHit()
        {
            _nrHits++;
        }

        public int GetHits()
        {
            return _nrHits;
        }

        public void AddFail()
        {
            _nrFails++;
        }

        public int GetFails()
        {
            return _nrFails;
        }

        public void SetFails(int fails)
        {
            _nrFails = fails;
        }

        internal void SetHits(int hits)
        {
            _nrHits = hits;
        }
    }
}
