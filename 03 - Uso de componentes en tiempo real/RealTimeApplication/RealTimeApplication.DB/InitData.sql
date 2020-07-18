Insert Client ([Name],[LastName],Telephone,FileImageIcon) 
values	('Erick','Aróstegui Cunza', '+1598675986','erick.png'),
		('Hector','Lloret', '+1594567986','hector.png'),
		('Nicolae','de La Torre', '+1599856386','nicolae.png'),
		('Juan Angel','Amor', '+1545624986','juan.png'),
		('Alberto','Aguirre', '+1595797086','alberto.png'),
		('Jenifer','Cuesta', '+1598606753','jenifer.png'),
		('Dana','Climent', '+159820539','dana.png'),
		('Maria','Ubeda', '+15204860','maria.png'),
		('Cristina','Feijoo', '+1495294730','cristina.png'),
		('Carol','Vilches', '+1968473635','carol.png');

Insert Product ([Description],Feature01,Feature02,Price,FileImage)
values	('Dell Laptop','500GB HDD','8GB RAM',950,'01.jpg'),
		('HP Laptop','500GB HDD','8GB RAM',850,'02.jpg'),
		('ACER Laptop','500GB HDD','8GB RAM',650,'03.jpg'),
		('Lenovo Ideapad L340 Gaming','500GB HDD','128GB RAM',1342,'04.jpg'),
		('ThinkPad P52','1TB HDD','512GB RAM',5372,'05.jpg'),
		('Laptop HP 15','500GB HDD','256GB RAM',925,'06.jpg'),
		('Laptop Aspire 5','1TB HDD','8GB RAM',984,'03.jpg'),
		('Laptop IdeaPad S340','256GB HDD','4GB RAM',522,'07.jpg'),
		('Laptop Gamer HP Pavilion','512GB SSD','8GB RAM',1134,'08.jpg'),
		('Laptop Gamer Nitro 5','1TB HDD','24GB',1372,'10.jpg');

Insert TrackingStatus([Description],IconCls)
values	('Order confirmed','fa fa-check'),
		('Order Billed','fa fa-money-check-alt'),
		('Picked by courier','fa fa-boxes'),
		('On the way','fa fa-truck'),
		('Ready for pickup','fa fa-box'),
		('Order delivered','fas fa-hand-holding-heart');

Insert [Order] (ClientId,[Description])
values	(1,'Venta a SJL'),
		(2,'Venta a San Isidro'),
		(3,'Venta a Magdalena'),
		(4,'Venta a Miraflores'),
		(5,'Venta a Los Olivos'),
		(6,'Venta a Surco'),
		(7,'Venta a Molina'),
		(8,'Venta a Monterrico'),
		(9,'Venta a Comas'),
		(10,'Venta a Independencia');

Insert Tracking (OrderId,EstimatedDeliveryTime,TrackingStatusId)
values	(1,GETDATE(),1),
		(2,GETDATE(),2),
		(3,GETDATE(),3),
		(4,GETDATE(),4),
		(5,GETDATE(),5),
		(6,GETDATE(),6),
		(7,GETDATE(),1),
		(8,GETDATE(),2),
		(9,GETDATE(),3),
		(10,GETDATE(),4);

Insert TrackingProduct(TrackingId,ProductId)
values	(1,1),(1,2),(1,3),
		(2,2),(2,3),(2,4),
		(3,3),(3,4),(3,5),
		(4,4),(4,5),(4,6),
		(5,5),(5,6),(5,7),
		(6,6),(6,7),(6,8),
		(7,7),(7,8),(7,9),
		(8,8),(8,9),(8,10),
		(9,9),(9,10),(9,1),
		(10,10),(10,1),(10,2);