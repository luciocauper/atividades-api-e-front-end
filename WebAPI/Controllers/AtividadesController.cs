using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    // localhost:xxxx/api/atividades
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly AppDB dbContext;

        public AtividadesController(AppDB dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAtividades()
        {
            return Ok(dbContext.Atividades.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getAtividadeById(Guid id)
        {
            var atividade = dbContext.Atividades.Find(id);

            if (atividade == null)
            {
                return NotFound();
            }
            return Ok(atividade);
        }
        [HttpPost]
        public IActionResult AddAtividades(AddAtvDto AddAtvDto)
        {
            var atv_obj = new Atividade()
            {
                Tarefa = AddAtvDto.Tarefa,
                ParaNome = AddAtvDto.ParaNome,
                Data = AddAtvDto.Data
            };

            dbContext.Atividades.Add(atv_obj);
            dbContext.SaveChanges();

            return Ok(atv_obj);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAtividade(Guid id, UpdateAtividadeDto updateAtividade)
        {
            var atividade = dbContext.Atividades.Find(id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Tarefa = updateAtividade.Tarefa;
            atividade.ParaNome = updateAtividade.ParaNome;
            atividade.Data = updateAtividade.Data;

            dbContext.SaveChanges();
            return Ok(atividade);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAtividade(Guid id)
        {
            var atividade = dbContext.Atividades.Find(id);

            if (atividade == null)
            {
                return NotFound();
            }

            dbContext.Atividades.Remove(atividade);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
