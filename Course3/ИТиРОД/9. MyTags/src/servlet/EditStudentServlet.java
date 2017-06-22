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

public class EditStudentServlet extends HttpServlet
{
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException
    {
        int id = Integer.parseInt(req.getParameter("id"));
        IStudentDAO studentDAO = new StudentDAO();
        Student student = new Student();
        try {
            student = studentDAO.Select(id);
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
        catch (ClassNotFoundException e) {
            e.printStackTrace();
        }

        req.setAttribute("id", student.getId());
        req.setAttribute("firstName", student.getFirstName());
        req.setAttribute("surName", student.getSurName());
        req.setAttribute("groupNumber", student.getGroupNumber());
        req.setAttribute("age", student.getAge());
        req.getRequestDispatcher("edit.jsp").forward(req, resp);
    }

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
            int id = Integer.parseInt(req.getParameter("id"));
            studentDAO.Update(id, new Student(n, p, Integer.parseInt(e), Integer.parseInt(c)));
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
