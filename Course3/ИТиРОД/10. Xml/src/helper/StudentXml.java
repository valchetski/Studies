package helper;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;
import student.Student;

import javax.xml.parsers.*;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import java.io.IOException;
import java.io.InputStream;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.List;

public class StudentXml
{
    //конвертирует содержимое xml файла в обычный список студентов
    public List<Student> readXML(InputStream stream) throws ParserConfigurationException, SAXException, IOException
    {
        SAXParser parser = SAXParserFactory.newInstance().newSAXParser();
        final List<Student> result = new ArrayList<Student>();

        DefaultHandler handler = new DefaultHandler() {
            @Override
            public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
                if (qName.equals("student")) {
                    Student student = new Student();
                    student.setFirstName(attributes.getValue("firstName"));
                    student.setSurName(attributes.getValue("surName"));
                    student.setAge(Integer.parseInt(attributes.getValue("age")));
                    student.setGroupNumber(Integer.parseInt(attributes.getValue("groupNumber")));
                    result.add(student);
                }
            }
        };

        parser.parse(stream, handler);
        return result;
    }

	//конвертирует список студентов в xml
    public String writeXML(ArrayList<Student> students) throws ParserConfigurationException, TransformerException
    {
        DocumentBuilder d = DocumentBuilderFactory.newInstance().newDocumentBuilder();
        Document document = d.newDocument();
        Element root = document.createElement("students");

        for (Student student: students)
        {
            Element node = document.createElement("student");
            node.setAttribute("id", String.valueOf(student.getId()));
            node.setAttribute("firstName", student.getFirstName());
            node.setAttribute("surName", student.getSurName());
            node.setAttribute("groupNumber", String.valueOf(student.getGroupNumber()));
            node.setAttribute("age", Integer.toString(student.getAge()));
            root.appendChild(node);
        }

        StringWriter writer = new StringWriter();
        StreamResult result = new StreamResult(writer);
        TransformerFactory.newInstance().newTransformer().transform(new DOMSource(root), result);
        return writer.toString();
    }
}
