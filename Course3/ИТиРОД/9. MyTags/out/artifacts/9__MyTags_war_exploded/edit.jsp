<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib tagdir="/WEB-INF/tags" prefix="myTag" %>

<html>
<head>
    <title></title>
</head>
<body>
    <a href="/index.jsp">Back</a>
    <form action="/editStudent" method="post">
        <myTag:Hidden name="id" value="${id}"/>
        Firstname:<myTag:TextBox name="firstName" value="${firstName}"/>
        Surname:<myTag:TextBox name="surName" value="${surName}"/>
        Group:<myTag:TextBox name="groupNumber" value="${groupNumber}"/>
        Age:<myTag:TextBox name="age" value="${age}"/>
        <myTag:SubmitButton value="Edit"/>
    </form>
</body>
</html>
