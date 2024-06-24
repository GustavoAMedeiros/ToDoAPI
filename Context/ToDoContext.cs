using ApiToDo.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiToDo.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<TarefaEntity> Tarefas { get; set; }

        
    }
}
