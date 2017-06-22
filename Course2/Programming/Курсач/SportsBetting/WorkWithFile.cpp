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
using namespace System;


//---------------------------------------------------------------------------
#pragma package(smart_init)

void LoadSports()
{
	string fileName = "Football.txt";
	LoadSport(fileName, football);
        fileName = "Hockey.txt";
	LoadSport(fileName, hockey);
        fileName = "Basketball.txt";
	LoadSport(fileName, basketball);
}

void LoadSport(string fileName, list<Match>& sport)
{
        ifstream file(fileName.c_str());
	string str;
	Match currencyMatch;
	while(!file.eof())
	{
		getline(file, str, ' ');
		if (str.empty() || str == "\n")
			continue;
		currencyMatch.date = str;
		getline(file, str, ' ');
		currencyMatch.time = str;
		getline(file, str, ' ');
		currencyMatch.home = str;
		getline(file, str, ' ');
		currencyMatch.guest = str;
		getline(file, str, ' ');
		currencyMatch.winnerHome = StrToFloat(str.c_str());
                double sdaf = currencyMatch.winnerHome;
                currencyMatch.winnerHome = int(sdaf*100 + 0.5)/100.0;
		getline(file, str, ' ');
		currencyMatch.draw = StrToFloat(str.c_str());
                double sdaf1 = currencyMatch.draw;
                currencyMatch.draw = int(sdaf1*100 + 0.5)/100.0;
		getline(file, str, '\n');
		currencyMatch.winnerGuest = StrToFloat(str.c_str());
                double sdaf2 = currencyMatch.winnerGuest;
                currencyMatch.winnerGuest = int(sdaf2*100 + 0.5)/100.0;
                sport.push_back(currencyMatch);
	}
}

void SaveSports()
{
        string fileName = "Football.txt";
	SaveSport(fileName, football);
        fileName = "Hockey.txt";
	SaveSport(fileName, hockey);
        fileName = "Basketball.txt";
	SaveSport(fileName, basketball);
}

void SaveSport(string fileName, list<Match> sport)
{
        ofstream file(fileName.c_str());
        int size = sport.size();
        list<Match> copySport = sport;
        for (int i = 0; i < size; i++)
        {
                Match temp = copySport.front();
                copySport.pop_front();
                file << temp.date << " ";
                file << temp.time << " ";
                file << temp.home << " ";
                file << temp.guest << " ";
                file << temp.winnerHome << " ";
                file << temp.draw << " ";
                file << temp.winnerGuest << "\n";
        }
}

list<Match> TodayMathes(list<Match> sport, string currencyData)
{
        int size = sport.size();
        list<Match> returnList;
        for (int i = 0; i < size; i++)
        {
                Match temp = sport.front();
                sport.pop_front();
                if (temp.date == currencyData)
                {
                        returnList.push_back(temp);
                }
        }
        return returnList;
}

list<Match> ChoiceSport(TComboBox *choiceSport)
{
        switch(choiceSport->ItemIndex)
        {
                case 0:
                        return football;
                case 1:
                        return hockey;
                case 2:
                        return basketball;
                default:
                        return football;
        }
}

