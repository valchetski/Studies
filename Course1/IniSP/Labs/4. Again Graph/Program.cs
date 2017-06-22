using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Again_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph_top = new Graph_top();
            var graph_edge = new Graph_edge();
            while (true)
            {
                Console.WriteLine("Выберите граф для работы:\n1 - Граф с числовой информацией в вершинах\n2 - Граф с числовой информацией на рёбрах\n0 - Выход");
                int choice;
                while (!Int32.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
                Console.Clear();
                bool Exit = true;
                switch (choice)
                {
                    case 1://граф с числовой информацией в вершинах
                        while (Exit)
                        {
                            Console.Write("\tГраф с числовой информацией в вершинах\n1 - Ввод графа\n2 - Добавить вершину\n3 - Добавить ребро\n4 - Удалить вершину\n5 - Удалить ребро\n6 - Вывести информацию о вершинах\n7 - Вывести матрицу смежности\n8 - Очистка графа\n9 - Тест\n10 - Назад\n0 - Выход\nВведите номер операции:");
                            int instruction;
                            while (!Int32.TryParse(Console.ReadLine(), out instruction) || instruction < 0 || instruction > 10)
                                Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
                            switch (instruction)
                            {
                                case 1://ввод графа
                                    graph_top.input();
                                    break;
                                case 2://добавление вершины и  инфорации
                                    graph_top.add_top();
                                    Console.WriteLine("Вершина успешно добавлена!");
                                    break;
                                case 3://добавление ребра
                                    graph_top.add_edge();
                                    Console.WriteLine("Ребро успешно добавлено!");
                                    break;
                                case 4://удаление вершины
                                    graph_top.del_top();
                                    Console.WriteLine("Вершина успешно удалена!");
                                    break;
                                case 5://удаление ребра
                                    graph_top.del_edge();
                                    Console.WriteLine("Ребро успешно удалено!");
                                    break;
                                case 6://просмотр информации о вершинах
                                    graph_top.watch1();
                                    break;
                                case 7://выводит матрицу смежности
                                    graph_top.write_matrix();
                                    break;
                                case 8://очистка графа
                                    graph_top.clear();
                                    Console.WriteLine("Граф успешно очищен!");
                                    break;
                                case 9:
                                    graph_top.test();
                                    break;
                                case 10://вернуться к выбору графа
                                    Console.Clear();
                                    Exit = false;
                                    break;
                                case 0:
                                    return;
                            }
                        }
                        break;
                    case 2://Граф с числовой информацией в ребрах
                        while (true)
                        {
                            Console.Write("\tГраф с числовой информацией в ребрах\n1 - Ввод графа\n2 - Добавить вершину\n3 - Добавить ребро\n4 - Удалить вершину\n5 - Удалить ребро\n6 - Вывести матрицу смежности\n7 - Очистка графа\n8 - Тест\n9 - Назад\n0 - Выход\nВведите номер операции:");
                            int instruction;
                            while (!Int32.TryParse(Console.ReadLine(), out instruction) || instruction < 0 || instruction > 9)
                                Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
                            switch (instruction)
                            {
                                case 1://ввод графа
                                    graph_edge.input();
                                    break;
                                case 2://добавление вершины 
                                    graph_edge.add_top();
                                    Console.WriteLine("Вершина успешно добавлена!");
                                    break;
                                case 3://добавление ребра и информации
                                    graph_edge.add_edge();
                                    Console.WriteLine("Ребро успешно добавлено!");
                                    break;
                                case 4://удаление вершины
                                    graph_edge.del_top();
                                    Console.WriteLine("Вершина успешно удалена!");
                                    break;
                                case 5://удаление ребра
                                    graph_edge.del_edge();
                                    Console.WriteLine("Ребро успешно удалено!");
                                    break;
                                case 6://вывод матрицы смежности
                                    graph_edge.write_matrix();
                                    break;
                                case 7://очистка графа
                                    graph_edge.clear();
                                    Console.WriteLine("Граф успешно очищен!");
                                    break;
                                case 8://тест
                                    graph_edge.test();
                                    break;
                                case 9://вернуться к выбору графа
                                    Console.Clear();
                                    Exit = false;
                                    break;
                                case 0://выход
                                    return;
                            }
                        }
                    case 0:
                        return;
                }
            }
        }
    }

    class Common//общие элементы графов
    {
        public int number;
        public int[,] matrix = new int[100, 100];
        public int value;

        public void input()
        {
            clear();
            Console.Write("Введите количество вершин: ");
            int top;
            while (!Int32.TryParse(Console.ReadLine(), out top) || top < 1)
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
            for (int i = 0; i < top; i++)
                add_top();
            Console.Write("Вершина(ы) успешно добавлена(ы)!\nВведите количество ребер: ");
            int edge;
            while (!Int32.TryParse(Console.ReadLine(), out edge))
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
            for (int i = 0; i < edge; i++)
                add_edge();
            Console.WriteLine("Ребро(а) успешно добавлено(ы)!");
        }

        public void clear()//очистка матрицы смежности
        {
            number = 0;
            Array.Clear(matrix, 0, 10000);//всем элементам матрицы присваевается значение 0
            for (int i = 0; i < 100; i++)
            {
                matrix[0, i] = i;
                matrix[i, 0] = i;
            }
        }

        public virtual void add_top()//добавление вершины
        {
            number++;
        }

        public virtual void add_edge()//добавление ребра
        {
            while (true)
            {
                Console.Write("Введите первую вершину ребра: ");
                int top1 = int.Parse(Console.ReadLine());
                Console.Write("Введите вторую вершину ребра: ");
                int top2 = int.Parse(Console.ReadLine());
                if (top1 > number || top2 > number)
                    Console.WriteLine("Некорректный ввод либо такой вершины не существует! Повторите еще раз!");
                else if (matrix[top1, top2] != 0)
                    Console.WriteLine("Ребро было добавлено раньше! Повторите еще раз!");
                else
                {
                    matrix[top1, top2] = value;
                    matrix[top2, top1] = value;
                    break;
                }
            }
        }

        public virtual int del_top()//удаление вершины
        {
            Console.Write("Введите номер вершины, которую хотите удалить: ");
            int top = int.Parse(Console.ReadLine());
            while (top > number)
            {
                Console.WriteLine("Такой вершины не существует! Повторите ввод!");
                top = int.Parse(Console.ReadLine());
            }
            number--;
            for (int j = 1; j < number + 1; j++)
                for (int i = 1; i < number + 1; i++)
                    if (i >= top)
                        if (j >= top)
                            matrix[i, j] = matrix[i + 1, j + 1];
                        else
                            matrix[i, j] = matrix[i + 1, j];
                    else
                        if (j >= top)
                            matrix[i, j] = matrix[i, j + 1];
                        else
                            matrix[i, j] = matrix[i, j];
            for (int i = 1; i <= number; i++)
            {
                matrix[top, i] = 0;
                matrix[i, top] = 0;
            }
            return top;
        }

        public void del_edge()//удаляет ребро
        {
            while (true)
            {
                Console.Write("Удаление ребра\nВведите первую вершину: ");
                int top1 = int.Parse(Console.ReadLine());
                Console.Write("Введите вторую вершину: ");
                int top2 = int.Parse(Console.ReadLine());
                if (top1 > number || top2 > number)
                    Console.WriteLine("Таких(ой) вершин(ы) не существует! Повторите ввод!");
                else if (matrix[top1, top2] == 0)
                    Console.WriteLine("Такое ребро не существует! Повторите ввод!");
                else
                {
                    matrix[top1, top2] = 0;
                    matrix[top2, top1] = 0;
                    break;
                }
            }
        }

        public virtual void write_matrix()//вывод матрицы смежности
        {
            Console.WriteLine("Матрица смежности:");
            for (int i = 0; i <= number; i++)
            {
                for (int j = 0; j <= number; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.Write("\n");
            }
        }

        public virtual void test()
        {
            input();
            write_matrix();
            del_edge();
            del_top();
            write_matrix();
        }
    }

    class Graph_top : Common//числовая информация в вершинах графа
    {
        public int[] value_top = new int[100];//значения, хранящиеся в вершинах

        public override void add_edge()//добавление ребра
        {
            base.value = 1;
            base.add_edge();
        }

        public override void add_top()//добавление вершины и инфорамации, хранящейся в ней
        {
            if (base.number == 0)
                base.clear();
            base.add_top();
            Console.Write("Введите число, которое будет хранится в {0}-ой вершине: ", base.number);
            value_top[base.number - 1] = int.Parse(Console.ReadLine());
        }

        public void watch1()//просмотр информации, хранящейся в вершинах
        {
            if (base.number == 0)
                Console.WriteLine("В графе нет вершин!");
            for (int i = 0; i < base.number; i++)
                Console.WriteLine("В {0}-ой(ей) вершине находится число {1}", i + 1, value_top[i]);
        }

        public override void write_matrix()//просмотр матрицы смежности
        {
            Console.WriteLine("Информация о вершинах:");
            base.write_matrix();
        }

        public override int del_top()//удаление вершины
        {
            int top = base.del_top();
            for (int i = top - 1; i < top; i++)
                value_top[i] = value_top[i + 1];
            return 0;
        }

        public override void test()//тестирование программы
        {
            base.test();
            watch1();
            base.clear();
        }
    }

    class Graph_edge : Common//числовая информация в ребрах графа
    {

        public override void add_top()//добавление вершины
        {
            base.add_top();
        }

        public override void add_edge()//добавление ребра и информации
        {
            Console.Write("Введите число, которое будет хранится в ребре: ");
            base.value = int.Parse(Console.ReadLine());
            base.add_edge();
        }

        public override int del_top()//удаление вершины
        {
            base.del_top();
            return 0;
        }

        public override void write_matrix()//вывод матрицы смежности
        {
            base.write_matrix();
        }

        public override void test()//тестирование программы
        {
            base.test();
            base.clear();
        }
    }
}
