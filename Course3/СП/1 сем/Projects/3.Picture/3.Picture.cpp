// 3.Picture.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "3.Picture.h"

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




HWND hWndPrintButton, hWndClearButton;
HDC hCompDC;
HBITMAP hCompBmp;
HPEN hRedPen;
POINT PaintArea[2];

bool isPrint = false;



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
	LoadString(hInstance, IDC_MY3PICTURE, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MY3PICTURE));

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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MY3PICTURE));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MY3PICTURE);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	PaintArea[0].x = 0; PaintArea[0].y = 50;
	PaintArea[1].x = 800; PaintArea[1].y = 600;

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


	POINT point[4];
	
	switch (message)
	{
	case WM_CREATE:
		SetWindowPos(hWnd, 0, 0, 0, 600, 400, SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE);//размер окна
		CreateButtons(hWnd);
		break;
	case WM_COMMAND:
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDC_ADD_BUTTON:
			isPrint = true;
			InvalidateRect(hWnd, NULL, TRUE);
			break;
		case IDC_CLEAR_BUTTON:
			isPrint = false;
			InvalidateRect(hWnd, NULL, TRUE);
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
	case WM_DRAWITEM:
	{
		LPDRAWITEMSTRUCT pdis = (LPDRAWITEMSTRUCT)lParam;
		FillRect(pdis->hDC, &pdis->rcItem,  //внутренняя заливка кнопки
			(HBRUSH)GetStockObject(WHITE_BRUSH));
		FrameRect(pdis->hDC, &pdis->rcItem, //обводка кнопки
			(HBRUSH)GetStockObject(BLACK_BRUSH));
		switch (pdis->CtlID)
		{
		case IDC_ADD_BUTTON:
		{
			const int deltaX = 5;
			const int deltaY = 10;
			point[0].x = 15;  point[0].y = 14;
			point[1].x = point[0].x - deltaX;  point[1].y = point[0].y + deltaY;
			point[2].x = point[0].x + deltaX;  point[2].y = point[0].y + deltaY;
			SelectObject(pdis->hDC, GetStockObject(BLACK_BRUSH)); //заливаем прямоугольник черным
			Polygon(pdis->hDC, point, 3); //рисует треугольник

			DrawTextA(pdis->hDC, "Paint", -1, &pdis->rcItem, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
			SelectObject(pdis->hDC, GetStockObject(WHITE_BRUSH));
		}
			break;
		case IDC_CLEAR_BUTTON:
		{
			SelectObject(pdis->hDC, GetStockObject(BLACK_BRUSH));
			const int left = 15;
			const int radius = left + 10;
			Ellipse(pdis->hDC, left, left, radius, radius); // рисует кружок в Clear

			DrawTextA(pdis->hDC, "Clear", -1, &pdis->rcItem, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
			SelectObject(pdis->hDC, GetStockObject(WHITE_BRUSH));
		}
			break;
		}
		if (pdis->itemState & ODS_SELECTED) //когда нажато--инвертирует цвет заливки
			InvertRect(pdis->hDC, &pdis->rcItem);
	}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		if (isPrint)
		{
			PrintLocomotive(hWnd, hdc);
		}
		else
		{
			hCompDC = NULL;
			BitBlt(hdc, PaintArea[0].x, PaintArea[0].y, PaintArea[1].x, PaintArea[1].y, hCompDC, 0, 0, SRCCOPY);
		}
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

BOOL Line(HDC hdc, int x1, int y1, int x2, int y2)
{
	MoveToEx(hdc, x1, y1, NULL); //сделать текущими координаты x1, y1
	return LineTo(hdc, x2, y2);
}

void CreateButtons(HWND hWnd)
{
	int buttonWidth = 100;
	int buttonHeight = 40;

	int deltaX = buttonWidth + 7;
	int x = 10;
	int y = 10;

	hWndPrintButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Add"),
		WS_VISIBLE | WS_CHILD | BS_OWNERDRAW,
		x,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_ADD_BUTTON,
		hInst,
		NULL);

	hWndClearButton = CreateWindowEx(NULL,
		_T("BUTTON"),
		_T("Clear"),
		WS_VISIBLE | WS_CHILD | BS_OWNERDRAW,
		x + deltaX,
		y,
		buttonWidth,
		buttonHeight,
		hWnd,
		(HMENU)IDC_CLEAR_BUTTON,
		hInst,
		NULL);
}

void PrintLocomotive(HWND hWnd, HDC hdc)
{
	RECT rectangle;
	POINT point[4];

	GetClientRect(hWnd, &rectangle); //размер окна
	hCompDC = CreateCompatibleDC(hdc);
	hCompBmp = CreateCompatibleBitmap(hdc, rectangle.right - rectangle.left, rectangle.bottom - rectangle.top);
	SelectObject(hCompDC, hCompBmp);
	hRedPen = CreatePen(PS_SOLID, 2, 0x0000FF); //ручкой будем рисовать
	SelectObject(hCompDC, hRedPen);
	FillRect(hCompDC, &rectangle, (HBRUSH)WHITE_BRUSH);//заливочка

	
	const int waggonageWidth = 250;
	const int leftWaggonageX1 = 100, rightWaggonageX1 = leftWaggonageX1 + waggonageWidth + 10;
	const int waggonageY1 = 100, waggonageY2 = waggonageY1 + 110; //от этого будет зависеть высота всего рисунка

	const int funnelX1 = leftWaggonageX1 + 20;
	const int funnelWidth = 20;
	const int funnelY1 = waggonageY1 - 50;

	Rectangle(hCompDC, funnelX1, funnelY1, funnelX1 + funnelWidth, waggonageY1);//труба
	Rectangle(hCompDC, leftWaggonageX1, waggonageY1, leftWaggonageX1 + waggonageWidth, waggonageY2);//контур левого вагона
	Rectangle(hCompDC, rightWaggonageX1, waggonageY1, rightWaggonageX1 + waggonageWidth, waggonageY2);//контур правого вагона

	const int deltaX = 60;
	const int width = 50;
	
	const int firstWheelX1 = leftWaggonageX1 + 10, secondWheelX1 = firstWheelX1 + deltaX, thirdWheelX1 = secondWheelX1 + deltaX,
		fourthWheelX1 = thirdWheelX1 + deltaX;

	const int wheelY1 = waggonageY2;
	const int wheelY2 = wheelY1 + width;
	Ellipse(hCompDC, firstWheelX1, wheelY1, firstWheelX1 + width, wheelY2); //колеса левого вагона
	Ellipse(hCompDC, secondWheelX1, wheelY1, secondWheelX1 + width, wheelY2);
	Ellipse(hCompDC, thirdWheelX1, wheelY1, thirdWheelX1 + width, wheelY2);
	Ellipse(hCompDC, fourthWheelX1, wheelY1, fourthWheelX1 + width, wheelY2);

	const int fifthWheelX1 = rightWaggonageX1 + 10, sixthWheelX1 = fifthWheelX1 + deltaX, seventhWheelX1 = sixthWheelX1 + deltaX,
		eighthWheelX1 = seventhWheelX1 + deltaX;
	
	Ellipse(hCompDC, fifthWheelX1, wheelY1, fifthWheelX1 + width, wheelY2);//колеса правого вагона
	Ellipse(hCompDC, sixthWheelX1, wheelY1, sixthWheelX1 + width, wheelY2);
	Ellipse(hCompDC, seventhWheelX1, wheelY1, seventhWheelX1 + width, wheelY2);
	Ellipse(hCompDC, eighthWheelX1, wheelY1, eighthWheelX1 + width, wheelY2);

	const int roadYUp = wheelY2;
	const int roadYDown = wheelY2 + 20;	
	Line(hCompDC, 0, roadYUp, rectangle.right, roadYUp);//рисуем дорогу
	Line(hCompDC, 0, roadYDown, rectangle.right, roadYDown);


	Arc(hCompDC, funnelX1, funnelY1 - 30, funnelX1 + 30, funnelY1 + 30, funnelX1 + 20, funnelY1 - 20, funnelX1, funnelY1);//дымок из трубы
	Arc(hCompDC, funnelX1 + 5, funnelY1 - 25, funnelX1 + 40, funnelY1 + 30, funnelX1 + 30, funnelY1 - 25, funnelX1, funnelY1);
	Arc(hCompDC, funnelX1 + 10, funnelY1 - 25, funnelX1 + 80, funnelY1 + 30, funnelX1 + 35, funnelY1 - 25, funnelX1 + 30, funnelY1);
	Arc(hCompDC, funnelX1 + 15, funnelY1 - 25, funnelX1 + 100, funnelY1 + 30, funnelX1 + 50, funnelY1 - 25, funnelX1 + 40, funnelY1);

	

	const int widthDoor = 60, heightDoor = 80;
	const int offset = 15;

	point[0].x = leftWaggonageX1 + offset;  point[0].y = waggonageY2; //дверь левого вагона
	point[1].x = leftWaggonageX1 + offset; point[1].y = waggonageY2 - heightDoor;
	point[2].x = leftWaggonageX1 + widthDoor; point[2].y = waggonageY2 - heightDoor;
	point[3].x = leftWaggonageX1 + widthDoor; point[3].y = waggonageY2;
	Polyline(hCompDC, point, 4);

	point[0].x = rightWaggonageX1 + offset; point[0].y = waggonageY2;//дверь правого вагона
	point[1].x = rightWaggonageX1 + offset; point[1].y = waggonageY2 - heightDoor;
	point[2].x = rightWaggonageX1 + widthDoor; point[2].y = waggonageY2 - heightDoor;
	point[3].x = rightWaggonageX1 + widthDoor; point[3].y = waggonageY2;
	Polyline(hCompDC, point, 4);

	BitBlt(hdc, PaintArea[0].x, PaintArea[0].y, PaintArea[1].x, PaintArea[1].y, hCompDC, 0, 0, SRCCOPY);//задается расположение изображения
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
