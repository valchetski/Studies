/* Создать  локальную  таблицу  с  названием  TEMP  по  одной  из  таблицы  в  базе 
данных  на  выбор.В  цикле  перебрать  записи  таблицы  и  вывести  каждую  запись 
изцикла на экран*/

drop table temp;
CREATE GLOBAL TEMPORARY TABLE TEMP ON COMMIT PRESERVE ROWS AS (SELECT * FROM deals);

begin   
  for i in (select * from TEMP) loop
    dbms_output.Put_line(i.employer_id || ' ' || i.candidate_id || ' ' || i.position || ' ' || i.comission);
  end loop;   
end;



