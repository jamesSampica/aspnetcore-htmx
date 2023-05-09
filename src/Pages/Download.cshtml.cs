using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class PagesModel : PageModel
    {
        static List<Person> People = new(){ new("John", "123 1st Street", "IA", new(2000, 1, 4)),
                                            new("Sue", "921 West 2nd Rd", "IA", new(1990, 2, 5)),
                                            new("Mark", "16 32nd Ave", "ND", new(1995, 3, 6)) };

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

            var fileContents = $"{State!}-{From!}-{To!}{Environment.NewLine}";
            foreach(var person in People.Where(p => p.State == State || (From <= p.BirthDate && p.BirthDate <= To))) 
                fileContents += $"{person.Name}-{person.Address}-{person.BirthDate}{Environment.NewLine}";

            return File(Encoding.Default.GetBytes(fileContents), "text/csv", "my-download.txt");
        }
    }

    public record Person(string Name, string Address, string State, DateOnly BirthDate);
}
