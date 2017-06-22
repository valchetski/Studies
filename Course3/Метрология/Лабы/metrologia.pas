var 
  a: array[1..8, 1..8] of integer;
  i, j, temp, min, minRow, minCol : integer;
 begin
  for i:= 1 to 8 do begin//ввод массива
    for j:=1 to 8 do begin
      a[i,j] := 25 - random(50);
      write(a[i, j] + ' ');      
    end;
    writeln();
  end;
    
  min := a[1,1];//находим минимальный
  for i:= 1 to 8 do
    for j:=1 to 8 do begin
      if(a[i,j] < min) then 
      begin
        min := a[i,j];
        minRow := i;
        minCol := j;
      end;      
    end; 
    
  if(min < -1) then//меняем местами
  begin
    for i:=1 to 8 do 
    begin
      temp := a[i, i];
      a[i, i] := a[i,8-i+1];
      a[i,8-i+1] := temp;       
    end;
  end;
  
  writeln(min);
  writeln(minRow);
  writeln(minCol);
  
  for i:= 1 to 8 do begin
    for j:=1 to 8 do begin      
      write(a[i, j] + ' ');
    end;
    writeln();
  end;  
 end.