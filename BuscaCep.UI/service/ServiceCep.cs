using BuscaCep.UI.model;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace BuscaCep.UI.service
{
    public static class ServiceCep
    {
        public async static Task<EnderecoCompleto> GetEnderecoByCepAsync(string Cep)
        {
            var URL = Settings.UrlViaCep;
            var enderecoCompleto = new EnderecoCompleto();
            enderecoCompleto = null;
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(string.Format(URL, Cep));
                var contentStream =  await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    enderecoCompleto = serializer.Deserialize<EnderecoCompleto>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Json Inválido.");
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

            }
            return enderecoCompleto;
        }
    }
}
