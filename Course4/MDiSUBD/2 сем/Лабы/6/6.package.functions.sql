create or replace package functionsPackage is

  function higherdeal(comission_number in number) return varchar;

end functionsPackage;
/
create or replace package body functionsPackage is

function higherdeal(comission_number in number) return varchar is
    dealStr varchar(100);
begin
  select (employer_id || ' ' || candidate_id || ' ' || position || ' ' || comission) into dealStr from deals where 
    (comission > comission_number and rownum = 1);  
  return dealStr;
end higherdeal;

end functionsPackage;