declare
  myCandidates SYS_REFCURSOR;
  
  type myRow is record (ID NUMBER, SALARY_SIZE NUMBER, COMISSION NUMBER);
  myRecord myRow;
begin
  CandidatesWithLessSalarySize(myCandidates);
  
  loop
    fetch myCandidates into myRecord;
    exit when myCandidates%notfound;
    DBMS_OUTPUT.PUT_LINE('id = ' || myRecord.id || ', salary_size = ' || myRecord.salary_size || ', comission = ' || myRecord.comission);
  end loop;  
   
end;