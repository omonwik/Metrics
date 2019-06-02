﻿using Metrics.Models.Interfaces;
using System.Threading.Tasks;

namespace Metrics.Models
{
    public class SymbolsCountStrategy : IMetricsStrategy
    {
        public string Text { get; }
        public string Result { get; private set; }

        public SymbolsCountStrategy(string text)
        {
            Text = text;
        }

        public void Process()
        {
            CalculateSymbolsCount();
        }

        private void CalculateSymbolsCount()
        {
            Result = "Количество символов в тексте: " + Text.Length.ToString();
        }

        public async Task ProcessAsync()
        {
            await Task.Run(Process);
        }
    }
}