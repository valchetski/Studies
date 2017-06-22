package servlet;

import student.IStudentDAO;
import student.Student;
import student.StudentDAO;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.SQLException;

public class AddStudentServlet extends HttpServlet
{
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException
    {
        String n=req.getParameter("firstName");
        String p=req.getParameter("surName");
        String e=req.getParameter("groupNumber");
        String c=req.getParameter("age");

        IStudentDAO studentDAO = new StudentDAO();
        try
        {
            studentDAO.Insert(new Student(n, p, Integer.parseInt(e), Integer.parseInt(c)));
        }
        catch (SQLException e1) {
            e1.printStackTrace();
        }
        catch (ClassNotFoundException e1) {
            e1.printStackTrace();
        }

        resp.sendRedirect("/");
    }
}
