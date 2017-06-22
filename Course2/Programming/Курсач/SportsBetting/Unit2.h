//---------------------------------------------------------------------------

#ifndef Unit2H
#define Unit2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <CheckLst.hpp>
#include <Grids.hpp>
#include <ValEdit.hpp>
#include <Buttons.hpp>

using namespace std;
using namespace System;
//---------------------------------------------------------------------------
class TForm2 : public TForm
{
__published:	// IDE-managed Components
        TButton *Button1;
        TButton *Button2;
        TCheckListBox *CheckListBox1;
        TValueListEditor *ValueListEditor1;
        TBitBtn *BitBtn1;
        void __fastcall CheckListBox1ClickCheck(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall BitBtn1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm2(TComponent* Owner);
        void ToForm();
        void ChangeMoney();
        void WinMoney(list<string> winMoney);
        void SaveMoneyToFile(string pathFile);
        bool isAdd;
};
//---------------------------------------------------------------------------
extern PACKAGE TForm2 *Form2;
//---------------------------------------------------------------------------
#endif
