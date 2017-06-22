// sx.cpp: определяет точку входа для приложения.
//

#include "stdafx.h"
#include "6.Registry.h"
#include "string.h"
#include "TlHelp32.h"
#include "CommCtrl.h"
#include "Psapi.h"
#include "Windows.h"
#include "stdlib.h"
#include "stdio.h"
#include "tchar.h"


#define EDIT 40001
#define SEARCH 40002
#define COMBOBOX 40003

#define hight 1050
#define MAX_LOADSTRING 100


HWND ListBox, SearchBtn, TextFind, ComboBox;

int selectedHKEYindex = 0;


HKEY GetHKEY(int index)
{
	switch (index)
	{
	case 1:
		return HKEY_CURRENT_USER;
	case 2:
		return HKEY_LOCAL_MACHINE;
	case 3:
		return HKEY_USERS;
	case 4:
		return HKEY_CURRENT_CONFIG;
	default:
		return HKEY_CLASSES_ROOT;
	}
}
void Scan(HKEY hKey, LPCSTR subkey, HWND hwnd, CHAR* string) {
	HKEY key;
	int err = RegOpenKeyEx(hKey, subkey, 0, KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS, &key);

	if (err != 0)
		return;
	int index = 0;
	char* name[10240];
	while ((err = RegEnumKey(key, index++, (LPSTR)name, 10240)) != ERROR_NO_MORE_ITEMS) 
	{
		if (lstrlen(subkey) == 0)
			Scan(hKey, (LPCSTR)name, hwnd, string);
		else 
		{
			char path[10240];
			sprintf(path, "%s\\%s", subkey, name);
			Scan(hKey, path, hwnd, string);
		}
	}

	index = 0;
	int type, size = 1024;
	char data[1024];
	int namesize = 1024;
	while ((err = RegEnumValue(key, index++, (LPSTR)name, (LPDWORD)&namesize, 0, (LPDWORD)&type, (LPBYTE)data, (LPDWORD)&size)) == 0) 
	{
		if (type == REG_SZ) 
		{
			char str[10052];
			sprintf(str, "%s\\%s - %s\n", subkey, name, data);
			if (lstrlen(data) > 0) 
				if (strstr(data, string)) 
				{
					HANDLE f = CreateFile((LPCSTR)data, GENERIC_READ, FILE_SHARE_READ,NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,NULL);
					if (f == INVALID_HANDLE_VALUE) 
					{
						WIN32_FIND_DATA d;
						if (FindFirstFile(data, &d) == INVALID_HANDLE_VALUE)
						{
							SendMessage(ListBox, LB_ADDSTRING, 0, (LPARAM)str);
						}
					} 
					else
						CloseHandle(f);
				}
		}
		namesize = size = 1024;
	}
	RegCloseKey(key);
}

DWORD WINAPI Thread(LPVOID lpParam)
{
	HANDLE  hStdout = NULL;
	CHAR* str = (CHAR*)lpParam;
	HKEY key = GetHKEY(selectedHKEYindex);

	if( (hStdout = GetStdHandle(STD_OUTPUT_HANDLE)) == INVALID_HANDLE_VALUE )  
		return 1;
	Scan(key, "", NULL, str);
	MessageBox(NULL, "Поиск завершен!", "", MB_OK);
	return 0;

}

// Глобальные переменные:
HINSTANCE hInst;								// текущий экземпляр
TCHAR szTitle[MAX_LOADSTRING];					// Текст строки заголовка
TCHAR szWindowClass[MAX_LOADSTRING];			// имя класса главного окна

// Отправить объявления функций, включенных в этот модуль кода:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: разместите код здесь.
	MSG msg;
	HACCEL hAccelTable;

	// Инициализация глобальных строк
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_SX, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Выполнить инициализацию приложения:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_SX));

	// Цикл основного сообщения:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  ФУНКЦИЯ: MyRegisterClass()
//
//  НАЗНАЧЕНИЕ: регистрирует класс окна.
//
//  КОММЕНТАРИИ:
//
//    Эта функция и ее использование необходимы только в случае, если нужно, чтобы данный код
//    был совместим с системами Win32, не имеющими функции RegisterClassEx'
//    которая была добавлена в Windows 95. Вызов этой функции важен для того,
//    чтобы приложение получило "качественные" мелкие значки и установило связь
//    с ними.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SX));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_SX);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   ФУНКЦИЯ: InitInstance(HINSTANCE, int)
//
//   НАЗНАЧЕНИЕ: сохраняет обработку экземпляра и создает главное окно.
//
//   КОММЕНТАРИИ:
//
//        В данной функции дескриптор экземпляра сохраняется в глобальной переменной, а также
//        создается и выводится на экран главное окно программы.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	LPCSTR titles[5];

	titles[0] = "HKEY_CLASSES_ROOT";
	titles[1] = "HKEY_CURRENT_USER";
	titles[2] = "HKEY_LOCAL_MACHINE";
	titles[3] = "HKEY_USERS";
	titles[4] = "HKEY_CURRENT_CONFIG";
   HWND hWnd;

   hInst = hInstance; // Сохранить дескриптор экземпляра в глобальной переменной

   hWnd = CreateWindow(szWindowClass, "6.Registry", WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }
   
   TextFind = CreateWindowEx(WS_EX_CLIENTEDGE, "EDIT", NULL, WS_CHILD | WS_VISIBLE, 10, 10, 500, 25, hWnd, (HMENU)EDIT, hInst, NULL);
   ListBox = CreateWindowEx(WS_EX_CLIENTEDGE, "LISTBOX", NULL, 
	   WS_CHILD | WS_VISIBLE | WS_VSCROLL | ES_AUTOVSCROLL | WS_HSCROLL | ES_AUTOHSCROLL, 10, 40, 950, 400, hWnd, NULL, hInst, NULL);
   ComboBox = CreateWindowEx(WS_EX_CLIENTEDGE, "Combobox", NULL, WS_CHILD | WS_VISIBLE | WS_VSCROLL | CBS_DROPDOWNLIST, 520, 10, 200, 120, hWnd, (HMENU)COMBOBOX, hInst, NULL);
   SearchBtn = CreateWindowEx(WS_EX_APPWINDOW, "BUTTON", NULL, WS_CHILD | WS_VISIBLE, 720, 10, 100, 25, hWnd, (HMENU)SEARCH, hInst, NULL);
	SendMessage(ListBox, LB_SETHORIZONTALEXTENT, 1500, 0);
	for (int i = 0; i < 5; i++)
		SendMessage(ComboBox, CB_INSERTSTRING, (WPARAM)i, (LPARAM)titles[i]);
			SendMessage(ComboBox,CB_SETCURSEL,(WPARAM)0, 0);
			SetWindowText(SearchBtn, "Search");		
   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  ФУНКЦИЯ: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  НАЗНАЧЕНИЕ:  обрабатывает сообщения в главном окне.
//
//  WM_COMMAND	- обработка меню приложения
//  WM_PAINT	-Закрасить главное окно
//  WM_DESTROY	 - ввести сообщение о выходе и вернуться.
//
//

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	CHAR* buf = new TCHAR[128];
	int len = 0;
	HANDLE hThread = 0;
	

    switch (message)
    {
		case WM_CREATE:
		{
			
			break;
		}
		case WM_COMMAND:
			switch (LOWORD(wParam))
			{
			case COMBOBOX:
				if (HIWORD(wParam) == CBN_SELCHANGE)
					selectedHKEYindex = SendMessage(ComboBox, CB_GETCURSEL, 0, 0);
				break;
			case SEARCH:
				try
				{
					SendMessage(ListBox, LB_RESETCONTENT, 0, 0);
					len = SendMessage(TextFind, EM_LINELENGTH, 0, 0);
					if (len == 0)
						throw "Ошибка";
					GetDlgItemText(hWnd, EDIT, buf, len+1);
					hThread = CreateThread( NULL, 10241024, Thread, buf, 0, NULL);
				}
				catch (...)
				{
					MessageBox(hWnd, "Введите что-нибудь", "Ошибка", MB_OK);
				}
				break;
			default:
				break;
			}
			break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
        break;
    }

    return 0;

}

// Обработчик сообщений для окна "О программе".
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
