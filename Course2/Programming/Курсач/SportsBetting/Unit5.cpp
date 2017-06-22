//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit5.h"
#include "Unit4.h"
#include "Unit3.h"
#include "Unit1.h"
#include "Money.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm5 *Form5;
//---------------------------------------------------------------------------
__fastcall TForm5::TForm5(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm5::FormCreate(TObject *Sender)
{
        Edit1->Clear();
        Edit2->Clear();
        Label3->Hide();
        if(EnterInProfile())
        {
                Form1->Enter();
        }
        else
        {
                Form5->Show();
        }
        Form4->allUsersNames = Form5->FindAllUsers();
}
//---------------------------------------------------------------------------
bool TForm5::EnterInProfile()
{
        string pathFile = "D:\\Учеба\\Программирование\\Курсач\\SportsBetting\\RunOptions.txt";
        ifstream file(pathFile.c_str());
        string login, password;
        bool isEnter = false;
	while(!file.eof())
	{
                string temp;
		getline(file, temp, ' ');
		if ((!temp.empty()) && (temp != "\n"))
                {
                        login = temp;
		        getline(file, temp, '\n');
                        password = temp;
                        isEnter = true;
                        Form5->Enter(login, password);
                        break;
                }
        }
        file.close();
        return isEnter;
}

void __fastcall TForm5::Button1Click(TObject *Sender)
{
        Form5->Hide();
        Form4->Show();
}
//---------------------------------------------------------------------------
void __fastcall TForm5::BitBtn1Click(TObject *Sender)
{
        string login = Edit1->Text.c_str();
        string password = Edit2->Text.c_str();
        if(Enter(login, password))
        {
                RememberMe(login, password);
        }
}

void TForm5::RememberMe(string login, string password)
{
        string pathRunOptions = "D:\\Учеба\\Программирование\\Курсач\\SportsBetting\\RunOptions.txt";
        if (CheckBox1->Checked)
        {
                ofstream fileRunOptions(pathRunOptions.c_str(), ios::app);
                fileRunOptions << login << " ";
                fileRunOptions << password << "\n";
                fileRunOptions.close();
        }
        else
        {
                ofstream fileRunOptions(pathRunOptions.c_str());//содержимое файла очищается
                fileRunOptions.close();
        }
}

bool TForm5::Enter(string login, string password)
{
        list<string> allUsers = Form5->FindAllUsers();
        int size = allUsers.size();
        bool isEnter = false;
        for (int i = 0; i < size; i++)
        {
                string directoryName = allUsers.front();
                allUsers.pop_front();
                userDirectory = path + directoryName + "\\";
                if(directoryName == login)
                {
                        if(password == GetPassword(login))
                        {
                                Form5->Hide();
                                LoadAll(login);
                                isEnter = true;
                                break;
                        }
                }
        }
        if (isEnter)
        {
                Form1->Enter();
        }
        else
        {
                Label3->Show();
        }
        return isEnter;
}

string TForm5::GetPassword(string login)
{
        string pathFile = userDirectory + login + ".txt";
        ifstream file(pathFile.c_str());
        string password = "";
	while(!file.eof())
	{
                string temp;
		getline(file, temp, '\n');
		if ((!temp.empty()) && (temp != "\n") && (temp == "Пользователь"))
                {
		        getline(file, temp, ' ');
                        if (temp == login)
                        {
                                getline(file, password, ' ');
                                break;
                        }
                }
        }
        file.close();
        return password;
}

//---------------------------------------------------------------------------
void TForm5::LoadAll(string login)
{
        string pathFile = userDirectory + login + ".txt";
        ifstream file(pathFile.c_str());
        LoadUser(file);
        string pathMoney =  userDirectory + login + "Money.txt";
        LoadMoneyFromFile(pathMoney);
        string pathBet = userDirectory + login + "Bet.txt";
        string pathBetCopy = userDirectory + "copy" + login + "Bet.txt";
        ifstream fileBet(pathBet.c_str());
        ofstream fileBetCopy(pathBetCopy.c_str());
        Form1->MyBetToForm(fileBet, fileBetCopy);
        Form1->MyMoneyToForm();
        /////////////////////////
        fileBet.close();
        fileBetCopy.close();
        ifstream ifs(pathBetCopy.c_str());  //Потом переместить куда-нибуддь
        ofstream ofs(pathBet.c_str());
        string stri;
        while (getline(ifs,stri))
                ofs << stri << '\n';
        ///////////////////////////////
}

void TForm5::LoadUser(ifstream& file)
{
	string str;
	while(!file.eof())
	{
		getline(file, str, '\n');
		if ((!str.empty()) && (str != "\n") && (str == "Пользователь"))
                {
                        User user = Form4->user;
		        getline(file, str, ' ');
                        user.login = str;
                        getline(file, str, ' ');
                        user.password = str;
                        getline(file, str, ' ');
                        user.mail = str;
                        getline(file, str, ' ');
                        user.webMoneyPurse = str;
                        getline(file, str, ' ');
                        user.gender = str;
                        getline(file, str, ' ');
                        user.dateOfBirth = str;
                        getline(file, str, '\n');
                        user.location = str;
                        Form4->user = user;
                        break;
                }
	}
}

list<string> TForm5::FindAllUsers()
{
                string folder_path = path.c_str();
                folder_path += "*";
		HANDLE hSearch;
		WIN32_FIND_DATA pFileData;
		hSearch = FindFirstFile(folder_path.c_str(), &pFileData);
                list<string> allUsers;
		if (hSearch != INVALID_HANDLE_VALUE)
                {
			do
			{
				if ((pFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
                                {
                                        string directoryName = pFileData.cFileName;
                                        if ((directoryName != ".") && (directoryName != ".."))
                                        {
                                                allUsers.push_back(directoryName);
                                        }
                                }
			}
			while (FindNextFile(hSearch, &pFileData));
                }
                FindClose(hSearch);
                return allUsers;
}
void __fastcall TForm5::FormClose(TObject *Sender, TCloseAction &Action)
{
        Form1->NotEnter();
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit1Change(TObject *Sender)
{
        Label3->Hide();        
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit2Change(TObject *Sender)
{
        Label3->Hide();        
}
//---------------------------------------------------------------------------
void TForm5::CloseRegistration()
{
        Form5->Show();
}

