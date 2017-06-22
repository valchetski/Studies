//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#include <string>
#include <Windows.h>
#include <string.h>
#include <fstream>
#include <locale.h>
#include <list>
#include <cstring.h>
#pragma hdrstop

#include "Unit2.h"
#include "Unit4.h"
#include "Money.cpp"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm2 *Form2;
//---------------------------------------------------------------------------
__fastcall TForm2::TForm2(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void TForm2::SaveMoneyToFile(string pathFile)
{
        ofstream file(pathFile.c_str());
        list<Cash> copyAllMoney = allMoney;
        int size =  copyAllMoney.size();
        for (int i = 0; i < size; i++)
	{
                Cash temp = copyAllMoney.front();
                copyAllMoney.pop_front();
                file << (FloatToStr(temp.money)).c_str() << " ";
                file << temp.currency << "\n";
        }
}

void __fastcall TForm2::CheckListBox1ClickCheck(TObject *Sender)
{
        int number = CheckListBox1->ItemIndex;
        if (CheckListBox1->Checked[number])
        {
                Button1->Enabled = true;
                Button2->Enabled = true;
        }
        else
        {
                Button1->Enabled = false;
                Button2->Enabled = false;
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button1Click(TObject *Sender)
{
        ValueListEditor1->Show();
        Button1->Hide();
        Button2->Hide();
        int size = CheckListBox1->Items->Count;
        int j = 1;
        for(int i = 0; i < size; i++)
        {
                if (CheckListBox1->Checked[i])
                {
                        ValueListEditor1->Keys[j] = CheckListBox1->Items->operator [](i);
                        ValueListEditor1->Strings->Add("");
                        j++;
                }
        }
        ValueListEditor1->Strings->Delete(j-1);
        BitBtn1->Show();
        BitBtn1->Caption = "Вывести деньги";
        isAdd = false;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::BitBtn1Click(TObject *Sender)
{
        ChangeMoney();
}
//---------------------------------------------------------------------------

void TForm2::ToForm()
{
        CheckListBox1->Clear();
        Button1->Show();
        Button1->Enabled = false;
        Button2->Show();
        Button2->Enabled = false;
        BitBtn1->Hide();
        ValueListEditor1->Hide();
        list<Cash> copyAllMoney = allMoney;
        int size = copyAllMoney.size();
        for (int i = 0; i < size; i++)
        {
                Cash temp = copyAllMoney.front();
                copyAllMoney.pop_front();
                string money = (FloatToStr(temp.money)).c_str();
                string toListbox = money + " " + temp.currency;
                Form2->CheckListBox1->Items->Add(toListbox.c_str());
        }
}

void TForm2::ChangeMoney()
{
        int size = CheckListBox1->Items->Count;
        int j = 1;
        list<Cash> copyAllMoney = allMoney;
        allMoney.clear();
        for(int i = 0; i < size; i++)
        {
                Cash newCash = copyAllMoney.front();
                copyAllMoney.pop_front();
                string temp = (CheckListBox1->Items->operator [](i)).c_str();
                int pos = temp.find(' ', 1);
                temp = temp.substr(pos + 1, temp.length() - 1);
                string temp1 =  ValueListEditor1->Keys[j].c_str();
                if ((CheckListBox1->Items->operator [](i) == ValueListEditor1->Keys[j]) || (temp == temp1))
                {
                        string temp = (ValueListEditor1->Strings->operator [](j-1)).c_str();
                        int position = temp.find('=',1);
                        temp = temp.substr(position + 1, temp.length() - 1);
                        if (isAdd)
                        {
                                newCash.money = newCash.money + StrToFloat(temp.c_str());
                        }
                        else
                        {
                                newCash.money = newCash.money - StrToFloat(temp.c_str());
                        }
                        j++;
                }
                if (j > (ValueListEditor1->RowCount - 1))
                        j--;
                allMoney.push_back(newCash);
        }
        CheckListBox1->Clear();
        ToForm();//меняем значения в счете
        SaveMoneyToFile(Form4->user.login);
}

void TForm2::WinMoney(list<string> winMoney)
{
        int size = winMoney.size();
        for (int i = 0; i < size; i++)
        {
                string win = winMoney.front();
                winMoney.pop_front();
                int pos = win.find(' ', 1);
                float money = StrToFloat((win.substr(0, pos)).c_str());
                string currency = win.substr(pos + 1, win.length() - 1);
                int sizeAllMoney = allMoney.size();
                list<Cash> copyAllMoney = allMoney;
                allMoney.clear();
                for(int j = 0; j < sizeAllMoney; j++)
                {
                        Cash cash = copyAllMoney.front();
                        copyAllMoney.pop_front();
                        if (cash.currency == currency)
                        {
                                cash.money += money;
                        }
                        allMoney.push_back(cash);
                }
        }
}

void __fastcall TForm2::Button2Click(TObject *Sender)
{
        ValueListEditor1->Show();
        Button1->Hide();
        Button2->Hide();
        int size = CheckListBox1->Items->Count;
        int j = 1;
        for(int i = 0; i < size; i++)
        {
                if (CheckListBox1->Checked[i])
                {
                        string temp = (CheckListBox1->Items->operator [](i)).c_str();
                        int pos = temp.find(' ', 1);
                        temp = temp.substr(pos + 1, temp.length() - 1);
                        ValueListEditor1->Keys[j] = temp.c_str();
                        ValueListEditor1->Strings->Add("");
                        j++;
                }
        }
        ValueListEditor1->Strings->Delete(j-1);
        BitBtn1->Show();
        BitBtn1->Caption = "Ввести деньги";
        isAdd = true;
}
//---------------------------------------------------------------------------

