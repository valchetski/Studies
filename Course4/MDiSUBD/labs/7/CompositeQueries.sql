USE `mydb`;

SELECT hotel.Name, mIN(room.CostPerDay) AS MINCost FROM hotel
	INNER JOIN room ON room.Hotel_idHotel = hotel.idHotel
		WHERE hotel.idHotel = (SELECT hotel.idHotel FROM hotel WHERE hotel.StarsCount > 4) 
			GROUP BY hotel.Name;
        
   
SELECT city.Name, count(adress.Street) AS StreetCount FROM city 
	INNER JOIN adress ON adress.City_idCity = city.idCity
		WHERE city.idCity IN (SELECT city.idCity FROM city WHERE length(city.Name) < 6) 
			GROUP BY city.idCity;     
            
SELECT company.Name, client.Firstname, mIN(client.BirthDate)  FROM company
	INNER JOIN company_hAS_client ON company.idCompany = company_hAS_client.Company_idCompany
		INNER JOIN client ON company_hAS_client.Client_idClient = client.idClient
			WHERE client.BirthDate IN (SELECT client.BirthDate FROM client WHERE client.BirthDate < '2000.01.01')
				GROUP BY company.idCompany;
                
   
        
            