USE `mydb`;

SELECT lower(concat(Firstname, ' ', Surname)) AS fullname FROM client;

SELECT idRoom, round(CostPerDay) AS RoundedPrice, 
	(mod(round(CostPerDay), 10) = 0) AS CanIBuyItWithOnly10DollarsBanknotes  FROM room;
    
SELECT lower(concat(Firstname, ' ', Surname)) AS fullname,
 convert((datediff(curdate(), BirthDate) / 365), UNSIGNED INTEGER) AS age FROM client;
