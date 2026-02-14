namespace LinqPractical
{

    public class LinqQuery
    {
        public static void Run()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var names = new List<string> { "Ram", "Shyam", "Mohan", "Sita" };

            var employees = new List<Employee> {
        new Employee { Id = 1, Name = "Ram", Dept = "IT", Salary = 50000 },
        new Employee { Id = 2, Name = "Shyam", Dept = "HR", Salary = 40000 },
        new Employee { Id = 3, Name = "Mohan", Dept = "IT", Salary = 60000 },
      };

            var projects = new List<Project> {
        new Project { EmpId = 1, ProjectName = "Banking App" },
        new Project { EmpId = 2, ProjectName = "HR Portal" }
      };
            Console.WriteLine("---- WHERE ----");
            var even = numbers.Where(x => x % 2 == 0);
            Console.WriteLine(string.Join(",", even));

            Console.WriteLine("\n---- SELECT ----");
            var empNames = employees.Select(e => e.Name);
            Console.WriteLine(string.Join(",", empNames));

            Console.WriteLine("\n---- SKIP / TAKE ----");
            Console.WriteLine("Skip: " + string.Join(",", numbers.Skip(2)));
            Console.WriteLine("Take: " + string.Join(",", numbers.Take(3)));

            Console.WriteLine("\n---- ANY / ALL / CONTAINS ----");
            Console.WriteLine(numbers.Any(x => x > 5));
            Console.WriteLine(numbers.All(x => x > 0));
            Console.WriteLine(numbers.Contains(3));

            Console.WriteLine("\n---- APPEND / PREPEND ----");
            Console.WriteLine(string.Join(",", numbers.Append(7)));
            Console.WriteLine(string.Join(",", numbers.Prepend(0)));

            Console.WriteLine("\n---- AGGREGATES ----");
            Console.WriteLine("Count: " + numbers.Count());
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Average: " + numbers.Average());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("Min: " + numbers.Min());

            Console.WriteLine("\nMax Salary Employee:");
            var maxSalaryEmp = employees.MaxBy(e => e.Salary);
            Console.WriteLine(maxSalaryEmp.Name + " - " + maxSalaryEmp.Salary);

            Console.WriteLine("\n---- FIRST / LAST ----");
            Console.WriteLine(numbers.First());
            Console.WriteLine(numbers.Last());

            Console.WriteLine("\n---- ElementAt ----");
            var element = numbers.ElementAt(2);
            Console.WriteLine("element", +element);

            Console.WriteLine("\n---- Join ----");

            var depts = new List<Department> { new Department { Name = "IT" },
                                         new Department { Name = "HR" } };

            var join =
                employees.Join(depts,
                               emp => emp.Dept,    // employee dept
                               dept => dept.Name,  // department name
                               (emp, dept) => new {
                                   EmployeeName = emp.Name,
                                   DepartmentName = dept.Name
                               });

            // print
            foreach (var item in join)
            {
                Console.WriteLine($"{item.EmployeeName} - {item.DepartmentName}");
            }

            Console.WriteLine("\n---- GroupJoin ----");

            var groupJoin = depts.GroupJoin(
                employees, dept => dept.Name, emp => emp.Dept,
                (dept, emps) => new { DepartmentName = dept.Name, Employees = emps });

            // print
            foreach (var group in groupJoin)
            {
                Console.WriteLine($"Department: {group.DepartmentName}");

                foreach (var emp in group.Employees)
                {
                    Console.WriteLine("  " + emp.Name);
                }
            }

            Console.WriteLine("\n---- DISTINCT ----");
            Console.WriteLine(string.Join(",", numbers.Distinct()));

            Console.WriteLine("\n---- UNION ----");
            var a = new[] { 1, 2, 3 };
            var b = new[] { 3, 4, 5 };
            Console.WriteLine(string.Join(",", a.Union(b)));

            Console.WriteLine("\n---- GROUP BY (Dept) ----");
            var groupBy = employees.GroupBy(e => e.Dept);
            foreach (var group in groupBy)
            {
                Console.WriteLine("Dept: " + group.Key);
                foreach (var emp in group)
                {
                    Console.WriteLine("  " + emp.Name);
                }
            }

            Console.WriteLine("\n---- ORDER BY SALARY ----");
            var orderBySalary = employees.OrderBy(e => e.Salary);
            foreach (var emp in orderBySalary)
            {
                Console.WriteLine(emp.Name + " - " + emp.Salary);
            }

            Console.WriteLine("\n---- ZIP ----");
            var zip = numbers.Zip(names, (n, name) => $"{n}-{name}");
            Console.WriteLine(string.Join(",", zip));

            Console.WriteLine("\n---- CHUNK ----");
            var chunks = numbers.Chunk(2);
            foreach (var chunk in chunks)
            {
                Console.WriteLine(string.Join(",", chunk));
            }

            Console.WriteLine("\n---- PLINQ ----");
            var parallel = numbers.AsParallel().Where(x => x > 3);
            Console.WriteLine(string.Join(",", parallel));

            Console.WriteLine("\n---- left Join ----");
            var leftJoin =
                from emp in employees
                join dept in depts on emp.Dept equals
                    dept.Name into deptGroup
                from dept in deptGroup.DefaultIfEmpty()
                select new
                {
                    EmployeeName = emp.Name,
                    DepartmentName = dept?.Name ?? "No Dept"
                };

            foreach (var item in leftJoin)
            {
                Console.WriteLine($"{item.EmployeeName} - {item.DepartmentName}");
            }

            Console.WriteLine("\n---- Multiple Table Join ----");

            var result = employees
                             .Join(depts, emp => emp.Dept, dept => dept.Name,
                                   (emp, dept) => new { emp, dept })
                             .Join(projects, ed => ed.emp.Id, proj => proj.EmpId,
                                   (ed, proj) => new {
                                       Employee = ed.emp.Name,
                                       Department = ed.dept.Name,
                                       Project = proj.ProjectName
                                   });

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"{item.Employee} - {item.Department} - {item.Project}");
            }
        }
    }

}

public class Employee
{
    public int Id;
    public string Name;
    public string Dept;
    public int Salary;
}

public class Department
{
    public string Name;
}
public class Project
{
    public int EmpId;
    public string ProjectName;
}