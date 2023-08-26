using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    public class ExpenseEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseEntry
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            IQueryable<ExpenseEntry> entries = _context.ExpenseEntries.Include(e => e.Category);

            if (startDate.HasValue)
            {
                entries = entries.Where(e => e.Date >= startDate);
            }

            if (endDate.HasValue)
            {
                entries = entries.Where(e => e.Date <= endDate);
            }

            var filteredEntries = await entries.ToListAsync();
            return View(filteredEntries);
        }

    }
}
