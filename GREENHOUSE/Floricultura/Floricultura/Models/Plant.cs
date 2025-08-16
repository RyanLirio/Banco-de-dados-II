using System.ComponentModel.DataAnnotations;

namespace Floricultura.Models
{
    public class Plant
    {
        [Key]
        public string Nome { get; set; }
        public float? Humidade { get; set; }

    }
}
