using System.Security.Cryptography.X509Certificates;

namespace LINQSnippets
{
    public class Snippets
    {
        static public void BasicLINQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            //1- SELECT * of cars
            var carList = from car in cars select car;
            var carList2 = cars;

            foreach ( var car in carList )
            {
                Console.WriteLine(car);
            }

            //2- SELECT WHERE Audi
            var audiList = from car in cars
                           where car.Contains("Audi") select car;
            var audiList2 = cars.Where(x => x.Contains("Audi"));

           
        }
            //3- Number Examples
        static public void LinqNumbers() 
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Each number multipled by 3
            //Take all, but 9
            //Order ascending

            var processedNumberList = numbers.Select(num => num * 3)
                                      .Where(num => num != 9)
                                      .OrderBy(num => num);

            var processedNumberSql = from num in numbers
                                     where num != 9
                                     orderby num ascending
                                     select num * 3;


        }
        static public void SearchExamples()
        {
            var textList = new List<string>()
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "f",
                "c"
            };

            //1- First element
            var fist = textList.First();

            //2- First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //3- First element that contains "j"

            var jText = textList.First(x => x.Contains('j'));

            //4- First element that contains "z" or default

            var firstOrDefaultText = textList.FirstOrDefault(t => t.Contains('z'));

            //4- Last element that contains "z" or default

            var lastOrDefault = textList.LastOrDefault(t => t.Contains("z"));

            //5- Single Values

            var uniqueText = textList.Single();
            var uniqueText2 = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8, 10 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4,8}
            var miEvenNumbers = evenNumbers.Except(otherEvenNumbers);

        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3",
            };

            var myOpinionSelection = myOpinions.SelectMany(x => x.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Diego",
                            Email = "diego@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "Fernando",
                            Email = "fernando@gmail.com",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name = "Mica",
                            Email = "Mica@gmail.com",
                            Salary = 3000
                        }
                    }

                },
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Alejandra",
                            Email = "ale@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "Rodolfo",
                            Email = "rodolfo@gmail.com",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name = "JOrge",
                            Email = "jorge@gmail.com",
                            Salary = 3000
                        }
                    }

                }
             };


            //OBTAIN ALL Employess of all Enterprises
            var employeeList = enterprises.SelectMany(e => e.Employees);

            // Know if ana list is empty
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(e => e.Employees.Any());

            // All enterprises at least  employees white more than 1000E of salary

            bool hasEmployeeWithSalaryMore1000 = enterprises.Any(e => e.Employees.Any(e => e.Salary > 1000));
        }

        static public void LinqCollection()
        {
            var firstList = new List<string>()
            {
                "a","b","c"
            };
            var secondList = new List<string>()
            {
                "a","c","d"
            };

            //INNER JOIN
            var commonResult = from el in firstList
                               join sec in secondList
                               on el equals sec
                               select new {el,sec};

            var commmonResult2 = firstList.Join(secondList,
                                  first=> first,
                                  sec=> sec,
                                  (first, sec) => new {first,sec});

            //OUTER JOIN - LEFT
            var leftOuterJoin = from el in firstList
                                join sec in secondList
                                on el equals sec
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where el != temporalElement
                                select new { el };

            var leftOuterJoin2 = from el in firstList
                                 from sec in secondList.Where(s => s == el).DefaultIfEmpty()
                                 select new {el,sec};

            var rightOuterJoin = from sec in secondList
                                 join el in firstList
                                on sec equals el
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where sec != temporalElement
                                select new { sec };

            //UNION
           // var unionList = leftOuterJoin.Union(rightOuterJoin);
        }
        static public void SkipTakeLinq()
        {
            var miList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            //SKIP - SALTAR
            var skipTwoFirstElement = miList.Skip(2);

            var skipLastTwo = miList.SkipLast(2);

            var skipeWhile = miList.SkipWhile(n => n < 4);

            //TAKE - OBTENER

            var takeFirstTwo = miList.Take(2);

            var takeLastTwo = miList.TakeLast(2);

            var takeWhile = miList.TakeWhile(n => n < 4);
        }



        //Paging with Skip y Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection,int pag,int resultPerPage)
        {
            int startIndex = (pag - 1)* resultPerPage;
            return collection.Skip(startIndex).Take(resultPerPage);
        }

        // Variables

        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 8, 9, 10 };

            var aboutAverage = from n in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(n, 2)
                               where nSquared > average
                               select n;
            foreach (var n in aboutAverage)
            {
                Console.WriteLine("Number: {0} Square: {1}",n,Math.Pow(n,2));
            }
        }
        
        //ZIP

        public static void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            
            
            string[] stringNumbers = { "one", "two", "three","four","five" };
            List<string> stringList = new List<string>();
            

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers,(num,word) => num + "+" + word);
        }

        //REPEAT & RANGE
        public static void RepeatRangeLINQ()
        {
            //Generate collection from 1 - 1000 ==> Range
            var first1000 = Enumerable.Range(0, 1000);

            //Repeat a value N times

            var fiveXs = Enumerable.Repeat("X", 5);
            
        }

        public static void StudentsLinq()
        {
            var classRoom = new[]
            {
                new Student()
                {
                    Id= 1,
                    Name = "Diego",
                    Grade = 90,
                    Certified= true,
                },
                  new Student()
                {
                    Id= 2,
                    Name = "Fernando",
                    Grade = 90,
                    Certified= true,
                },
                     new Student()
                {
                    Id= 3,
                    Name = "Jorge",
                    Grade = 30,
                    Certified= false,

                },
                           new Student()
                {
                    Id= 4,
                    Name = "Mica",
                    Grade = 100,
                    Certified= true,

                },
                                 new Student()
                {
                    Id= 5,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified= false,

                },
            };

            var certifiedStudents = from stu in classRoom
                                    where stu.Certified
                                    select stu;

            var certifiedStudents2 = classRoom.Where(x=> x.Certified).ToList();

            var notCertifiedStudent = from stu in classRoom
                                      where !stu.Certified
                                      select stu;

            var approvedStudentsName = from stu in classRoom
                                   where stu.Grade >= 50 && stu.Certified
                                   select stu.Name;
            var approvedStudentsName2 = classRoom.Where(x => x.Certified && x.Grade >= 50);


        }

        //ALL que todos cumplan
        public static void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10);

            bool allAreBiggerOrEqualThan2 = numbers.All(x => x > 2);

            var emptyList = new List<int>();

            bool allNumberAreGreaterThan0 = numbers.All(x => x >= 0);
        }
        //AGGREGATE

        public static void AggregateQueries()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Sum all numbers

            int sum = numbers.Aggregate((pre, curr) => pre + curr);

            string[] words = { "hello", "my", "name","is","Diego" };
            string greeting = words.Aggregate((pre, curr) => pre + curr);
        }
        //DISTINCT
        public static void DistintValues()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
            var distintcValues = numbers.Distinct();
        }
        //GROUPBY

        public static void GroupBY()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Obtain only even numbers and generate two groups

            var grouped = numbers.GroupBy(x => x % 2 == 0);

            var classRoom = new[]
            {
                new Student()
                {
                    Id= 1,
                    Name = "Diego",
                    Grade = 90,
                    Certified= true,
                },
                  new Student()
                {
                    Id= 2,
                    Name = "Fernando",
                    Grade = 90,
                    Certified= true,
                },
                     new Student()
                {
                    Id= 3,
                    Name = "Jorge",
                    Grade = 30,
                    Certified= false,

                },
                           new Student()
                {
                    Id= 4,
                    Name = "Mica",
                    Grade = 100,
                    Certified= true,

                },
                                 new Student()
                {
                    Id= 5,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified= false,

                },
            };

            var certifiedQuery = classRoom.GroupBy(x => x.Certified);



        }

        public static void RelationLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id= 1,
                    Title="Mi first post",
                    Content= "My First content",
                    Comments= new List<Comment>
                    {
                        new Comment()
                        {
                            Id= 1,
                            Title="My first comment",
                            Content="my content"
                        },
                        new Comment()
                        {
                            Id= 2,
                            Title="My second comment",
                            Content="my other content"
                        },
                        new Comment()
                        {
                            Id= 3,
                            Title="My third comment",
                            Content="my content"
                        }
                    }
                },
                 new Post()
                {
                    Id= 2,
                    Title="Mi second post",
                    Content= "My second content",
                    Comments= new List<Comment>
                    {
                        new Comment()
                        {
                            Id= 4,
                            Title="My other comment",
                            Content="my content"
                        },
                        new Comment()
                        {
                            Id= 5,
                            Title="My five comment",
                            Content="my other content"
                        },
                        new Comment()
                        {
                            Id= 6,
                            Title="My third comment",
                            Content="my new content"
                        }
                    }
                }
            };



        var commentContent = posts.SelectMany
                (p => p.Comments,
                (post,comment)=> new {post.Id,comment.Content});


        }

     }
}