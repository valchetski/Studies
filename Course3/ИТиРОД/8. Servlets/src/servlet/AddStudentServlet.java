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

public class AddStudentServlet extends HttpServlet
{
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException
    {
       String toPage =
                "<a href=\"/\">Back</a>"+
                "<form method=\"post\">" +
                "   Firstname:" + Page.GetInput("firstName", "")+
                "   Surname:" + Page.GetInput("surName", "") +
                "   Group:" + Page.GetInput("groupNumber", "") +
                "   Age:" + Page.GetInput("age", "") +
                "   <input type=\"submit\" value=\"Create\"/>" +
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
