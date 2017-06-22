create or replace package cursorsPackage is

  CURSOR ids return candidates%Rowtype;  

end cursorsPackage;
/
create or replace package body cursorsPackage is

  CURSOR ids return candidates%Rowtype  IS SELECT * FROM candidates; 

end cursorsPackage;