using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// додавати вірші;+
// видаляти вірші; +
// змінювати інформацію про вірші;+
// шукати вірш за різними характеристиками;+
// зберігати колекцію віршів у файл;+
// завантажувати колекцію віршів з файлу+
namespace HW_14_26_06_2024
{
    internal class PoemDataBase:IDisposable,IEnumerable
    {
        private List<Poem> _list;
        public string PathToData {  get; set; }
        public PoemDataBase()
        {
            _list = new List<Poem>();
            PathToData = @".\poem_data.bin";
        }
        
        public void AddPoem(Poem p)
        {
            _list.Add(p);
        }
        public void AddPoem(string title, string author, int year, string theme, string text)
        {
            _list.Add(new Poem(title, author, year, theme, text));
        }
        public void DelPoem(int ind)
        {
            if (ind >= 0 && ind < _list.Count)
            {
                _list.Remove(_list[ind]);
            }
            else
                throw new Exception("Not in range");
        }
        public void ChangeInfo(int ind, string title, string author, int year, string theme, string text)
        {
            if (ind >= 0 && ind < _list.Count)
            {
                _list[ind].Title = title;
                _list[ind].Author = author;
                _list[ind].Year = year;
                _list[ind].Theme = theme;
                _list[ind].Text = text;
            }
            else
                throw new Exception("Not in range");
        }
        public Poem SearchByTitle(string title)
        {
            foreach(Poem poem in _list)
            {
                if(poem.Title == title) return poem;
            }
            throw new Exception("Poem not found");
        }
        public List<Poem> SearchByAuthor(string author)
        {
            List<Poem> searchList = new List<Poem>();
            foreach (Poem poem in _list)
            {
                if (poem.Author == author)
                {
                    searchList.Add(poem);
                }
            }
            return searchList;
        }
        public List<Poem> SearchByYear(int year)
        {
            List<Poem> searchList = new List<Poem>();
            foreach (Poem poem in _list)
            {
                if (poem.Year == year)
                {
                    searchList.Add(poem);
                }
            }
            return searchList;
        }
        public List<Poem> SearchByTheme(string theme)
        {
            List<Poem> searchList = new List<Poem>();
            foreach (Poem poem in _list)
            {
                if (poem.Theme == theme)
                {
                    searchList.Add(poem);
                }
            }
            return searchList;
        }
        
        public void Save()
        {
            using (FileStream fs = new FileStream(PathToData, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs)) 
                {
                    foreach (var item in _list)
                    {
                        bw.Write(item.Title);
                        bw.Write(item.Author);
                        bw.Write(item.Year);
                        bw.Write(item.Theme);
                        bw.Write(item.Text);
                    }
                }
            }
        }
        public void Load()
        {
            using (FileStream fs = new FileStream(PathToData, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Length > br.BaseStream.Position)
                    {
                        _list.Add(new Poem(br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadString(), br.ReadString()));
                    }
                }
            }
        }
        public IEnumerator<Poem> GetEnumerator()
        {
            foreach (var poem in _list)
            {
                yield return poem;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _list.Clear();
        }
    }
}
