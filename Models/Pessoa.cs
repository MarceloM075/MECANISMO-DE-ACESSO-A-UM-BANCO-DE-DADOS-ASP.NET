using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_SQLSERVER.Models
{
    public class Pessoa
    {
        protected int? id;

        [Key()]
        public int? Id { get => id; set => id = value; }

        public string? Nome { get; set; }

        public long? Cpf { get; set;}

        public virtual Telefones? Telefone { get; set; } = new Telefones();

        [ForeignKey("Telefone")]
        public int? TelefoneId { get; set; }

        public virtual Enderecos? Endereco { get; set; } = new Enderecos();

        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
    }
}
