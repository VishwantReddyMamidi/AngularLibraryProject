using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        [JsonIgnore]
        public virtual ICollection<Books> Books { get; set; }
    }
}
