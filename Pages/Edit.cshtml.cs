using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Data;
using ProcessoSeletivo.Model;

namespace ProcessoSeletivo.Pages
{
    public class EditModel : PageModel
    {
        private readonly ProcessoSeletivoContext _context;

        public EditModel(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pergunta Pergunta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta =  await _context.Pergunta.FirstOrDefaultAsync(m => m.PerguntaId == id);
            if (pergunta == null)
            {
                return NotFound();
            }
            Pergunta = pergunta;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pergunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerguntaExists(Pergunta.PerguntaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PerguntaExists(int id)
        {
            return _context.Pergunta.Any(e => e.PerguntaId == id);
        }
    }
}
