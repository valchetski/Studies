/* Объявить  переменные  типа  INT,  DATE,  BOOLEAN.  Присвоитьзначения, 
соответствующие типам. Выполнить преобразование переменных типа INT, DATE, 
BOOLEAN  в  FLOAT,  CHAR,  SMALLINT  соответственно  и  вывести  результат  на 
экран
*/
declare
  vInt int := 12;
  vDate date := to_date('07.01.2012', 'dd.mm.yyyy');
  vBool boolean := true;
  vFloat float;
  vSmallInt smallint;
begin
  select (cast(vInt as float)) into vFloat from dual;
  dbms_output.Put_line(vFloat);
  
  dbms_output.Put_line(to_char(vDate));
  
  if(vBool) then
    vSmallInt := 1;
  else
    vSmallInt := 0;
  end if;
  dbms_output.Put_line(vSmallInt);
end;