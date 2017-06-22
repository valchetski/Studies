package servlet;

import helper.StudentXml;
import student.IStudentDAO;
import student.Student;
import student.StudentDAO;
import javax.servlet.ServletException;
import javax.servlet.annotation.MultipartConfig;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.Part;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

@MultipartConfig
public class XmlToObjects extends HttpServlet
{
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
		try
        {
			Part filePart = request.getPart("file");
            InputStream stream = filePart.getInputStream();

            List<Student> students = new StudentXml().readXML(stream);
            IStudentDAO studentDAO = new StudentDAO();

            for (Student student: students)
            {
            	studentDAO.Insert(student);
            }
            response.sendRedirect("/");

        }
        catch (Exception e)
        {
            throw new ServletException(e);
        }
	}

}
