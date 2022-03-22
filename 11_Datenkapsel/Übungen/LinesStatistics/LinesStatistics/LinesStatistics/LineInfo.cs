using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesStatistics
{
    public class LineInfo
    {
        private int _wordsCounter;
        private string _originalText;
        private string _resultText;
        private bool _hasMoreWordsThanAverage;

        public int GetWordsCounter()
        {
            return _wordsCounter;
        }

        public void SetWordsCounter(int wordsCounter)
        {
            _wordsCounter = wordsCounter;
        }

        public string GetOriginalText()
        {
            return _originalText;
        }

        public void SetOriginalText(string originalText)
        {
            _originalText = originalText;
        }

        public string GetResultText()
        {
            return _resultText;
        }

        public void SetResultText(string resultText)
        {
            _resultText = resultText;
        }

        public bool GetHasMoreWordsThanAverage()
        {
            return _hasMoreWordsThanAverage;
        }

        public void SetHasMoreWordsThanAverage(bool hasMoreWordsThanAverage)
        {
            _hasMoreWordsThanAverage = hasMoreWordsThanAverage;
        }
    }
}
