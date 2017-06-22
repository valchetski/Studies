declare
  deal varchar(100);
  myCandidates SYS_REFCURSOR;
begin
  deal := functionsPackage.higherdeal(160);
  dbms_output.put_line(deal);
  
  proceduresPackage.CandidatesWithLessSalarySize(myCandidates);
end;