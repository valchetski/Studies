//---------------------------------------------------------------------------

#ifndef WorkWithFileH
#define WorkWithFileH
using namespace std;
struct Match
{
	string date;
	string time;
	string home;
	string guest;
	double winnerHome;
	double draw;
	double winnerGuest;
};
list<Match> football;
list<Match> hockey;
list<Match> basketball;

void LoadSport(string fileName, list<Match>& sport);
void SaveSport(string fileName, list<Match> sport);
void SaveSports();
list<Match> TodayMathes(list<Match> sport, string currencyData);
list<Match> ChoiceSport(TComboBox *choiceSport);
//---------------------------------------------------------------------------
#endif
