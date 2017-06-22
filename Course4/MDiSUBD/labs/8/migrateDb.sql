DELETE FROM client WHERE client.idClient > 0;
ALTER TABLE client AUTO_INCREMENT = 1;
INSERT INTO mynewdb.client SELECT * FROM mydb.client;

DELETE FROM company WHERE company.idCompany > 0;
ALTER TABLE company AUTO_INCREMENT = 1;
INSERT INTO mynewdb.company SELECT * FROM mydb.company;

DELETE FROM company_has_client WHERE company_has_client.Client_idClient > 0;
ALTER TABLE client AUTO_INCREMENT = 1;
INSERT INTO mynewdb.company_has_client SELECT * FROM mydb.company_has_client;

INSERT INTO mynewdb.adress(Street, House, City, Country)
	SELECT Street, House, mydb.city.Name, mydb.Country.Name FROM mydb.adress
		INNER JOIN mydb.city ON mydb.adress.City_idCity = mydb.city.idCity
			INNER JOIN mydb.country ON mydb.city.Country_idCountry = mydb.country.idCountry;
			