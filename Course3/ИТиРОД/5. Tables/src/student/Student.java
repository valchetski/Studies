package student;

public class Student
{
    //region id
    private int id;

    public void setId(int value)
    {
        if(value > 0)
        {
            id = value;
        }
    }

    public int getId()
    {
        return id;
    }

    //endregion

    //region firstName
    private String firstName;

    public void setFirstName(String value)
    {
        if(value != null && !value.equals(""))
        {
            firstName = value;
        }
    }

    public String getFirstName()
    {
        return firstName;
    }
    //endregion

    //region surName
    private String surName;

    public void setSurName(String value)
    {
        if(value != null && !value.equals(""))
        {
            surName = value;
        }
    }

    public String getSurName()
    {
        return surName;
    }

    //endregion

    //region groupNumber
    private int groupNumber;

    public void setGroupNumber(int value)
    {
        if(value > 0 && value < 999999)
        {
            groupNumber = value;
        }
    }

    public int getGroupNumber()
    {
        return groupNumber;
    }

    //endregion

    //region age
    private int age;

    public void setAge(int value)
    {
        if(value > 0 && value < 120)
        {
            age = value;
        }
    }

    public int getAge()
    {
        return age;
    }

    //endregion

    public Student()
    {

    }

    public Student(String firstName, String surName, int groupNumber, int age)
    {
        this.firstName = firstName;
        this.surName = surName;
        this.groupNumber = groupNumber;
        this.age = age;
    }



    @Override
    public String toString()
    {
        return String.format("ID: %d, Имя: %s, Фамилия: %s, Группа: %d, Возраст: %d", id, firstName, surName, groupNumber, age);
    }
}
