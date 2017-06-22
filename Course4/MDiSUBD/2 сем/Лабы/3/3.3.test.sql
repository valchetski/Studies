declare
  myEmployers SYS_REFCURSOR;
  
  type myRow is record (ID NUMBER, comission varchar(100));
  myRecord myRow;
begin
  GetEmployersByActivityKind('activity', myEmployers);
  
  loop
    fetch myEmployers into myRecord;
    exit when myEmployers%notfound;
    DBMS_OUTPUT.PUT_LINE('id = ' || myRecord.id || ', comission = ' || myRecord.comission);
  end loop;  
   
end;