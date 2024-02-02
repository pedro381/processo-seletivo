using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProcessoSeletivo.Data;
using ProcessoSeletivo.Model;

namespace ProcessoSeletivo.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ProcessoSeletivoContext _context;

        public CreateModel(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pergunta Pergunta { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pergunta.Add(Pergunta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
