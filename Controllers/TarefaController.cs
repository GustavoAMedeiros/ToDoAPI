using ApiToDo.Context;
using ApiToDo.DTOs;
using ApiToDo.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public TarefaController(ToDoContext context)
        {
            _context = context;
        }

        [HttpPost, Route("CriarTarefa")]
        public IActionResult CriarTarefa(TarefaEntity tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet, Route("ObterTodasAsTarefas")]
        public IActionResult ObterTodasAsTarefas()
        {
            var tarefas = _context.Tarefas;

            return tarefas == null ? NotFound() : Ok(tarefas);
        }

        [HttpGet, Route("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpGet, Route("ObterPorTitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Title.Contains(titulo));

            return Ok(tarefa);
        }

        [HttpPut, Route("AtualizarTarefa/{id}")]
        public IActionResult AtualizarTarefa(int id, TarefaEntity tarefaAtualizada)
        {
            var tarefaBancoDados = _context.Tarefas.Find(id);

            if (tarefaBancoDados == null)
            {
                return NotFound();
            }

            tarefaBancoDados.Title = tarefaAtualizada.Title;
            tarefaBancoDados.Done = tarefaAtualizada.Done;
            tarefaAtualizada.Description = tarefaAtualizada.Description;

            _context.Tarefas.Update(tarefaBancoDados);
            _context.SaveChanges();

            return Ok(tarefaBancoDados);
        }

        [HttpPatch, Route("AtualizarStatus/{id}")]
        public IActionResult AtualizarStatus(int id, TarefaStatusDTO tarefaStatusAtualizado)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
            {
                return NotFound();
            }

            tarefaBanco.Done = tarefaStatusAtualizado.Done;

            _context.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }

        [HttpDelete, Route("DeletarTarefa/{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }
            _context.Remove(tarefa);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
