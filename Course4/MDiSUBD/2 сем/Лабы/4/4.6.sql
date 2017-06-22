/*Создать строковый триггер, который будет фиксировать в отдельно организованной 
таблице  старое  и  новое  значение  текстового  поля,  если  в  одной  из  таблиц  было 
изменено это значение*/

CREATE OR REPLACE TRIGGER ChangeWatcher
  BEFORE INSERT OR UPDATE OF comission ON deals
      FOR EACH ROW
begin
  insert into comissionchanged(old_value, new_value) values(:old.comission, :new.comission);     
end;
         
      