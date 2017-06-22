/* Вывести список работодателей по заданному виду деятельности и отсортировать 
список по возрастанию комиссионных*/
create or replace procedure GetEmployersByActivityKind(activity in varchar, resultSet out SYS_REFCURSOR) as
begin
  open resultSet for select employers.id, deals.comission from employers 
    join deals on employers.id = deals.employer_id
      where employers.activity_kind = activity
        order by deals.comission;
end;