drop table "SYSTEM"."DEALS";
drop table "SYSTEM"."CANDIDATES";
drop table "SYSTEM"."EMPLOYERS";
--------------------------------------------------------
--  DDL for Table CANDIDATES
--------------------------------------------------------



  CREATE TABLE "SYSTEM"."CANDIDATES" 
   (	"ID" NUMBER, 
	"SURNAME" VARCHAR2(20 BYTE), 
	"FIRSTNAME" VARCHAR2(20 BYTE), 
	"PATRONYMIC" VARCHAR2(20 BYTE), 
	"QUALIFICATION" VARCHAR2(20 BYTE), 
	"ACTIVITY_KIND" VARCHAR2(20 BYTE), 
	"OTHER_DATA" VARCHAR2(20 BYTE), 
	"SALARY_SIZE" NUMBER
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index CANDIDATE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYSTEM"."CANDIDATE_PK" ON "SYSTEM"."CANDIDATES" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  Constraints for Table CANDIDATES
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."CANDIDATES" ADD CONSTRAINT "CANDIDATE_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "SYSTEM"."CANDIDATES" MODIFY ("ID" NOT NULL ENABLE);
  
  
--------------------------------------------------------
--  DDL for Table EMPLOYERS
--------------------------------------------------------

  CREATE TABLE "SYSTEM"."EMPLOYERS" 
   (	"ID" NUMBER, 
	"NAME" VARCHAR2(20 BYTE), 
	"ACTIVITY_KIND" VARCHAR2(20 BYTE), 
	"ADDRESS" VARCHAR2(20 BYTE), 
	"PHONE" VARCHAR2(20 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index EMPLOYERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYSTEM"."EMPLOYERS_PK" ON "SYSTEM"."EMPLOYERS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  Constraints for Table EMPLOYERS
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."EMPLOYERS" ADD CONSTRAINT "EMPLOYERS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "SYSTEM"."EMPLOYERS" MODIFY ("ID" NOT NULL ENABLE);
  
  
--------------------------------------------------------
--  DDL for Table DEALS
--------------------------------------------------------

  CREATE TABLE "SYSTEM"."DEALS" 
   (	"EMPLOYER_ID" NUMBER, 
	"CANDIDATE_ID" NUMBER, 
	"POSITION" VARCHAR2(20 BYTE), 
	"COMISSION" NUMBER
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  Ref Constraints for Table DEALS
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."DEALS" ADD CONSTRAINT "CANDIDATE_ID" FOREIGN KEY ("CANDIDATE_ID")
	  REFERENCES "SYSTEM"."CANDIDATES" ("ID") ENABLE;
  ALTER TABLE "SYSTEM"."DEALS" ADD CONSTRAINT "EMPLOYER_ID" FOREIGN KEY ("EMPLOYER_ID")
	  REFERENCES "SYSTEM"."EMPLOYERS" ("ID") ENABLE;



--remove and add new candidates
delete candidates;
insert into candidates (id, surname, firstname, patronymic, qualification, activity_kind, other_data, salary_size) 
  values (1,'Stasevich', 'Vitaliy', 'Alexandrovich', 'developer', 'it', 'sfsdf', 500);
  
insert into candidates (id, surname, firstname, patronymic, qualification, activity_kind, other_data, salary_size) 
  values (2,'Stasevich', 'Vitaliy', 'Alexandrovich', 'developer', 'it', 'sfsdf', 500);  
  
insert into candidates (id, surname, firstname, patronymic, qualification, activity_kind, other_data, salary_size) 
  values (3,'Stasevich', 'Vitaliy', 'Alexandrovich', 'developer', 'it', 'sfsdf', 500);  
  
insert into candidates (id, surname, firstname, patronymic, qualification, activity_kind, other_data, salary_size) 
  values (4,'Stasevich', 'Vitaliy', 'Alexandrovich', 'developer', 'it', 'sfsdf', 200);  
  
insert into candidates (id, surname, firstname, patronymic, qualification, activity_kind, other_data, salary_size) 
  values (5,'Stasevich', 'Vitaliy', 'Alexandrovich', 'developer', 'it', 'sfsdf', 500);  
  
--remove and add new employers
delete employers;
insert into employers (id, name, activity_kind, address, phone) values(1, 'I find your job1', 'some', 'Minsk', 'sdfsdfs');
insert into employers (id, name, activity_kind, address, phone) values(2, 'I find your job2', 'activity', 'Minsk', 'sdfsdfs');
insert into employers (id, name, activity_kind, address, phone) values(3, 'I find your job3', 'some', 'Minsk', 'sdfsdfs');
insert into employers (id, name, activity_kind, address, phone) values(4, 'I find your job4', 'good', 'Minsk', 'sdfsdfs');
insert into employers (id, name, activity_kind, address, phone) values(5, 'I find your job5', 'activity', 'Minsk', 'sdfsdfs');

--remove and add new deals
delete deals;
insert into deals (employer_id, candidate_id, position, comission) values(1,1,'developer', 100);
insert into deals (employer_id, candidate_id, position, comission) values(2,2,'developer', 1000);
insert into deals (employer_id, candidate_id, position, comission) values(3,3,'developer', 200);
insert into deals (employer_id, candidate_id, position, comission) values(4,4,'developer', 600);
insert into deals (employer_id, candidate_id, position, comission) values(5,5,'developer', 100);