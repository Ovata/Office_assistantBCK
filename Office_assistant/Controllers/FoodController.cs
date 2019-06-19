using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Office_assistant.Context;
using Office_assistant.Model;
using Office_assistant.Repositories;

namespace Office_assistant.Controllers
{
    [Route("api/Food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        
            private readonly _dataRepository<Food> _dataRepository;
            private readonly ApplicationDbContext _foodContext;
         
            public FoodController(_dataRepository<Food> dataRepository, ApplicationDbContext foodContext)
            {
                _dataRepository = dataRepository;
                _foodContext = foodContext;

            }
            // GET: api/stores


            [HttpGet]
            public IActionResult Get()
            {
                IEnumerable<Food> stores = _dataRepository.GetAll();
                return Ok(stores);

            }

            // GET api/stores/5
           
            [HttpGet("{id}", Name = "GetFood")]
            public IActionResult Get(int ID)
            {
                Food food = _dataRepository.Get(ID);
                if (food == null)
                {
                    return NotFound("The store record couldn't be found.");
                }
                return Ok(food);
            }
            //[Route("users")]
            //[HttpGet]
            //public IActionResult GetFood([FromQuery] int id)
            //{
            //    IQueryable<Food> food = _foodContext.Foods
            //        .Where(u => u.ID == id);
            //    if (food == null)
            //    {
            //        return NotFound("The store record couldn't be found");
            //    }
            //    return Ok(food);
            //}



            
            [HttpPost]
            public IActionResult Post([FromBody] Food food)
            {
                if (food == null)
                {
                    return BadRequest("store is null");
                }
                _dataRepository.Add(food);
                return CreatedAtRoute(
                        "GetFood",
                        new { Id = food.Id },
                        food);
            }

            //Post: api/stores/ send-email
            //[Route("send-email")]
            //public async Task<IActionResult> SendEmailAsync([FromQuery] string username, string subject, string message)
            //{
            //    return Ok();
            //}

            //PUT: api/stores/5
           
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Food food)
            {
                if (food == null)
                {
                    return BadRequest("store is null ");
                }

                Food storeToUpdate = _dataRepository.Get(food.Id);
                if (storeToUpdate == null)
                {
                    return NotFound("The store could not be found");
                }

                _dataRepository.Update(storeToUpdate, food);
                return NoContent();
            }

            //Delete: api/stores/5
            
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Food food = _dataRepository.Get(id);
                if (food == null)
                {
                    return NotFound("The stores record couldn't be found.");
                }
                _dataRepository.Delete(food);
                return NoContent();
            }

        }
    }
