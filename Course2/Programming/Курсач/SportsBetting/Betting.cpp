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
#include "Betting.h"
using namespace std;
using namespace System;
//---------------------------------------------------------------------------

#pragma package(smart_init)

void AddBetList(list<Bet>& betList, string resultMatch, float koef, string date, string time, string teamHome, string teamGuest)
{
        Bet newBet;
        newBet.date = date;
        newBet.home = teamHome;
        newBet.guest = teamGuest;
        newBet.resultMatch = resultMatch;
        newBet.coefficient = koef;
        //т.к. ставка занесена в список, но на нее еще не поставлены деньги
        //заносим в пол€ значени€ по умолчанию
        newBet.money = defaultMoney;
        newBet.currency = defaultCurrency;
        newBet.isBetTreatment = false;
        newBet.winning = 0;
        betList.push_back(newBet);
}

void DeleteBetList(list<Bet>& betList, string date, string time, string teamHome, string teamGuest, string resultMatch)
{
        Bet deleteBet;
        deleteBet.date = date;
        deleteBet.home = teamHome;
        deleteBet.guest = teamGuest;
        deleteBet.resultMatch = resultMatch;
        int size = betList.size();
        list<Bet> copyBetList = betList;
        Bet temp;
        for (int i = 0; i < size; i++)
        {
                temp = copyBetList.front();
                copyBetList.pop_front();
                if ((temp.date == deleteBet.date) && (temp.home == deleteBet.home) && (temp.guest == deleteBet.guest) && (temp.resultMatch == deleteBet.resultMatch))
                {
                        break;
                }
        } 
        //т.к. не работает нормальное удаление, то очищаем список
        //и перезаписывем, не добавл€€ удал€емый элемент
        copyBetList.clear();
        copyBetList = betList;
        betList.clear();
        for (int i = 0; i < size; i++)
        {
                temp = copyBetList.front();
                copyBetList.pop_front();
                if ((temp.date == deleteBet.date) && (temp.home == deleteBet.home) && (temp.guest == deleteBet.guest) && (temp.resultMatch == deleteBet.resultMatch))
                {
                        continue;
                }
                betList.push_back(temp);
        }
}

void SaveOrdinarToFile(List& betList, ofstream& file, string currency, float money)
{
        int size = betList.size();
        for (int i = 0; i < size; i++)
        {
                file << "ќрдинар" << "\t\n";
                Bet temp = betList.front();
                betList.pop_front();
                file << temp.date << "\t";
                file << temp.home << " ";
                file << temp.guest << " ";
                file << temp.resultMatch << " ";
                double sdaf = temp.coefficient;
                temp.coefficient = int(sdaf*100 + 0.5)/100.0;
                string str = (FloatToStr(temp.coefficient)).c_str();
                file << str << " ";
                if ((money == defaultMoney) && (currency == defaultCurrency))
                {
                        file << temp.money << " ";
                        file << temp.currency << " ";
                }
                else
                {
                        file << (FloatToStr(money)).c_str() << " ";
                        file << currency << " ";
                }
                file << temp.isBetTreatment << " ";
                file << temp.winning << "\n";
        }
}

void SaveExpressToFile(List& betList, ofstream& file, string currency, float money)
{
        file << "Ёкспресс" << "\t\n";
        int size = betList.size();
        for (int i = 0; i < size; i++)
        {
                Bet temp = betList.front();
                betList.pop_front();
                file << temp.date << "\t";
                file << temp.home << " ";
                file << temp.guest << " ";
                file << temp.resultMatch << " ";
                file << temp.coefficient << " ";
                if ((money == defaultMoney) && (currency == defaultCurrency))
                {
                        file << temp.money << " ";
                        file << temp.currency << " ";
                }
                else
                {
                        file << (FloatToStr(money)).c_str() << " ";
                        file << currency << " ";
                }
                file << temp.isBetTreatment << " ";
                file << temp.winning << "\n";
        }
        file << "/Ёкспресс" << "\t\n";
}

void SaveSystemToFile(List& betList, ofstream& file, string currency, float money, string dimension)
{
        file << "—истема" << "\t\n";
        int size = betList.size();
        file << dimension << "\n";
        for (int i = 0; i < size; i++)
        {
                Bet temp = betList.front();
                betList.pop_front();
                file << temp.date << "\t";
                file << temp.home << " ";
                file << temp.guest << " ";
                file << temp.resultMatch << " ";
                file << temp.coefficient << " ";
                if ((money == defaultMoney) && (currency == defaultCurrency))
                {
                        file << temp.money << " ";
                        file << temp.currency << " ";
                }
                else
                {
                        file << (FloatToStr(money)).c_str() << " ";
                        file << currency << " ";
                }
                file << temp.isBetTreatment << " ";
                file << temp.winning << "\n";
        }
        file << "/—истема" << "\t\n";
} 

list<float> AllCoef(TMemo *Memo1, TComboBox *choiceBet, float money, int dimension)
{
        list<float> koefList;
        list<float> returnList;
        if (Memo1->Lines->Strings[0] != emptyCoupon.c_str())
        {
                int numberMatches = Memo1->Lines->Count;
                for (int i = 0; i < numberMatches; i++) //добавл€ем все коэффициенты в список
                {
                        if (((i + 1) % 2) == 0) //в Memo в каждой четной строчке есть коэффициенты
                        {
                                list<string> matchik = Parse((Memo1->Lines->Strings[i]).c_str());
                                string opa = matchik.back().c_str();
                                float koef = StrToFloat(opa.c_str());
                                koefList.push_back(koef);
                        }
                }
                switch(choiceBet->ItemIndex)
                {
                        case 0:
                                returnList = CalculateOrdinar(koefList, money);
                                break;
                        case 1:
                                returnList = CalculateExpress(koefList, money);
                                break;
                        case 2:
                                returnList = CalculateSystem(koefList, money, dimension);
                                break;
                }
        }
        else
        {
                returnList.push_back(0);
                returnList.push_back(0);
                returnList.push_back(0);
        }
        return returnList;
}

list<float> CalculateOrdinar(list<float> koefList, float money)
{
        int size = koefList.size();
        float win = 0;
        for (int i = 0; i < size; i++)
        {
                float koef = koefList.front();
                koefList.pop_front();
                win += koef * money;
        }
        float allMoney = money * size;
        list<float> resultBet;
        float resultKoef = 1;
        resultBet.push_back(allMoney);
        resultBet.push_back(win);
        resultBet.push_back(resultKoef);
        return resultBet;
}

list<float> CalculateExpress(list<float> koefList, float money)
{
        int size = koefList.size();
        float resultKoef = 1;
        for (int i = 0; i < size; i++)
        {
                float koef = koefList.front();
                koefList.pop_front();
                resultKoef *= koef;
        }
        float win = resultKoef * money;
        float allMoney = money;
        list<float> resultBet;
        resultBet.push_back(allMoney);
        resultBet.push_back(win);
        resultBet.push_back(resultKoef);
        return resultBet;
}

list<float> CalculateSystem(list<float> koefList, float money, int dimension)
{
        int size = koefList.size();
        float moneyOnOneBet = money / size;
        list<intList> allCombination = overkill(size, dimension); //получаем все возможные комбинации
        size = allCombination.size();
        list<float> combinationCoefficients;
        float winMoney = 0;;
        for (int i = 0; i < size; i++)
        {
                intList oneCombination = allCombination.front();
                allCombination.pop_front();
                float winOneBet = moneyOnOneBet;
                for(int j = 0; j < dimension; j++)
                {
                        int numberCoef = oneCombination.front();
                        oneCombination.pop_front();
                        float coef = GetElementList(koefList, numberCoef);
                        winOneBet *= coef;
                }
                winMoney += winOneBet;
        }
        list<float> resultBet;
        resultBet.push_back(money);
        resultBet.push_back(winMoney);
        resultBet.push_back(1);//т.к. общего кэфа у ставок —истема нету. то просто добавл€ем в список значение 1
        return resultBet;
}

float GetElementList(list<float> koefList, int number)
{
        float element = 0;
        for(int i = 1; i <= number; i++)
        {
                element = koefList.front();
                koefList.pop_front();
        }
        return element;
}

list<intList> overkill(int size, int dimension)
{
        const int a[7] = {1, 2, 3, 4, 5, 6, 7};
        intList result;
        list<intList> allCombination;
        for(int i=1; i<(1<<size); ++i)
        {
                for(int j = 0; j<size; ++j)
                {
                        if(i & (1<<j))
                        {
                                result.push_back(a[j]);
                        }
                }
                        if (int(result.size()) == dimension)
                        {
                                allCombination.push_back(result);
                        }
                        result.clear();
        }
        return allCombination;
}
//возвращает название команды и кэф на ее победу
list<string> Parse(string pars)
{
        string temp = "";
        list<string> result;
        int size = pars.size();
        for (int i = 0; i < size; i++)
        {
                if (((pars[i] == ' ') || (pars[i] == '\t')) && (temp != " "))
                {
                        result.push_back(temp);
                        temp = "";
                }
                else if ((pars[i] != ' ') && (pars[i] != '\t'))
                {
                        temp += pars[i];
                }
        }
        if (temp != " ")
        {
                result.push_back(temp);
                temp = "";
        }
        return result;
}
//все выбранные ставки должны быть в одном списке
//если выбраны 2 ставки ординар, а потом было решено поставить экспресс
//то из списка ординарных ставок ставки перейдут в список экспресс-ставок
void AllInOneList(list<Bet>& inList, list<Bet>& outList1, list<Bet>& outList2)
{
        if (outList1.size() != 0)
        {
                inList = outList1;
        }
        else if (outList2.size() != 0)
        {
                inList = outList2;
        }
        outList1.clear();
        outList2.clear();
}
