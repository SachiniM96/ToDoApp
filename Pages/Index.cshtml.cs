using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Pages
{
    //public class IndexModel : PageModel
    //{
    //    private readonly ILogger<IndexModel> _logger;

    //    public IndexModel(ILogger<IndexModel> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public void OnGet()
    //    {

    //    }
    //}

    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        [BindProperty]
        public TodoItem NewTodo { get; set; }

        public async Task OnGetAsync()
        {
            TodoItems = await _context.TodoItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.TodoItems.Add(NewTodo);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
