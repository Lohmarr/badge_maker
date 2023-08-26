using badge_maker;

List<Employee> employees = Util.GetEmployees();

Util.PrintEmployees(employees);
Util.MakeCSV(employees);
await Util.MakeBadges(employees);