package main;

import file.FileWorker;

public class Main
{
    public static void main(String[] args)
    {
        String fileName = "file.txt";
        System.out.printf("Статистика использования символов в файле %s\n", fileName);
        System.out.println(FileWorker.GetStatistic(fileName));
    }
}
