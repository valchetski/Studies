/* Создать  системный  триггер  на  уровне  схемы,  который  будет  фиксировать  в 
отдельно  организованной  таблице  информацию  о  пользователях  и  объектах, 
структуру  которых  создают,  причем  таким  объектом  является  таблица  или 
представление.*/

create or replace trigger SystemTrigger
  after create on schema
declare
  objectType varchar(10) := 'Unknown';
begin
  if ora_dict_obj_type = 'TABLE' then 
    objectType := 'Table';
  elsif ora_dict_obj_type = 'VIEW' then
    objectType := 'View';
  end if;   
  
  insert into databasechanged(username, object_type) values (user, objectType);
end;