<%@ page import="student.StudentDAO" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="student.Student" %>
<%@ page import="java.sql.SQLException" %>

<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib tagdir="/WEB-INF/tags" prefix="myTag" %>

<%
    StudentDAO studentDAO = new StudentDAO();
    ArrayList<Student> myStudents = null;
    try {
        myStudents = studentDAO.Select("", "", "", "");
    } catch (SQLException e) {
        e.printStackTrace();
    } catch (ClassNotFoundException e) {
        e.printStackTrace();
    }
%>
<html>
  <head>
    <title></title>
  </head>
  <body>
    <a href="/create.jsp">Create</a>
    <myTag:AllStudents students="<%=myStudents%>"/>
  </body>
</html>
