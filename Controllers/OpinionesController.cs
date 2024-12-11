using Microsoft.AspNetCore.Mvc;

using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class OpinionesController : ControllerBase
    {
        public static List<Opiniones> Opinion = new List<Opiniones>();

        [HttpGet]
        public ActionResult<IEnumerable<Opiniones>> GetAll()
        {
            return Ok(Opinion);
        }

        [HttpGet("{id}")]
        public ActionResult<Opiniones> GetById(int id)
        {
            var opinion = Opinion.FirstOrDefault(o => o.IdOpinion == id);
            if (opinion == null)
                return NotFound();
            return Ok(opinion);
        }

        [HttpPost]
        public ActionResult<Opiniones> Create([FromBody] Opiniones opinion)
        {
            Opinion.Add(opinion);
            return CreatedAtAction(nameof(GetById), new { id = opinion.IdOpinion }, opinion);
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Opiniones updatedOpinion)
        {
            var opinion = Opinion.FirstOrDefault(c => c.IdOpinion == id);
            if (opinion == null)
                return NotFound();

            opinion.IdOpinion = updatedOpinion.IdOpinion;
            opinion.NombreOpinante = updatedOpinion.NombreOpinante;
            opinion.ApellidoOpinante = updatedOpinion.ApellidoOpinante;
            opinion.Opinion = updatedOpinion.Opinion;

            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var opinion = Opinion.FirstOrDefault(o => o.IdOpinion == id);
            if (opinion == null)
                return NotFound();

            Opinion.Remove(opinion);
            return NoContent();
        }



       public static void InicializarDatos()
        {
            Opinion.Add(new Opiniones(1, "Fran", "Rebollo", "Buen cine","8/10"));
            Opinion.Add(new Opiniones(2, "Miguel", "Aznar", "Mal cine","3/10"));
            Opinion.Add(new Opiniones(3, "Marta", "Pérez", "Buen cine","6/10"));
        }






    }
}