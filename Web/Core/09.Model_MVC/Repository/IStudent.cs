using WebMVC_Model1.Models;

namespace WebMVC_Model1.Repository
{
    public interface IStudent
    {
        List<StudentModel> getAllStudents();
        StudentModel getStudentById(int id);

    }
}
