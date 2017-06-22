package programTags;

import student.Student;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;

public class ToCorrectForm extends SimpleTagSupport
{
    public Student student;
    public void setStudent(Student student)
    {
        this.student = student;
    }

    @Override
    public void doTag() throws JspException, IOException
    {
        try
        {
            student.setFirstName(madeCorrect(student.getFirstName()));
            student.setSurName(madeCorrect(student.getSurName()));
            getJspContext().setAttribute("student", student);
        }
        catch (Exception ignored) {

        }
    }

    private String madeCorrect(String correctable)
    {
        if(correctable.length() > 0)
        {
            String s = correctable.substring(0, 1).toUpperCase();
            correctable = s.concat(correctable.substring(1, correctable.length()));
        }
        return correctable;
    }

}
