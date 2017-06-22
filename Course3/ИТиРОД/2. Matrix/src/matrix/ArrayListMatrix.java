package matrix;

import java.io.*;
import java.util.ArrayList;
import java.util.Objects;
import java.util.Random;

import file.FileWork;

public class ArrayListMatrix extends ArrayList<ArrayList<Double>>
{
    public ArrayListMatrix(){}

    //заполняем матрицу случайными числами
    public ArrayListMatrix(int rows, int columns)
    {
        Random random = new Random();
        ArrayList<Double> forAdd;
        for(int i = 0; i < rows; i++)
        {
            forAdd = new ArrayList<>();
            for(int j = 0; j < columns; j++)
            {
                forAdd.add((double) random.nextInt(100));
            }
            this.add(forAdd);
        }
    }

    public static ArrayListMatrix ReadFromFile(String fileName)
    {
        ArrayListMatrix result = new ArrayListMatrix();
        Reader fileReader = FileWork.OpenRead(fileName);
        char symbol;
        String value = "";
        ArrayList<Double> forAdd;
        while (((symbol = FileWork.Read(fileReader)) != (char)-1) || (!Objects.equals(value, "")))
        {
            if(symbol != '\r' && symbol != '\n' && Character.isDefined(symbol))
            {
                value += symbol;
            }
            else if (symbol == '\n' || !Character.isDefined(symbol))
            {
                forAdd = new ArrayList<>();
                String[] array = value.split(" ");
                for (String anArray : array)
                {
                    forAdd.add(Double.parseDouble(anArray));
                }
                result.add(forAdd);
                value = "";
            }
        }
        FileWork.Close(fileReader);
        return result;
    }


    public static ArrayListMatrix GetZeroMatrix(int rows, int columns)
    {
        ArrayListMatrix result = new ArrayListMatrix();
        ArrayList<Double> forAdd;
        for(int i = 0; i < rows; i++)
        {
            forAdd = new ArrayList<>();
            for(int j = 0; j < columns; j++)
            {
                forAdd.add(0.0);
            }
            result.add(forAdd);
        }
        return result;
    }

    //сохраняем в .txt файл
    public void Save(String fileName)
    {
        //вместо \n используем эту переменную т.к. при записи в файл \n будет игнорироваться(хз почему)
        //и все будет в одну строчку
        String newLine = System.getProperty("line.separator");

        Writer fileWriter = FileWork.OpenWrite(fileName);
        String matrix = "";
        for (ArrayList<Double> row : this)//построчно считываем матрицу
        {
            for(Double value : row) //достаем элементы из строки
            {
                matrix += value + " ";
            }
            matrix = matrix.substring(0, matrix.length() - 1);//обрезаем последний пробел
            matrix += newLine;
        }
        FileWork.Write(fileWriter, matrix);
        FileWork.Close(fileWriter);
    }

    public ArrayListMatrix Multiplication(ArrayListMatrix arrayListMatrix)
    {
        ArrayListMatrix resultMatrix = new ArrayListMatrix();
        Double value;
        ArrayList<Double> resultRow;

        for(int i = 0; i < this.size(); i++)
        {
            resultRow = new ArrayList<>();
            for (int j = 0; j < arrayListMatrix.get(0).size(); j++)
            {
                value = 0.0;
                for(int k = 0; k < this.get(0).size(); k++)
                {
                    value += this.get(i).get(k) * arrayListMatrix.get(k).get(j);
                }
                resultRow.add(value);
            }
            resultMatrix.add(resultRow);
        }
        return resultMatrix;
    }

    @Override
    public String toString()
    {
        String matrixToPrint = "";
        for(ArrayList<Double> i : this)
        {
            matrixToPrint += i + "\n";
        }
        return matrixToPrint;
    }
}