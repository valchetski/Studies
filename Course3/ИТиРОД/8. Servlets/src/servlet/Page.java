package servlet;

public class Page
{
    public static String GetPage(String value)
    {
        return  "<html>"+
                "<head>"+
                "   <title>Students</title>"+
                "</head>"+
                "<body>"+
                    value+
                "</body>"+
                "</html>";
    }

    public static String GetInput(String name, String value)
    {
        return String.format("<input type=\"text\" name=\"%s\" value=\"%s\"/><br/><br/>", name, value);
    }
}
