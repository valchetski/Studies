BEGIN{
	FS ="," #задаем свой разделитель столбцов
	isThereFilm=0
	maxBudget=0	
	number=0
	
	print "Введите название фильма:"
	getline filmName < "-"
	print "\nРезультат поиска:"
}
{	
	if(filmName == $1)
	{
		print $0
		isThereFilm=1
	}

	if(maxBudget < $3)
	{
		maxBudget = $3
		maxBudgetFilm = $1
	}	

	years[$2] = years[$2] " " $1 ", "
	
}

$2~19{	
	filmsBefore2000 = filmsBefore2000 $1 ":" $2 ","	
}

/а/{
	number++
}



END{
	if(isThereFilm == 0)
	{
		print "Фильм \"" filmName "\" не найден\n"
	}
		
	print "Всего фильмов: " NR "\n"
	print "Количество фильмов с буквой \"а\" в названии: " number "\n"

	print "Наибольший бюджет в размере" maxBudget "$ у фильма " maxBudgetFilm "\n"  

	
	print "Фильмы по годам"	
	for(year in years)
	{
		print year " : " substr(years[year], 1, length(years[year])-2)	
	}

	print "\nФильмы до 2000 года"	
	split(filmsBefore2000, array, ",")	
	for(film in array)
	{
		split(array[film], array1, ":")		
		print array1[1] array1[2]	

	}	
}



