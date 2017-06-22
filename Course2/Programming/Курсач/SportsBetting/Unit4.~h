//---------------------------------------------------------------------------

#ifndef Unit4H
#define Unit4H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <CheckLst.hpp>
#include <Grids.hpp>
#include <ValEdit.hpp>
#include <Buttons.hpp>
#include <iostream>
#include <string>
#include <Windows.h>
#include <string.h>
#include <fstream>
#include <locale.h>
#include <list>
#include <cstring.h>
using namespace std;
using namespace System;
//---------------------------------------------------------------------------
struct User
        {
        string login;
        string password;
        string mail;
        string webMoneyPurse;
        string gender;
        string dateOfBirth;
        string location;
        };

string path = "Users\\";
string userDirectory;

        
class TForm4 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TEdit *Edit1;
        TEdit *Edit2;
        TEdit *Edit3;
        TEdit *Edit4;
        TEdit *Edit5;
        TRadioButton *RadioButton1;
        TRadioButton *RadioButton2;
        TLabel *Label7;
        TLabel *Label8;
        TComboBox *dateCB;
        TComboBox *monthCB;
        TComboBox *yearsCB;
        TMemo *Memo1;
        TComboBox *webMoneyCB;
        TBitBtn *BitBtn1;
        TLabel *Label9;
        TLabel *Label10;
        TLabel *Label11;
        TLabel *Label12;
        TLabel *Label13;
        TLabel *Label14;
        TLabel *Label15;
        TLabel *Label16;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall BitBtn1Click(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Edit1Change(TObject *Sender);
        void __fastcall Edit2Change(TObject *Sender);
        void __fastcall Edit3Change(TObject *Sender);
        void __fastcall Edit4Change(TObject *Sender);
        void __fastcall Edit5Change(TObject *Sender);
        void __fastcall Memo1Change(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm4(TComponent* Owner);
        void AddUser();
        void SaveUserToFile(string pathFile);
        bool IsBusy(string login);
        bool IsCorrectRegistration();

        User user;
        list<User> usersList;
        list<string> allUsersNames;
};
//---------------------------------------------------------------------------
extern PACKAGE TForm4 *Form4;
//---------------------------------------------------------------------------
#endif
