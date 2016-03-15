using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishWebsite.Models
{
    public class Translation
    {
        [Key]
        public int TranslationID { get; set; }
        public int SingleWordID { get; set; }
        public int LanguageID { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }

        public virtual SingleWord SingleWord { get; set; }
        public virtual Language Language { get; set; }
    }
}