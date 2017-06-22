//---------------------------------------------------------------------------

#ifndef Unit5H
#define Unit5H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Mask.hpp>
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
//---------------------------------------------------------------------------
class TForm5 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TEdit *Edit1;
        TEdit *Edit2;
        TBitBtn *BitBtn1;
        TButton *Button1;
        TLabel *Label3;
        TCheckBox *CheckBox1;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall BitBtn1Click(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Edit1Change(TObject *Sender);
        void __fastcall Edit2Change(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm5(TComponent* Owner);
        void LoadUser(ifstream& file);
        void LoadAll(string login);
        list<string> FindAllUsers();
        string GetPassword(string login);
        bool Enter(string login, string password);
        void RememberMe(string login, string password);
        bool EnterInProfile();
        void CloseRegistration();
};
//---------------------------------------------------------------------------
extern PACKAGE TForm5 *Form5;
//---------------------------------------------------------------------------
#endif
