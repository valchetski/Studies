package student;

import java.sql.*;
import java.util.ArrayList;

public class StudentDAO implements IStudentDAO
{
    Connection connection = null;

    private void OpenConnection() throws SQLException, ClassNotFoundException
    {
        try
        {
            //регестируем jdbc драйвер(он позволит получить соединение с базой данных по специально описанному URL)
            //может быть ошибка ClassNotFoundException. для ее исправления нужно:
            //1. Скачать файл mysql-connector-java-x.x.x-bin.jar
            //2. Нажать File->Project Structure->Libraries->нажать на плюс и выбрать этот файл
            Class.forName("com.mysql.jdbc.Driver");

            String url = "jdbc:mysql://localhost/students";
            String name = "root";
            String password = "volander";
            connection = DriverManager.getConnection(url, name, password);
        }
        catch (ClassNotFoundException e)
        {
            throw new ClassNotFoundException("ClassNotFoundException: " + e.getMessage());
        }
        catch (SQLException e)
        {
            throw new SQLException("Проблема при открытии соединения с базой данных");
        }
    }

    private void CloseConnection() throws SQLException
    {
        if (connection != null)
        {
            try
            {
                connection.close();
            }
            catch (SQLException e)
            {
                throw new SQLException("Не получается закрыть соединение с базой данных");
            }
        }
    }

    private void DoStatement(String statement) throws SQLException, ClassNotFoundException
    {
        OpenConnection();
        connection.prepareStatement(statement).executeUpdate();
        CloseConnection();
    }

    @Override
    public void Insert(Student student) throws SQLException, ClassNotFoundException
    {
        String statement = String.format(
                "INSERT INTO students(id, firstName, surName, groupNumber, age) SELECT MAX(id) + 1,\'%s\',\'%s\',%d,%d from students",
                student.getFirstName(), student.getSurName(), student.getGroupNumber(), student.getAge());
        DoStatement(statement);
    }

    @Override
    public boolean Delete(String firstName, String surName, String groupNumber, String age) throws SQLException, ClassNotFoundException
    {
        boolean isThereOneParameter = false;
        String statement = "DELETE FROM students WHERE";
        if(!firstName.isEmpty())
        {
            statement += String.format(" firstName = '%s'", firstName);
            isThereOneParameter = true;
        }
        if(!surName.isEmpty())
        {
            statement += String.format(" %s surName = '%s'", isThereOneParameter ? "AND" : "", surName);
            isThereOneParameter = true;
        }
        if(!groupNumber.isEmpty())
        {
            statement += String.format(" %s groupNumber = %d", isThereOneParameter ? "AND" : "", Integer.parseInt(groupNumber));
            isThereOneParameter = true;
        }
        if(!age.isEmpty())
        {
            statement += String.format(" %s age = %d", isThereOneParameter ? "AND" : "", Integer.parseInt(age));
        }
        DoStatement(statement);
        return true;
    }

    @Override
    public boolean Delete(int id) throws SQLException, ClassNotFoundException
    {
        String statement = "DELETE FROM students WHERE id = " + id;
        DoStatement(statement);
        return true;
    }


    @Override
    public void Update(int id, Student newStudent) throws SQLException, ClassNotFoundException
    {
        String statement = String.format("UPDATE students SET firstName = \'%s\', " +
                "surName = \'%s\', groupNumber = %d, " +
                "age = %d WHERE id = %d", newStudent.getFirstName(), newStudent.getSurName(),
                newStudent.getGroupNumber(), newStudent.getAge(), id);
        DoStatement(statement);
    }

    @Override
    public ArrayList<Student> Select(String firstName, String surName, String groupNumber, String age) throws SQLException, ClassNotFoundException
    {
        OpenConnection();

        String statement = String.format("Select * From students Where firstName LIKE '%%%s%%' AND surName LIKE '%%%s%%'", firstName, surName);
        if(groupNumber != "")
        {
            statement += String.format(" AND groupNumber = %d", Integer.parseInt(groupNumber));
        }
        if(age != "")
        {
            statement += String.format(" AND age = %d", Integer.parseInt(age));
        }
        ResultSet resultSet = connection.createStatement().executeQuery(statement);
        Student student;
        ArrayList<Student> students = new ArrayList<Student>();
        while (resultSet.next())
        {
            student = new Student();
            student.setId(resultSet.getInt("id"));
            student.setFirstName(resultSet.getString("firstName"));
            student.setSurName(resultSet.getString("surName"));
            student.setGroupNumber(resultSet.getInt("groupNumber"));
            student.setAge(resultSet.getInt("age"));
            students.add(student);
        }
        resultSet.close();

        CloseConnection();
        return students;
    }

    @Override
    public Student Select(int id) throws SQLException, ClassNotFoundException {
        OpenConnection();

        String statement = String.format("Select * From students Where id = %d", id);
        ResultSet resultSet = connection.createStatement().executeQuery(statement);

        Student student = new Student();
        resultSet.next();
        student.setId(resultSet.getInt("id"));
        student.setFirstName(resultSet.getString("firstName"));
        student.setSurName(resultSet.getString("surName"));
        student.setGroupNumber(resultSet.getInt("groupNumber"));
        student.setAge(resultSet.getInt("age"));

        resultSet.close();

        CloseConnection();
        return student;
    }
}
