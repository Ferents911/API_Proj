USE [ProductDatabase]
GO

SELECT Orders.Id, Orders.Number, Orders.Amount, OrderedProducts.ProductId, OrderedProducts.OrderId, Products.Id, Products.Name, Products.Price
FROM OrderedProducts
 INNER JOIN Products ON OrderedProducts.ProductId = Products.Id
 INNER JOIN Orders ON OrderedProducts.OrderId = Orders.Id
		   




