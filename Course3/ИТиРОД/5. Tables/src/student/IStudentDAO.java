package student;

import java.sql.SQLException;
import java.util.ArrayList;

public interface IStudentDAO
{
    public void Insert(Student student) throws SQLException, ClassNotFoundException;
    public boolean Delete(String firstName, String surName, String groupNumber, String age) throws SQLException, ClassNotFoundException;
    public boolean Delete(int id) throws SQLException, ClassNotFoundException;
    public void Update(int id, Student newStudent) throws SQLException, ClassNotFoundException;
    public ArrayList<Student> Select(String firstName, String surName, String groupNumber, String age) throws SQLException, ClassNotFoundException;
    public Student Select(int id) throws SQLException, ClassNotFoundException;
}
