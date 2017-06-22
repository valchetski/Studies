 /* Определить  переменную  Date1  типа  ДАТА.  Присвоить  ей  значениедаты 
07.01.2012 в формате dd.mm.yyyy.*/
declare
  Date1 date;
begin
  Date1 := to_date('07.01.2012', 'dd.mm.yyyy');
  dbms_output.Put_line(TO_CHAR(Date1, 'dd.mm.yyyy'));
end;
