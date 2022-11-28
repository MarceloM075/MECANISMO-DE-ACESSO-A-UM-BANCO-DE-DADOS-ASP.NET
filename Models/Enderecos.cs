using System.ComponentModel.DataAnnotations;

namespace PIM_VIII_SQLSERVER.Models
{
    public class Enderecos
    {
        protected int? id;

        [Key()]
        public int? Id { get => id; set => id = value; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        public string? Logradouro { get; set; }

        public string? Bairro { get; set; }

        public int Numero { get; set; }

        public int? Cep { get; set; }

    }
}