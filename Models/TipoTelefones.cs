using System.ComponentModel.DataAnnotations;

namespace PIM_VIII_SQLSERVER.Models
{
    public class TipoTelefones
    {
        protected int? id;

        [Key()]
        public int? Id { get => id; set => id = value; }

        public string? tipo;

        public string? Tipo
        {
            get { return tipo; }
            set 
            {
                string temp = value[0].ToString();
                if (temp == "9") 
                {
                    tipo = "celular";
                }
                else
                {
                    tipo = "residencial";
                }
            }
        }
    }
}