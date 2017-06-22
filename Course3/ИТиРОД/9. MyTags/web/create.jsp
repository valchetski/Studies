<%--
  Created by IntelliJ IDEA.
  User: Alexander
  Date: 19.04.2015
  Time: 18:06
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib tagdir="/WEB-INF/tags" prefix="myTag" %>
<html>
<head>
    <title></title>
</head>
<body>
    <a href="/index.jsp">Back</a>
    <form action="/addStudent" method="post">
        Firstname:<myTag:TextBox name="firstName" value=""/>
        Surname:<myTag:TextBox name="surName" value=""/>
        Group:<myTag:TextBox name="groupNumber" value=""/>
        Age:<myTag:TextBox name="age" value=""/>
        <myTag:SubmitButton value="Create"/>
    </form>
</body>
</html>
