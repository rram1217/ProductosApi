using ProductoFront.Models;

namespace ProductoFront.Services
{
    public class ProductoService
    {
        private readonly List<Producto> _Producto = new();
        private int _nextId = 1;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductoService> _logger;
        private const string API_URL = "api/Producto";

        public ProductoService(HttpClient httpClient, ILogger<ProductoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Producto>> ObtenerTodas()
        {
            try
            {
                var Producto = await _httpClient.GetFromJsonAsync<List<Producto>>(API_URL);
                return Producto ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener Productos: {ex.Message}");
                return new List<Producto>();
            }
        }

        public async Task<Producto?> ObtenerPorId(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Producto>($"{API_URL}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener Producto: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Crear(Producto Producto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(API_URL, Producto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Actualizar(int id, Producto Producto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{API_URL}/{id}", Producto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar Producto: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{API_URL}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar Producto: {ex.Message}");
                return false;
            }
        }

        //public async Task<bool> CambiarEstado(int id, bool completada)
        //{
        //    try
        //    {
        //        var Producto = await ObtenerPorId(id);
        //        if (Producto != null)
        //        {
        //            Producto.IsCompleted = completada;
        //            return await Actualizar(id, Producto);
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al cambiar estado: {ex.Message}");
        //        return false;
        //    }
        //}
    }
 
}
