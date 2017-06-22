package main;

import student.IStudentDAO;
import student.Student;
import student.StudentDAO;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args)
    {
        boolean isExit = false;
        int choice;
        Scanner scanner = new Scanner(System.in);
        IStudentDAO studentDAO = new StudentDAO();
        Student student;
        while (!isExit)
        {
            System.out.print("1 - Добавить\n2 - Удалить\n3 - Обновить\n4 - Вывести всех\n0 - Выход\nВведите номер операции: ");
            choice = scanner.nextInt();
            scanner.nextLine();
            try
            {
                switch (choice)
                {
                    case 1:
                        student = new Student();
                        System.out.print("Введите имя: ");
                        student.setFirstName(scanner.nextLine());
                        System.out.print("Введите фамилию: ");
                        student.setSurName(scanner.nextLine());
                        System.out.print("Введите номер группы: ");
                        student.setGroupNumber(scanner.nextInt());
                        System.out.print("Введите возраст: ");
                        student.setAge(scanner.nextInt());
                        studentDAO.Insert(student);
                        break;
                    case 2:
                        System.out.print("Введите имя(или нажмите Enter): ");
                        String firstName = scanner.nextLine();
                        System.out.print("Введите фамилию(или нажмите Enter): ");
                        String surName = scanner.nextLine();
                        System.out.print("Введите группу(или нажмите Enter): ");
                        String groupNumber = scanner.nextLine();
                        System.out.print("Введите возраст(или нажмите Enter): ");
                        String age = scanner.nextLine();
                        studentDAO.Delete(firstName, surName, groupNumber, age);
                        break;
                    case 3:
                        System.out.print("Введите фамилию: ");
                        surName = scanner.nextLine();
                        Student oldStudent = studentDAO.Select("", surName, "", "").get(0);
                        System.out.print(oldStudent.toString());

                        Student newStudent = new Student();

                        System.out.print("\nВведите имя(или нажмите Enter): ");
                        firstName = scanner.nextLine();
                        newStudent.setFirstName(!firstName.isEmpty() ? firstName : oldStudent.getFirstName());

                        System.out.print("Введите фамилию(или нажмите Enter): ");
                        surName = scanner.nextLine();
                        newStudent.setSurName(!surName.isEmpty() ? surName : oldStudent.getSurName());

                        System.out.print("Введите группу(или нажмите Enter): ");
                        groupNumber = scanner.nextLine();
                        newStudent.setGroupNumber(!groupNumber.isEmpty() ? Integer.parseInt(groupNumber) : oldStudent.getGroupNumber());

                        System.out.print("Введите возраст(или нажмите Enter): ");
                        age = scanner.nextLine();
                        newStudent.setAge(!age.isEmpty() ? Integer.parseInt(age) : oldStudent.getAge());

                        studentDAO.Update(oldStudent.getId(), newStudent);
                        break;
                    case 4:
                        System.out.println("Список студентов");
                        ArrayList<Student> students = studentDAO.Select("", "","", "");
                        for (Student printStudent : students)
                        {
                            System.out.println(printStudent.toString());
                        }
                        break;
                    case 0:
                        isExit = true;
                        break;
                }
            }
            catch (Exception e)
            {
                System.out.println("\nОшибка! " + e.getMessage());
            }
        }
    }
}
