using System;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class ExpenseEntry
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public ExpenseCategory Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
