using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishWebsite.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }

        public string LanguageName { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Translation> Translation { get; set; }

    }
}