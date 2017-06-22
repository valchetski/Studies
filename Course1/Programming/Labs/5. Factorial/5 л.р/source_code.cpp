#include <stdio.h> 
#include <malloc.h> 
#include <string.h> 
#include <Windows.h>
#include <locale.h>

typedef struct item 
{ 
	int digit; 
	struct item *next; 
	struct item *prev; 
} Item; 

typedef struct mnumber 
{ 
	Item *head; 
	Item *tail; 
	int n; 
} MNumber; 
 
MNumber CreateMNumber(char *initStr); 
void AddDigit(MNumber *number, int digit); 
void PrintMNumber(MNumber number); 
MNumber MultiMNumber(MNumber n1, MNumber n2); 
MNumber SumMNumber(MNumber result, MNumber factor); 
 
void main(void) 
{ 
	setlocale( LC_ALL,"Russian" ); 
	int n = 0;
	char str[10];
	printf("¬ведите n=");
	scanf("%d", &n);
	MNumber result = CreateMNumber("1");
	for (int i = 1; i <= n; i++)
	{
		MNumber factor = CreateMNumber(itoa (i, str, 10));
		result = MultiMNumber(result, factor); 
	}
	printf("\t%d!=",n);
	PrintMNumber(result);
	printf("\n");
	system("pause");
} 

MNumber CreateMNumber(char initStr[]) 
{ 
	MNumber number = {NULL, NULL, 0}; 
	for (int n = strlen(initStr)-1; n >= 0; n--) 
		AddDigit(&number, initStr[n]-'0'); 
	return number; 
} 

void AddDigit(MNumber *number, int digit) 
{ 
    Item *p = (Item *)malloc(sizeof(Item)); 
    p->digit = digit; 
    p->next = p->prev = NULL; 
    if (number->head == NULL) 
      number->head = number->tail = p; 
    else 
	{ 
      number->tail->next = p; 
      p->prev = number->tail; 
      number->tail = p; 
    } 
    number->n++; 
} 

MNumber MultiMNumber(MNumber result, MNumber factor) 
{ 
	MNumber multi = CreateMNumber(""); 
	MNumber summand = CreateMNumber(""); 
	Item *p_result = result.head, *p_factor = factor.head; 
	int digit, pos = 0, zeros = 0, value_result, value_factor; 
	while (p_factor || p_result)
	{
		if (p_factor)
		{
			value_factor = p_factor->digit;
			p_factor = p_factor->next;
		}
		else
			value_factor = 0;
		p_result = result.head;
		multi = CreateMNumber("");
		for (int i = 1; i<=zeros; i++)
			AddDigit(&multi, 0);
		zeros++;
		while (p_result) 
		{ 
			if (p_result) 
			{ 
				value_result = p_result->digit; 
				p_result = p_result->next;
			} 
			else 
				value_result = 0; 
			digit = (value_result * value_factor + pos) % 10; 
			pos = (value_result * value_factor + pos) / 10; 
			AddDigit(&multi, digit); 
		}
		if (pos) 
			AddDigit(&multi, pos);
		summand = SumMNumber(multi, summand);
	}  
	return summand;
} 

MNumber SumMNumber(MNumber multi, MNumber summand)
{
	MNumber sum = CreateMNumber(""); 
	Item *p_multi = multi.head, *p_summand = summand.head; 
	int digit, pos = 0, value_multi, value_summand; 
	while (p_multi || p_summand)
	{ 
		if (p_multi) 
		{
			value_multi = p_multi->digit; 
			p_multi = p_multi->next;
		} 
		else
			value_multi = 0; 
		if (p_summand) 
		{
			value_summand = p_summand->digit; 
			p_summand = p_summand->next;
		} 
		else
			value_summand = 0; 
		digit = (value_multi + value_summand + pos) % 10; 
		pos = (value_multi + value_summand + pos) / 10; 
		AddDigit(&sum, digit); 
	} 
	if (pos)
		AddDigit(&sum, pos); 
  return sum; 
} 

void PrintMNumber(MNumber number) 
{ 
   Item *p = number.tail; 
   while (p) 
   { 
		printf("%d", p->digit); 
		p = p->prev; 
   } 
 } 