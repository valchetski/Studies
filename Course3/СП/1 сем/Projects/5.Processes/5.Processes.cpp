// 5.Processes.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "5.Processes.h"

#include <commctrl.h>
#include <tlhelp32.h>

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

HWND hProcessListView, hModuleListView;
TCHAR buf1[256] = L"";

int APIENTRY _tWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPTSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_MY5PROCESSES, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY5PROCESSES));

	// Main message loop:
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
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY5PROCESSES));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MY5PROCESSES);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message)
	{
	case WM_CREATE:
		SetWindowPos(hWnd, 0, 0, 0, 1000, 500, SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE);//размер окна
		CreateListViewes(hWnd);

		TCHAR* header[2];
		header[0] = L"Thread"; header[1] = L"Priority";
		SetListViewColumns(hProcessListView, 2, header); //тут прорисовываются стобцы

		header[0] = L"Module"; header[1] = L"ExePath";
		SetListViewColumns(hModuleListView, 2, header);
		PrintProcessList(hProcessListView);
		break;
	// Общий заголовок сообщения для элементов управления.
	case WM_NOTIFY:
	{
		LPNMHDR lpnmHdr = (LPNMHDR)lParam;
		//кликнули на листбокс с процессами левой кнопкой мыши
		if ((lpnmHdr->idFrom == IDC_PROCESS_LISTVIEW) && ((lpnmHdr->code == NM_CLICK) || (lpnmHdr->code == LVN_ITEMCHANGED)))
		{
			ListView_GetItemText(hProcessListView, SendMessage(hProcessListView, LVM_GETNEXTITEM, -1, LVNI_SELECTED), 0, buf1, MAX_LOADSTRING);
			ListView_DeleteAllItems(hModuleListView);
			PrintModuleList(Search(hProcessListView), hModuleListView);
		}
		//кликнули на листбокс с процессами правой кнопкой кнопкой мыши
		else if ((lpnmHdr->idFrom == IDC_PROCESS_LISTVIEW) && (lpnmHdr->code == NM_RCLICK))
		{
			HMENU hMenu = CreatePopupMenu();

			AppendMenu(hMenu, MFT_STRING, 10, L"Idle");//неработающий, незанятый 
			AppendMenu(hMenu, MFT_STRING, 11, L"Normal");//11--это id пункта меню
			AppendMenu(hMenu, MFT_STRING, 12, L"High");
			AppendMenu(hMenu, MFT_STRING, 13, L"Real time");

			POINT cp;
			GetCursorPos(&cp);

			TrackPopupMenu(hMenu, TPM_RIGHTBUTTON | TPM_TOPALIGN | TPM_LEFTALIGN, cp.x, cp.y, 0, hWnd, NULL);
		}
	}
		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case 10:
			ChangePriority(L"4", IDLE_PRIORITY_CLASS);
			break;
		case 11:
			ChangePriority(L"7", NORMAL_PRIORITY_CLASS);
			break;
		case 12:
			ChangePriority(L"13", HIGH_PRIORITY_CLASS);
			break;
		case 13:
			ChangePriority(L"24", REALTIME_PRIORITY_CLASS);
			break;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

void CreateListViewes(HWND hWndParent)
{
	const int startX = 10, startY = 0, widthProcessListView = 350, height = 400, deltaX = widthProcessListView + 50,
		widthModuleListView = 600;
	hProcessListView = CreateWindow(WC_LISTVIEW, L"",
		WS_CHILD | LVS_REPORT,
		startX, startY, widthProcessListView, height,
		hWndParent, (HMENU)IDC_PROCESS_LISTVIEW, GetModuleHandle(NULL), NULL);
	// Чтобы определялись строка(item) и столбец(subitem) обязательно устанавливаем
	// расширенный стиль LVS_EX_FULLROWSELECT.
	ListView_SetExtendedListViewStyleEx(hProcessListView, 0, LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);
	
	hModuleListView = CreateWindow(WC_LISTVIEW, L"",
		WS_CHILD | LVS_REPORT,
		startX + deltaX, startY, widthModuleListView, height,
		hWndParent, (HMENU)IDC_MODULE_LISTVIEW, GetModuleHandle(NULL), NULL);
	ListView_SetExtendedListViewStyleEx(hModuleListView, 0, LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);

	ShowWindow(hProcessListView, SW_SHOWDEFAULT);
	ShowWindow(hModuleListView, SW_SHOWDEFAULT);
}

void SetListViewColumns(HWND hWndLV, int colNum, TCHAR* header[2])
{
	RECT rectangle;
	GetClientRect(hWndLV, &rectangle);//размеры listview

	int index = -1; //индекс столбца

	LVCOLUMN lvc;
	lvc.mask = LVCF_TEXT | LVCF_WIDTH;
	lvc.cx = (rectangle.right - rectangle.left) / colNum;
	lvc.cchTextMax = MAX_LOADSTRING;

	for (int i = 0; i < colNum; i++)
	{
		lvc.pszText = (LPWSTR)header[i]; //присваиваем текст
		index = ListView_InsertColumn(hWndLV, i, &lvc);
		if (index == -1) break;
	}

	if (hWndLV == hProcessListView)
	{
		int firstColumnWidth = (int)((rectangle.right - rectangle.left) / 1.3);
		ListView_SetColumnWidth(hWndLV, 0, firstColumnWidth);
		ListView_SetColumnWidth(hWndLV, 1, rectangle.right - firstColumnWidth);
	}
	else if (hWndLV == hModuleListView)
	{
		int firstColumnWidth = (rectangle.right - rectangle.left) / 5;
		ListView_SetColumnWidth(hWndLV, 0, firstColumnWidth);
		ListView_SetColumnWidth(hWndLV, 1, rectangle.right - firstColumnWidth);
	}
}

void PrintProcessList(HWND hWndLV)
{
	PROCESSENTRY32 peProcessEntry;
	TCHAR* szBuff[2];
	wchar_t value[256];
	HANDLE CONST hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (INVALID_HANDLE_VALUE != hSnapshot)
	{
		peProcessEntry.dwSize = sizeof(PROCESSENTRY32);
		Process32First(hSnapshot, &peProcessEntry);
		do {
			szBuff[0] = peProcessEntry.szExeFile; //название процесса
			_itot_s(peProcessEntry.pcPriClassBase, value, 10);
			szBuff[1] = { (TCHAR*)value }; //его приоритет
			AddListViewItems(hWndLV, 2, szBuff);
		} while (Process32Next(hSnapshot, &peProcessEntry));

		CloseHandle(hSnapshot);
	}
}

void PrintModuleList(int proc, HWND hWndLV) 
{
	MODULEENTRY32 meModuleEntry;
	TCHAR* szBuff[2];
	HANDLE CONST hSnapshot = CreateToolhelp32Snapshot(
		TH32CS_SNAPMODULE, proc);
	if (INVALID_HANDLE_VALUE != hSnapshot) 
	{
		meModuleEntry.dwSize = sizeof(MODULEENTRY32);
		Module32First(hSnapshot, &meModuleEntry);
		do {
			szBuff[0] = meModuleEntry.szModule;
			szBuff[1] = meModuleEntry.szExePath;
			AddListViewItems(hWndLV, 2, szBuff);
		} while (Module32Next(hSnapshot, &meModuleEntry));

		CloseHandle(hSnapshot);
	}
}

void WINAPI AddListViewItems(HWND hWndLV, int colNum, TCHAR* item[2])
{
	int iLastIndex = ListView_GetItemCount(hWndLV);

	LVITEM lvi;
	lvi.mask = LVIF_TEXT;
	lvi.cchTextMax = MAX_LOADSTRING;
	lvi.iItem = iLastIndex;
	lvi.pszText = item[0];
	lvi.iSubItem = 0;

	if (ListView_InsertItem(hWndLV, &lvi) != -1)//добавляем строку
	{
		for (int i = 1; i < colNum; i++)//вставляем туда текст
		{
			ListView_SetItemText(hWndLV, iLastIndex, i, item[i]);
		}
	}
}

int Search(HWND hWndLV)
{
	HANDLE CONST hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (INVALID_HANDLE_VALUE != hSnapshot) 
	{
		PROCESSENTRY32 peProcessEntry;
		peProcessEntry.dwSize = sizeof(PROCESSENTRY32);
		Process32First(hSnapshot, &peProcessEntry);
		do {
			if ((wcscmp(peProcessEntry.szExeFile, buf1)) == 0)
			{
				return peProcessEntry.th32ProcessID;
			}
		} while (Process32Next(hSnapshot, &peProcessEntry));

		CloseHandle(hSnapshot);
	}

	return -1;
}

void ChangePriority(TCHAR* priorityIndex, int priorityClass)
{
	ListView_GetItemText(hProcessListView, SendMessage(hProcessListView, LVM_GETNEXTITEM, -1, LVNI_SELECTED), 0, buf1, MAX_LOADSTRING);
	SetPriorityClass(OpenProcess(PROCESS_ALL_ACCESS, FALSE, Search(hProcessListView)), priorityClass);
	ListView_SetItemText(hProcessListView, SendMessage(hProcessListView, LVM_GETNEXTITEM, -1, LVNI_SELECTED), 1, priorityIndex);
}



// Message handler for about box.
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
