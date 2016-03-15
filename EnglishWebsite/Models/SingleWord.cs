using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishWebsite.Models
{
    public class SingleWord
    {
        [Key]
        public int ID { get; set; }
        public string Word { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Translation> Translation { get; set; }

    }
}