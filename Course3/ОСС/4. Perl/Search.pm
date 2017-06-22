use strict;

package Search;

use constant 
{
	BUS => "автобус",
	TROLLEYBUS => "троллейбус",
	TRAM => "трамвай"
};

#здесь ищем транспорт следующий по искомому маршруту
sub SearchTransport
{	
	#присваиваем номер маршрута	
	my $routeNumber = 0;
	if(@_[1] > 0)
	{
		$routeNumber = @_[1];
	}

	#определяем вид транспорта	
	my $transportName = "";
	if(@_[2] eq "1")
	{
		$transportName = BUS;
	}
	elsif(@_[2] eq "2")
	{
		$transportName = TROLLEYBUS;
	}
	elsif(@_[2] eq "3")
	{
		$transportName = TRAM;
	}
		

	#проверяем, есть ли такой маршрут	
	my @route = {};	
	open(transportFile, "transports");
	while(my $line = <transportFile>)
	{
		my @fields = split /, /, $line;
		if(($fields[0] == $routeNumber) && ($fields[1] == $transportName))
		{					
			chop $fields[@fields - 1];			
			@route = @fields;
		}				
	}
	return @route;
}

sub SearchShedule
{
	my $result = "";
	my $currentHour = 0;
	my $stopTime = "";	
	open(stopsFile, "stops");
	while(my $line = <stopsFile>)
	{
		my @fields = split /, /, $line;
		chop $fields[@fields - 1];
		#номер маршрута, вид транспорта, остановка, конечная остановка
		if(($fields[0] eq @_[1]) && ($fields[1] eq @_[2]) && ($fields[2] eq @_[3]) && ($fields[3] eq @_[4]))
		{			
			#в этом цикле добавляем время остановок транспорта
			for(my $i=4; $i < @fields; $i++)
			{
				$stopTime = $fields[$i];

				if($currentHour == 0)
				{
					$currentHour = (split /:/, $stopTime)[0];
				}
				elsif($currentHour < (split /:/, $stopTime)[0])
				{
					$currentHour = (split /:/, $stopTime)[0];
					$result = $result . "\n";
				}			
				$result = $result . $stopTime . ", ";
			}			
		}		
	}
	chop $result; #удаляет пробел в конце
	chop $result; #удаляет запятую в конце
	$result = $result . "\n";
	return $result;
}

#возвращает массив где будут хранится результаты, удовлетворяющие поиску
#т.е все названия остановок которые содержат строку, переданную через параметр
sub GetStops
{
	chop $_[1]; #обрезаю \n		
	my @stops;	
	my $i = 0;
	open(stopsFile, "stops");	
	while(my $line = <stopsFile>)
	{
		my @fields = split /, /, $line;
		chop $fields[@fields - 1];	
		
		if($fields[2] =~ /$_[1]/) #в fields[2] находится название остановки
		{			
			#если такой остановки нету в массиве--добавим ее			
			unless ($fields[2] ~~ @stops)
			{
				$stops[$i] = $fields[2];
				$i++;
			}								
		}
	}
	return @stops;
}

#возвращает строку, где хранится информация о останавливающемся на остановке транспорте
#остановка передается через параметр
sub SearchTransportStop
{	
	chop ($_[2]);
	my $result = "";
	my @stops;

	my @justArray = localtime();
	my $timeNow = $justArray[2] . ":" . $justArray[1];

	open(stopsFile, "stops");
	while(my $line = <stopsFile>)
	{
		my @fields = split /, /, $line;
		chop $fields[@fields - 1];	
		
		if($fields[2] =~ /$_[1]/) #в fields[2] находится название остановки
		{					
			#в массив добавляется время, номер маршрута, вид транспорта, конечная остановка			
			for(my $i = 4; $i < @fields; $i++)
			{				
				if($_[2] == 2)
				{
					$stops[@stops] = $fields[$i] . " " . $fields[0] . " " . $fields[1] . " " . $fields[3];
				}
				elsif($_[2] == 1)
				{				
					#если время остановки больше текущего времени--добавляем в массив инфу				
					if((split /:/, $fields[$i])[0] > (split /:/, $timeNow)[0])
					{
						$stops[@stops] = $fields[$i] . " " . $fields[0] . " " . $fields[1] . " " . $fields[3];
					}
					elsif(((split /:/, $fields[$i])[0] == (split /:/, $timeNow)[0]) && 
						((split /:/, $fields[$i])[1] >= (split /:/, $timeNow)[1]))
					{
						$stops[@stops] = $fields[$i] . " " . $fields[0] . " " . $fields[1] . " " . $fields[3];

					}
				}				
			}		
										
		}
	}
	#теперь этот массив надо отсортировать. сортируем по времени
	@stops = sort(@stops);

	for(my $i = 0; $i < @stops; $i++)
	{
		$result = $result . $stops[$i] . "\n";	
	}	
	return $result;
}

1;
