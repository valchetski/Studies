/*Предусмотреть  обработку  пользовательского  исключения,  когда  при  добавлении 
нового  соискателя  выводилось  бы  пользовательское  сообщение  об  ошибке,  если 
фамилия, имя и отчество полностью совпадают. 
*/
CREATE OR REPLACE TRIGGER UserException
  BEFORE INSERT ON candidates
      FOR EACH ROW
declare
  allTheSame exception;
begin
  if :new.firstname = :new.surname and :new.surname = :new.patronymic then
    raise allTheSame;
  end if;
exception
  when allTheSame then
     raise_application_error(-20000, 'User error: firstname, surname and patronymic are the same!');
end;