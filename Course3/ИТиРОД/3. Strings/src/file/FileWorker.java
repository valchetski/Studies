package file;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;

public class FileWorker
{
    private static int symbolsCount;

    public static HashMap<Character, Integer> GetStatisticInHashMap(String fileName)
    {
        symbolsCount = 0;
        HashMap<Character, Integer> characterUsage = new HashMap<Character, Integer>();
        FileInputStream fileInputStream = OpenFile(fileName);
        if(fileInputStream != null)
        {
            char symbol;
            while ((symbol = ReadChar(fileInputStream)) != (char)-1)
            {
                if(symbol != '\r' && symbol != '\n' && symbol != '\t' && symbol != ' ')
                {
                    if(characterUsage.containsKey(symbol))
                    {
                        characterUsage.put(symbol, characterUsage.get(symbol) + 1);
                    }
                    else
                    {
                        characterUsage.put(symbol, 1);
                    }
                    symbolsCount++;
                }
            }
        }
        CloseFile(fileInputStream);
        return characterUsage;
    }


    public static String GetStatistic(String fileName)
    {
        HashMap<Character, Integer> characterUsage = GetStatisticInHashMap(fileName);
        return GetStatisticMessage(characterUsage);
    }

    private static String GetStatisticMessage(HashMap<Character, Integer> charactersUsage)
    {
        ArrayList<Character> keys = new ArrayList<Character>(charactersUsage.keySet());
        Collections.sort(keys);
        String message = "";
        int count;
        for (Character character : keys)
        {
            count = charactersUsage.get(character);
            message += String.format("\"%c\" - %.3f%% (%d)\n", character, (float) (count * 100)/ symbolsCount, count);
        }
        message += String.format("Уникальных символов: %d\n", keys.size());
        message += String.format("Всего символов: %d", symbolsCount);
        return message;
    }

    private static FileInputStream OpenFile(String fileName)
    {
        FileInputStream fileInputStream; //открываем файл для чтения
        try
        {
            fileInputStream = new FileInputStream(fileName);
        }
        catch (FileNotFoundException e)
        {
            fileInputStream = null;
        }
        return fileInputStream;
    }

    //считываем один символ
    private static char ReadChar(FileInputStream fileInputStream)
    {
        try
        {
            return (char) fileInputStream.read();
        }
        catch (IOException e)
        {
            return (char) -1;
        }
    }

    private static void CloseFile(FileInputStream fileInputStream)
    {
        try
        {
            fileInputStream.close();
        }
        catch (IOException ignored) {	}
    }
}