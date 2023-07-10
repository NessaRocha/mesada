
using mesada.Data;
using mesada.Models;
using Microsoft.AspNetCore.Mvc;

namespace mesada.Controllers
{
    public class UsuariosControllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UsuariosController : ControllerBase
        {
            private readonly Data.MesadaDbContext _context;

            public UsuariosController(MesadaDbContext context)
            {
                _context = context;
            }

            // GET api/usuarios
            [HttpGet]
            public ActionResult<IEnumerable<Models.Usuario>> GetUsuarios()
            {
                var usuarios = _context.Usuarios.ToList();
                return Ok(usuarios);
            }

            // POST api/usuarios
            [HttpPost]
            public ActionResult<Usuario> CreateUsuario(Usuario usuario)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
            }

            // GET api/usuarios/1
            [HttpGet("{id}")]
            public ActionResult<Usuario> GetUsuario(int id)
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }

            // PUT api/usuarios/1
            [HttpPut("{id}")]
            public IActionResult UpdateUsuario(int id, Usuario usuario)
            {
                if (id != usuario.Id)
                {
                    return BadRequest();
                }

                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();

                return NoContent();
            }

            // DELETE api/usuarios/1
            [HttpDelete("{id}")]
            public IActionResult DeleteUsuario(int id)
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }