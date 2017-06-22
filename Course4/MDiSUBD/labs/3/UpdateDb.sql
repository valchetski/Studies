USE `mydb`;

UPDATE city SET Name = 'Gomel' WHERE Name = 'Minsk';

UPDATE client SET Firstname = 'Just', Surname = 'UPDATEd' WHERE FirstName = 'Piatro' AND Surname = 'Gunko';

UPDATE adress SET Street = 'UPDATEd Street', House = '1u' WHERE Street = 'Carter' AND House = '7';