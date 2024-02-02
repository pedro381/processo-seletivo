using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Data;
using ProcessoSeletivo.Model;

namespace ProcessoSeletivo.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ProcessoSeletivoContext _context;

        public DeleteModel(ProcessoSeletivoContext context)
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

            var pergunta = await _context.Pergunta.FirstOrDefaultAsync(m => m.PerguntaId == id);

            if (pergunta == null)
            {
                return NotFound();
            }
            else
            {
                Pergunta = pergunta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Pergunta.FindAsync(id);
            if (pergunta != null)
            {
                Pergunta = pergunta;
                _context.Pergunta.Remove(Pergunta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
