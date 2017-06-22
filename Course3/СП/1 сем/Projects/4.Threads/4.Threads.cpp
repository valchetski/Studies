// 4.Threads.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "4.Threads.h"
#include <stdlib.h>
#include <ctime>

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


ThreadManager tm_A, tm_B, tm_C, tm_D;
RECT rectangles[4];
TCHAR* names[4];

HWND hStartButton, hStopButton;
int threadNumber = 0;
bool isAllThreadCompleted = false;
bool doesntDrawPlease = true;
const int timeToRedraw = 5000;
int currentTime = timeToRedraw;

HDC hCompDC;
HBITMAP hCompBmp;
HPEN hRedPen;
POINT PaintArea[2];


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
	LoadString(hInstance, IDC_MY4THREADS, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY4THREADS));

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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY4THREADS));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MY4THREADS);
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

	static HANDLE hThreadA, hThreadB, hThreadC, hThreadD;
	bool isStop = false;

	RECT rectangle;

	ThreadManager* pTm;

	switch (message)
	{
	case WM_CREATE:
		CreateButtons(hWnd);
		SetWindowPos(hWnd, 0, 0, 0, 800, 600, SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE);//размер окна
		PaintArea[0].x = 0; PaintArea[0].y = 50;
		PaintArea[1].x = 800; PaintArea[1].y = 600;
		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDC_STARTBUTTON:
			if (hThreadA == NULL)
			{
				SetTimer(hWnd, 1, 1000, NULL);
				tm_A.hwndParent = hWnd;
				tm_A.name = _T("Thread 1");
				hThreadA = CreateThread(NULL, 0, ThreadFunc, &tm_A, 0, NULL);
				if (!hThreadA)
					MessageBox(hWnd, L"Error of create hThreadA", NULL, MB_OK);
				tm_B.hwndParent = hWnd;
				tm_B.name = L"Thread 2";
				hThreadB = CreateThread(NULL, 0, ThreadFunc, &tm_B, 0, NULL);
				if (!hThreadB)
					MessageBox(hWnd, L"Error of create hThreadB", NULL, MB_OK);
				tm_C.hwndParent = hWnd;
				tm_C.name = L"Thread 3";
				hThreadC = CreateThread(NULL, 0, ThreadFunc, &tm_C, 0, NULL);
				if (!hThreadC)
					MessageBox(hWnd, L"Error of create hThreadC", NULL, MB_OK);
				tm_D.hwndParent = hWnd;
				tm_D.name = L"Thread 4";
				hThreadC = CreateThread(NULL, 0, ThreadFunc, &tm_D, 0, NULL);
				if (!hThreadC)
					MessageBox(hWnd, L"Error of create hThreadD", NULL, MB_OK);
			}
			else
			{
				ResumeThread(hThreadA);
				ResumeThread(hThreadB);
				ResumeThread(hThreadC);
				ResumeThread(hThreadD);
				isStop = false;
			}			
			
			break;
		case IDC_STOPBUTTON:
			if (!isStop)
			{
				SuspendThread(hThreadA);
				SuspendThread(hThreadB);
				SuspendThread(hThreadC);
				SuspendThread(hThreadD);
				isStop = true;
			}
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

	case WM_TIMER:
		currentTime -= 1000;
		if (currentTime == 0)
		{
			currentTime = timeToRedraw;
		}
		break;
	case WM_PAINT:
	{
		hdc = BeginPaint(hWnd, &ps);

		
		if (isAllThreadCompleted && doesntDrawPlease == false)
		{
			GetClientRect(hWnd, &rectangle); //размер окна
			hCompDC = CreateCompatibleDC(hdc);
			hCompBmp = CreateCompatibleBitmap(hdc, rectangle.right - rectangle.left, rectangle.bottom - rectangle.top);
			SelectObject(hCompDC, hCompBmp);
			hRedPen = CreatePen(PS_SOLID, 2, 0x0000FF); //ручкой будем рисовать
			SelectObject(hCompDC, hRedPen);
			FillRect(hCompDC, &rectangle, (HBRUSH)WHITE_BRUSH);//заливочка		

			for (int i = 0; i < threadNumber; i++)
			{
				int deltaX = Random(400);
				int left = rectangles[i].left + deltaX;
				int deltaY = Random(200);
				Rectangle(hCompDC, left, rectangles[i].top + deltaY, rectangles[i].right + deltaX, rectangles[i].bottom + deltaY);
				TextOut(hCompDC, left + 10, rectangles[i].top + 25 + deltaY, (LPWSTR)names[i], 8);
			}

			threadNumber = 0;
			

			BitBlt(hdc, PaintArea[0].x, PaintArea[0].y, PaintArea[1].x, PaintArea[1].y, hCompDC, 0, 0, SRCCOPY);
			isAllThreadCompleted = false;
		}
		else if (doesntDrawPlease)
		{
			GetClientRect(hWnd, &rectangle); //размер окна
			hCompDC = CreateCompatibleDC(hdc);
			hCompBmp = CreateCompatibleBitmap(hdc, rectangle.right - rectangle.left, rectangle.bottom - rectangle.top);
			SelectObject(hCompDC, hCompBmp);
			hRedPen = CreatePen(PS_SOLID, 2, 0x0000FF); //ручкой будем рисовать
			SelectObject(hCompDC, hRedPen);
			FillRect(hCompDC, &rectangle, (HBRUSH)WHITE_BRUSH);//заливочка
			threadNumber = 0;			
		}

		//char buffer[20];
		//_itoa_s(currentTime / 1000, buffer, 20);
		//TextOutA(hdc, 300, 10, buffer, 1);

		EndPaint(hWnd, &ps);
	}
		break;
	case UM_THREAD_DONE:		
		pTm = (ThreadManager*)wParam;
		rectangles[threadNumber] = pTm->rectangle;
		names[threadNumber] = pTm->name;
		threadNumber++;
		if (threadNumber == 4)
		{
			isAllThreadCompleted = true;
			doesntDrawPlease = !doesntDrawPlease;
			InvalidateRect(hWnd, NULL, TRUE);			
		}
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
	int y = 10;


	hStartButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Start"),
		WS_VISIBLE | WS_CHILD | BS_PUSHBUTTON,
		x,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_STARTBUTTON,
		hInst,
		NULL);

	hStopButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Stop"),
		WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
		x + deltaX,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_STOPBUTTON,
		hInst,
		NULL);
}


DWORD WINAPI ThreadFunc(LPVOID  Ipv)
{
	while (true)
	{
		ThreadManager* pTm = (ThreadManager*)Ipv;
		pTm->rectangle.left = Random(300);
		pTm->rectangle.top = Random(200);
		pTm->rectangle.right = pTm->rectangle.left + pTm->rectangleWidth;
		pTm->rectangle.bottom = pTm->rectangle.top + pTm->rectangleHeight;
		SendMessage(pTm->hwndParent, UM_THREAD_DONE, (WPARAM)pTm, 0);
		Sleep(timeToRedraw);
	}
	
	return 0;
}

int Random(int maxNumber)
{
	int result = rand() % maxNumber;
	return result;
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
