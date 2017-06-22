package servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import student.IStudentDAO;
import student.Student;
import student.StudentDAO;
import helper.StudentXml;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class ObjectsToXml extends HttpServlet
{
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		try
        {
			IStudentDAO studentDAO = new StudentDAO();
			ArrayList<Student> students = studentDAO.Select("","","","");
			
            PrintWriter out = response.getWriter();
            StudentXml studentXml = new StudentXml();
            out.write(studentXml.writeXML(students));
        }
        catch (Exception e) {
            e.printStackTrace();
        }
	}
}
