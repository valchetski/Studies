//---------------------------------------------------------------------------


#pragma hdrstop
#include <vcl.h>
#include <iostream>
#include <string>
#include <Windows.h>
#include <string.h>
#include <fstream>
#include <locale.h>
#include <list>
#include <cstring.h>
#include <cstdio>
#include "MadeBet.h"
using namespace std;
using namespace System;

//---------------------------------------------------------------------------

#pragma package(smart_init)
void LoadResult()
{
        ifstream file("Results.txt");
	string str;
	while(!file.eof())
	{
                Result newResult;
		getline(file, str, ' ');
		if (str.empty() || str == "\n")
			continue;
		newResult.date = str;
		getline(file, str, ' ');
		newResult.home = str;
		getline(file, str, ' ');
		newResult.guest = str;
		getline(file, str, '\n');
		newResult.result = str;
                resultList.push_back(newResult);
	}
}

void SaveResult()
{
        ofstream file("Results.txt");
        int size = resultList.size();
        list<Result> copyResultList = resultList;
        for (int i = 0; i < size; i++)
        {
                Result temp = copyResultList.front();
                copyResultList.pop_front();
                file << temp.date << " ";
                file << temp.home << " ";
                file << temp.guest << " ";
                file << temp.result << "\n";
        }
}


