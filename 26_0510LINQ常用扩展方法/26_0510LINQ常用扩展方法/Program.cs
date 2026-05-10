using System.Collections;

namespace _26_0510LINQ常用扩展方法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1, Name = "jerry", Age = 28, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "jim", Age = 33, Gender = true, Salary = 3000 });
            list.Add(new Employee { Id = 3, Name = "lily", Age = 35, Gender = false, Salary = 9000 });
            list.Add(new Employee { Id = 4, Name = "lucy", Age = 16, Gender = false, Salary = 2000 });
            list.Add(new Employee { Id = 5, Name = "kimi", Age = 25, Gender = true, Salary = 1000 });
            list.Add(new Employee { Id = 6, Name = "nancy", Age = 35, Gender = false, Salary = 8000 });
            list.Add(new Employee { Id = 7, Name = "zack", Age = 35, Gender = true, Salary = 8500 });
            list.Add(new Employee { Id = 8, Name = "jack", Age = 33, Gender = true, Salary = 8000 });


            /*Employee e1 =  list.Where(r=>r.Name == "a").SingleOrDefault();
             Console.WriteLine(e1==null);
             Console.ReadLine();*/

            /*IEnumerable<Employee> list1 = list.OrderBy(r => r.Age).ThenByDescending(r=>r.Salary);
            foreach(Employee e in list1)
            {
                Console.WriteLine(e);
            }*/

            //var items =list.Skip(1).Take(10).ToList();
            //foreach (Employee e in items)
            //{
            //    Console.WriteLine(e);
            //}

            //IEnumerable<IGrouping<int,Employee>> listgroup = list.GroupBy(r=>r.Age);
            //foreach(IGrouping<int,Employee> group in listgroup)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach(Employee item in group)
            //    {
            //        Console.WriteLine(item);

            //    }
            //    Console.WriteLine("------------------------------------------------------");

            //}

            //投影集合
            //IEnumerable<Dog> select1 = list.Select(x => new Dog{ NickName=x.Name, Age=x.Age });
            //foreach (var item in select1)
            //{
            //    Console.WriteLine(item);
            //}

            //var select2 = list.Select(x => new { x.Name, x.Age });
            //foreach(var item in select2)
            //{
            //    Console.WriteLine(item);    
            //}

            IEnumerable<IGrouping<int, Employee>> listgroup = list.GroupBy(r => r.Age);
            var i1 = listgroup.Select(r => new
            {
                age=r.Key,
                maxs=r.Max(x => x.Salary)
            }).OrderBy(r=>r.age);
            foreach( var i in i1)
            {
                Console.WriteLine(i.age);
                Console.WriteLine(i.maxs);
                Console.WriteLine("-----------------------------------------");
            }


        }
    }
}
