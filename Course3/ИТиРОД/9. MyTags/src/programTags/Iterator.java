package programTags;

import student.Student;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;
import java.util.ArrayList;


public class Iterator extends SimpleTagSupport
{
    private java.util.Iterator iterator;

    public String var;
    public void setVar(String var) {
        this.var = var;
    }

    public ArrayList<Student> group;
    public void setGroup(ArrayList<Student> group) {
        this.group = group;
        if(group.size() > 0)
            iterator = group.iterator();
    }

    public void doTag() throws JspException, IOException {
        if (iterator == null)
            return;
        while (iterator.hasNext())
        {
            getJspContext().setAttribute(var, iterator.next());
            getJspBody().invoke(null);
        }
    }


}
