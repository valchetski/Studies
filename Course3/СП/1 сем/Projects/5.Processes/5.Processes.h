#pragma once

#include "resource.h"

void CreateListViewes(HWND hWndParent);
void SetListViewColumns(HWND hWndLV, int colNum, TCHAR* header[2]);
void WINAPI AddListViewItems(HWND hWndLV, int colNum, TCHAR* item[2]);
void PrintProcessList(HWND hWndLV);
int Search(HWND hWndLV);
void PrintModuleList(int proc, HWND hWndLV);
void ChangePriority(TCHAR* priorityIndex, int priorityClass);
