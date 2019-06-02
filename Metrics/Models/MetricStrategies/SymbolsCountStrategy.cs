using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication3.Models.Interfaces;

namespace WebApplication3.Models
{
    public class SymbolsCountStrategy : IMetricsStrategy
    {
        public string Text { get; }
        public string Result { get; private set; }

        public SymbolsCountStrategy(string text)
        {
            Text = text;
        }

        public string Process()
        {
            CalculateSymbolsCount();
            return Result;
        }

        private void CalculateSymbolsCount()
        {
            Result = "Количество символов: " + Text.Length.ToString();
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}