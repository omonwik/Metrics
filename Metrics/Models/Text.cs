using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metrics.Models
{
    public class Text
    {
        public string Content { get; set; }

        public Filters Filters { get; set; }
    }

    public class Filters
    {
        public bool MostUsedSymbols { get; set; }
        public bool SymbolsCount { get; set; }
        public bool WordsCount { get; set; }
        public bool ExclamatorySentencesCount { get; set; }
        public bool InterrogativeSentencesCount { get; set; }
    }
}