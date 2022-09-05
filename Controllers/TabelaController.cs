using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Managers;
using test2.Models;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaController : ControllerBase
    {
        private readonly ITabelaManager tabelaManager;
        public TabelaController(ITabelaManager tabelaManager)
        {
            this.tabelaManager = tabelaManager;
        }

        [HttpGet]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetTabela()
        {
            var tabela = tabelaManager.GetTabela();
            return Ok(tabela);
        }


        [HttpPost("Create")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create([FromBody] TabelaModel tabelaModel)
        {
            await tabelaManager.Create(tabelaModel);

            return Ok();
        }

        [HttpPut("Update pentru tanarul cu Id-ul 1")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] TabelaModel tabelaModel)
        {

            await tabelaManager.Update(tabelaModel);

            return Ok();
        }


        [HttpDelete("Delete dupa {id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            tabelaManager.Delete(id);

            return Ok();
        }
    }
}
