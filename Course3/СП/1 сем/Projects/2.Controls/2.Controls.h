#pragma once

#include "resource.h"

void CreateButtons(HWND hWnd);
void CreateEdit(HWND hWnd);
void CreateListBoxes(HWND hWnd);

void AddToListBox(HWND hWnd, TCHAR* addingText, HWND listBox);
void FromEditToLeftListBox(HWND hWnd);
void AddToRightListBox(HWND hWnd);

void ClearListBoxes();

void DeleteTextFromListBox(HWND listBox);