namespace HW_14_26_06_2024
{
//    Завдання 1:
//Створіть додаток для роботи з колекцією віршів, який
//зберігатиме таку інформацію:
// назва вірша;
// П.І.Б.автора;
// рік написання;
// текст вірша;
// тема вірша.
//Додаток має давати можливість:
// додавати вірші;
// видаляти вірші;
// змінювати інформацію про вірші;
// шукати вірш за різними характеристиками;
// зберігати колекцію віршів у файл;
// завантажувати колекцію віршів з файлу
    internal class Program
    {
        static void Main(string[] args)
        {
            //Poem poem1 = new Poem(
            //    "The Road Not Taken",
            //    "Robert Frost",
            //    1916,
            //    "Choices and consequences",
            //    "Two roads diverged in a yellow wood,\nAnd sorry I could not travel both\nAnd be one traveler, long I stood\nAnd looked down one as far as I could\nTo where it bent in the undergrowth;"
            //);
            //Poem poem2 = new Poem(
            //    "If—",
            //    "Rudyard Kipling",
            //    1910,
            //    "Maturity and personal integrity",
            //    "If you can keep your head when all about you\nAre losing theirs and blaming it on you,\nIf you can trust yourself when all men doubt you,\nBut make allowance for their doubting too;\n..."
            //);

            //Poem poem3 = new Poem(
            //    "Daffodils",
            //    "William Wordsworth",
            //    1807,
            //    "Nature's beauty and its impact on the human spirit",
            //    "I wandered lonely as a cloud\nThat floats on high o'er vales and hills,\nWhen all at once I saw a crowd,\nA host, of golden daffodils;\nBeside the lake, beneath the trees,\nFluttering and dancing in the breeze."
            //) ;
            PoemDataBase poemData = new PoemDataBase();
            //poemData.AddPoem( poem1);
            //poemData.AddPoem(poem2);
            //poemData.AddPoem(poem3);
            //poemData.Save();
            try
            {
                poemData.Load();
                foreach (Poem poem in poemData)
                {
                    Console.WriteLine("=====================");
                    Console.WriteLine(poem);
                }
                Console.WriteLine("\n\n");
                poemData.ChangeInfo(0, "NO TITLE", "ON AUTHOR", 2045, "FUTURE", "NOTEXT");
                foreach (Poem poem in poemData)
                {
                    Console.WriteLine("=====================");
                    Console.WriteLine(poem);
                }
                Console.WriteLine("\n\n");
                poemData.DelPoem(0);
                foreach (Poem poem in poemData)
                {
                    Console.WriteLine("=====================");
                    Console.WriteLine(poem);
                }
                Poem SPoem = poemData.SearchByTitle("If—");
                Console.WriteLine($"SEARCH POEM:\n{SPoem}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
