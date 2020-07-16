Insert Client ([Name],[LastName],Telephone) 
values	('Erick','Aróstegui Cunza', '+1598675986'),
		('Hector','Lloret', '+1594567986'),
		('Nicolae','de La Torre', '+1599856386'),
		('Juan Angel','Amor', '+1545624986'),
		('Alberto','Aguirre', '+1595797086'),
		('Aaron','Cuesta', '+1598606753'),
		('Abel','Climent', '+159820539'),
		('Abraham','Ubeda', '+15204860'),
		('Brahim','Feijoo', '+1495294730'),
		('Sergi','Vilches', '+1968473635');

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

Insert [Order] ([Description])
values	('Venta a SJL'),
		('Venta a San Isidro'),
		('Venta a Magdalena'),
		('Venta a Miraflores'),
		('Venta a Los Olivos');

Insert Tracking (OrderId,AddresseeClientId,EstimatedDeliveryTime,TrackingStatusId)
values	(1,1,GETDATE(),1),
		(2,2,GETDATE(),2),
		(3,3,GETDATE(),3),
		(4,4,GETDATE(),4),
		(5,5,GETDATE(),5);

Insert TrackingProduct(TrackingId,ProductId)
values	(1,1),(1,2),(1,3),
		(2,2),(2,3),(2,4),
		(3,3),(3,4),(3,5),
		(4,4),(4,5),(4,6),
		(5,5),(5,6),(5,7);