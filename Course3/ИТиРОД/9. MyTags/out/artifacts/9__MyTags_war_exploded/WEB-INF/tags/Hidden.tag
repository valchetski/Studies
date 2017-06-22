<%@ tag %>
<%@ attribute name="name" required="true" type="java.lang.String"%>
<%@ attribute name="value" required="true" type="java.lang.String"%>

<input type="hidden" name=<%=name%> value="<%=value%>"/>
