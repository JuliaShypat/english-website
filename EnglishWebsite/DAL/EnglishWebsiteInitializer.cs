using EnglishWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishWebsite.DAL
{
    public class EnglishWebsiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EnglishWebsiteContext>
    {
        protected override void Seed(EnglishWebsiteContext context)
        {
            var words = new List<SingleWord>
            {
            new SingleWord{Word="Dog", Note="" },
            new SingleWord{Word="Cat", Note=""},
            new SingleWord{Word="Bird", Note=""},
            new SingleWord{Word="Han", Note=""},
            new SingleWord{Word="Frog", Note=""},
            new SingleWord{Word="Fish", Note=""},
            new SingleWord{Word="Sun", Note=""},
            new SingleWord{Word="Earth", Note=""}
            };

            words.ForEach(s => context.SingleWords.Add(s));
            context.SaveChanges();

            var languages = new List<Language>
            {
                new Language{LanguageID=1, LanguageName="Polski", Description="PL"},                
                new Language{LanguageID=2, LanguageName="English", Description="EN"}
            };
            languages.ForEach(s => context.Languages.Add(s));
            context.SaveChanges();

            var translations = new List<Translation> 
            {
                new Translation{SingleWordID=1, LanguageID=1, Text="Pies",Priority=1},
                new Translation{SingleWordID=1, LanguageID=1, Text="Szczeniak",Priority=2},
                new Translation{SingleWordID=2, LanguageID=1, Text="Kot", Priority=1},
                new Translation{SingleWordID=2, LanguageID=1, Text="Kotka", Priority=2},
                new Translation{SingleWordID=3, LanguageID=1, Text="Ptak", Priority=1},
                new Translation{SingleWordID=4, LanguageID=1, Text="Kurczak", Priority=1},
                new Translation{SingleWordID=5, LanguageID=1, Text="Żaba", Priority=1},
                new Translation{SingleWordID=6, LanguageID=1, Text="Ryba", Priority=1},
                new Translation{SingleWordID=6, LanguageID=1, Text="Rybka", Priority=1},
                new Translation{SingleWordID=7, LanguageID=1, Text="Słońce", Priority=1},
                new Translation{SingleWordID=8, LanguageID=1, Text="Ziemia", Priority=1},
                new Translation{SingleWordID=8, LanguageID=1, Text="Ziemia (planeta)", Priority=1},
            };
            translations.ForEach(s => context.Translations.Add(s));
            context.SaveChanges();
        }
    }
}