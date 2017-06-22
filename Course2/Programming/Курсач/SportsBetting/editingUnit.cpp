//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "editingUnit.h"
#include "MadeBet.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TEditing *Editing;
//---------------------------------------------------------------------------
__fastcall TEditing::TEditing(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TEditing::FormCreate(TObject *Sender)
{
        DateTimePicker1->Date = Date();
        string currentTime = TimeToStr(Time()).c_str();
        int numberOfTheColon = currentTime.find(':', 1);
        int hour = StrToInt((currentTime.substr(0, numberOfTheColon)).c_str());
        if (hour < 10)
        {
                Edit1->Text = "0" + IntToStr(hour);
        }
        else
        {
                Edit1->Text = IntToStr(hour);
        }
        UpDown1->Position = StrToInt(Edit1->Text);
        Edit2->Text = (currentTime.substr(numberOfTheColon + 1, 2)).c_str();
        UpDown2->Position = StrToInt(Edit2->Text);
        Edit3->Clear();
        Edit4->Clear();
        Edit5->Clear();
        Edit6->Clear();
        Edit7->Clear();
        ComboBox1->ItemIndex = 0;

        DateTimePicker2->Date = Date();
        Edit8->Clear();
        Edit9->Clear();
        ComboBox2->ItemIndex = 0;

        DateTimePicker3->Date = Date();
        Edit10->Clear();
        Edit11->Clear();
        ComboBox3->ItemIndex = 0;
        ComboBox4->ItemIndex = 0;

        DateTimePicker4->Date = Date();
        Edit12->Clear();
        Edit13->Clear();
        ComboBox5->ItemIndex = 0;

        Label22->Hide();
}
//---------------------------------------------------------------------------
void __fastcall TEditing::UpDown2MouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
        if(Edit2->Text == "59")
        {
                UpDown2->Position = 0;
                Edit2->Text = "00";
        }
        else if (Edit2->Text == "00")
        {
                UpDown2->Position = 59;
                Edit2->Text = "59";
        }
        else if(UpDown2->Position < 10)
        {

               Edit2->Text = "0" + IntToStr(UpDown2->Position);
        }
        else
        {
                Edit2->Text = IntToStr(UpDown2->Position);
        }

}
//---------------------------------------------------------------------------
void __fastcall TEditing::BitBtn1Click(TObject *Sender)
{
        string pathFile;
        switch(ComboBox1->ItemIndex)
        {
                case 0:
                        pathFile = "Football.txt";
                        break;
                case 1:
                        pathFile = "Hockey.txt";
                        break;
                case 2:
                        pathFile = "Basketball.txt";
                        break;

        }
        ofstream file(pathFile.c_str(), ios::app);
        file << (DateToStr(DateTimePicker1->Date)).c_str() << " ";
        string time = (Edit1->Text + ":" + Edit2->Text).c_str();
        file << time << " ";
        string home = Edit3->Text.c_str();
        file << home << " ";
        string guest = Edit4->Text.c_str();
        file << guest << " ";
        string homeWin = Edit5->Text.c_str();
        file << homeWin << " ";
        string nobodyWin = Edit6->Text.c_str();
        file << nobodyWin << " ";
        string guestWin = Edit7->Text.c_str();
        file << guestWin << "\n";
        Edit3->Clear();
        Edit4->Clear();
        Edit5->Clear();
        Edit6->Clear();
        Edit7->Clear();
        Label22->Show();
}
//---------------------------------------------------------------------------
void TEditing::DeleteMatch(list<Match>& matchList, string date, string teamHome, string teamGuest)
{
        Match deleteMatch;
        deleteMatch.date = date;
        deleteMatch.home = teamHome;
        deleteMatch.guest = teamGuest;
        int size = matchList.size();
        list<Match> copyMatchList = matchList;
        matchList.clear();
        for (int i = 0; i < size; i++)
        {
                Match temp = copyMatchList.front();
                copyMatchList.pop_front();
                if ((temp.date == deleteMatch.date) && (temp.home == deleteMatch.home) && (temp.guest == deleteMatch.guest))
                {
                        continue;
                }
                matchList.push_back(temp);
        }
}

void TEditing::DeleteResult(string date, string teamHome, string teamGuest)
{
        Result deleteResult;
        deleteResult.date = date;
        deleteResult.home = teamHome;
        deleteResult.guest = teamGuest;
        int size = resultList.size();
        list<Result> copyResultList = resultList;
        resultList.clear();
        for (int i = 0; i < size; i++)
        {
                Result temp = copyResultList.front();
                copyResultList.pop_front();
                if ((temp.date != deleteResult.date) || (temp.home != deleteResult.home) || (temp.guest != deleteResult.guest))
                {
                        resultList.push_back(temp);
                } 
        }
}
void __fastcall TEditing::BitBtn2Click(TObject *Sender)
{
        string date = (DateToStr(DateTimePicker2->Date)).c_str();
        string home = Edit8->Text.c_str();
        string guest = Edit9->Text.c_str();
        switch(ComboBox2->ItemIndex)
        {
                case 0:
                        DeleteMatch(football, date, home, guest);
                        break;
                case 1:
                        DeleteMatch(hockey, date, home, guest);
                        break;
                case 2:
                        DeleteMatch(basketball, date, home, guest);
                        break;
        }
        SaveSports(); // â workwithfile
}
//---------------------------------------------------------------------------



void __fastcall TEditing::BitBtn3Click(TObject *Sender)
{
        Result newResult;
        newResult.date = DateToStr(DateTimePicker3->Date).c_str();
        newResult.home = Edit10->Text.c_str();
        newResult.guest = Edit11->Text.c_str();
        int index = ComboBox4->ItemIndex;
        newResult.result = (ComboBox4->Items->operator [](index)).c_str();
        resultList.push_back(newResult);
        SaveResult();
}
//---------------------------------------------------------------------------

void __fastcall TEditing::BitBtn4Click(TObject *Sender)
{
        string date = DateToStr(DateTimePicker1->Date).c_str();
        string home = Edit12->Text.c_str();
        string guest = Edit13->Text.c_str();
        DeleteResult(date, home, guest);
        SaveResult();
}
//---------------------------------------------------------------------------


void __fastcall TEditing::Edit3Change(TObject *Sender)
{
        Label22->Hide();        
}
//---------------------------------------------------------------------------

