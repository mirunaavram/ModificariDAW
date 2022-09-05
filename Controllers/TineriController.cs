using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Managers;
using test2.Models;
using test2.Repositories;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TineriController : ControllerBase
    {
        //private readonly TineriContext db;
        //cand mi se initiaza controller ul prin constructor , mi se va instantia si contextul


        private readonly ITineriManager manager;

        public TineriController(ITineriManager tineriManager)

        {
            this.manager = tineriManager;
        }

        [HttpGet]
        [Authorize(Policy = "BasicUser")] //se numeste atribut
        public async Task<IActionResult> GetTineri()
        {

            var tineri = manager.GetTineri();

            return Ok(tineri);
        }

        
        
        [HttpGet("select")]
        [Authorize(Policy = "BasicUser")]
        //eager loading
        public async Task<IActionResult> GetTineriIdsEager()
        {
            //luam info din baza de date
            //contextul face leg intre baza de date si cod

            var tineriIds = manager.GetTineriIds();
            
            return Ok(tineriIds);
        }

        

        [HttpGet("eager-join")]
        [Authorize(Policy = "BasicUser")]

        public async Task<IActionResult> JoinEager()
        {

            var tineri = manager.GetTineriWithJoin();

            foreach (var x in tineri)
            {
                var y = x.Locatie;
            }
        
            return Ok(tineri);
        }

        [HttpGet("filter")]
        [Authorize(Policy = "BasicUser")]

        public async Task<IActionResult> Filter()
        {

            var tineri = manager.GetTineriFiltered();


            return Ok(tineri);
        }

        [HttpGet("orderby")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> OrderBy()
        {

            /* var db = new TineriContext();
             var tineri = db.Tineri
                 .Include(x => x.Locatie)
                 .Include(x => x.TanarActivitate)
                 //.Where(x => x.Locatie.Oras == "Bucharest")
                 //.Select(x => new { Id = x.Id, Nume = x.Nume }) //selectez numai ce vreau eu, nu all
                 .ToList()
                 .OrderBy(x=> x.Nume)
                 .ToList();
            */
            var tineri = manager.GetTineriFilteredOrdered();

            return Ok(tineri);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create([FromBody] string nume)
        {
            
            var newTanar = new Tanar
            {
                Id = Guid.NewGuid(),
                Nume = nume
            };

            await manager.Create(newTanar);

            return Ok();
        }

        [HttpPost("withObj")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create([FromBody] TanarModel tanarModel)
        {

            var newTanar = new Tanar
            {
                //Id = tanarModel.Id,
                Id = Guid.NewGuid(),
                Nume = tanarModel.Nume,
                Prenume = tanarModel.Prenume
            };

            await manager.Create(newTanar);

            return Ok();
        }

        [HttpPut("withObj")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update([FromBody] EditTanarModel editTanarModel)
        {

            await manager.Update(editTanarModel);

            return Ok();
        }


        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            manager.Delete(Id);

            return Ok();
        }


    }
}
