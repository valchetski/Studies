//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <Buttons.hpp>
#include <ActnCtrls.hpp>
#include <ActnMan.hpp>
#include <ToolWin.hpp>
#include <ComCtrls.hpp>
#include <Grids.hpp>
#include <CheckLst.hpp>
#include <Menus.hpp>
#include "WorkWithFile.h"
#include "Betting.h"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TDateTimePicker *DateTimePicker1;
        TLabel *Label1;
        TComboBox *choiceSport;
        TLabel *Label2;
        TComboBox *choiceBet;
        TLabel *Label3;
        TGroupBox *GroupBox2;
        TCheckListBox *homeCB;
        TCheckListBox *drawCB;
        TListBox *timeLB;
        TCheckListBox *guestCB;
        TGroupBox *GroupBox3;
        TLabel *Label4;
        TLabel *Label5;
        TMemo *Memo1;
        TLabel *Label6;
        TEdit *Edit1;
        TComboBox *choiceCurrencyCB;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TLabel *Label10;
        TEdit *Edit2;
        TLabel *Label11;
        TLabel *Label12;
        TLabel *Label13;
        TLabel *Label14;
        TBitBtn *BitBtn1;
        TBitBtn *BitBtn2;
        TLabel *Label15;
        TMainMenu *MainMenu1;
        TMenuItem *N1;
        TMenuItem *N2;
        TMenuItem *N4;
        TLabel *Label16;
        TLabel *Label17;
        TMenuItem *userName1;
        TMenuItem *N3;
        TMenuItem *N5;
        TPanel *Panel1;
        TLabel *Label18;
        TMenuItem *N6;
        TMenuItem *N7;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall DateTimePicker1Change(TObject *Sender);
        void __fastcall choiceSportChange(TObject *Sender);
        void __fastcall drawCBClick(TObject *Sender);
        void __fastcall guestCBClick(TObject *Sender);
        void __fastcall Edit1Change(TObject *Sender);
        void __fastcall choiceBetChange(TObject *Sender);
        void __fastcall Edit1Click(TObject *Sender);
        void __fastcall choiceCurrencyCBChange(TObject *Sender);
        void __fastcall homeCBClickCheck(TObject *Sender);
        void __fastcall BitBtn1Click(TObject *Sender);
        void __fastcall BitBtn2Click(TObject *Sender);
        void __fastcall N2Click(TObject *Sender);
        void __fastcall N1Click(TObject *Sender);
        void __fastcall Edit2Change(TObject *Sender);
        void __fastcall Edit2Click(TObject *Sender);
        void __fastcall N4Click(TObject *Sender);
        void __fastcall N3Click(TObject *Sender);
        void __fastcall N5Click(TObject *Sender);
        void __fastcall N6Click(TObject *Sender);
        void __fastcall N7Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
        void MathesToForm(list<Match> todayMathes);
        void ChoiceMatch(TCheckListBox *checkBox, list<Bet>& betList);
        void MakeBet(TCheckListBox *checkBox);
        void AllUnChecked(TCheckListBox *checkBox);
        void AddToMemo(string teamAndKoef);
        void DeleteFromMemo(string line);
        void ClearForm();
        void BetToForm();
        bool isInitialize;
        void SaveBetsToFile(string path);
        void MyBetToForm(ifstream& file, ofstream& fileCopy);
        void MyMoneyToForm();
        void NotEnter();
        void Enter();
        double minBet();
        bool isEnoughMoney(double moneyBet);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
