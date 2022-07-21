using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExcelGenerator.Models
{
    public class ModelData
    {
        public string Subtitulo { get; set; }

        [JsonProperty("paises")]
        public List<Pais> Paises { get; set; }

    }

    public class Pais
    {
        [JsonProperty("gentilico")]
        public string Gentilico { get; set; }

        [JsonProperty("nome_pais")]
        public string NomePais { get; set; }

        [JsonProperty("nome_pais_int")]
        public string NomePaisInt { get; set; }

        [JsonProperty("sigla")]
        public string Sigla { get; set; }
    }

}
