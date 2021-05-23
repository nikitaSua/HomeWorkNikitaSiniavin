using LInqHomeWork.helpClass;
using System;
using System.Collections.Generic;

namespace LInqHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };

            LinqRequests.NumbersFromTenTofifty();
            LinqRequests.NumbersFromTenTofiftymultipleTHree();
            LinqRequests.LibqTenTims();
            LinqRequests.WordsWithLetter("aaa; abb; ccc; dap");
            LinqRequests.WordInString("aaa; abb; ccc; dap");
            LinqRequests.LongestWord("aaa; xabbx; abb; ccc; dap");
            LinqRequests.AverageLength("aaa; xabbx; abb; ccc; dap");
            LinqRequests.ShorstReverse("aaa; xabbx; abb; ccc; dap");
            LinqRequests.IsExistAabb();
            LinqRequests.LastWord();

            LinqRequests.ActorNames(data);
            LinqRequests.NumOfActorsCreatedInAugest(data);
            LinqRequests.TwoOldestActor(data);
            LinqRequests.ArticlePerAuthor(data);
            LinqRequests.DifferentLettersInActorName(data);
            LinqRequests.ArticleOrdered(data);
            LinqRequests.NameActorFilms(data);
            LinqRequests.SumInt(data);
            LinqRequests.DictionaryAutor(data);

        }
    }
}
