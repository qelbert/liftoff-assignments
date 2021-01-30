using Countdown_ASP.NET.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Countdown_ASP.NET.Models;

namespace Countdown_ASP.NET.Controllers
{
    [ApiController]
    [Route(Entrypoint)]
    public class Collection1Controller : ControllerBase
    {
        public const string Entrypoint = "/api/resources";

        private readonly Collection1DbContext _dbContext;

        public Collection1Controller(Collection1DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetCollection",
            Summary = "Retrieve all Products",
            Description = "Publicly available"
   )]
        [SwaggerResponse(200, "List of public entity data", Type = typeof(List<Collection1Entity>))]
        public ActionResult GetResources() => Ok(_dbContext.Collection1.ToList());

        [HttpPost]
        [SwaggerOperation(OperationId = "RegisterEntity", Summary = "Create a new Entity")]
        [SwaggerResponse(201, "Returns new data", Type = typeof(Collection1Entity))]
        [SwaggerResponse(400, "Invalid or missing data", Type = null)]
        public ActionResult RegisterEntity([FromBody] Collection1NewEntityDto NewEntityDto)
        {
            var entityEntry = _dbContext.Collection1.Add(new Collection1Entity());
            entityEntry.CurrentValues.SetValues(NewEntityDto);
            _dbContext.SaveChanges();

            var newEntity = entityEntry.Entity;

            return CreatedAtAction(
              nameof(GetEntity),
              new { entityId = newEntity.Id },
              newEntity
            );
        }

        [HttpGet]
        [Route("{entityId}")]
        [SwaggerOperation(OperationId = "GetEntity", Summary = "Retrieve Entity data")]
        [SwaggerResponse(200, "Complete Entity data", Type = typeof(Collection1Entity))]
        [SwaggerResponse(404, "Entity not found", Type = null)]
        public ActionResult GetEntity([FromRoute] long entityId)
        {
            var entity = _dbContext.Collection1.Find(entityId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete]
        [Route("{entityId}")]
        [SwaggerOperation(
          OperationId = "DeleteEntity",
          Summary = "Cancel (delete) an Entity"
        )]
        [ProducesResponseType(204)] // suppress default swagger 200 response code
        [SwaggerResponse(204, "No content success", Type = null)]
        public ActionResult DeleteEntity([FromRoute] long entityId)
        {
            _dbContext.Collection1.Remove(new Collection1Entity { Id = entityId });

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                // row did not exist
                return NotFound();
            }

            return NoContent();
        }


    }
}
