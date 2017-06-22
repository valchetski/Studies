package helper;

import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpServletResponseWrapper;
import java.io.CharArrayWriter;
import java.io.PrintWriter;

//используется для вывода информации на html страницу
public class ResponseWrapper extends HttpServletResponseWrapper
{
    private CharArrayWriter output;

    public ResponseWrapper(HttpServletResponse response)
    {
        super(response);
        this.output = new CharArrayWriter();
    }

    public String toString()
    {
        return output.toString();
    }

    public PrintWriter getWriter()
    {
        return new PrintWriter(output);
    }
}
