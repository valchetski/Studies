//---------------------------------------------------------------------------

#ifndef Unit6H
#define Unit6H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <iostream>
#include <string>
#include <Windows.h>
#include <string.h>
#include <fstream>
#include <locale.h>
#include <list>
#include <cstring.h>
using namespace std;
//---------------------------------------------------------------------------
class TForm6 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TDateTimePicker *DateTimePicker1;
        TDateTimePicker *DateTimePicker2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TEdit *Edit1;
        TEdit *Edit2;
        TLabel *Label7;
        TEdit *Edit3;
        TLabel *Label8;
        TEdit *Edit4;
        TLabel *Label9;
        TLabel *Label10;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall DateTimePicker1Change(TObject *Sender);
        void __fastcall DateTimePicker2Change(TObject *Sender);
        void __fastcall Label4Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm6(TComponent* Owner);
        void OpenStatistic();
        void CalculateStatistic(TDate date1, TDate date2);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm6 *Form6;
struct OneBet
{
        string date;
        string currency;
        float win;
};

list<OneBet> allStatistic;
string officeBirthDay = "07.11.2013";
TDate dateOfficeBirthDay = StrToDate(officeBirthDay.c_str());
//---------------------------------------------------------------------------
#endif
