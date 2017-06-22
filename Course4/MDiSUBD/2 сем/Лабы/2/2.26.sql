/* Создать курсор по данным нескольких таблиц на выбор с несколькими полями*/
DECLARE
  CURSOR ids IS SELECT candidates.id as cId, employers.id as eId FROM candidates, employers;
  cursorRow ids%ROWTYPE;
BEGIN
  OPEN ids; 

	FETCH ids INTO cursorRow;		
  dbms_output.Put_line(cursorRow.cId); 
  dbms_output.Put_line(cursorRow.eId); 
	
	CLOSE ids;
END;