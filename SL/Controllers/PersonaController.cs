using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduardoVilla_Examen.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = BL.Persona.GetAll();

            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int idPersona)
        {
            var result = BL.Persona.GetById(idPersona);

            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(int idPersona)
        {
            var result = BL.Persona.Delete(idPersona);

            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update([FromBody] ML.Persona persona)
        {
            var result = BL.Persona.Update(persona);

            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromBody] ML.Persona persona)
        {
            var result = BL.Persona.Add(persona);

            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }
    }
}
