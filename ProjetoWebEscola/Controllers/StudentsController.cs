using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebEscola.Data;
using ProjetoWebEscola.Models;

namespace ProjetoWebEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var student = await _context.Student.ToListAsync(); // Obter todos os alunos do banco de dados
            return View(student);
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 se não encontrar o aluno
            }

            var student = await _context.Student.FirstOrDefaultAsync(a => a.Id == id); // Usando string id
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,ProfilePictureUrl,Matricula")] Student student) // Atualização de Aluno
        {
            if (ModelState.IsValid)
            {
                _context.Add(student); // Adiciona aluno ao contexto
                await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de alunos
            }
            return View(student); // Retorna a view se o modelo não for válido
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Alunos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FullName,ProfilePictureUrl,Matricula")] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student); // Atualiza aluno no contexto
                    await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(a => a.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.FindAsync(id); // Obter aluno pelo ID
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student); // Remove aluno do contexto
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.Id == id); // Verifica se o aluno existe no banco de dados
        }
    }
}
