<%@ tag %>
<%@ attribute name="students" required="true" type="java.util.ArrayList<student.Student>" rtexprvalue="true" %>
<%@ taglib tagdir="/WEB-INF/tags" prefix="myTag" %>


<%@ taglib uri="/WEB-INF/programTags/Iterator.tld" prefix="iter"%>
<%@ taglib uri="/WEB-INF/programTags/ToCorrectForm.tld" prefix="corout"%>

<table>
    <tr>
        <th>Firstname</th>
        <th>Surname</th>
        <th>Group</th>
        <th>Age</th>
    </tr>

    <iter:iterator var="student"  group="<%=students%>">
        <corout:toCorrectForm student="${student}"/>
        <myTag:RenderStudent student="${student}"/>
    </iter:iterator>
</table>