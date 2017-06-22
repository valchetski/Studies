#include "quadraticEquation.h"
#include "power.h"
#include "radians.h"

#include <iostream>
using namespace std;

int main()
{
	int choice;
	bool isExit = false;
	while (isExit == false)
	{
		cout << "\n\tМатематический помощник\n1 - Найти корни квадратного уравнения\n2 - Возведение числа в степень";
		cout << "\n3 - Перевести градусы в радианы\n0 - Выход из программы";
		cout << "\nВведите номер операции: ";
		cin >> choice;
		switch (choice)
		{
		case 1:
		{
			double a, b, c;
			cout << "\tРешение квадратного уравнения ax^2 + bx + c = 0";
			cout << "\nВведите а: ";
			cin >> a;
			cout << "Введите b: ";
			cin >> b;
			cout << "Введите c: ";
			cin >> c;
			double *result;
			result = calculateQuadraticEquation(a, b, c);
			double x1 = result[0];
			double x2 = result[1];
			cout << "\nx1 = " << x1;
			cout << "\nx2 = " << x2;
		}
		break;

		case 2:
		{
			double a, b;
			cout << "\tВозведение числа в степень";
			cout << "Введите основание: ";
			cin >> a;
			cout << "Введите степень: ";
			cin >> b;
			double result = power(a, b);
			cout << "Результат: " << result;
			break;
		}
		case 3:
		{
			double a;
			cout << "\tПеревод градусов в радианы";
			cout << "\nВведите значение в градусах: ";
			cin >> a;
			double result = degreeToRadian(a);
			cout << "Значение в радианах" << result;
			break;
		}
		case 0:
			isExit = true;
			break;
		default:
			break;
		}
	}
	
	
	
}
