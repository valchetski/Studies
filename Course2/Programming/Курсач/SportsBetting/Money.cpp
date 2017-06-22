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
#include "WorkWithFile.h"  
#include "Money.h"

//---------------------------------------------------------------------------

#pragma package(smart_init)
void LoadMoneyFromFile(string path)
{
        //сохранение денег переделай, епта
        ifstream file(path.c_str());
        string str;
        while(!file.eof() && file != NULL)
	{
                getline(file, str, ' ');
		if ((!str.empty()) && (str != "\n"))
                {
                        Cash newMoney;
                        newMoney.money = StrToFloat(str.c_str());
                        getline(file, str, '\n');
                        newMoney.currency = str;
                        allMoney.push_back(newMoney); 
                }
        }
}

void MoneyDefault()
{
        Cash temp;
        temp.money = 0;
        temp.currency = "BLR";
        allMoney.push_back(temp);
        temp.money = 0;
        temp.currency = "RR";
        allMoney.push_back(temp);
        temp.money = 0;
        temp.currency = "USD";
        allMoney.push_back(temp);
        temp.money = 0;
        temp.currency = "EUR";
        allMoney.push_back(temp);
}




