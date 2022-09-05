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
    public class ActivitateController : ControllerBase
    {
        private readonly IActivitateManager activitateManager;
        public ActivitateController(IActivitateManager activitateManager)
        {
            this.activitateManager = activitateManager;
        }

        [HttpGet]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetActivitate()
        {
            var activitate = activitateManager.GetActivitate();
            return Ok(activitate);
        }


        [HttpGet("select dupa id")]
        [Authorize(Policy = "BasicUser")]
        //eager loading
        public async Task<IActionResult> GetActivitateIdsEager()
        {
            
            var activitateIds = activitateManager.GetActivitateIds();

            return Ok(activitateIds);
        }



        [HttpGet("join cu PerioadaActivitate")]
        [Authorize(Policy = "BasicUser")]

        public async Task<IActionResult> JoinEager()
        {

            var activitate = activitateManager.GetActivitateWithJoin();

            /*foreach (var x in activitate)
            {
                var y = x.Locatie;
            }*/

            return Ok(activitate);
        }

        [HttpGet("filter")]
        [Authorize(Policy = "BasicUser")]

        public async Task<IActionResult> Filter()
        {

            var activitate = activitateManager.GetActivitateFiltered();
            return Ok(activitate);
        }

        [HttpGet("orderby")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> OrderBy()
        {

           
            var activitate = activitateManager.GetActivitatiOrdered();

            return Ok(activitate);
        }

        

        [HttpPost("Create")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create([FromBody] ActivitateModel activitateModel)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            var newActivitate = new Activitate
            {
                Id = str, //am generat un id automat
                Nume = activitateModel.Nume,
                Categorie = activitateModel.Categorie,
                NrParticipanti = activitateModel.NrParticipanti
            };

            await activitateManager.Create(newActivitate);

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] ActivitateModel activitateModel)
        {

            await activitateManager.Update(activitateModel);

            return Ok();
        }


        [HttpDelete("Delete dupa {id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            activitateManager.Delete(id);

            return Ok();
        }
    }
}
