/*Вывести сделку, у которой размер комиссионных превышает заданное число*/
create or replace function HigherDeal(comission_number in number) return varchar is
  dealStr varchar(100);
begin
  select (employer_id || ' ' || candidate_id || ' ' || position || ' ' || comission) into dealStr from deals where 
    (comission > comission_number and rownum = 1);  
  return dealStr;
end;