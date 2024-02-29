using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

[ApiController]
[Route("api/[controller]")]
public class ArchivosController : ControllerBase
{
    private readonly string ruta = @"D:\.NET\ProductosSLN\Productos\Uploads";

    [HttpPost("subir")]
    public async Task<IActionResult> SubirArchivo([FromForm] IFormFile archivo)
    {
        // Verificar si se recibió un archivo
        if (archivo == null || archivo.Length == 0)
            return BadRequest("No se ha enviado ningún archivo.");

        // Generar un nombre único para el archivo
        var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);
        var rutaCompleta = Path.Combine(ruta, nombreArchivo);

        // Guardar el archivo en la ubicación deseada en el servidor
        using (var stream = new FileStream(rutaCompleta, FileMode.Create))
        {
            await archivo.CopyToAsync(stream);
        }

        // Devolver la ruta del archivo almacenado
        var urlArchivo = Url.Content("~/uploads/" + nombreArchivo);
        return Ok(new { url = urlArchivo });
    }
}
