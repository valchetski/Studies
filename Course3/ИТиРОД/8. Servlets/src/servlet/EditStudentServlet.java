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
        String toPage =
                "<a href=\"/\">Back</a>"+
                        "<form method=\"post\">" +
                        "   <input type=\"hidden\" name=\"id\" value=\"" + student.getId() +"\"/>" +
                        "   Firstname:" + Page.GetInput("firstName",student.getFirstName() )+
                        "   Surname:" + Page.GetInput("surName", student.getSurName()) +
                        "   Group:" + Page.GetInput("groupNumber", String.valueOf(student.getGroupNumber())) +
                        "   Age:" + Page.GetInput("age", String.valueOf(student.getAge())) +
                        "   <input type=\"submit\" value=\"Edit\"/>" +
                        "</form>  ";
        PrintWriter out = resp.getWriter();
        out.write(Page.GetPage(toPage));
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
