USE `mydb`;

#удаляем проверку на внешние ключи 
#это позволит выполнить удаление в следующей строчке
SET FOREIGN_KEY_CHECKS=0; 

		

DELETE FROM country WHERE idCountry > 0; #удалит все записи
ALTER TABLE country AUTO_INCREMENT = 1;
INSERT INTO country (Name) VALUES ('Belarus');
INSERT INTO country (Name) VALUES ('Russia');
INSERT INTO country (Name) VALUES ('Ukraine');
INSERT INTO country (Name) VALUES ('Australia');
INSERT INTO country (Name) VALUES ('New Zealand');

DELETE FROM city WHERE idCity > 0;
ALTER TABLE city AUTO_INCREMENT = 1;
INSERT INTO city (Name, Country_idCountry) VALUES ('Minsk', 1);
INSERT INTO city (Name, Country_idCountry) VALUES ('Moscow', 2);
INSERT INTO city (Name, Country_idCountry) VALUES ('Kiev', 3);
INSERT INTO city (Name, Country_idCountry) VALUES ('Sidney', 4);
INSERT INTO city (Name, Country_idCountry) VALUES ('Auckland', 5);

DELETE FROM adress WHERE idAdress > 0;
ALTER TABLE adress AUTO_INCREMENT = 1;
INSERT INTO adress (Street, HoUSE, City_idCity) VALUES ('J. Kolasa', '28', 1);
INSERT INTO adress (Street, HoUSE, City_idCity) VALUES ('Lenina', '12a', 2);
INSERT INTO adress (Street, HoUSE, City_idCity) VALUES ('Frunze', '72', 3);
INSERT INTO adress (Street, HoUSE, City_idCity) VALUES ('Del Piero', '10', 4);
INSERT INTO adress (Street, HoUSE, City_idCity) VALUES ('Carter', '7', 5);
INSERT INTO adress (Street, HoUSE, City_idCity) VALUES ('For Hotel', '1', 1);

DELETE FROM company WHERE idCompany > 0;
ALTER TABLE company AUTO_INCREMENT = 1;
INSERT INTO company (Name, Adress_idAdress) VALUES('Go find yourself!', 1);
INSERT INTO company (Name, Adress_idAdress) VALUES('U Michalicha', 2);
INSERT INTO company (Name, Adress_idAdress) VALUES('Dynamo', 3);
INSERT INTO company (Name, Adress_idAdress) VALUES('Paradyse', 4);
INSERT INTO company (Name, Adress_idAdress) VALUES('Paradyse v2.0', 5);

DELETE FROM client WHERE idClient > 0;
ALTER TABLE client AUTO_INCREMENT = 1;
INSERT INTO client (Firstname, Surname, BirthDate) VALUES ('Alexander', 'Volchetsky', '1995-03-22');
INSERT INTO client (Firstname, Surname, BirthDate) VALUES ('Ivan', 'Steriotipoff', '1995-04-22');
INSERT INTO client (Firstname, Surname, BirthDate) VALUES ('Piatro', 'Gunko', '1991-03-25');
INSERT INTO client (Firstname, Surname, BirthDate) VALUES ('Tim', 'Cahill', '1985-06-22');
INSERT INTO client (Firstname, Surname, BirthDate) VALUES ('Some', 'Man', '1965-01-22');

DELETE FROM company_has_client WHERE Company_idCompany > 0;
ALTER TABLE company_has_client AUTO_INCREMENT = 1;
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (1,1);
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (1,2);
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (2,3);
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (3,3);
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (4,5);
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (5,2);
INSERT INTO company_has_client (Company_idCompany, Client_idClient) VALUES (2,4);

DELETE FROM hotel WHERE idHotel > 0;
alter table hotel auto_increment = 1;
INSERT INTO hotel (Name, StarsCount, Adress_idAdress) VALUES ('Europa', 5, 6);
INSERT INTO hotel (Name, StarsCount, Adress_idAdress) VALUES ('Diamond', 4, 4);

DELETE FROM room WHERE idRoom > 0;
alter table room auto_increment = 1;
INSERT INTO room (idRoom, CostPerDay, Hotel_idHotel) VALUES (1, 70, 1);
INSERT INTO room (idRoom, CostPerDay, Hotel_idHotel) VALUES (2, 100.4, 1);
INSERT INTO room (idRoom, CostPerDay, Hotel_idHotel) VALUES ('3a', 45.13, 2);
INSERT INTO room (idRoom, CostPerDay, Hotel_idHotel) VALUES (4, 40.13, 2);





