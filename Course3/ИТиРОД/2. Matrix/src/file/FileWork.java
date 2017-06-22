package file;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Reader;
import java.io.Writer;

public class FileWork
{
    public static Reader OpenRead(String fileName)
    {
        try
        {
            return new FileReader(fileName);
        }
        catch (FileNotFoundException e)
        {
            return null;
        }
    }

    public static Writer OpenWrite(String fileName)
    {
        try
        {
            return new FileWriter(fileName, false);
        }
        catch (IOException e)
        {
            return null;
        }
    }

    //читаем символ
    public static char Read(Reader fileReader)
    {
        try
        {
            return (char) fileReader.read();
        }
        catch (IOException e)
        {
            return (char) -1;
        }
    }

    //записываем всю строку
    public static void Write(Writer fileWriter, String matrix)
    {
        try
        {
            fileWriter.write(matrix);
        }
        catch (IOException ignored) {	}
    }

    public static void Close(Reader fileReader)
    {
        try
        {
            fileReader.close();
        }
        catch (IOException e) {}
    }

    public static void Close(Writer fileWriter)
    {
        try
        {
            fileWriter.close();
        }
        catch (IOException e) {}
    }
}
