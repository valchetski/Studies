/*Создать  операторный  триггер,  который  будет  фиксировать  в  отдельно 
организованной  таблице  дату  операции,  вид  операции,  имя  пользователя  при 
удалении, добавлении или изменении данных в одной из таблиц.*/
create or replace trigger DealsChanged
  before delete or insert or update on deals
declare
  operationKind varchar(10) := 'Unknown';
begin
  if deleting then
    operationKind := 'Delete'; 
  elsif inserting then
    operationKind := 'Insert';   
  elsif updating then
    operationKind := 'Update';
  end if; 
  
  insert into dealschanged(operation_date, operation_kind, username) values(SYSDATE, operationKind, user);
end;