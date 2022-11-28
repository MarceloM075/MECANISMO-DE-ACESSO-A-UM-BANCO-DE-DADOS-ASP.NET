using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_SQLSERVER.Models
{
    public class Telefones
    {
        protected int? id;

        [Key()]
        public int? Id { get => id; set => id = value; }

        public int Ddd { get; set; }

        public int? Numero { get; set; }

        public virtual TipoTelefones? TipoTelefone { get; set; } = new TipoTelefones();

        public int TipoTelefoneId { get; set; }
    }
}