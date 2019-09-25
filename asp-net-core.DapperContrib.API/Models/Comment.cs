using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_core.DapperContrib.API.Models
{
    [Table("dbo.Comentarios")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Mensagem { get; set; }
    }
}
