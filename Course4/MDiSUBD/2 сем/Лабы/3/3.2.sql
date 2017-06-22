/*Вывести список соискателей, которые имеют предполагаемый размер заданной 
платы меньше, чем размер комиссионных, предлагаемых со стороны 
работодателя. 
*/
create or replace procedure CandidatesWithLessSalarySize(resultSet out SYS_REFCURSOR ) as  
begin
  open resultSet for select candidates.id, candidates.salary_size, deals.comission from candidates 
    join deals on candidates.id = deals.candidate_id
      where (candidates.salary_size < deals.comission);    
end;