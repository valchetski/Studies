#!/bin/bash

oldLab() #функция без аргументов       
{	
	echo -n "Пользователь: " > $filename
	#параметр -n не выводит в конце символ новой строки
	whoami >> $filename
	echo -n "Сегодняшняя дата: " >> $filename
	echo `date` >> $filename
	echo -n "Количество процессов: " >> $filename
	ps -a | wc -l >> $filename # | это конвейер
	#wc -l количество строк
}

clear

filename="result.txt" 
directoryName="1.ShellScript"
test -d $directoryName || mkdir $directoryName
#test -d вернет 0 если папка уже существует
cd $directoryName && touch $filename
oldLab

echo "\tСодержимое файла $filename:"
cat $filename 

echo "\tКоличество txt файлов в папке $directoryName: "
ls [a-r][a-e]*.t?t | wc -l #там будет один файл result.txt

echo "\tВсе файлы папки $directoryName: "
for file in `ls`
do
  echo $file
done








