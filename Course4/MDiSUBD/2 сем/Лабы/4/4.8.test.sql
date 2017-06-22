delete dealschanged;

update deals set comission = 150 where employer_Id = 2 or employer_id = 1;

insert into deals (employer_id, candidate_id, position, comission) values(2,1,'developer', 300);
delete deals where employer_id = 2 and  candidate_id = 1;

select * from dealschanged;