using DesafioPGESE.Application.Services;
using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DesafioPGESEAPI.API.Controllers
{
    [Authorize]
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<Usuario>))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = "Error fetching users", details = ex.Message});
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>User data</returns>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success", typeof(Usuario))]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                if (usuario == null)
                    return NotFound(new {message = "User not found."});
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error fetching user", details = ex.Message });
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="usuario">User data</param>
        /// <returns>Is created user</returns>
        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse(201, "Created", typeof(Usuario))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> Add([FromBody] Usuario usuario)
        {
            try
            {
                await _usuarioService.AddAsync(usuario);
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error creating user", details = ex.Message });
            }
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">Id of the user to update</param>
        /// <param name="usuario">Updated user data</param>
        /// <returns>No content if successful</returns>
        [HttpPut("{id}")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioExists = await _usuarioService.GetByIdAsync(id);
                if (usuarioExists == null)
                    return NotFound(new { message = "User not found." });
                usuario.Id = id;
                await _usuarioService.UpdateAsync(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error updating user", details = ex.Message });
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">Id of the user to delete</param>
        /// <returns>No content if successful</returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuarioExists = await _usuarioService.GetByIdAsync(id);
                if (usuarioExists == null)
                    return NotFound(new { message = "User not found." });
                await _usuarioService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error deleting user", details = ex.Message });
            }
        }
    }
}
