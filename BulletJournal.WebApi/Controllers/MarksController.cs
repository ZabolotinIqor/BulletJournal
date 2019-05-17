using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulletJournal.Core.DTO;
using BulletJournal.Core.Models;
using BulletJournal.Core.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MarksController:Controller
    {
        private readonly IMarksService marksService;

        public MarksController(IMarksService marksService)
        {
            this.marksService = marksService;
        }
        [HttpPost("AddMark")]
        public async Task<ActionResult> AddMark([FromBody]MarkDTO marks)
        {
            if (ModelState.IsValid)
            {
                var result =  await marksService.AddMark(marks);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            return BadRequest("Not correct query");
        }

        [HttpGet("GetAllMarks")]
        public async Task<ActionResult> GetAllMarks()
        {
            var result = await marksService.GetAllMarks();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
