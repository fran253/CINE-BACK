using Microsoft.AspNetCore.Mvc;

using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class ComidaController : ControllerBase
    {
        public static List<Comida> complementos = new List<Comida>();

        [HttpGet]
        public ActionResult<IEnumerable<Comida>> GetAll()
        {
            return Ok(complementos);
        }

        [HttpGet("{id}")]
        public ActionResult<Comida> GetById(int id)
        {
            var complemento = complementos.FirstOrDefault(c => c.IdComplemento == id);
            if (complemento == null)
                return NotFound();
            return Ok(complemento);
        }

        [HttpPost]
        public ActionResult<Comida> Create([FromBody] Comida complemento)
        {
            complementos.Add(complemento);
            return CreatedAtAction(nameof(GetById), new { id = complemento.IdComplemento }, complemento);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Comida updatedComplemento)
        {
            var complemento = complementos.FirstOrDefault(c => c.IdComplemento == id);
            if (complemento == null)
                return NotFound();

            complemento.IdComplemento = updatedComplemento.IdComplemento;
            complemento.ImagenComplemento = updatedComplemento.ImagenComplemento;
            complemento.NombreComplemento = updatedComplemento.NombreComplemento;
            complemento.DescripcionComplemento = updatedComplemento.DescripcionComplemento;
            complemento.PrecioComplemento = updatedComplemento.PrecioComplemento;

            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var complemento = complementos.FirstOrDefault(c => c.IdComplemento == id);
            if (complemento == null)
                return NotFound();

            complementos.Remove(complemento);
            return NoContent();
        }


        public static void InicializarDatos()
        {
            complementos.Add(new Comida(1,"../imgs/palomitas.png", "Palomitas", "", 3.50));
            complementos.Add(new Comida(2, "../imgs/palomitas.png", "Perrito Caliente", "", 5.50));
            complementos.Add(new Comida(3, "../imgs/palomitas.png", "Bebida Random", "", 2.50));
            complementos.Add(new Comida(4, "../imgs/palomitas.png", "Nachos", "", 4.50));
            complementos.Add(new Comida(5, "../imgs/palomitas.png", "Palomitas Dulces", "", 4.00));

        }
    }

}