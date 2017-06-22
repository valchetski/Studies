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
#include "WorkWithFile.cpp"
#include "Betting.cpp"
#include "Unit2.cpp"
#include "Unit3.cpp"
#include "Unit4.h"
#include "Unit5.cpp"
#include "Unit6.cpp"
#include "editingUnit.cpp"
#include "MadeBet.h"
using namespace std;

#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
     MainMenu1->Items->Count;
     isInitialize = false;
     choiceSport->ItemIndex = 0;
     choiceBet->ItemIndex = 0;
     choiceCurrencyCB->ItemIndex = 0;
     Edit2->Text = "0";
     Edit1->Text = "1";
     Edit2->Hide();
     Label7->Hide();
     Label11->Caption = "/0";
     isInitialize = true;
     Edit1->Text = "0";
     Label11->Hide();
     Label12->Hide();
     Label13->Hide();
     Label15->Hide();
     Label16->Hide();
     Label17->Hide();
     BitBtn1->Hide();
     BitBtn2->Hide();
     Label18->Hide();

     Label6->Hide();
     Edit1->Hide();
     choiceCurrencyCB->Hide();
     Label7->Hide();
     Label14->Hide();
     Label10->Hide();
     Label8->Hide();
     Label9->Hide();

     LoadSports();
     DateTimePicker1->Date = Date(); // устанавливает текущую дату
     string currentDate = DateToStr(DateTimePicker1->Date).c_str();
     list<Match> todayMathes = TodayMathes(football, currentDate);
     MathesToForm(todayMathes);
     //LoadMoneyFromFile();

}
//---------------------------------------------------------------------------

void TForm1::MathesToForm(list<Match> todayMatches)
{   
        int size = todayMatches.size();
        for(int i = 0; i < size; i++)
        {
                Match temp = todayMatches.front();
                todayMatches.pop_front();
                timeLB->Items->Add(temp.time.c_str());
                string teamAndKoef = temp.home + " " + (FloatToStr(temp.winnerHome)).c_str();
                homeCB->Items->Add(teamAndKoef.c_str());
                drawCB->Items->Add(FloatToStr(temp.draw));
                teamAndKoef = temp.guest + " " + (FloatToStr(temp.winnerGuest)).c_str();
                guestCB->Items->Add(teamAndKoef.c_str());
        }
}

void __fastcall TForm1::DateTimePicker1Change(TObject *Sender)
{
        Form3->Memo1->Clear();
        Form3->Memo2->Clear();
        Form3->Memo3->Clear();
        timeLB->Items->Clear();
        homeCB->Items->Clear();
        drawCB->Items->Clear();
        guestCB->Items->Clear();
        list<Match> sport = ChoiceSport(choiceSport);
        string currencyData = DateToStr(DateTimePicker1->Date).c_str();
        list<Match> todayMathes = TodayMathes(sport, currencyData);
        MathesToForm(todayMathes);
        Label15->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::choiceSportChange(TObject *Sender)
{
        timeLB->Items->Clear();
        homeCB->Items->Clear();
        drawCB->Items->Clear();
        guestCB->Items->Clear();
        list<Match> sport = ChoiceSport(choiceSport);
        Match cha = sport.front();
        string currencyData = DateToStr(DateTimePicker1->Date).c_str();
        list<Match> todayMathes = TodayMathes(sport, currencyData);
        MathesToForm(todayMathes);
        Label15->Hide();
}
//---------------------------------------------------------------------------

void TForm1::ChoiceMatch(TCheckListBox *checkBox, List& betList)
{
        int number = checkBox->ItemIndex;
        string teamAndKoef = (checkBox->Items->operator [](number)).c_str();
        list<string> temp = Parse(teamAndKoef);
        string selectedTeam = temp.front();
        string resultMatch = "";
        double koef = StrToFloat(temp.back().c_str());
        string drawResult =  temp.back();  //если выбрана ставка на ничью, то
        //функция Parse() возвратит список из одного элемента
        //там будет только значение коэффициента
        if(drawResult == selectedTeam)
        {
                resultMatch = "Н";
        }

        teamAndKoef = (homeCB->Items->operator [](number)).c_str();
        temp = Parse(teamAndKoef);
        string teamHome = temp.front();
        if (teamHome == selectedTeam)
        {
                resultMatch = "П1";
        }

        teamAndKoef = (guestCB->Items->operator [](number)).c_str();
        temp = Parse(teamAndKoef);
        string teamGuest = temp.front();
        if (teamGuest == selectedTeam)
        {
                resultMatch = "П2";
        }

        string toMemo = teamHome + " - " + teamGuest +  "\n\t" + resultMatch + " - " + (FloatToStr(koef)).c_str();
        string date = DateToStr(DateTimePicker1->Date).c_str();
        string time = (timeLB->Items->operator [](number)).c_str();
        if(checkBox->Checked[number])
        {
                AddBetList(betList, resultMatch, koef, date, time, teamHome, teamGuest);
                AddToMemo(toMemo);
                BitBtn1->Show();
                BitBtn2->Show();
                Label6->Show();
                Edit1->Show();
                choiceCurrencyCB->Show();
                Label8->Show();
                Label9->Show();
        }
        else
        {
                DeleteBetList(betList, date, time, teamHome, teamGuest, resultMatch);
                DeleteFromMemo(toMemo); 
                if (Memo1->Lines->operator [](0) == emptyCoupon.c_str())
                {
                        BitBtn1->Hide();
                        BitBtn2->Hide();
                        Label6->Hide();
                        Edit1->Hide();
                        choiceCurrencyCB->Hide();
                        Label7->Hide();
                        Label14->Hide();
                        Label10->Hide();
                        Label8->Hide();
                        Label9->Hide();
                        Label12->Hide();
                        Label13->Hide();
                        Edit2->Hide();
                        Label11->Hide();
                }
        }
}

void TForm1::AddToMemo(string line)
{
        if (Memo1->Lines->Strings[0] == emptyCoupon.c_str())
        {
                Memo1->Clear();
        }
        int pos = line.find('\n', 1);
        string line1 = line.substr(0, pos);
        Memo1->Lines->Add(line1.c_str());
        line = line.substr(pos + 1, line.length() - 1);
        Memo1->Lines->Add(line.c_str());
}

void TForm1::DeleteFromMemo(string line)
{
        int pos = line.find('\n', 1);
        int count =  Memo1->Lines->Count;
        for(int i = 0; i < count; i += 2)
        {
                string line1 = line.substr(0, pos);
                if (Memo1->Lines->Strings[i] == line1.c_str())
                {
                        line1 = line.substr(pos + 1, line.length() - 2);//-2 потому что в конце еще будет знак табуляции
                        if (Memo1->Lines->Strings[i + 1] == line1.c_str())
                        {
                                Memo1->Lines->Delete(i);
                                Memo1->Lines->Delete(i);
                                i -= 2;
                        }
                }
        }
        if(Memo1->Lines->Count == 0)
        {
                Memo1->Clear();
                Memo1->Lines->Add(emptyCoupon.c_str());
        }
}

void TForm1::MakeBet(TCheckListBox *checkBox)
{     
        string dimension = (Label11->Caption).c_str();
        dimension = dimension.substr(1, dimension.size() - 1);
        int dimens = StrToInt(dimension.c_str());
        int number = checkBox->ItemIndex;
        string teamAndKoef = (checkBox->Items->operator [](number)).c_str();
        if (checkBox->Checked[number])
        {
                dimens++;
        }
        else
        {
                dimens--;
        }
        Label11->Caption = "/" + IntToStr(dimens);
        if (dimens > 2)
        {
                string temp = (IntToStr(dimens - 1)).c_str();
                Edit2->Text = temp.c_str();
        }
        else
        {
                Edit2->Text = "0";
        }
        switch(choiceBet->ItemIndex)
        {
                case 0:
                        Label10->Show();
                        Label14->Show();
                        AllInOneList(ordinarList, expressList, systemList);
                        ChoiceMatch(checkBox, ordinarList);
                        break;
                case 1:
                        Label12->Show();
                        Label13->Show();
                        AllInOneList(expressList, ordinarList, systemList);
                        ChoiceMatch(checkBox, expressList);
                        break;
                case 2:
                        Edit2->Show();
                        Label7->Show();
                        Label11->Show();
                        AllInOneList(systemList, expressList, ordinarList);
                        ChoiceMatch(checkBox, systemList);
                        if (dimens < 3)
                        {
                                BitBtn1->Hide();
                                BitBtn2->Hide();
                        }
                        break;
        }
        BetToForm();
}

void __fastcall TForm1::homeCBClickCheck(TObject *Sender)
{
        MakeBet(homeCB);
        Label15->Hide();
}
//---------------------------------------------------------------------------


void __fastcall TForm1::drawCBClick(TObject *Sender)
{
        MakeBet(drawCB);
        Label15->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::guestCBClick(TObject *Sender)
{
        MakeBet(guestCB);
        Label15->Hide();
}
//---------------------------------------------------------------------------



void __fastcall TForm1::Edit1Change(TObject *Sender)
{
        if (isInitialize)
        {
                BetToForm();
        }
}
//---------------------------------------------------------------------------

void TForm1::BetToForm()
{
        int number = choiceCurrencyCB->ItemIndex;
        string currency = (choiceCurrencyCB->Items->Strings[number]).c_str();
        try
        {  
                float money = StrToFloat(Edit1->Text);
                int dimension = StrToInt(Edit2->Text);
                list <float> finalCoef = AllCoef(Memo1, choiceBet, money, dimension);
                float allMoney = finalCoef.front();
                finalCoef.pop_front();
                Label10->Caption = FloatToStr(allMoney) + "  " + currency.c_str();
                double win = finalCoef.front();
                finalCoef.pop_front();
                win = int(win * 100 + 0.5) / 100.0;
                Label9->Caption = FloatToStr(win) + "  " + currency.c_str();
                float maxKoef = finalCoef.front();
                finalCoef.pop_front();
                Label13->Caption = FloatToStr(maxKoef);
        }
        catch (EConvertError &ex)
        {
                Label10->Caption = "0";
                Label9->Caption = "0";
                BitBtn1->Hide();
                BitBtn2->Hide();
        }
}

void __fastcall TForm1::choiceBetChange(TObject *Sender)
{
        switch(choiceBet->ItemIndex)
        {
                case 0:
                        AllInOneList(ordinarList, expressList, systemList);
                        Label6->Caption = "Сумма на каждый ординар";
                        Edit2->Hide();
                        Label7->Hide();
                        Label10->Show();
                        Label11->Hide();
                        Label12->Hide();
                        Label13->Hide();
                        Label14->Show();
                        break;
                case 1:
                        AllInOneList(expressList, ordinarList, systemList);
                        Label6->Caption = "Сумма на весь экспресс";
                        Edit2->Hide();
                        Label7->Hide();
                        Label10->Hide();
                        Label11->Hide();
                        Label14->Hide();
                        break;
                case 2:
                        AllInOneList(systemList, expressList, ordinarList);
                        Label6->Caption = "Сумма на систему";
                        string dimension = Label11->Caption.c_str();
                        dimension = dimension.substr(1, dimension.length() - 1);
                        int dim = StrToInt(dimension.c_str());
                        if (dim > 0)
                        {
                                Edit2->Show();
                                Label7->Show();
                                Label11->Show();
                        }
                        Label10->Hide();
                        Label12->Hide();
                        Label13->Hide();
                        Label14->Hide();
                        break;
        }
        BetToForm();
        Label15->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Edit1Click(TObject *Sender)
{
        Edit1->Clear();
        Label15->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::choiceCurrencyCBChange(TObject *Sender)
{
        BetToForm();
        Label15->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::BitBtn1Click(TObject *Sender)
{
        ClearForm(); 
}

void TForm1::ClearForm()
{
        Memo1->Clear();
        Memo1->Lines->Add(emptyCoupon.c_str());
        AllUnChecked(homeCB);
        AllUnChecked(drawCB);
        AllUnChecked(guestCB);
        ordinarList.clear();
        expressList.clear();
        systemList.clear();
        Edit1->Text = "0";
        Label15->Hide();
        Label6->Hide();
        Edit1->Hide();
        Edit2->Hide();
        choiceCurrencyCB->Hide();
        Label7->Hide();
        Label14->Hide();
        Label10->Hide();
        Label8->Hide();
        Label9->Hide();
        Label11->Hide();
        BitBtn1->Hide();
        BitBtn2->Hide();
        BetToForm();
}
//---------------------------------------------------------------------------
void TForm1::AllUnChecked(TCheckListBox *checkBox)
{
        int size = checkBox->Items->Count;
        for (int i = 0; i < size; i++)
        {
                checkBox->Checked[i] = false;
        }
}

void __fastcall TForm1::BitBtn2Click(TObject *Sender)
{
        string path = userDirectory + Form4->user.login + "Bet.txt";
        double moneyBet = StrToFloat(Edit1->Text);
        double minbet = minBet();
        int number = choiceCurrencyCB->ItemIndex;
        string currency = (choiceCurrencyCB->Items->operator [](number)).c_str();
        Label12->Hide();
        Label13->Hide();
        if (moneyBet < minbet)
        {
                Label18->Caption = "Минимальная ставка " + FloatToStr(minbet) + " " + currency.c_str();
                Label18->Show();
        }
        else if(!isEnoughMoney(moneyBet))
        {
                Label18->Caption = "Недостаточно средств";
                Label18->Show();
        }
        else
        {
                SaveBetsToFile(path);
                Label18->Hide();
                Label11->Caption = "/0";
                Edit2->Text = 0;
        }
}
//---------------------------------------------------------------------------

bool TForm1::isEnoughMoney(double moneyBet)
{
        int number = choiceCurrencyCB->ItemIndex;
        list<Cash> copyAllMoney = allMoney;
        Cash cash;
        for (int i = 0; i <= number; i++)
        {
                cash = copyAllMoney.front();
                copyAllMoney.pop_front();
        }
        float moneyInPurse = cash.money;
        bool isEnough;
        if (moneyBet <= moneyInPurse)
        {
                isEnough = true;
        }
        else
        {
                isEnough = false;
        }
        return isEnough;
}

double TForm1::minBet()
{
        double minBet = 5000; //в бел. рублях
        switch (choiceCurrencyCB->ItemIndex)
        {
                case 1:
                        minBet /= 282;
                        minBet = int(minBet*100 + 0.5)/100.0;
                        break;
                case 2:
                        minBet /= 9300;
                        minBet = int(minBet*100 + 0.5)/100.0;
                        break;
                case 3:
                        minBet /= 12540;
                        minBet = int(minBet*100 + 0.5)/100.0;
                        break;
        }
        return minBet;
}
void TForm1::SaveBetsToFile(string path)
{
        try
        {
        ofstream file(path.c_str(), ios::app);//сохраняем в файл с добавлением новых ставок
        float money = StrToFloat(Edit1->Text);
        int index = choiceCurrencyCB->ItemIndex;
        string currency = (choiceCurrencyCB->Items->operator [](index)).c_str();
        switch(choiceBet->ItemIndex)
        {
                case 0:
                        SaveOrdinarToFile(ordinarList, file, currency, money);
                        ordinarList.clear();
                        break;
                case 1:
                        SaveExpressToFile(expressList, file, currency, money);
                        expressList.clear();
                        break;
                case 2:
                        string dimension = Edit2->Text.c_str();
                        dimension += Label11->Caption.c_str();
                        SaveSystemToFile(systemList, file, currency, money, dimension);
                        break;
        }
        ClearForm();
        Label15->Show();
        }
        catch (EConvertError &ex)
        {
                Label10->Caption = "0";
                Label9->Caption = "0";
                Edit1->Text = "0";
        }
}

void __fastcall TForm1::N2Click(TObject *Sender)//выводит деньги на форму
{
        Form2->Show();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::N1Click(TObject *Sender)
{
        Form3->Show();
}
//---------------------------------------------------------------------------

void  TForm1::MyBetToForm(ifstream& file, ofstream& fileCopy)
{
        Form3->Memo1->Clear();
        Form3->Memo2->Clear();
        Form3->Memo3->Clear();
        string currencyData = DateToStr(Form1->DateTimePicker1->Date).c_str();
        list<string> winMoney = Form3->LoadBet(file, fileCopy, currencyData);
        Form2->WinMoney(winMoney);
}

void TForm1::MyMoneyToForm()
{
        Form2->ToForm();
        string login = Form4->user.login;
        string path1 = path + login + "\\" + login + "Money.txt";
        Form2->SaveMoneyToFile(path1);
}

void __fastcall TForm1::Edit2Change(TObject *Sender)
{
        try
        {
                int dim1 = StrToInt(Edit2->Text);
                string dimension =  Label11->Caption.c_str();
                dimension = dimension.substr(1, dimension.length());
                int dim2 = StrToInt(dimension.c_str());
                if (dim1 >= dim2)
                {
                        Edit2->Text = "0";
                }
                if (isInitialize)
                {
                        BetToForm();
                }
        }
        catch (EConvertError &ex)
        {

        }
}
//--------------------------------------------------------------------------- 
void __fastcall TForm1::Edit2Click(TObject *Sender)
{
        Edit2->Clear();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::N4Click(TObject *Sender)
{
        Form1->Hide();
        Form5->Show();
}
//---------------------------------------------------------------------------
void TForm1::NotEnter()
{
        Form1->GroupBox3->Hide();
        Form1->Show();
        Form1->N1->Visible = false;
        Form1->N2->Visible = false;
        Form1->N4->Visible = true;
        Form1->N5->Visible = false;
        Form1->userName1->Visible = false;
        Form1->Label16->Show();
        Form1->Label17->Show();
        string pathRunOptions = "RunOptions.txt";
        ofstream fileRunOptions(pathRunOptions.c_str());//очищаем файл
        allMoney.clear();
}

void TForm1::Enter()
{
        Form1->Show();
        Form1->N1->Visible = true;
        Form1->N2->Visible = true;
        Form1->N4->Visible = false;
        Form1->N5->Visible = false;
        Form1->N6->Visible = false;
        Form1->userName1->Visible = true;
        Form1->userName1->Caption = Form4->user.login.c_str();
        Form1->Label16->Hide();
        Form1->Label17->Hide();
        Form1->GroupBox3->Show();
        if (Form1->userName1->Caption == "&administrator")
        {
                Form1->N5->Visible = true;
                Form1->N1->Visible = false;
                Form1->N2->Visible = false;
                Form1->N6->Visible = true;
        }
}

void __fastcall TForm1::N3Click(TObject *Sender)
{
        Form1->NotEnter();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::N5Click(TObject *Sender)
{
        Form6->OpenStatistic();
        Form6->DateTimePicker1Change(Sender); //вызываем обработчик события DateTimePicker1Change
        //который вызывает CalculateStatistic
        Form6->Show();
}

void __fastcall TForm1::N6Click(TObject *Sender)
{
        Editing->Show();
}
//---------------------------------------------------------------------------




void __fastcall TForm1::N7Click(TObject *Sender)
{
     timeLB->Clear();
     homeCB->Clear();
     guestCB->Clear();
     drawCB->Clear();
     football.clear();
     hockey.clear();
     basketball.clear();
     MainMenu1->Items->Count;
     isInitialize = false;
     choiceSport->ItemIndex = 0;
     choiceBet->ItemIndex = 0;
     choiceCurrencyCB->ItemIndex = 0;
     Edit2->Text = "0";
     Edit1->Text = "1";
     Edit2->Hide();
     Label7->Hide();
     Label11->Caption = "/0";
     isInitialize = true;
     Edit1->Text = "0";
     Label11->Hide();
     Label12->Hide();
     Label13->Hide();
     Label15->Hide();
     Label16->Hide();
     Label17->Hide();
     BitBtn1->Hide();
     BitBtn2->Hide();
     Label18->Hide();

     Label6->Hide();
     Edit1->Hide();
     choiceCurrencyCB->Hide();
     Label7->Hide();
     Label14->Hide();
     Label10->Hide();
     Label8->Hide();
     Label9->Hide();

     LoadSports();
     
     string currentDate = DateToStr(DateTimePicker1->Date).c_str();
     list<Match> todayMathes = TodayMathes(football, currentDate);
     MathesToForm(todayMathes);
}
//---------------------------------------------------------------------------


