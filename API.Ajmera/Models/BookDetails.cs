using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Ajmera.Models
{
    [Table("BookDetails")]
    public class BookDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
    }
}
