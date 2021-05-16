using LInqHomeWork.helpClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInqHomeWork
{
    public class LinqRequests
    {
        public static void NumbersFromTenTofifty()
        {
            var str = Enumerable.Range(10, 41).Select(i => i);

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
        }

        public static void NumbersFromTenTofiftymultipleTHree()
        {
            var str = Enumerable.Range(10, 41).Select(i => i).Where(i=>i%3==0);

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
        }

        public static void LibqTenTims()
        {
            var str = Enumerable.Repeat("Linq", 10);

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
        }
        public static void WordsWithLetter(string inputStr)
        {
            var answer = inputStr.Split("; ").Select(i => i).Where(i => i.Contains("a"));

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
        }
        


        public static void WordInString(string inputStr)
        {
            var answer = inputStr.Split("; ").Select(i => i).Where(i => i.Equals("abb")).Any();

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            Console.WriteLine(answer);
        }

        public static void LongestWord(string inputStr)
        {
            var answer = inputStr.Split("; ").OrderByDescending(n => n.Length).First();

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            Console.WriteLine(answer);
        }

        public static void AverageLength(string inputStr)
        {
            var answer = inputStr.Split("; ").Select(n => n.Length).Average();

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            Console.WriteLine(answer);
        }
        public static void ShorstReverse(string inputStr)
        {
            var answer = string.Join("", inputStr.Split("; ").OrderBy(n => n.Length).First().Reverse());

            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");
            Console.WriteLine(answer);
        }

        public static void IsExistAabb()
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");
            string word = "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh";
            IEnumerable<string> words = word.Split("; ").ToList();
            Console.WriteLine(string.Join(",", words.Select(x => string.Join("", x.ToCharArray().Take(2)) == "aa" && x.ToCharArray().Skip(2).All(x => x == 'b'))));
        }
        public static void LastWord()
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            Console.WriteLine($"\n{methodName}");

            string word = "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh";
            var result = word.Split("; ").ToList().Where(x => string.Join("", x.ToCharArray().TakeLast(2)) != "bb").Last();
            Console.WriteLine(result);
        }




        public static void ActorNames(List<object> list)
        {
            Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name);
            
            var films = list.Where(a=>a is Film).Cast<Film>();
            var actors = films.Select(x => string.Join(", ", x.Actors.Select(a => a.Name)));

            foreach (var item in actors)
            {
                Console.WriteLine(item);
            }
        }

        public static void NumOfActorsCreatedInAugest(List<object> list)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            var films = list.Where(a => a is Film).Cast<Film>();
            IEnumerable<Actor> actors = films.FirstOrDefault().Actors.Concat(films.LastOrDefault().Actors).Distinct();
            int restlt = actors.Where(x => x.Birthdate.Month == 8).Count();

            Console.WriteLine(restlt);
        }

        public static void TwoOldestActor(List<object> list)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            var films = list.Where(a => a is Film).Cast<Film>();
            IEnumerable<Actor> actors = films.FirstOrDefault().Actors.Concat(films.LastOrDefault().Actors).Distinct();

            var restlt = actors.OrderBy(x => x.Birthdate).TakeLast(2);

            Console.WriteLine(string.Join(", ", restlt.Select(a=>a.Name+"  "+a.Birthdate)));
        }

        public static void ArticlePerAuthor(List<object> list)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            var articles = list.Where(a =>a is Article).Cast<Article>();
            var authors = articles.Select(a => a.Author).Distinct();
            var artPerAuthor = authors.Select(a => a + "  " + articles.Where(b => a == b.Author).Count());
            foreach (var item in artPerAuthor)
            {
                Console.WriteLine(item);
            }
        }

        public static void DifferentLettersInActorName(List<object> list)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            var articles = list.Where(a => a is Article).Cast<Article>();
            var AllNames =string.Join("", articles.Select(a => a.Author).Distinct());
            var answer = AllNames.ToCharArray().Distinct().Count();

            Console.WriteLine(answer);
        }

        public static void ArticleOrdered(List<object> list)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            var articles = list.Where(a => a is Article).Cast<Article>();
            var OrderdArticles = articles.OrderBy(a => a.Author + a.Pages);

            var answer = string.Join(", ", OrderdArticles.Select(a => a.Name));
            Console.WriteLine(answer);
        }

        public static void NameActorFilms(List<object> list)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            IEnumerable<Film> films = list.Where(x => x is Film).Cast<Film>();
            IEnumerable<Actor> actors = films.FirstOrDefault().Actors.Concat(films.LastOrDefault().Actors).Distinct();

            Console.WriteLine(string.Join(", ", actors.Select(x => x.Name +
            string.Join(", ", (films.Where(b => b.Actors.Any(c => c.Name == x.Name)).Select(x => x.Name))))));
        }


        public static void SumInt(List<object> data)
        {
            Console.WriteLine($"\n{System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            IEnumerable<Article> articles = data.Where(x => x is Article).Cast<Article>();
            int result = 0;
            foreach (var article in articles)
                result += article.Pages;
            IEnumerable<List<int>> lists = data.Where(x => x is List<int>).Cast<List<int>>();
            foreach (var list in lists)
                foreach (var item in list)
                    result += item;
            Console.WriteLine(result);
        }

        public static void DictionaryAutor(List<object> data)
        {
            IEnumerable<Article> articles = data.Where(x => x is Article).Cast<Article>();
            IEnumerable<string> authors = articles.Select(x => x.Author).Distinct();
            Dictionary<string, IEnumerable<Article>> authorArticles = new Dictionary<string, IEnumerable<Article>>();
            foreach (var author in authors)
            {
                authorArticles.Add(author, articles.Where(x => x.Author == author));
            }
        }



    }

}
