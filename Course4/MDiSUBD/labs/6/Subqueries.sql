USE `mydb`;

SELECT adress.Street AS StreetsINMINsk FROM adress WHERE adress.City_idCity = 
	(SELECT city.idCity FROM city WHERE city.Name = 'MINsk');
    
SELECT room.idRoom AS RoomsCheaper100dollars FROM room WHERE room.idRoom IN 
	(SELECT room.idRoom FROM room WHERE room.CostPerDay < 100);
    
SELECT room.idRoom AS RoomCheaper50IN5StarsHotels FROM room WHERE (room.CostPerDay, room.Hotel_idHotel) IN
	(SELECT room.CostPerDay, hotel.idHotel FROM room, hotel 
		WHERE room.CostPerDay < 50 AND hotel.StarsCount > 4);