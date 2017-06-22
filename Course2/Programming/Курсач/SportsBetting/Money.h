//---------------------------------------------------------------------------

#ifndef MoneyH
#define MoneyH
using namespace std;
void LoadMoneyFromFile(string path);
void MoneyDefault();
struct Cash
{
        float money;
        string currency;
};

list<Cash> allMoney;
//---------------------------------------------------------------------------
#endif
