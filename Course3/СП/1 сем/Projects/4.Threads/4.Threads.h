#pragma once

#include "resource.h"

struct ThreadManager
{	
	HWND hwndParent;
	TCHAR* name;
	int rectangleWidth = 90;
	int rectangleHeight = 70;
	RECT rectangle;
};

enum UserMsg { UM_THREAD_DONE = WM_USER + 1 };


void CreateButtons(HWND hWnd);
DWORD WINAPI ThreadFunc(LPVOID  Ipv);
HANDLE CreateThread(HWND hWnd, ThreadManager threadManager);
int Random(int maxNumber);