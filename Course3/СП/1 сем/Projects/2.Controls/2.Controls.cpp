// 2.Controls.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "2.Controls.h"

#define MAX_LOADSTRING 1000

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

HWND hWndAddButton, hWndClearButton, hWndToRightButton, hWndDeleteButton, hEdit,
	hLeftListBox, hRightListBox;


int APIENTRY _tWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPTSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;////////////
	HACCEL hAccelTable;


	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_MY2CONTROLS, szWindowClass, MAX_LOADSTRING);

	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY2CONTROLS));

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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY2CONTROLS));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MY2CONTROLS);
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

		SetWindowPos(hWnd, 0, 0, 0, 300, 250, SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE);//размер окна

		CreateButtons(hWnd);
		CreateEdit(hWnd);
		CreateListBoxes(hWnd);
		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		case IDC_ADD_BUTTON:
			SendMessage(hLeftListBox, LB_SETHORIZONTALEXTENT, 130, 0);
			FromEditToLeftListBox(hWnd);			
			break;
		case IDC_CLEAR_BUTTON:
			ClearListBoxes();
			SendMessage(hLeftListBox, LB_SETHORIZONTALEXTENT, 0, 0);
			SendMessage(hRightListBox, LB_SETHORIZONTALEXTENT, 0, 0);
			//SendMessage(hLeftListBox, LB_RESETCONTENT, NULL, 0);

			break;
		case IDC_TORIGHT_BUTTON:
			SendMessage(hRightListBox, LB_SETHORIZONTALEXTENT, 130, 0);

			AddToRightListBox(hWnd);
			break;
		case IDC_DELETE_BUTTON:
			DeleteTextFromListBox(hLeftListBox);
			DeleteTextFromListBox(hRightListBox);
			break;

		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
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

void CreateButtons(HWND hWnd)
{
	int buttonWidth = 60;
	int buttonHeight = 24;

	int deltaX = 67;
	int x = 10;
	int y = 150;

	hWndAddButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Add"),
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		x,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_ADD_BUTTON,
		GetModuleHandle(NULL),
		NULL);

	hWndClearButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Clear"),
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		x + deltaX,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_CLEAR_BUTTON,
		GetModuleHandle(NULL),
		NULL);

	hWndToRightButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("To right"),
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		x + 2*deltaX,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_TORIGHT_BUTTON,
		GetModuleHandle(NULL),
		NULL);

	hWndDeleteButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Delete"),
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		x + 3*deltaX,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_DELETE_BUTTON,
		GetModuleHandle(NULL),
		NULL);
}

void CreateEdit(HWND hWnd)
{
	hEdit = CreateWindowEx(WS_EX_CLIENTEDGE,
		_T("EDIT"),
		_T("edit"),
		WS_CHILD | WS_VISIBLE | ES_MULTILINE | ES_AUTOVSCROLL | ES_AUTOHSCROLL,
		10,
		120,
		260,
		20,
		hWnd,
		(HMENU)IDC_EDIT,
		GetModuleHandle(NULL),
		NULL);
}

void CreateListBoxes(HWND hWnd)
{
	int width = 130;
	int height = 100;
	int x = 10;
	int y = 10;

	hLeftListBox = CreateWindowExW(WS_EX_CLIENTEDGE
		, L"LISTBOX", NULL
		, WS_CHILD | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL
		, x, y, width, height
		, hWnd, NULL, hInst, NULL);


	hRightListBox = CreateWindowExW(WS_EX_CLIENTEDGE
		, L"LISTBOX", NULL
		, WS_CHILD | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL
		, x + width, y, width, height
		, hWnd, NULL, hInst, NULL);
}

void FromEditToLeftListBox(HWND hWnd)
{
	TCHAR editText[MAX_LOADSTRING];
	GetWindowText(hEdit, editText, lstrlen(editText));
	AddToListBox(hWnd, editText, hLeftListBox);
}

void AddToListBox(HWND hWnd, TCHAR* addingText, HWND listBox)
{
	TCHAR listBoxText[MAX_LOADSTRING];
	
	int count = SendMessage(listBox, LB_GETCOUNT, 0, 0);

	if (count == 0)
	{
		SendMessage(listBox, LB_ADDSTRING, 0, (LPARAM)addingText);
	}
	else
	{
		bool isStringAlreadyExist = false;
		for (int i = 0; i < count; i++)
		{
			SendMessage(listBox, LB_GETTEXT, (WPARAM)i, (LPARAM)listBoxText);

			if (_tcscmp(listBoxText, addingText) == false)//когда строки одинаковые
			{
				isStringAlreadyExist = true;
				break;
			}
		}

		if (isStringAlreadyExist == false)
		{
			SendMessage(listBox, LB_ADDSTRING, 0, (LPARAM)addingText);
		}
	}
}

void AddToRightListBox(HWND hWnd)
{	
	TCHAR leftListBoxText[MAX_LOADSTRING];

	int selectedItem = SendMessage(hLeftListBox, LB_GETCURSEL, 0, 0);

	if (selectedItem > -1)
	{
		SendMessage(hLeftListBox, LB_GETTEXT, (WPARAM)selectedItem, (LPARAM)leftListBoxText);
		AddToListBox(hWnd, leftListBoxText, hRightListBox);
	}
	//SendMessage(hLeftListBox, LB_SETCURSEL, -1, 0);
}

void ClearListBoxes()
{
	SendMessage(hLeftListBox, LB_RESETCONTENT, 0, 0);
	SendMessage(hRightListBox, LB_RESETCONTENT, 0, 0);
}

void DeleteTextFromListBox(HWND listBox)
{
	int selectedItem = SendMessage(listBox, LB_GETCURSEL, 0, 0);
	if (selectedItem > -1)
	{
		SendMessage(listBox, LB_DELETESTRING, selectedItem, 0);
	}
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
