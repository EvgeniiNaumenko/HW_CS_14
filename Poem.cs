using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14_26_06_2024
{
    internal class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public Poem()
        {
            Title = "NoName";
            Author = "NoAythor";
            Year = 0;
            Theme = "NoTheme";
            Text = "NoText";
        }
        public Poem (string title, string author, int year, string theme,string text)
        {
            Title = title;
            Author = author;
            Year = year;
            Text = text;
            Theme = theme;
        }
        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nYear: {Year}\nTheme:{Theme}\nText:\n{Text}";
        }
    }
}
