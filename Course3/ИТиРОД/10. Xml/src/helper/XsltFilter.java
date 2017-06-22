package helper;

import javax.servlet.*;
import javax.servlet.http.HttpServletResponse;
import javax.xml.transform.Source;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.stream.StreamResult;
import javax.xml.transform.stream.StreamSource;
import java.io.IOException;
import java.io.StringReader;
import java.io.StringWriter;

//преобразывает вывод xml файла в нормальный вид(выведет таблицу студентов)
public class XsltFilter implements Filter
{
    private final String XSLT = "<?xml version=\"1.0\"?>\n" +
            "<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">" +
            "<xsl:template match=\"students\">" +
            "  <html>" +
            "<head>" +
            "    <meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n" +
            "</head>" +
            "  <body>" +
            "  <div>" +
            "    <table>" +
            "      <tr>" +
            "        <th>Id</th>" +
            "        <th>FirstName</th>" +
            "        <th>Surname</th>" +
            "        <th>Age</th>" +
            "        <th>GroupNumber</th>" +
            "      </tr>" +
            "      <xsl:for-each select=\"student\">" +
            "        <tr>" +
            "          <td><xsl:value-of select=\"@id\"/></td>" +
            "          <td><xsl:value-of select=\"@firstName\"/></td>" +
            "          <td><xsl:value-of select=\"@surName\"/></td>" +
            "          <td><xsl:value-of select=\"@age\"/></td>" +
            "          <td><xsl:value-of select=\"@groupNumber\"/></td>" +
            "        </tr>" +
            "      </xsl:for-each>" +
            "    </table>" +
            "  </div>" +
            "  </body>" +
            "  </html>" +
            "</xsl:template>" +
            "</xsl:stylesheet>";


    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException
    {
        ResponseWrapper wrapper = new ResponseWrapper((HttpServletResponse) servletResponse);
        filterChain.doFilter(servletRequest, wrapper);

        try
        {
            Source xslt = new StreamSource(new StringReader(XSLT));
            Transformer transformer = TransformerFactory.newInstance().newTransformer(xslt);
            Source text = new StreamSource(new StringReader(wrapper.toString()));
            StringWriter sw = new StringWriter();
            transformer.transform(text, new StreamResult(sw));
            servletResponse.getWriter().print(sw.toString());
        }
        catch (Exception e) {
            throw new ServletException(e);
        }
    }

    @Override
    public void destroy() {

    }

    public void init(FilterConfig fConfig) throws ServletException
    {

    }
}
