using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class RazorPersonaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var result = BL.Persona.GetAll();

            if (result.Item1)
            {
                return View(result.Item3);
            }
            else
            {
                return View(null);
            }

        }

        [HttpGet]
        public IActionResult From(int? idPersona)
        {
            if (idPersona != 0)
            {
                var result = BL.Persona.GetById(idPersona.Value);

                if (result.Item1)
                {
                    return View(result.Item3);
                }
                else
                {
                    return View(null);
                }
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult From(ML.Persona persona)
        {
            if (ModelState.IsValid)
            {
                if (persona.IdPersona != 0)
                {
                    var result = BL.Persona.Update(persona);

                    if (result.Item1)
                    {
                        return RedirectToAction("Index", "RazorPersona");
                    }
                    else
                    {
                        return View(null);
                    }
                }
                else
                {
                    var result = BL.Persona.Add(persona);

                    if (result.Item1)
                    {
                        return RedirectToAction("Index", "RazorPersona");
                    }
                    else
                    {
                        return View(null);
                    }
                }
            }
            else
            {
                return View(persona);
            }

        }


        [HttpGet]
        public IActionResult Delete(int idPersona)
        {
            var result = BL.Persona.Delete(idPersona);

            if (result.Item1)
            {
                return RedirectToAction("index", "RazorPersona");
            }
            else
            {
                return View(null);
            }
        }
    }
}
