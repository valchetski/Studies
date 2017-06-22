#include <stdio.h>
#include <Windows.h>

int main()
{
	int m = 0, number, last, penultimate, temp, inc = 0, dec = 0;
	int increase_array[10000], decrease_array[10000];
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	printf("\t Ќайти все натуральные числа, не превосход€щие заданного m, дес€тична€");
	printf("\n запись которых есть строго возврастающа€ или строго убывающа€");
	printf("\n последовательность цифр \n \n \n");
	printf("\t ¬ведите натуральное число m:");
	scanf_s("%d", &m);
	if (m > 0)
	{
		for (number = 10; number <= m; ++number)
		{
			temp = number;
			last = temp % 10;	//последн€€ цифра в числе
			penultimate = (temp % 100) / 10;//предпоследн€€ цифра в числе			
			if (last > penultimate)
			{
				while (temp >= 10)
				{
					temp = temp / 10;
					last = penultimate;	//последн€€ цифра в числе
					penultimate = (temp % 100) / 10;//предпоследн€€ цифра в числе
					if (last <= penultimate)
						break;
				}
				if (temp < 10)
				{
					increase_array[inc] = number;
					++inc;
				}
			}
			else if (last < penultimate)
			{
				while (temp >= 10)
				{
					temp = temp / 10;
					last = penultimate;	//последн€€ цифра в числе
					penultimate = (temp % 100) / 10;//предпоследн€€ цифра в числе
					if (last >= penultimate)
						break;
				}
				if (temp < 10)
				{
					decrease_array[dec] = number;
					++dec;
				}
			}
		}
		printf("\n");
		printf("\t ¬озврастающа€ последовательность цифр:");
		for (number = 0; number < inc; ++number)
			printf("%d ", increase_array[number]);
		printf("\n \n \t ”бывающа€ последовательность цифр:");
		for (number = 0; number < dec; ++number)
			printf("%d ", decrease_array[number]);
	}
	else
		printf("\n\tќшибка! ¬ведите натуральное число");
	printf("\n \n");
	system("pause");
	return 0;
}
