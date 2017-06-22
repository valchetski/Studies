USE `mydb`;

DELETE client , company_has_client  FROM client, company_has_client  
	WHERE client.idClient = company_has_client.Client_idClient AND client.BirthDate <= '1995-01-01';

