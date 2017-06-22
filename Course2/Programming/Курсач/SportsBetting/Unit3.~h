//---------------------------------------------------------------------------

#ifndef Unit3H
#define Unit3H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include "Betting.h"
using namespace std;
using namespace System;


//---------------------------------------------------------------------------
class TForm3 : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControl1;
        TTabSheet *TabSheet1;
        TTabSheet *TabSheet2;
        TMemo *Memo1;
        TMemo *Memo2;
        TTabSheet *TabSheet3;
        TMemo *Memo3;
        void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm3(TComponent* Owner);
        list<string> LoadBet(ifstream& file, ofstream& filecopy, string currencyData);
        string LoadOrdinarMBet(ifstream& file, ofstream& fileCopy, string currencyData);
        string LoadExpressMBet(ifstream& file, ofstream& fileCopy, string currencyData);
        string LoadSystemMBet(ifstream& file, ofstream& fileCopy, string currencyData);
        Bet LoadOneBet(ifstream& file);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm3 *Form3;
//---------------------------------------------------------------------------
#endif
