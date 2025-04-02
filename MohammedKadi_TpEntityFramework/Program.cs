using Microsoft.Extensions.DependencyInjection;
using MohammedKadi_TpEntityFramework.Data;
using MohammedKadi_TpEntityFramework.Entities;
using MohammedKadi_TpEntityFramework.Repositories;
using MohammedKadi_TpEntityFramework.Repositories.Interfaces;


var Services = new ServiceCollection();

// IAjout des services
Services.AddScoped<AppDbContext>();
Services.AddScoped<IRepository<Student>, Repository<Student>>();
Services.AddScoped<IUnitOfWork<Student>, UnitOfWork<Student>>();


// Construction du provider
var serviceProvider = Services.BuildServiceProvider();

// Resolution du service
IUnitOfWork<Student> unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork<Student>>();



// Add new student /////////////////////////////////////
var newStudent = new Student { Id = 7, FirstName = "Lkhakhi", LastName = "Gravenberg", StudentNumber = 12523688 };
unitOfWork.Repository.Add(newStudent);
await unitOfWork.SaveChangesAsync();
Console.WriteLine("Bien Ajouter");



// Get all students
var students = unitOfWork.Repository.GetAll();
PrintStudents(students);




// Get by Id /////////////////////////////////////
var st = unitOfWork.Repository.GetById(7);



// Update /////////////////////////////////////
st.FirstName = "newName";
st.LastName = "Lao";
await unitOfWork.SaveChangesAsync(); // Save changes

var updatedStudent = unitOfWork.Repository.GetById(7);
Console.WriteLine($"Id = {updatedStudent.Id}, FirstName = {updatedStudent.FirstName}, LastName = {updatedStudent.LastName}, Number = {updatedStudent.StudentNumber}");




// Delete /////////////////////////////////////
unitOfWork.Repository.Delete(updatedStudent);
await unitOfWork.SaveChangesAsync(); // Save changes after deletion


students = unitOfWork.Repository.GetAll();
PrintStudents(students);
  



// fonction pour afficher la list des etudiants
static void PrintStudents(IEnumerable<Student> students)
{
    foreach (var student in students)
    {
        Console.WriteLine($"Id = {student.Id}, FirstName = {student.FirstName}, LastName = {student.LastName}, Number = {student.StudentNumber}");
    }
}
