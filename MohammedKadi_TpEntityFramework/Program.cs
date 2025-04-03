using Microsoft.Extensions.DependencyInjection;
using MohammedKadi_TpEntityFramework.Data;
using MohammedKadi_TpEntityFramework.Entities;
using MohammedKadi_TpEntityFramework.Repositories;
using MohammedKadi_TpEntityFramework.Repositories.Interfaces;


var Services = new ServiceCollection();

// IAjout des services
Services.AddScoped<AppDbContext>();
Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Construction du provider
var serviceProvider = Services.BuildServiceProvider();

// Resolution du service
AppDbContext context = serviceProvider.GetRequiredService<AppDbContext>();
IUnitOfWork unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();


// Add new student /////////////////////////////////////
var newStudent = new Student { Id = 7, FirstName = "Lkhakhi", LastName = "Gravenberg", StudentNumber = 12523688 };
unitOfWork.StudentRepository.Add(newStudent);
await unitOfWork.SaveChangesAsync();
Console.WriteLine("Bien Ajouter");



// Get all students
var students = unitOfWork.StudentRepository.GetAll();
PrintStudents(students);




// Get by Id /////////////////////////////////////
var st = unitOfWork.StudentRepository.GetById(7);



// Update /////////////////////////////////////
st.FirstName = "newName";
st.LastName = "Lao";
await unitOfWork.SaveChangesAsync(); // Save changes

var updatedStudent = unitOfWork.StudentRepository.GetById(7);
Console.WriteLine($"Id = {updatedStudent.Id}, FirstName = {updatedStudent.FirstName}, LastName = {updatedStudent.LastName}, Number = {updatedStudent.StudentNumber}");




// Delete /////////////////////////////////////
unitOfWork.StudentRepository.Delete(updatedStudent);
await unitOfWork.SaveChangesAsync(); // Save changes after deletion


students = unitOfWork.StudentRepository.GetAll();
PrintStudents(students);



// test View ///////////////////////////////////////

// script Sql View

//create VIEW MyView_Students AS  
//SELECT 
//    Id,
//    FirstName,
//    LastName,
//    StudentNumber  
//FROM Students s;

var studentsParView = context.StudentsView.ToList();
Console.WriteLine("get student utilisant View ------------");
foreach (var student in studentsParView)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - {student.StudentNumber}");
}


// fonction pour afficher la list des etudiants
static void PrintStudents(IEnumerable<Student> students)
{
    foreach (var student in students)
    {
        Console.WriteLine($"Id = {student.Id}, FirstName = {student.FirstName}, LastName = {student.LastName}, Number = {student.StudentNumber}");
    }
}
