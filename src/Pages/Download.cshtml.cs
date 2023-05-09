using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class PagesModel : PageModel
    {

        public void OnGet()
        {
        }

        [BindProperty] public string? State { get; set; }
        [BindProperty] public DateOnly? From { get; set; }
        [BindProperty] public DateOnly? To { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return File(Encoding.Default.GetBytes($"{State!}-{From!}-{To!}"), "text/csv", "my-download.txt");
        }
    }
}
