delete databasechanged;

drop table "SYSTEM"."TESTTABLE";
create table "SYSTEM"."TESTTABLE"("ID" NUMBER);

drop view testView;
CREATE VIEW testView AS SELECT * FROM deals;

select * from databasechanged;