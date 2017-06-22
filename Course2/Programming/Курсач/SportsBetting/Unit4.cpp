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

#include "Unit4.h"
#include "Unit5.h"
#include "Unit2.h"
#include "Money.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm4 *Form4;
//---------------------------------------------------------------------------
__fastcall TForm4::TForm4(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm4::FormCreate(TObject *Sender)
{
        //BitBtn1->Hide();
        CreateDirectory(path.c_str(), NULL);
        Edit1->Clear();
        Edit2->Clear();
        Edit3->Clear();
        Edit4->Clear();
        Edit5->Clear();
        Memo1->Clear();
        string webMoneyPurse[4] = {"B", "R", "Z", "E"};
        for (int i = 1; i <= 4; i++)
        {
                webMoneyCB->Items->Add((webMoneyPurse[i-1]).c_str());
        }
        webMoneyCB->ItemIndex = 0;
        for (int i = 1; i <= 31; i++)
        {
                dateCB->Items->Add(IntToStr(i));
        }
        dateCB->ItemIndex = 0;
        string months[12] = {"Январь", "Февраль", "Март"
                           , "Апрель", "Май", "Июнь"
                           , "Июль", "Август", "Сентября"
                           , "Октябрь", "Ноябрь", "Декабрь"};
        for (int i = 1; i <= 12; i++)
        {
                monthCB->Items->Add((months[i-1]).c_str());
        }
        monthCB->ItemIndex = 0;
        for (int i = 1995; i >= 1920; i--)
        {
                yearsCB->Items->Add(IntToStr(i));
        }
        yearsCB->ItemIndex = 0;

        Label9->Hide();
        Label10->Hide();
        Label11->Hide();
        Label12->Hide();
        Label13->Hide();
        Label14->Hide();
        Label15->Hide();
        Label16->Hide();
}
//---------------------------------------------------------------------------

void TForm4::AddUser()
{
        user.login = Edit1->Text.c_str();
        user.password = Edit2->Text.c_str();
        user.mail = Edit4->Text.c_str();
        int number = webMoneyCB->ItemIndex;
        string currency = (webMoneyCB->Items->operator [](number)).c_str();
        string numberPurse = Edit5->Text.c_str();
        user.webMoneyPurse = currency + numberPurse;
        if (RadioButton1->Checked)
        {
                user.gender = RadioButton1->Caption.c_str();
        }
        else
        {
                user.gender = RadioButton2->Caption.c_str();
        }
        number = dateCB->ItemIndex;
        string date = (dateCB->Items->operator [](number)).c_str();
        number = monthCB->ItemIndex;
        string month = (monthCB->Items->operator [](number)).c_str();
        number = yearsCB->ItemIndex;
        string years = (yearsCB->Items->operator [](number)).c_str();
        user.dateOfBirth = date + "." + month + "." + years;
        number = Memo1->Lines->Count;
        for (int i = 0; i < number; i++)
        {
                user.location += (Memo1->Lines->operator [](i)).c_str();
                user.location += " ";
        }
}

void TForm4::SaveUserToFile(string pathFile)
{
        ofstream file(pathFile.c_str());//файл очищается
        file << "Пользователь" << "\n";
        file << user.login << " ";
        file << user.password << " ";
        file << user.mail << " ";
        file << user.webMoneyPurse << " ";
        file << user.gender << " ";
        file << user.dateOfBirth << " ";
        file << user.location << "\n";
        file.close();
}

void __fastcall TForm4::BitBtn1Click(TObject *Sender)
{
        Label15->Show();
        if(IsCorrectRegistration())
        {
                AddUser();
                string login = user.login;
                userDirectory = path + login + "\\";
                CreateDirectory((userDirectory).c_str(), NULL);
                string pathFile = userDirectory + login + ".txt";
                SaveUserToFile(pathFile);
                MoneyDefault();
                pathFile = userDirectory + login + "Money.txt";
                Form2->SaveMoneyToFile(pathFile);
                ofstream fileBet((userDirectory + login + "Bet.txt").c_str());//просто создаем файл
                fileBet.close();
                //Form4->Close();
                Label15->Caption = "Вы успешно зарегистрированы";
                Label15->Font->Color = clGreen;
                Label16->Show();
                Label16->Caption = "Теперь можете войти";
        }
        else
        {
                Label15->Caption = "Правильно заполните все поля";
                Label15->Font->Color = clRed;
                Label16->Hide();
        }
}
//---------------------------------------------------------------------------

bool TForm4::IsCorrectRegistration()
{
        if (Label9->Font->Color == clRed)
                return false;
        if (Label10->Font->Color == clRed)
                return false;
        if (Label11->Font->Color == clRed)
                return false;
        if (Label12->Font->Color == clRed)
                return false;
        if (Label13->Font->Color == clRed)
                return false;
        if (Label14->Font->Color == clRed)
                return false;
        return true;
}

void __fastcall TForm4::FormClose(TObject *Sender, TCloseAction &Action)
{
        Form5->CloseRegistration();
}
//---------------------------------------------------------------------------
bool TForm4::IsBusy(string login)
{
        bool isBusy = false;
        list<string> copyAllUsersNames = allUsersNames;
        int size = copyAllUsersNames.size();
        for (int i = 0; i < size; i++)
        {
                string temp = copyAllUsersNames.front();
                copyAllUsersNames.pop_front();
                if (temp == login)
                {
                        isBusy = true;
                        break;
                }
        }
        return isBusy;
}

void __fastcall TForm4::Edit1Change(TObject *Sender)
{
        string login = Edit1->Text.c_str();
        Label9->Show();
        if (login.size() < 4)
        {
                Label9->Caption = "Короткий логин";
                Label9->Font->Color = clRed;
        }
        else if(IsBusy(login))
        {
                Label9->Caption = "Логин занят";
                Label9->Font->Color = clRed;
        }
        else
        {
                Label9->Caption = "Логин свободен";
                Label9->Font->Color = clGreen;
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm4::Edit2Change(TObject *Sender)
{
        string password = Edit2->Text.c_str();
        Label10->Show();
        if(password.size() < 6)
        {
                Label10->Caption = "Короткий пароль";
                Label10->Font->Color = clRed;
        }
        else
        {
                Label10->Caption = "Правильный пароль";
                Label10->Font->Color = clGreen;
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm4::Edit3Change(TObject *Sender)
{
        string repeatePassword = Edit3->Text.c_str();
        string password = Edit2->Text.c_str();
        Label11->Show();
        if (password == repeatePassword)
        {
                Label11->Caption = "Пароли совпадают";
                Label11->Font->Color = clGreen;
        }
        else
        {
                Label11->Caption = "Пароли не совпадают";
                Label11->Font->Color = clRed;
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm4::Edit4Change(TObject *Sender)
{
        string email = Edit4->Text.c_str();
        int posSobachka = email.find('@', 1);
        int posDot = email.find('.', 1);
        Label12->Show();
        if ((posSobachka != -1) && (posDot != -1))
        {
                string temp = email.substr(posDot, email.length());
                if ((temp.length() > 2) && (temp.length() < 5))
                {
                        Label12->Caption = "Правильный email";
                        Label12->Font->Color = clGreen;
                }
                else
                {
                        Label12->Caption = "Неправильный email";
                        Label12->Font->Color = clRed;
                }
        }
        else
        {
                Label12->Caption = "Неправильный email";
                Label12->Font->Color = clRed;
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm4::Edit5Change(TObject *Sender)
{
        try
        {
                Label13->Show();
                int number = StrToInt(Edit5->Text.c_str());
                Label13->Caption = "Правильный номер";
                Label13->Font->Color = clGreen;
        }
        catch(EConvertError &ex)
        {
                Label13->Caption = "Неправильный номер";
                Label13->Font->Color = clRed;
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm4::Memo1Change(TObject *Sender)
{
        Label14->Show();
        if (Memo1->Text.Length() > 0)
        {
                Label14->Caption = "Правильное место жительства";
                Label14->Font->Color = clGreen;
        }
        else
        {
                Label14->Caption = "Укажите место жительства";
                Label14->Font->Color = clRed;
        }
}
//---------------------------------------------------------------------------

