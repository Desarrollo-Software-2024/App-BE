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
                    series.Add(new SerieDTO
                    {
                        title = serieOmdb.title,
                        fechaLanzamiento = serieOmdb.fechaLanzamiento,
                        directores = serieOmdb.directores,
                        escritores = serieOmdb.escritores,
                        elenco = serieOmdb.elenco,
                        portada = serieOmdb.portada,
                        paisOrigen = serieOmdb.paisOrigen,
                        calificacionImdb = serieOmdb.calificacionImdb,
                        duracion = serieOmdb.duracion,
                        generos = serieOmdb.generos,
                        trama = serieOmdb.trama,
                        idioma = serieOmdb.idioma
                    });
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
            [JsonProperty("Title")]
            public string title { get; set; }

            [JsonProperty("Released")]
            public string fechaLanzamiento { get; set; }

            [JsonProperty("Director")]
            public string directores { get; set; }

            [JsonProperty("Writer")]
            public string escritores { get; set; }

            [JsonProperty("Actors")]
            public string elenco { get; set; }

            [JsonProperty("Poster")]
            public string portada { get; set; }

            [JsonProperty("Country")]
            public string paisOrigen { get; set; }

            [JsonProperty("imdbRating")]
            public string calificacionImdb { get; set; }

            [JsonProperty("Runtime")]
            public string duracion { get; set; }

            [JsonProperty("Genre")]
            public string generos { get; set; }

            [JsonProperty("Plot")]
            public string trama { get; set; }

            [JsonProperty("Language")]
            public string idioma { get; set; }
        }
    }

}

