<%@ tag %>
<%@ attribute name="student" required="true" type="student.Student" rtexprvalue="true" %>

<tr>
    <td><%=student.getFirstName()%></td>
    <td><%=student.getSurName()%></td>
    <td><%=student.getGroupNumber()%></td>
    <td><%=student.getAge()%></td>
    <td><a href="/deleteStudent?id=<%=student.getId()%>">delete</a></td>
    <td><a href="/editStudent?id=<%=student.getId()%>">edit</a></td>
</tr>