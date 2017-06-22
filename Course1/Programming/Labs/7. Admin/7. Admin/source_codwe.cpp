#include <iostream>
#include <string>
#include <Windows.h>
#include <string.h>
#include <fstream>
#include <locale.h>
using namespace std;

//номер комнаты
typedef unsigned long tNumber;

//уже заселилось в комнату
typedef unsigned long tSettled;

//тип номера
typedef string tType_room;

//тип номера по количеству мест
typedef string tSeats;

//этаж
typedef unsigned long tFloor;

//ремонт
typedef string tRepair;

//ВИД НА МОРЕ
typedef string tSea_views;

//структура для хранения информации об одном номере
typedef struct Room 
{
	tNumber Number;
	tSettled Settled;
	tType_room Type_room;
	tSeats Seats;
	tFloor Floor;
	tRepair Repair;
	tSea_views Sea_views;
	Room *Next, *Prev;
	Room() { Settled = 0; };
}tRoom;

//ФИО
typedef string tName;

//Серия и номер паспорта
typedef string tSeries;

//Дата рождения
typedef string tBirthday;

//номер комнаты
typedef unsigned long tNumber;

//дата приезда
typedef string tArrival;

//дата выселения
typedef string tEviction;

//стоимость проживания
typedef unsigned long tCost;

//структура для хранения информации об одном постояльце
typedef struct tGuest 
{
	tName Name;
	tSeries Series;
	tBirthday Birthday;
	tNumber Number;
	tArrival Arrival;
	tEviction Eviction;
	tCost Cost;
	tGuest *Next, *Prev;
} tGuest;

tRoom *All = NULL;//все номера
tRoom *Free = NULL;//свободные
tRoom *Busy = NULL;//занятые
tRoom *Reserved = NULL;//зарезервированные
tRoom *temp_room = NULL;

tGuest *Guest = NULL;//постояльцы
tGuest *temp_guest = NULL;

void list_of_numbers();
tRoom* Add_Room(tRoom *Room);//добавление
void Output(tRoom *Room_temp);
void bypass(tRoom *Room);//обход
void number_search(tRoom *Room);
void number_search1(tRoom *Room_temp, int fiel, string element);
bool check_for_null(tRoom *Room_temp);
void editing ();//редактирование
tRoom* Delete(tRoom *Room, int element);
void sort(tRoom *Room_temp);
int prior(string element);
tRoom* Sort(tRoom *Room_temp); 
void list_of_guest();
void Add_Guest();//регистрация посетителя
void bypas_guest();//обход
void Output_guest(tGuest *Guest_temp);//вывод инфы о номере
tType_room type_search(tNumber Number, tRoom *Room, string find);
void eviction();
tRoom* edition1(tRoom *Room_temp, int number);
tRoom* select_one(tRoom* cha, tNumber Number);
void exemption_numbers();//освобождение номера
void lodger_eviction(tNumber number);//выселение постояльца
void Delete_Guest(int element);
int change_date();//задержка номера
void early_eviction();
void search_lodger();
void search_lodger1(int fiel, string element);
tRoom* Load(tRoom* Room, string list);
void Save(tRoom* Room, string list);
void Save_All();

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	All = Load(All, "All.txt");
	Free = Load(Free, "Free.txt");
	Busy = Load(Busy, "Busy.txt");
	Reserved = Load(Reserved, "Reserved.txt");
	while (true)
	{
		printf("\n1 - Работа со списками номеров\n2 - Работа с заселяющимися постояльцами\n3 - Работа с выселяющимися постояльцами\n4 - Поиск постояльца по разным критериям\n0 - Выход\nВведите номер операции: ");
		int choice = 0;
		scanf_s("%d", &choice);
		switch (choice)
		{
			case 1://списки номеров
				list_of_numbers();
				break;
			case 2: //список гостей
				list_of_guest();
				break;
			case 3: //выселение
				eviction();
				break;
			case 4:
				search_lodger();
				break;
			case 0:
				Save_All();
				return;
			default:
				system("cls");
				printf("Ошибка ввода. Введите число от 0 до 7\n");
				break;
		}
	}
}

void Save(tRoom* Room, string list)
{
	tRoom *Room_temp = Room;
	if (Room_temp != NULL)
	{
		while (Room_temp ->Next != NULL)
			Room_temp = Room_temp->Next;
		ofstream file(list);
		if (file == NULL)
		{
			cout << "Ошибка при открытии файла " << list << endl;
			system("pause");
			exit(0);
		}
		while (Room_temp != NULL)
		{
			file << Room_temp->Number << " ";
			file << Room_temp->Type_room << " ";
			file << Room_temp->Seats << " ";
			file << Room_temp->Floor << " ";
			file << Room_temp->Repair << " ";
			file << Room_temp->Sea_views << " ";
			file << Room_temp->Settled << "\n";
			Room_temp = Room_temp->Prev;
		}
	}
	if (list == "All.txt" && Guest != NULL)///////////ОТКРЫТИЕ СПИСКА ПОСЕТИТЕЛЕЙ
	{
		ofstream filek("Visitor.txt");
		while (Guest ->Next != NULL)
			Guest = Guest->Next;
		if (filek == NULL)
		{
			cout << "Ошибка при открытии файла <<Visitor.txt>>" << endl ;
			system("pause");
			exit(0);
		}
		while (Guest != NULL)
		{
			filek << Guest->Number << " ";
			filek << Guest->Name << " ";
			filek << Guest->Series << " ";
			filek << Guest->Birthday << " ";
			filek << Guest->Arrival << " ";
			filek << Guest->Eviction << " ";
			filek << Guest->Cost << "\n";
			Guest = Guest->Prev;
		}
	}
}

void Save_All()
{
	Save(All, "All.txt");
	Save(Free, "Free.txt");
	Save(Busy, "Busy.txt");
	Save(Reserved, "Reserved.txt");
}

tRoom* Load(tRoom* Room, string list)
{
	tRoom* newelement = new tRoom;
	ifstream file(list);
	string str;
	Room = NULL;
	if (file == NULL)
	{
		cout << "Ошибка при открытии файла " << list << endl;
		system("pause");
		exit(0);
	}
	while (!file.eof())
	{
		getline(file, str, ' ');
		if (str.empty() || str == "\n")
			break;
		newelement->Number = stoi(str);
		getline(file, str, ' ');
		if (str == "Обычный" || str == "Королевский")
		{
			newelement->Type_room = str + " номер";
			getline(file, str, ' ');
		}
		else
			newelement->Type_room = str;
		getline(file, newelement->Seats, ' ');
		getline(file, str, ' ');
		newelement->Floor = stoi(str);
		getline(file, newelement->Repair, ' ');
		getline(file, newelement->Sea_views, ' ');
		getline(file, str, '\n');
		newelement->Settled = stoi(str);
		newelement->Prev = Room;
		newelement->Next = NULL;
		if (Room)
		{
			temp_room->Next = newelement;
			temp_room->Next->Prev = temp_room;
			temp_room = temp_room->Next;
		}
		else
			temp_room = Room = newelement;
		newelement = new tRoom;
	}
	if (list == "All.txt")///////////ОТКРЫТИЕ СПИСКА ПОСЕТИТЕЛЕЙ
	{
		tGuest* newelement = new tGuest;
		ifstream filek("Visitor.txt");
		string stro4ka;
		Guest = NULL;
		if (filek == NULL)
		{
			cout << "Ошибка при открытии файла <<Visitor.txt>>" << endl ;
			system("pause");
			exit(0);
		}
		while (!filek.eof())
		{
			getline(filek, stro4ka, ' ');				
			if (stro4ka.empty() || stro4ka == " " || stro4ka == "\n")
				break;
			newelement->Number = stoi(stro4ka);
			getline(filek, newelement->Name, ' ');
			getline(filek, stro4ka, ' ');
			newelement->Name = newelement->Name + " " + stro4ka;
			getline(filek, newelement->Series, ' ');
			getline(filek, newelement->Birthday, ' ');
			getline(filek, newelement->Arrival, ' ');
			getline(filek, newelement->Eviction, ' ');
			getline(filek, stro4ka, '\n');
			if (stro4ka.empty() || stro4ka == " " || stro4ka == "\n")
				newelement->Cost = 0;
			else
				newelement->Cost = stoi(stro4ka);
			newelement->Prev = Guest;
			newelement->Next = NULL;
			if (Guest)
			{
				temp_guest->Next = newelement;
				temp_guest->Next->Prev = temp_guest;
				temp_guest = temp_guest->Next;
			}
			else
				temp_guest = Guest = newelement;
				newelement = new tGuest;
		}
	}
	return Room;
}
/////++++++++++++++
void search_lodger()
{
	int choice = 0;
	string search;
	printf("Выберите поле\n1 - ФИО\n2 - Серия и номер паспорта\n3 - Дата рождения\n4 - Номер комнаты\n5 - Дата заселения\n6 - Дата выселения\nВведите число: ");
	scanf_s("%d", &choice);
	switch (choice)
	{
	case 1://ПОИСК ПО НОМЕРУ
		printf("Введите ФИО: ");
		break;
	case 2://ПОИСК ПО КОЛИЧЕСТВУ МЕСТ
		printf("Введите серию и номер паспорта: ");
		break;
	case 3://ПОИСК ПО ТИПУ
		printf("Введите дату рождения: ");
		break;
	case 4://ПОИСК ПО ЭТАЖУ
		printf("Введите номер комнаты: ");
		break;
	case 5://ПОИСК ПО РЕМОНТУ
		printf("Введите дату заселения: ");
		break;
	case 6:
		printf("Введите дату выселения: ");
		break;
	}
	cin.ignore();
	getline(cin, search);
	search_lodger1(choice, search);
}

void search_lodger1(int fiel, string element)
{
	bool found = false;
	string find;
	tGuest *temp = Guest;
	while (temp != NULL)
	{
		switch (fiel)
		{
		case 1:
			find = temp->Name;
			break;
		case 2:
			find = temp->Series;
			break;
		case 3:
			find = temp->Birthday;
			break;
		case 4:
			find = to_string(temp->Number);
			break;
		case 5:
			find = temp->Arrival;
			break;
		case 6:
			find = temp->Eviction;
			break;
		}
		if (find == element)
		{
			Output_guest(temp);
			found = true;
		}
		temp = temp->Prev;
	}
	if (!found)
	{
		printf("Поиск не дал результатов\n");
		system("pause");
	}
}

void eviction()//МЕНЮХА
{
	system("cls");
	while (true)
	{
		printf("1 - Отображение постояльцев, отъезжающих сегодня\n2 - Освобождение/задержка номера\n3 - Досрочный отъезд\n4 - Возврат в предыдущее меню\n0 - Выход\nВведите число: ");
		int choice = 0;
		cin.ignore();
		cin >> choice;
		switch (choice)
		{
		case 1:
			bypas_guest();
			break;
		case 2:
			printf("1 - Освобождение номера\n2 - Задержка номера\nВведите число: ");
			cin.ignore();
			cin >> choice;
			switch (choice)
			{
			case 1:
				exemption_numbers();
				break;
			case 2:
				printf("Введите дату: ");
				change_date();
				break;
			}
			break;
		case 3:
			printf("Введите дату, до которой будет продлено проживание: ");
			early_eviction();
			break;
		case 4:
			return;
		case 0:
			Save_All();
			exit(0);
		}
	}
}

void exemption_numbers()//ОСВОБОЖДЕНИЕ НОМЕРА
{
	if (Guest == NULL)
	{
		printf("Список гостей пуст");
		system("pause");
		return;
	}
	int number = 0;
	printf("Введите освобождаемый номер: ");
	cin >> number;
	tRoom *temp = Busy;
	while(temp != NULL && temp->Number != number) 
		temp = temp->Prev;
	if (temp == NULL)//ЕСЛИ ЭЛЕМЕНТА НЕТУ В СПИСКЕ ЗАНЯТЫХ НОМЕРОВ
	{
		while(Free != NULL && Free->Number != number) 
			Free = Free->Prev;
		Free->Settled--;
		while (Free->Next != NULL)
			Free = Free->Next;
	}
	else
	{
		tRoom *element = new tRoom;
		element = select_one(Busy, number);
		Busy =  Delete(Busy, number);
		element->Prev = Free;
		element->Next = NULL;
		if (Free == NULL)
			Free = element;
		else
		{
			Free->Next = element;
			Free = element;
		}
	}
	lodger_eviction(number);
}

void lodger_eviction(tNumber number)
{
	tGuest *temp = new tGuest;
	temp = Guest; 
	while(temp != NULL) 
	{
		if(temp->Number == number)
		{
			Delete_Guest(number);
			temp = Guest;
			while (temp->Next != NULL)
				temp = temp->Next;
		}
		else
			temp = temp->Prev;
	}
}

void Delete_Guest(int element)
{
	if (Guest == NULL)
		printf("Гостей почему-то нету:(\n");
	else
	{
		tGuest *Room_temp = Guest;
		string opa;
		while(Room_temp != NULL)//ИЩЕМ НУЖНЫЙ ЭЛЕМЕНТ
			if(Room_temp->Number == element)
			{
				opa = Room_temp->Name;
				break;
			}
			else
				Room_temp = Room_temp->Prev;
		if(Room_temp->Prev == NULL)//если удаляется первый элемент, то
		{
			if (Room_temp->Next == NULL) 		//если этот элемент единственный
				Guest = Room_temp = NULL;
			else 				//если он первый, но не единственный
			{
				Room_temp->Next->Prev = NULL;
				Guest = Room_temp->Next;
			}
			delete Room_temp;
		}
		else if (Room_temp->Next == NULL)		//если удаляем последний элемент, то
		{
			Room_temp->Prev->Next = NULL;	//предыдущий элемент указывает на NULL
			Room_temp = Room_temp->Prev;		//указатель на последний элемент //указывает на предпоследний
			Guest = Room_temp;
		}		
		else //если элемент находится в центре списка
		{
			Room_temp->Prev->Next = Room_temp->Next; //предыдущий элемент указывает на следующий
			Room_temp->Next->Prev = Room_temp->Prev; //следующий указывает на предыдущий
			Room_temp = Room_temp->Prev;
			Guest = Room_temp->Next;
		}
		cout << "Посетитель " << opa << " выселен" << endl;			
	}	
}

int change_date()
{
		string date, name;
		cin.ignore();
		getline(cin, date);
		printf("Введите ФИО: ");
		getline(cin, name);
		while(Guest != NULL)//ИЩЕМ НУЖНЫЙ ЭЛЕМЕНТ
			if(Guest->Name == name)
				break;
			else
				Guest = Guest->Prev;

		if(Guest != NULL) 
		{
			Guest ->Eviction = date;
			int days = atoi(Guest->Eviction.substr(0, 2).c_str()) - atoi(Guest->Arrival.substr(0, 2).c_str());
			tRoom *temp = new tRoom;
			temp = Free;
			while (Free->Prev != NULL || (Free->Prev == NULL && Free->Next == NULL && Free != NULL))
			{
				if (Guest->Number == Free->Number)
				{
					Guest->Cost = 50 * days * prior(type_search(Guest->Number, Free, "Type_room")) * prior(type_search(Guest->Number, Free, "Seats")) * prior(type_search(Guest->Number, Free, "Repair")) * prior(type_search(Guest->Number, Free, "Sea_views"));
					break;
				}
				if (Free->Prev != NULL)
					Free = Free->Prev;
				else
					break;
			}
			if (Free->Prev == NULL)
			{
				temp = Busy;
				while (Busy->Prev != NULL || (Busy->Prev == NULL && Busy->Next == NULL && Busy != NULL))
				{
					if (Guest->Number == Busy->Number)
					{
						Guest->Cost = 50 * days * prior(type_search(Guest->Number, Busy, "Type_room")) * prior(type_search(Guest->Number, Busy, "Seats")) * prior(type_search(Guest->Number, Busy, "Repair")) * prior(type_search(Guest->Number, Busy, "Sea_views"));
						break;
					}
					if (Busy->Prev != NULL)
						Busy = Busy->Prev;
					else 
						break;
				}
			}
			while(Free->Next != NULL)
				Free = Free->Next;
			while(Busy->Next != NULL)
				Busy = Busy->Next;
			cout << "Стоимость проживания: " << Guest->Cost << "$" << endl; 
			while (Guest->Next != NULL)
				Guest = Guest->Next;
		}
		else 
		{
			system("cls");
			cout << "Постояльца с именем " << name << " нет" << endl;
			system("pause");
		}
		return Guest->Number;
}

void early_eviction()
{
	int number = change_date();
	bool w = false;
	tRoom *temp = Busy; 
	w = false;
	while(temp != NULL) 
		if(temp->Number == number)
		{
			w = true;
			break;
		}
		else
			temp = temp->Prev;
	if (w)//номер переводится из списка занятых номеров в список свободных
	{
		tRoom *element = new tRoom;
		element = select_one(Busy, number);
		Busy =  Delete(Busy, number);
		element->Prev = Free;
		element->Next = NULL;
		if (Free == NULL)
			Free = element;
		else
		{
			Free->Next = element;
			Free = element;
		}
	}
	else
	{
		while(Free->Prev != NULL || (Free->Prev == NULL && Free->Next == NULL && Free != NULL))
			if(Free->Number == number)
			{
				w = true;
				break;
			}
			else if(Free->Prev != NULL)
					Free = Free->Prev;
			else 
				break;
		if (w)
			Free->Settled--;
		else
		{
			system("cls");
			cout << "Такого номера нет";
			system("pause");
		}
	}
	lodger_eviction(number);
}

void bypas_guest()//обход
{
	tGuest *Guest_temp = new tGuest;
	Guest_temp = Guest;
	string date;
	system("cls");
	if (Guest_temp == NULL)
		printf("Гостей почему-то нету:(\n");
	else
	{
		printf("Введите дату: ");
		cin.ignore();
		getline(cin, date);
		while (Guest_temp != NULL)
		{
			if (date == Guest_temp->Eviction)
				Output_guest(Guest_temp);
			Guest_temp = Guest_temp->Prev;
		}
	}
	system("pause");
}

void Output_guest(tGuest *Guest_temp)//вывод инфы о номере
{
	printf("------------------------------------------\n");
	cout << "ФИО: " << Guest_temp->Name << endl;
	cout << "Серия и номер паспорта: " << Guest_temp->Series << endl;
	cout << "Дата рождения: " << Guest_temp->Birthday << endl;
	cout << "Номер комнаты: " << Guest_temp->Number << endl;
	cout << "Дата приезда: " << Guest_temp->Arrival << endl;
	cout << "Дата отъезда: " << Guest_temp->Eviction;
	printf("\n------------------------------------------\n");
}

///////////////////////////////////////////////////////////////////КОНЕЦ РАБОТЫ С ВЫСЕЛЯЮЩИМИСЯ ПОСТОЯЛЬЦАМИ

void list_of_guest()
{
	system("cls");
	while (true)
	{
		printf("1 - Поиск подходящего номера\n2 - Регистрация постояльца\n3 - Возврат в предыдущее меню\n0 - Выход\nВведите номер операции: ");
		int choice = 0;
		scanf_s("%d", &choice);
		system("cls");
		switch (choice)
		{
		case 1:
			number_search(Free);
			break;
		case 2:
			Add_Guest();
			break;
		case 3:
			return;
		case 0:
			Save_All();
			exit(0);
		default:
			system("cls");
			printf("Ошибка ввода. Введите число от 0 до 3\n");
			break;
		}
	}	
}

void Add_Guest()//регистрация посетителя
{
	tGuest *newelement = new tGuest;
	int choice = 0;
	system("cls");
	cin.ignore();
	printf("Введите номер комнаты: ");
	scanf_s("%d", &newelement->Number);
	if (select_one(Free, newelement->Number) == NULL)//проверяем, есть ли такой номер
	{
		system("cls");
		cout << "Такого номера нет" << endl;
		system("pause");
		return;
	}
	cin.ignore();
	printf("Введите ФИО: ");
	getline (cin, newelement->Name);
	printf("Введите серию и номер паспорта: ");
	getline (cin, newelement->Series);
	printf("Введите дату рождения: ");
	getline (cin, newelement->Birthday);
	printf("Введите дату заселения: ");
	getline (cin, newelement->Arrival);
	printf("Введите дату выселения: ");
	getline (cin, newelement->Eviction);
	int days = atoi(newelement->Eviction.substr(0, 2).c_str()) - atoi(newelement->Arrival.substr(0, 2).c_str());
	newelement->Cost = 50 * days * prior(type_search(newelement->Number, Free, "Type_room")) * prior(type_search(newelement->Number, Free, "Seats")) * prior(type_search(newelement->Number, Free, "Repair")) * prior(type_search(newelement->Number, Free, "Sea_views"));
	cout << "Стоимость проживания: " << newelement->Cost << "$" << endl; 
	while (Free->Number != newelement->Number)//ищем нужный номер
		Free = Free->Next;
	Free->Settled++;
	while (All->Number != Free->Number)
		All = All->Next;
	All->Settled++;
	if (Free->Settled == prior(type_search(newelement->Number, Free, "Seats")))//номер переводится из списка свободных номеров в список занятых
	{
		tRoom *element = select_one(Free, newelement->Number);
		Free =  Delete(Free, newelement->Number);
		element->Prev = Busy;
		element->Next = NULL;
		if (Busy == NULL)
			Busy = element;
		else
		{
			Busy->Next = element;
			Busy = Busy->Next;
		}
	}
	while(Free->Next != NULL)
		Free = Free->Next;
	while(All->Next != NULL)
		All = All->Next;
/*	Guest_temp->Prev = Guest;
	Guest_temp->Next = NULL;
	if (Guest == NULL)
		Guest = Guest_temp;
	else
	{
		Guest->Next = Guest_temp;
		Guest = Guest_temp;
	}*/
}

tRoom* select_one(tRoom* Room, tNumber Number)
{
    tRoom *old_temp = new tRoom;
	old_temp = Room;
    tRoom *Room_temp = new tRoom;
	while( old_temp != NULL )
		if (old_temp->Number == Number)
		{
			Room_temp->Number = old_temp->Number;
			Room_temp->Seats = old_temp->Seats;
			Room_temp->Type_room = old_temp->Type_room;
			Room_temp->Floor = old_temp->Floor;
			Room_temp->Repair = old_temp->Repair;
			Room_temp->Sea_views = old_temp->Sea_views;
			Room_temp->Settled = Room_temp->Settled;
			Room_temp->Next = Room_temp->Prev = NULL;
			return Room_temp;
		}
		else
			old_temp = old_temp->Prev;
	return NULL;
}	

tType_room type_search(tNumber Number, tRoom *Room, string find)
{
	tRoom *Room_temp = new tRoom;
	while (Room->Next != NULL)
		Room = Room->Next;
	Room_temp = Room;
	while (Room_temp != NULL)
		if (Room_temp->Number == Number)
		{
			if (find == "Type_room")
				return Room_temp->Type_room;
			if (find == "Seats")
				return Room_temp->Seats;
			if (find == "Repair")
				return Room_temp->Repair;
			if (find == "Sea_views")
				return Room_temp->Sea_views;
		}
		else
			Room_temp = Room_temp->Prev;
	return NULL;
}
/////////////////////////////////////////////////////////////////////////////////КОНЕЦ РАБОТЫ С ЗАСЕЛЯЮЩИМИСЯ ПОСЕТИТЕЛЯМИ
void list_of_numbers()//список номеров
{
	system("cls");
	while (true)
	{
		printf("1 - Отображение всех номеров\n2 - Поиск номера по разным критериям\n3 - Редактирование списка номеров\n4 - Сортировка номеров по разным критериям\n5 - Возврат в предыдущее меню\n0 - Выход\nВведите номер операции: ");
		int choice = 0;
		scanf_s("%d", &choice);
		system("cls");
		switch (choice)
		{
		case 1:
			bypass(All);
			break;
		case 2:
			printf("Выберите номера для поиска\n1 - Все\n2 - Свободные\n3 - Занятые\n4 - Зарезервированные\n5 - Назад\n0 - Выход\nВведите число: ");
			scanf_s("%d", &choice);
			switch (choice)
			{
			case 1:
				number_search(All);
				break;
			case 2:
				number_search(Free);
				break;
			case 3:
				number_search(Busy);
				break;
			case 4:
				number_search(Reserved);
				break;
			case 5:
				break;
			case 0:
				Save_All();
				exit(0);
			}
			break;
		case 3:
			editing();
			break;
		case 4:
			if (check_for_null(All))
				All = Sort(All);
			bypass(All);
			break;
		case 5:
			return;
		case 0:
			Save_All();
			exit(0);
		default:
			system("cls");
			printf("Ошибка ввода. Введите число от 0 до 5\n");
			break;
		}
	}	
}

tRoom* Add_Room(tRoom *Room)//добавление
{
	tRoom *newelement = new tRoom;
	int choice = 0;
	system("cls");
	printf("Введите номер: ");
	scanf_s("%d", &newelement->Number);
	printf("Выберите тип номера:\n1 - Обычный номер\n2 - Полулюкс\n3 - Люкс\n4 - Королевский номер\nВведите число: ");
	scanf_s("%d", &choice);
    switch (choice)
		{
		case 1:
			newelement->Type_room = "Обычный номер";
			break;
		case 2:
			newelement->Type_room = "Полулюкс";
			break;
		case 3:
			newelement->Type_room = "Люкс";
			break;
		case 4:
			newelement->Type_room = "Королевский номер";
			break;
		default:
			printf("Ошибка ввода. Введите число от 1 до 4");
			break;
		}
	printf("Выберите количество мест в номере:\n1 - Одноместный\n2 - Двуместный\n3 - Трехместный\n4 - Четырехместный\nВведите число: ");
	scanf_s("%d", &choice);
    switch (choice)
		{
		case 1:
			newelement->Seats = "Одноместный";
			break;
		case 2:
			newelement->Seats = "Двуместный";
			break;
		case 3:
			newelement->Seats = "Трехместный";
			break;
		case 4:
			newelement->Seats = "Четырехместный";
			break;
		default:
			printf("Ошибка ввода. Введите число от 1 до 4");
			break;
		}
	printf("Введите этаж: ");
	scanf_s("%d", &newelement->Floor);
	printf("Выберите состояние ремонта:\n1 - Отремонтирован\n2 - Ремонтируется\nВведите число: ");
	scanf_s("%d", &choice);
    switch (choice)
		{
		case 1:
			newelement->Repair = "Отремонтирован";
			break;
		case 2:
			newelement->Repair = "Ремонтируется";
			break;
		default:
			printf("Ошибка ввода. Введите число от 1 до 2");
			break;
		}
	printf("Вид на море:\n1 - Есть\n2 - Нет\nВведите число: ");
	scanf_s("%d", &choice);
    switch (choice)
		{
		case 1:
			newelement->Sea_views = "Есть";
			break;
		case 2:
			newelement->Sea_views = "Нет";
			break;
		default:
			printf("Ошибка ввода. Введите число от 1 до 2");
			break;
		}
	newelement->Prev = Room;
	newelement->Next = NULL;
	temp_room = Room;
	while(temp_room->Next)
		temp_room = temp_room->Next;
	if (Room)
	{
		temp_room->Next = newelement;
		temp_room->Next->Prev = temp_room;
		temp_room = temp_room->Next;
	}
	else
		temp_room = Room = newelement;
	return Room;
}//добавление номера

tRoom* Delete(tRoom *Room, int element)
{
	if (Room == NULL)
	{
		printf("Комнат почему-то нету:(\n");
		return NULL;
	}
	else
	{
		tRoom *Room_temp = new tRoom;
		Room_temp = Room;
		while(Room_temp != NULL)//ИЩЕМ НУЖНЫЙ ЭЛЕМЕНТ
			if(Room_temp->Number == element)
				break;
			else
				Room_temp = Room_temp->Prev;
		if (Room_temp == NULL)
			return Room;
		if(Room_temp->Prev == NULL)//если удаляется первый элемент, то
		{
			if (Room_temp->Next == NULL) 		//если этот элемент единственный
				Room = Room_temp = NULL;
			else 				//если он первый, но не единственный
			{
				Room_temp->Next->Prev = NULL;
				Room = Room_temp->Next;
			}
			delete Room_temp;
			return Room;
		}
		if (Room_temp->Next == NULL)		//если удаляем последний элемент, то
		{
			Room_temp->Prev->Next = NULL;	//предыдущий элемент указывает на NULL
			Room_temp = Room_temp->Prev;		//указатель на последний элемент //указывает на предпоследний
			Room = Room_temp;
			return Room;
		}		
		else //если элемент находится в центре списка
		{
			Room_temp->Prev->Next = Room_temp->Next; //предыдущий элемент указывает на следующий
			Room_temp->Next->Prev = Room_temp->Prev; //следующий указывает на предыдущий
			Room_temp = Room_temp->Prev;
			Room = Room_temp->Next;
			return Room;
		}
	}	
}

void Output(tRoom *Room_temp)//вывод инфы о номере
{
	printf("------------------------------------------\n");
	printf("Номер: %d\nЭтаж: %d",Room_temp->Number, Room_temp->Floor);
	cout<<"\nТип номера: "<<Room_temp->Type_room;
	cout<<", "<<Room_temp->Seats;
	cout<<"\nСостояние ремонта: "<<Room_temp->Repair;
	cout<<"\nВид на море: "<<Room_temp->Sea_views;
	printf("\n------------------------------------------\n");
}

void bypass(tRoom *Room)//обход
{
	tRoom *Room_temp = Room;
	system("cls");
	if (Room_temp == NULL)
		printf("Комнат почему-то нету:(\n");
	else
	{
		while (Room_temp ->Next != NULL)
			Room_temp = Room_temp->Next;
		while (Room_temp != NULL)
		{
			Output(Room_temp);
			Room_temp = Room_temp->Prev;
		}
	}
	system("pause");
	system("cls");
}

void number_search(tRoom *Room_temp)
{
	int choice = 0;
	int number = 0;
	printf("Выберите поле\n1 - Номер\n2 - Количество мест\n3 - Тип\n4 - Этаж\n5 - Ремонт\n6 - Вид на море\nВведите число: ");
	scanf_s("%d", &choice);
	switch (choice)
	{
	case 1://ПОИСК ПО НОМЕРУ
		printf("Введите искомое число: ");
		scanf_s("%d",&number);
		if (check_for_null(Room_temp))
			number_search1(Room_temp, 1,to_string(number));
		break;
	case 2://ПОИСК ПО КОЛИЧЕСТВУ МЕСТ
		printf("Сколько мест в номере:\n1 - Одно\n2 - Два\n3 - Три\n4 - Четыре\nВведите число: ");
		scanf_s("%d", &choice);
		if (check_for_null(Room_temp))
			switch (choice)
			{
			case 1:
				number_search1(Room_temp, 2, "Одноместный");
				break;
			case 2:
				number_search1(Room_temp, 2, "Двуместный");
				break;
			case 3:
				number_search1(Room_temp, 2, "Трехместный");
				break;
			case 4:
				number_search1(Room_temp, 2, "Четырехместный");
				break;
			default:
				printf("Ошибка ввода. Введите число от 1 до 4");
				break;
			}
		break;
	case 3://ПОИСК ПО ТИПУ
		printf("Какой тип номера:\n1 - Обычный номер\n2 - Полулюкс\n3 - Люкс\n4 - Королевский номер\nВведите число: ");
		scanf_s("%d", &choice);
		if (check_for_null(Room_temp))
			switch (choice)
			{
			case 1:
				number_search1(Room_temp, 3, "Обычный номер");
				break;
			case 2:
				number_search1(Room_temp, 3, "Полулюкс");
				break;
			case 3:
				number_search1(Room_temp, 3, "Люкс");
				break;
			case 4:
				number_search1(Room_temp, 3, "Королевский номер");
				break;
			default:
				printf("Ошибка ввода. Введите число от 1 до 4");
				break;
			}
		break;
	case 4://ПОИСК ПО ЭТАЖУ
		printf("Введите этаж: ");
		scanf_s("%d",&number);
		if (check_for_null(Room_temp))
			number_search1(Room_temp, 4, to_string(number));
		break;
	case 5://ПОИСК ПО РЕМОНТУ
		printf("Выберите состояние ремонта:\n1 - Отремонтирован\n2 - Ремонтируется\nВведите число: ");
		scanf_s("%d", &choice);
		if (check_for_null(Room_temp))
			switch (choice)
			{
			case 1:
				number_search1(Room_temp, 5, "Отремонтирован");
				break;
			case 2:
				number_search1(Room_temp, 5, "Ремонтируется");
				break;
			default:
				printf("Ошибка ввода. Введите число от 1 до 2");
				break;
			}
		break;
	case 6:
		printf("Вид на море:\n1 - Есть\n2 - Нет\nВведите число: ");
		scanf_s("%d", &choice);
		if (check_for_null(Room_temp))
			switch (choice)
			{
			case 1:
				number_search1(Room_temp, 6, "Есть");
				break;
			case 2:
				number_search1(Room_temp, 6, "Нет");
				break;
			default:
				printf("Ошибка ввода. Введите число от 1 до 2");
				break;
			}
		break;
	}
}

void number_search1(tRoom *Room_temp, int fiel, string element)
{
	string find;
	bool found = false;
	while (Room_temp != NULL)
	{
		switch (fiel)
		{
		case 1:
			find = to_string(Room_temp->Number);
			break;
		case 2:
			find = Room_temp->Seats;
			break;
		case 3:
			find = Room_temp->Type_room;
			break;
		case 4:
			find = to_string(Room_temp->Floor);
			break;
		case 5:
			find = Room_temp->Repair;
			break;
		case 6:
			find = Room_temp->Sea_views;
			break;
		}
		if (find == element)
		{
			Output(Room_temp);
			found = true;
		}
		Room_temp = Room_temp->Prev;
	}
	if (!found)
	{
		printf("Поиск не дал результатов\n");
		system("pause");
	}
}

bool check_for_null(tRoom *Room_temp)
{
	if(Room_temp)
		return true;
	else
	{
		system("cls");
		printf("Список номеров пуст\n");
		system("pause");
		return false;
	}
}

void editing()
{
	int choice = 0;
	int number = 0;
	bool found = false;
	tRoom *element = new tRoom;
	printf("1 - Добавить номер\n2 - Удалить номер\n3 - Редактировать номер\nВведите число: ");
	scanf_s("%d",&choice);
	switch (choice)
	{
	case 1://ДОБАВЛЕНИЕ
		All = Add_Room(All);
		element = select_one(All, All->Number);
		element->Prev = Free;
		element->Next = NULL;
		if (Free == NULL)
			Free = element;
		else
		{
			Free->Next = element;
			Free = Free->Next;
		}
		break;
	case 2://УДАЛЕНИЕ
		printf("Введите номер комнаты: ");
		scanf_s("%d", &number);
		if (select_one(Free, number))
		{
			Free = Delete(Free, number);
			All = Delete(All, number);
			found = true;
		}
		if (select_one(Busy, number))
		{
			Busy = Delete(Busy, number);
			All = Delete(All, number);
			found = true;
		}
		if (select_one(Reserved, number))
		{
			Reserved = Delete(Reserved, number);
			All = Delete(All, number);
			found = true;
		}
		if (found)
			cout << "Комната №" << number << " удалена" << endl; 
		else
			cout << "Комната №" << number << " не найдена";
		break;
	case 3:
		printf("Введите номер комнаты: ");
		scanf_s("%d", &number);
		if (select_one(Free, number))
		{
			Free = edition1(Free, number);
			element = select_one(Free, number);
			found = true;
		}
		if (select_one(Busy, number))
		{
			Busy = edition1(Busy, number);
			element = select_one(Busy, number);
			found = true;
		}
		if (select_one(Reserved, number))
		{
			Reserved = edition1(Reserved, number);
			element = select_one(Reserved, number);
			found = true;
		}
		if (found)
		{
			All = Delete(All, number);
			while (All ->Next != NULL)
				All = All->Next;
			element->Prev = All;
			element->Next = NULL;
			if (All == NULL)
			All = element;
			else
			{
				All->Next = element;
				All = All->Next;
			}
			cout << "Комната №" << number << " отредактирована" << endl; 
		}
		else
			cout << "Комната №" << number << " не найдена";
		break;
	}
}

tRoom* edition1(tRoom *Room, int number)
{
	 	int choice = 0;
		while(Room != NULL)//ИЩЕМ НУЖНЫЙ ЭЛЕМЕНТ
			if(Room->Number == number)
				break;
			else
				Room = Room->Prev;
		printf("Выберите поле для редактирования\n1 - Номер\n2 - Количество мест\n3 - Тип\n4 - Этаж\n5 - Ремонт\n6 - Вид на море\n7 - Назад\n0 - Выход\nВведите число: ");
		fflush(stdin);
		scanf_s("%d", &choice);
		switch (choice)
		{
			case 1:
				printf("Введите число: ");
				scanf_s("%d",&number);
				if (check_for_null(Room))
						Room->Number = number;
				break;
			case 2:
				printf("Количество мест в номере:\n1 - Одно\n2 - Два\n3 - Три\n4 - Четыре\nВведите число: ");
				scanf_s("%d", &choice);
				if (check_for_null(Room))
					switch (choice)
					{
					case 1:
						Room->Seats = "Одноместный";
						break;
					case 2:
						Room->Seats = "Двуместный";
						break;
					case 3:
						Room->Seats = "Трехместный";
						break;
					case 4:
						Room->Seats = "Четырехместный";
						break;
					default:
						printf("Ошибка ввода. Введите число от 1 до 4");
						break;
					}
				break;
			case 3:
				printf("Тип номера:\n1 - Обычный номер\n2 - Полулюкс\n3 - Люкс\n4 - Королевский номер\nВведите число: ");
				scanf_s("%d", &choice);
				if (check_for_null(Room))
					switch (choice)
					{
					case 1:
						Room->Type_room = "Обычный номер";
						break;
					case 2:
						Room->Type_room = "Полулюкс";
						break;
					case 3:
						Room->Type_room = "Люкс";
						break;
					case 4:
						Room->Type_room = "Королевский номер";
						break;
					default:
						printf("Ошибка ввода. Введите число от 1 до 4");
						break;
					}
				break;
			case 4:
				printf("Введите этаж: ");
				scanf_s("%d",&number);
				if (check_for_null(Room))
					Room->Floor = number;
				break;
			case 5:
				printf("Выберите состояние ремонта:\n1 - Отремонтирован\n2 - Ремонтируется\nВведите число: ");
				scanf_s("%d", &choice);
				if (check_for_null(Room))
					switch (choice)
					{
					case 1:
						Room->Repair = "Отремонтирован";
						break;
					case 2:
						Room->Repair = "Ремонтируется";
						break;
					default:
						printf("Ошибка ввода. Введите число от 1 до 2");
						break;
					}
				break;
			case 6:
				printf("Вид на море:\n1 - Есть\n2 - Нет\nВведите число: ");
				scanf_s("%d", &choice);
				if (check_for_null(Room))
					switch (choice)
					{
					case 1:
						Room->Sea_views = "Есть";
						break;
					case 2:
						Room->Sea_views = "Нет";
						break;
					default:
						printf("Ошибка ввода. Введите число от 1 до 2");
						break;
					}
				break;
			case 7:
				return Room;
			case 0:
				Save_All();
				exit(0);
		}
return Room;
}

tRoom* Sort(tRoom *Room_temp) 
{
	tRoom *tmp;
	tRoom *a;
    tRoom t;
    int flag = 1;
 	int choice = 0;
	printf("Выберите поле для сортировки\n1 - Номер\n2 - Количество мест\n3 - Тип\n4 - Этаж\n5 - Ремонт\n6 - Вид на море\nВведите число: ");
	scanf_s("%d", &choice);
    while(flag == 1)
	{
        tmp = Room_temp;
		a = tmp->Prev;
        flag = 0;
		while(a)
		{
			bool w = false;
			switch (choice)
			{
				case 1 ://по номеру 
					if(tmp->Number > a->Number)
						w = true;
					break;
				case 2 ://по количеству мест
					if(prior(tmp->Seats) > prior(a ->Seats)) 
						w = true;
					break;
				case 3 ://по типу
					if(prior(tmp->Type_room) > prior(a ->Type_room)) 
						w = true;
					break;
				case 4 ://по этажу
					if (tmp->Floor > a->Floor)
						w = true;
					break;
				case 5 ://по ремонту
					if(prior(tmp->Repair) > prior(a ->Repair)) 
						w = true;
					break;
				case 6 ://по виду на море
					if(prior(tmp->Sea_views) > prior(a ->Sea_views)) 
						w = true;
					break;
			}
			 if (w == true)
			 {
				t.Number = tmp->Number;
				t.Seats = tmp->Seats;
				t.Type_room = tmp->Type_room;
				t.Floor = tmp->Floor;
				t.Repair = tmp->Repair;
				t.Sea_views = tmp->Sea_views;
				t.Settled = tmp->Settled;

				tmp->Number = a->Number;
				tmp->Seats = a->Seats;
				tmp->Type_room = a->Type_room;
				tmp->Floor = a->Floor;
				tmp->Repair = a->Repair;
				tmp->Sea_views = a->Sea_views;
				tmp->Settled = a->Settled;

				a->Number = t.Number;
				a->Seats = t.Seats;
				a->Type_room = t.Type_room;
				a->Floor = t.Floor;
				a->Repair = t.Repair;
				a->Sea_views = t.Sea_views;
				a->Settled = t.Settled;
                flag = 1;
			 }
			 tmp = tmp->Prev;
			 a = a->Prev;
		}
	}
	return tmp;
}

int prior(string element)
{
	if (element == "Одноместный" || element == "Обычный номер" || element == "Ремонтируется" || element == "Нет")
		return 1;
	if (element == "Двуместный" || element == "Полулюкс" || element == "Отремонтирован" || element == "Есть")
		return 2;
	if (element == "Трехместный" || element == "Люкс")
		return 3;
	if (element == "Четырехместный" || element == "Королевский номер")
		return 4;
	return NULL;
}
