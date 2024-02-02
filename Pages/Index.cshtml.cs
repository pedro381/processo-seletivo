using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Model;

namespace ProcessoSeletivo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ProcessoSeletivoContext _context;

        public IndexModel(Data.ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public IList<Pergunta> Pergunta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pergunta = await _context.Pergunta.ToListAsync();
        }
    }
}
