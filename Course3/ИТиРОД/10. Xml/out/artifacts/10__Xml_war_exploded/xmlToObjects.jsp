<%--
  Created by IntelliJ IDEA.
  User: Alexander
  Date: 20.04.2015
  Time: 16:57
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title></title>
</head>
<body>
    <form method="POST" action="/xmlToObjects" enctype="multipart/form-data">
        <input type="file" name="file" /><br>
        <input type="submit" value="Convert" />
    </form>
</body>
</html>
