#include <iostream>
#include <string.h>
 
#define NUMBER 1000
#define DELIM " \t\n,.:;!?"
#define MAX_WORDS 1000
 
int split(char* str, char** tok);
int unique(char** arr, int size);
 
void main()
{
	setlocale( LC_ALL, "rus" );
	char buf0[NUMBER] = "", text[NUMBER] = "", buf[NUMBER] = "";
	FILE *fp;
	int i, array_count[NUMBER];
	fp = fopen("input.txt", "r");  
	if (!fp) //если файл не открылся, то происходит выход из программы
		exit(1);         
	while (fgets(text, NUMBER, fp) != NULL)//копирование слов из текста в строку
	{
		for (i = 0; i < (int) strlen(text); i++)
			if (text[i] == '\n')
				text[i] = '\0';
		strcat(buf0, text);
		strcat(buf0, " ");
	}
	char* unique_token[MAX_WORDS];
	strcpy(buf, buf0);
	int words = split(buf, unique_token);//считает количество слов и заносит их в массив	
    int new_size = unique(unique_token, words);	//удаляет слово из массива, если она повторяется в тексте более одного раза и возвращает размер массива	
	strcpy(buf, buf0);
	char* token[MAX_WORDS];
	split(buf, token);
	for (i = 0; i < new_size; ++i)
	{
		int count = 0;
		for (int j = 0; j < words; ++j)
			if (!strcmp(token[j], unique_token[i]))//проверяет, равны ли элементы в массивах
				++count;
		array_count[i] = count;	
	}
	char* temp[1];	
	 for(i = 0; i < new_size; i++)
        for(int j = (new_size - 1); j > i; j--)
            if(array_count[j - 1] < array_count[j])//сортировка элементов по убыванию
            {
                int x = array_count[j - 1];
				temp[0] = unique_token[j - 1];
                array_count[j - 1] = array_count[j];
				unique_token[j - 1] = unique_token[j];
                array_count[j] = x;
				unique_token[j] = temp[0];
            }
	if (new_size > 20)//будет выводится 20 наиболее используемых слов
		new_size = 20;
	for (i = 0; i < new_size; ++i)
	{
		if (array_count[i] == 1)
			break;
		printf("%s\t-\t%d\n", unique_token[i], array_count[i]);
	}
    fclose(fp);
	system("pause");
}
 
int split(char* str, char** token)//считает количество слов и заносит их в массив	
{
    int tokens = 0;
	char* ptr = strtok(str, DELIM);
    for (; ptr != NULL; ptr = strtok(NULL, DELIM), ++tokens)
        token[tokens] = ptr;
    return tokens;
}
 
int unique(char** arr, int size)	//удаляет слово из массива, если она повторяется в тексте более одного раза и возвращает размер массива	
{
    int i, j;
    for (i = 0; i < size; ++i)
        for (j = 0; j < size; ++j)
            if (i != j && !strcmp(arr[i], arr[j]))
            {
                int t = j;
                --size;
                for (; t < size; ++t)
                    arr[t] = arr[t + 1];
                arr[t] = NULL;				
            }
    return size;
}