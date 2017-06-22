USE `mydb`;

#количество улиц в городе
SELECT city.Name AS City, count(Street) AS StreetsCount  FROM city, adress
	WHERE adress.City_idCity = city.idCity GROUP BY City_idCity;
    
#минимальная цена в отеле
SELECT hotel.Name, min(room.CostPerDay) AS MinCost FROM hotel, room
	WHERE room.Hotel_idHotel = hotel.idHotel GROUP BY hotel.Name;
    
    
    
    
#города с более чем одной улицей
SELECT city.Name AS CityWithMoreThanOneStreet, count(Street) AS StreetsCount  FROM city, adress
	WHERE adress.City_idCity = city.idCity GROUP BY City_idCity HAVING count(Street) > 1;
    
#отели, имеющие комнаты дешевле 50 
SELECT hotel.Name AS HotelWithCostLess50, min(room.CostPerDay) AS MinCost FROM hotel, room
	WHERE room.Hotel_idHotel = hotel.idHotel GROUP BY hotel.Name HAVING min(CostPerDay) < 50; 
    
    
    
    
SELECT company.Name, city.Name AS City, adress.Street, adress.House  FROM company, adress, city
	WHERE company.Adress_idAdress = adress.idAdress AND adress.City_idCity = city.idCity;

SELECT hotel.Name, city.Name AS City, adress.Street, adress.House  FROM hotel, adress, city
	WHERE hotel.Adress_idAdress = adress.idAdress AND adress.City_idCity = city.idCity;
    