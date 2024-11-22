using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibreriaFullStackBackEndinC.Models
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public int pages { get; set; }
        [Required]
        public double price { get; set; }
    }
}

