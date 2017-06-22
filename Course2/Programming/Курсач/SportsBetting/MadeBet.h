//---------------------------------------------------------------------------

#ifndef MadeBetH
#define MadeBetH
#include "Betting.h"

//List mOrdinarList;
//list<List> mExpressList;

struct Result
{
        string date;
        string home;
        string guest;
        string result;
};

list <Result> resultList;

string LoadOrdinarMBet(ifstream& file, ofstream& fileCopy, string currencyData, TMemo *Memo1, TMemo *Memo2, TMemo *Memo3);
string LoadExpressMBet(ifstream& file, ofstream& fileCopy, string currencyData, TMemo *Memo1, TMemo *Memo2, TMemo *Memo3);
string LoadSystemMBet(ifstream& file, ofstream& fileCopy, string currencyData, TMemo *Memo1, TMemo *Memo2, TMemo *Memo3);
void ToMemo(Bet bet, TMemo *Memo);
void ExpressAndSystemToMemo(string forMemo, TMemo *Memo);

void SaveResult();
//---------------------------------------------------------------------------
#endif
