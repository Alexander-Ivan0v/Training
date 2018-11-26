using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Models.Views;
using Training.Processors.Business;

namespace Training.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IGetTrainingBusiness _training;

        public TrainingController(IGetTrainingBusiness training)
        {
            _training = training;
        }

        // GET api/v1/training
        [HttpGet]
        public async Task<IList<Models.Views.Training>> ListAsync()
        {   
            return await _training.GetAsync();
        }

        // GET api/v1/training/5
        [HttpGet("{id}")]
        public ActionResult<string> List(int id)
        {
            return "value";
        }

        // POST api/v1/training
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v1/training/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/training/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
