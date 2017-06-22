declare
  deal varchar(100);
begin
  deal := higherdeal(160);
  dbms_output.put_line(deal);
end;