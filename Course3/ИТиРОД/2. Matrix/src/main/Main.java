package main;

import matrix.*;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args)
    {
        final String folderPath= "matrixes\\";
        final String matrix1Path = folderPath + "matrix1.txt", matrix2Path = folderPath + "matrix2.txt";
        final String arrayResultPath = folderPath + "arrayMatrixResult.txt", linkedResultPath = folderPath + "linkedMatrixResult.dat";

        ArrayListMatrix arrayListMatrix1 = new ArrayListMatrix(), arrayListMatrix2 = new ArrayListMatrix();
        LinkedListMatrix linkedListMatrix1 = new LinkedListMatrix(), linkedListMatrix2 = new LinkedListMatrix();

        Scanner scanner = new Scanner(System.in);
        System.out.print("Откуда брать матрицы?\n1 - Из файлов\n2 - Сгенерировать\nВведите номер: ");
        int choice = scanner.nextInt();
        switch (choice)
        {
            case 1://считываем из файлов
                arrayListMatrix1 = ArrayListMatrix.ReadFromFile(matrix1Path);
                arrayListMatrix2 = ArrayListMatrix.ReadFromFile(matrix2Path);

                linkedListMatrix1 = LinkedListMatrix.ReadFromFile(matrix1Path);
                linkedListMatrix2 = LinkedListMatrix.ReadFromFile(matrix2Path);
                break;
            case 2://заполняем случайными числами
                System.out.print("Ввод первой матрицы\nВведите количество строк: ");
                int rows = scanner.nextInt();
                System.out.print("Введите количество столбцов: ");
                int columns = scanner.nextInt();
                arrayListMatrix1 = new ArrayListMatrix(rows, columns);
                linkedListMatrix1 = new LinkedListMatrix(rows, columns);

                System.out.print("Ввод второй матрицы\nВведите количество строк: ");
                rows = scanner.nextInt();
                System.out.print("Введите количество столбцов: ");
                columns = scanner.nextInt();
                arrayListMatrix2 = new ArrayListMatrix(rows, columns);
                linkedListMatrix2 = new LinkedListMatrix(rows, columns);
                break;
        }
        scanner.close();

        if(arrayListMatrix1.get(0).size() != arrayListMatrix2.size())
        {
            System.out.println("Выполнение умножения невозможно! Матрицы не согласованы");
            return;
        }


        //перемножаем матрицы с ArrayList, узнаем время выполнения и добавляем результирующую матрицу в файл
        System.out.println("Тестируем матрицу с ArrayList");
        PrintMatrix(arrayListMatrix1);
        System.out.println("X");
        PrintMatrix(arrayListMatrix2);
        System.out.println("=");
        long arrayListMatrixTime = System.currentTimeMillis();
        arrayListMatrix1 = arrayListMatrix1.Multiplication(arrayListMatrix2);
        arrayListMatrixTime = System.currentTimeMillis() - arrayListMatrixTime;
        PrintMatrix(arrayListMatrix1);
        arrayListMatrix1.Save(arrayResultPath);

        System.out.println("Тестируем матрицу с LinkedList");
        PrintMatrix(linkedListMatrix1);
        System.out.println("X");
        PrintMatrix(linkedListMatrix2);
        System.out.println("=");
        long linkedListMatrixTime = System.currentTimeMillis();
        linkedListMatrix1 = linkedListMatrix1.Multiplication(linkedListMatrix2);
        linkedListMatrixTime = System.currentTimeMillis() - linkedListMatrixTime;
        linkedListMatrix1.Serialize(linkedResultPath);
        linkedListMatrix1 = linkedListMatrix1.Deserialize(linkedResultPath);
        PrintMatrix(linkedListMatrix1);

        System.out.println(String.format("Умножение матриц с ArrayList длилось %d миллисекунд", arrayListMatrixTime));
        System.out.println(String.format("Умножение матриц с LinkedList длилось %d миллисекунд", linkedListMatrixTime));
    }

    static void PrintMatrix(ArrayListMatrix matrix)
    {
        for(ArrayList<Double> i : matrix)
        {
            System.out.println(i);
        }
    }


    static void PrintMatrix(LinkedListMatrix matrix)
    {
        for(LinkedList<Double> i : matrix)
        {
            System.out.println(i);
        }
    }
}
/*ArrayList это список, реализованный на основе массива, 
 * а LinkedList — это классический связный список, основанный на объектах с ссылками между ними. 
 * Преимущества ArrayList: в возможности доступа к произвольному элементу по индексу за постоянное время (так как это массив)
 * вставка в конец списка в среднем производится за постоянное время. В среднем потому, что при записи элемента, будет создан новый массив 
 * в него будут помещены все элементы из старого массива + новый, добавляемый элемент. 
 * Недостатки ArrayList проявляются при вставке/удалении элемента в середине списка — это взывает перезапись всех элементов размещенных 
 * «правее» в списке на одну позицию влево, кроме того, при удалении элементов размер массива не уменьшается, до явного вызова метода trimToSize().
 * 
 * LinkedList наоборот, за постоянное время может выполнять вставку/удаление элементов в списке 
 * Доступ к произвольному элементу осуществляется за линейное время (но доступ к первому и последнему элементу списка всегда 
 * осуществляется за константное время — ссылки постоянно хранятся на первый и последний, так что добавление элемента в конец 
 * списка вовсе не значит, что придется перебирать весь список в поисках последнего элемента). 
 * В целом же, LinkedList в абсолютных величинах проигрывает ArrayList и по потребляемой памяти и по скорости выполнения операций. 
 * LinkedList предпочтительно применять, когда происходит активная работа (вставка/удаление) с серединой списка или в случаях,
 *  когда необходимо гарантированное время добавления элемента в список.
 * 
 * Сравнение:
 * у меня используются операции получения элемента из списка и добавление в конец
 * Получение: ArrayList- O(1), LinkedList - O(n)
 * Добавление в конец: ArrayList - Чем больше элементов, тем медленнее, LinkedList - O(1)
 * Вывод: при небольших размерах массивов arraylist будет работать быстрее
 * */