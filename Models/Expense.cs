using System;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        // Заменили DateTime на DateTimeOffset
        public DateTimeOffset Date { get; set; }

        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}


