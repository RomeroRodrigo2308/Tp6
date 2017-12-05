using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    [Table("Document")]
    class Document
    {
        [Key]
        [Column(Order = 1)]
        public string Number { get; set; }

        [Key]
        [Column(Order = 2)]
        public DocumentType Type { get; set; }
    }
}
