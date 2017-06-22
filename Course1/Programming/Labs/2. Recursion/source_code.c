#include <stdio.h>
#include <conio.h>
#include <Windows.h>
#include <io.h>

void main (void)
{
	void positive_element (int massiv[50], int index);
	int replacement (int n);
	int choice = 0, massiv[50], index = 0, temp_int = 0, n = 0, answer;	
	unsigned i;
	char string[100]="", temp[10]="";
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);	
	printf("Что делаем?");
	printf("\n1 - Заменяем содержимое аргумента функции на значение  n-го числа Фибоначчи");
	printf("\n2 - Считаем количество положительных элементов в массиве\n\n");
	printf("Введите номер операции (1 или 2): ");
	scanf_s("%d%*c", &choice);	
	while(choice != 1 && choice != 2 )
    {
		printf("Ошибка! Введите число 1 или 2: ");	
		fflush(stdin);
		scanf_s("%d%*c", &choice);
    }
	if (choice == 1)//числа Фибоначчи
	{
		printf("Введите число натуральное число n: ");
		scanf_s("%d", &n);
		while(n < 1)
		{
			printf("Ошибка! Введите натуральное число: ");	
			fflush(stdin);
			scanf_s("%d%*c", &n);
		}
		answer = replacement(n - 1);
		printf("%d-ый член чисел Фибоначчи равен %d\n",n,answer);
		system("pause");
	}
	if (choice == 2)// положительные элементы массива
	{
		printf("\nВведите элементы массива(через пробел): ");		
		gets_s(string, 100);
		n = strlen(string);
 		for (i =  0; i <= strlen(string); ++i)
			if (string[i] != ' ' && string[i] != '\0')
			{
				temp[temp_int] = string[i];
				++temp_int;
			}
			else
				if (temp != "")
				{
					massiv[index] = atoi(temp);
					++index;
					temp_int = 0;
					ZeroMemory(temp,10);
				}		
		positive_element(massiv, index);	
	}	
}

void positive_element (int massiv[50], int index)
{
	int index_p = 0, positive_mass[50], i;
	for (i = 0; i <= index - 1; ++i)
		if (massiv[i] >0)
		{
			positive_mass[index_p] = massiv[i];
			++index_p;
		}
	printf("Положительные элементы массива:");
	for (i = 0; i <= index_p - 1; ++i)
		printf("%d ", positive_mass[i]);
	printf(". Всего: %d", index_p);
	printf("\n");
	system("pause");	
}

int replacement (int n)
{
	int Fibonacci (int number, int first, int second);
	int first = 0, second = 1;
	n = Fibonacci(n, first, second);
	return n;	
}

int Fibonacci (int number, int first, int second)
{
	if (number == 0)
		return first;
	else
		return Fibonacci (number - 1, second, first + second);
}