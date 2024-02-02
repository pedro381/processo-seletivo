using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Data;
using ProcessoSeletivo.Model;

namespace ProcessoSeletivo.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ProcessoSeletivoContext _context;

        public DetailsModel(ProcessoSeletivoContext context)
        {
            _context = context;
        }

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
    }
}
