package servlet;

import student.IStudentDAO;
import student.Student;
import student.StudentDAO;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.ArrayList;


public class PrintAllStudentsServlet extends HttpServlet
{
    public void doGet(HttpServletRequest request,
                      HttpServletResponse response)
            throws ServletException, IOException
    {
        try
        {
            IStudentDAO studentDAO = new StudentDAO();
            ArrayList<Student> students = studentDAO.Select("", "", "", "");

            String toPage =
                    "<a href=\"/addStudent\">Create</a>"+
                    "<table>"+
                    "   <tr>"+
                    "       <th>Firstname</td>"+
                    "       <th>Surname</td>"+
                    "       <th>Group</td>"+
                    "       <th>Age</td>"+
                    "   </tr>";
            for (Student student: students)
            {
               toPage +=
                        "<tr>" +
                        "   <td>"+student.getFirstName()+ "</td>"+
                        "   <td>"+student.getSurName()+ "</td>"+
                        "   <td>"+student.getGroupNumber() + "</td>"+
                        "   <td>"+student.getAge()+ "</td>"+
                        "   <td><a href=\"/deleteStudent?id=" + student.getId() + "\">delete</a></td>"+
                        "   <td><a href=\"/editStudent?id=" + student.getId() + "\">edit</a></td>"+
                        "</tr>";
            }
            toPage += "</table>";
            PrintWriter out = response.getWriter();
            out.write(Page.GetPage(toPage));

        }
        catch (SQLException e)
        {

        }
        catch (ClassNotFoundException e)
        {

        }
        finally {

        }

    }

}
