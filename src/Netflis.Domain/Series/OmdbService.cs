using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Volo.Abp.DependencyInjection;

namespace Netflis.Series
{
    public class OmdbService : ISeriesApiService
    {
        private static readonly string apiKey = "f189f7f3"; // Reemplaza con tu clave API de OMDb.
        private static readonly string baseUrl = "http://www.omdbapi.com/";

        public async Task<ICollection<SerieDTO>> GetSeriesAsync(string title, string gender)
        {
            using HttpClient client = new HttpClient();

            List<SerieDTO> series = new List<SerieDTO>();

            string url = $"{baseUrl}?s={title}&apikey={apiKey}&type=series";

            try
            {
                // Hacer la solicitud HTTP y obtener la respuesta como string
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON a un objeto SearchResponse
                var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);

                // Retornar la lista de series si existen
                var seriesOmdb = searchResponse?.Search ?? new List<SerieOmdb>();

                foreach (var serieOmdb in seriesOmdb)
                {
                    series.Add(new SerieDTO { title = serieOmdb.title });
                }

                return series;
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Se ha producido un error en la búsqueda de la serie", e);
            }
        }

        private class SearchResponse
        {
            [JsonProperty("Search")]
            public List<SerieOmdb> Search { get; set; }
        }
        private class SerieOmdb
        {
            public string title { get; set; }
            public string fechaLanzamiento { get; set; }
            public string directores { get; set; }
            public string escritores { get; set; }
            public string elenco { get; set; }
            public string portada { get; set; }
            public string paisOrigen { get; set; }
            public string calificacionImdb { get; set; }
            public string duracion { get; set; }
            public string generos { get; set; }
            public string trama { get; set; }
            public string idioma { get; set; }
        }
    }

    /*
    public class OmdbService : ISeriesApiService
    {

        private readonly HttpClient _httpClient;
        private const string ApiKey = "f189f7f3";
        private const string BaseUrl = "http://www.omdbapi.com/";

        // Constructor para inyectar HttpClient, no hace falta ya que viene con el framework
         public OmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    // Método POST para buscar series por título y género
    public async Task<SerieDTO[]> GetSeriesAsync(string titulo, string genero)
        {
            // Crear el cuerpo de la solicitud en formato JSON
            var searchRequest = new
            {
                Titulo = titulo,
                Genero = genero
            };

            // Realizar la solicitud POST enviando el cuerpo como JSON
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44396/api/app/serie/search", searchRequest);

            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Leer y procesar la respuesta JSON
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonResponse);

                // Verificar si la API devolvió resultados
                if (json["Response"]?.ToString() == "False")
                {
                    return Array.Empty<SerieDTO>(); // No hay resultados
                }

                // Extraer la lista de series desde el JSON
                var seriesJson = json["Search"];
                if (seriesJson == null)
                {
                    return Array.Empty<SerieDTO>();
                }

                // Lista para almacenar las series mapeadas
                var seriesList = new List<SerieDTO>();

                // Procesar cada serie obtenida y obtener detalles adicionales
                foreach (var serie in seriesJson)
                {
                    var serieId = serie["imdbID"]?.ToString();
                    var serieDetails = await ObtenerDetallesSerieAsync(serieId);

                    if (serieDetails != null)
                    {
                        seriesList.Add(serieDetails);
                    }
                }

                return seriesList.ToArray(); // Devolver la lista de series
            }

            // Si la solicitud no fue exitosa, lanzar un error con el mensaje del servidor
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error en la búsqueda de series: {errorMessage}");
        }

        // Método auxiliar para obtener los detalles de cada serie por ID
        private async Task<SerieDTO> ObtenerDetallesSerieAsync(string serieId)
        {
            var url = $"{BaseUrl}?apikey={ApiKey}&i={serieId}";

            // Realizar la solicitud GET para obtener detalles
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(jsonResponse);

            // Mapear el JSON a SerieDTO (implementa esta parte según tus necesidades)
            var serieDTO = new SerieDTO
            {
                title = json["Title"]?.ToString(),
                fechaLanzamiento = json["Released"]?.ToString(),
                directores = json["Director"]?.ToString(),
                escritores = json["Writer"]?.ToString(),
                elenco = json["Actors"]?.ToString(),
                portada = json["Poster"]?.ToString(),
                paisOrigen = json["Country"]?.ToString(),
                calificacionImdb = json["imdbRating"]?.ToString(),
                duracion = json["Runtime"]?.ToString(),
                trama = json["Plot"]?.ToString(),
                idioma = json["Language"]?.ToString(),
                generos = json["Genre"]?.ToString(),
                // Otros campos
            };

            return serieDTO;
        }
    }
    */
}

