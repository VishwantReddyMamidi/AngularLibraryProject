using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Books
    {
        [Key]
        public Guid ISBN { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid? UserID { get; set; }

        public virtual Users User { get; set; }
    }
}
