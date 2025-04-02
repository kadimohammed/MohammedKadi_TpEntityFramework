

using MohammedKadi_TpEntityFramework.Data;

AppDbContext context = new AppDbContext();

var students = context.Students.ToList();

foreach (var student in students)
{
    Console.WriteLine($"Id = {student.Id}, FirstName = {student.FirstName}, LastName = {student.LastName},Number = {student.StudentNumber}");
}