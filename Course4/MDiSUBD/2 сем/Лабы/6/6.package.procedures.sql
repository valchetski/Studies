create or replace package proceduresPackage is

  procedure CandidatesWithLessSalarySize(resultSet out SYS_REFCURSOR );
  
  procedure GetEmployersByActivityKind(activity in varchar, resultSet out SYS_REFCURSOR);

end proceduresPackage;
/
create or replace package body proceduresPackage is

procedure CandidatesWithLessSalarySize(resultSet out SYS_REFCURSOR ) as  
begin
  open resultSet for select candidates.id, candidates.salary_size, deals.comission from candidates 
    join deals on candidates.id = deals.candidate_id
      where (candidates.salary_size < deals.comission);    
end;

procedure GetEmployersByActivityKind(activity in varchar, resultSet out SYS_REFCURSOR) as
begin
  open resultSet for select employers.id, deals.comission from employers 
    join deals on employers.id = deals.employer_id
      where employers.activity_kind = activity
        order by deals.comission;
end;

end proceduresPackage;