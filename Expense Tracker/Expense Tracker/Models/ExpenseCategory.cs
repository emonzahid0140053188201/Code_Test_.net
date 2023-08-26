using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models

{
    public class ExpenseCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
