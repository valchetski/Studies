package matrix;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Reader;
import java.util.LinkedList;
import java.util.Objects;
import java.util.Random;

import file.FileWork;

public class LinkedListMatrix extends LinkedList<LinkedList<Double>>
{
    public LinkedListMatrix(){}

    public static LinkedListMatrix ReadFromFile(String fileName)
    {
        LinkedListMatrix result = new LinkedListMatrix();
        Reader fileReader = FileWork.OpenRead(fileName);
        char symbol;
        String value = "";
        LinkedList<Double> forAdd;
        while (((symbol = FileWork.Read(fileReader)) != (char)-1) || (!Objects.equals(value, "")))
        {
            if(symbol != '\r' && symbol != '\n' && Character.isDefined(symbol))
            {
                value += symbol;
            }
            else if (symbol == '\n' || !Character.isDefined(symbol))
            {
                forAdd = new LinkedList<>();
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

    public LinkedListMatrix(int rows, int columns)
    {
        Random random = new Random();
        LinkedList<Double> forAdd;
        for(int i = 0; i < rows; i++)
        {
            forAdd = new LinkedList<>();
            for(int j = 0; j < columns; j++)
            {
                forAdd.add((double) random.nextInt(5));
            }
            this.add(forAdd);
        }
    }

    public static LinkedListMatrix GetZeroMatrix(int rows, int columns)
    {
        LinkedListMatrix result = new LinkedListMatrix();
        LinkedList<Double> forAdd;
        for(int i = 0; i < rows; i++)
        {
            forAdd = new LinkedList<>();
            for(int j = 0; j < columns; j++)
            {
                forAdd.add(0.0);
            }
            result.add(forAdd);
        }
        return result;
    }

    public LinkedListMatrix Multiplication(LinkedListMatrix linkedListMatrix)
    {
        LinkedListMatrix resultMatrix = new LinkedListMatrix();
        Double value;
        LinkedList<Double> resultRow;

        for(int i = 0; i < this.size(); i++)
        {
            resultRow = new LinkedList<>();
            for(int j = 0; j < linkedListMatrix.get(0).size(); j++)
            {
                value = 0.0;
                for(int k = 0; k < this.get(0).size(); k++)
                {
                    value += this.get(i).get(k) * linkedListMatrix.get(k).get(j);
                }
                resultRow.add(value);
            }
            resultMatrix.add(resultRow);
        }
        return resultMatrix;
    }

    public void Serialize(String fileName)
    {
        try(ObjectOutputStream objectOutputStream = new ObjectOutputStream(new FileOutputStream(fileName)))
        {
            objectOutputStream.writeObject(this);
        }
        catch(Exception ignored){  }
    }

    public LinkedListMatrix Deserialize(String fileName)
    {
        try(ObjectInputStream ois = new ObjectInputStream(new FileInputStream(fileName)))
        {
            return (LinkedListMatrix)ois.readObject();
        }
        catch(Exception ex)
        {
            return new LinkedListMatrix();
        }
    }

    @Override
    public String toString()
    {
        String matrixToPrint = "";
        for(LinkedList<Double> i : this)
        {
            matrixToPrint += i + "\n";
        }
        return matrixToPrint;
    }
}