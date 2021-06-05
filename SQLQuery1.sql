

/*  Task 1 */
SELECT ProductID as ID, Name, ProductNumber as Number, Color FROM SalesLT.Product;
SELECT Customer.CustomerID AS ID, Customer.FirstName  + Customer.LastName as FIO, 
Customer.EmailAddress AS Email, Customer.Phone  FROM SalesLT.Customer as Customer;
/*  Task 1 end*/

/*
Задание 2 - фильтрация данных (выводить идентификатор, название и номер продукта + атрибут который упоминается)
*/
SELECT Pd.ProductID as ID, Pd.Name, Pd.ProductNumber as Number, Pd.Color FROM SalesLT.Product as Pd Where Pd.Color = 'Black';

SELECT Pd.ProductID as ID, Pd.Name, Pd.ProductNumber as Number, Pd.Color FROM SalesLT.Product as Pd Where Pd.Color = 'Black' Or Pd.Color='Yellow';
SELECT * FROM SalesLT.Product as Pd Where Pd.Weight>1000;

SELECT * FROM SalesLT.Product as Pd Where Pd.Weight<6000;

SELECT * FROM SalesLT.Product
WHERE Weight BETWEEN 2000 AND 5000;

SELECT * FROM SalesLT.Product
WHERE ProductNumber LIKE 'BK%' OR ProductNumber LIKE 'BB%';

SELECT * FROM SalesLT.Product As pd
WHERE pd.SellEndDate >= SYSDATETIME();
/*
Задание 2 - фильтрация данных (выводить идентификатор, название и номер продукта + атрибут который упоминается)
END
*/

/*
Задание 3 - сортировка
*/
SELECT * FROM SalesLT.Product As pd
order by pd.Color;

SELECT * FROM SalesLT.Product As pd
order by pd.Color asc ,pd.Weight desc;

SELECT * FROM SalesLT.Product As pd
order by pd.Color asc ,pd.Weight desc;

SELECT * FROM SalesLT.Product As pd
order by pd.ProductID asc ,pd.Weight desc;
/*
Задание 3 - сортировка
END
*/

/*
Задание 4 - пагинация (paging, разбивка по страницам)
*/
SELECT top(10) * FROM SalesLT.Product;

SELECT top(10) * FROM SalesLT.Product As pd
order by pd.Weight;

SELECT top(10) * FROM SalesLT.Product As pd
order by pd.Weight desc;

SELECT * FROM SalesLT.Product As pd
order by pd.Weight desc OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;
/*
Задание 4 - пагинация (paging, разбивка по страницам)
END
*/
/*
Задание 5 - соединения (joins)
*/
--1) Вывести ид продукта, имя, номер, цвет, вес и цену, по которой продали и скидку (в процентах)
SELECT pd.ProductID as ID, pd.Name, pd.ProductNumber as Number, pd.Color, pd.Weight, od.UnitPrice, od.UnitPriceDiscount FROM SalesLT.Product pd
left join SalesLT.SalesOrderDetail as od on od.ProductID= pd.ProductID;

--2) Вывести идентификтор кастомера, фио, емейл и телефон, город, страну, почтовый код и адрес
SELECT C.CustomerID AS ID, C.FirstName  + C.LastName as FIO, 
C.EmailAddress AS Email, C.Phone, Adr.City, Adr.CountryRegion, Adr.PostalCode FROM SalesLT.Customer as C
left join SalesLT.CustomerAddress as CustAdr on C.CustomerID= CustAdr.CustomerID
left join SalesLT.Address as Adr ON CustAdr.AddressID = Adr.AddressID;

--3) Вывести ид продукта, имя, номер, категорию (родительскую) и подкатегорию (если есть)

/*
Задание 5 - соединения (joins)
END
*/

/*
Задание 6 - группировка
*/
--1) Подсчитать общее кол-во продуктов
SELECT Count(*) FROM SalesLT.Product;

--2) Подсчитать кол-во продуктов, продажи которых закончены
SELECT Count(*) FROM SalesLT.Product As pd
WHERE pd.SellEndDate <= SYSDATETIME();

--3) Подсчитать кол-во продуктов, вес которых не указан
SELECT AVG(pd.Weight) FROM SalesLT.Product As pd
WHERE pd.Weight IS NOT NULL;

--5) Подсчитать средний вес ВСЕХ продуктов
SELECT AVG(pd.Weight) FROM SalesLT.Product As pd;

--6) Вычислить макс и мин вес для продуктов
SELECT MIN(pd.Weight) as MinWeight, MAX(pd.Weight) as MaxWeight FROM SalesLT.Product As pd;

--7) Сгруппировать продукты по категориям, вывести ид категории, 
--название и кол-во продуктов в категории, суммарный вес продуктов 
--в категории, макс вес в категории, мин вес в категории, средний вес в категории
SELECT cat.Name as CategoryName, 
cat.ProductCategoryID, 
count(*) as NumProdInCat , 
sum(pd.Weight) as WeightSumInCategory, 
MAX(pd.Weight) as MaxWeightInCat,
MIN(pd.Weight)  as MinWeightInCat,
AVG(pd.Weight)  as AvgWeightInCat
FROM SalesLT.Product As pd
left join SalesLT.ProductCategory AS cat 
ON cat.ProductCategoryID = pd.ProductCategoryID
GROUP BY 
cat.Name, 
cat.ProductCategoryID;

--8) Сгруппировать продукты по категориям, вывести ид категории, название и суммарный вес продуктов в категории
SELECT cat.ProductCategoryID as ID, 
cat.Name as CategoryName, 
SUM(pd.Weight) as WeightSumInCategory
FROM SalesLT.Product As pd
left join SalesLT.ProductCategory AS cat 
ON cat.ProductCategoryID = pd.ProductCategoryID
GROUP BY 
cat.Name, 
cat.ProductCategoryID
ORDER BY cat.Name;

--9) Из результата предыдущего запроса убрать те, категории, для которых MAX, MIN, SUM ИЛИ AVG NULL
SELECT cat.Name as CategoryName, 
cat.ProductCategoryID, 
count(*) as NumProdInCat , 
sum(pd.Weight) as WeightSumInCategory, 
MAX(pd.Weight) as MaxWeightInCat,
MIN(pd.Weight)  as MinWeightInCat,
AVG(pd.Weight)  as AvgWeightInCat
FROM SalesLT.Product As pd
left join SalesLT.ProductCategory AS cat 
ON cat.ProductCategoryID = pd.ProductCategoryID
GROUP BY 
cat.Name, 
cat.ProductCategoryID
HAVING sum(pd.Weight)>0 AND MAX(pd.Weight)>0 AND MIN(pd.Weight)>0 AND AVG(pd.Weight)>0;

--10) Из результата предыдущего вывести только те категории, для которых макс вес более 10000
SELECT cat.Name as CategoryName, 
cat.ProductCategoryID, 
count(*) as NumProdInCat , 
sum(pd.Weight) as WeightSumInCategory, 
MAX(pd.Weight) as MaxWeightInCat,
MIN(pd.Weight)  as MinWeightInCat,
AVG(pd.Weight)  as AvgWeightInCat
FROM SalesLT.Product As pd
left join SalesLT.ProductCategory AS cat 
ON cat.ProductCategoryID = pd.ProductCategoryID
GROUP BY 
cat.Name, 
cat.ProductCategoryID
HAVING sum(pd.Weight)>0 AND MAX(pd.Weight)>=1000 AND MIN(pd.Weight)>0 AND AVG(pd.Weight)>0;
/*
Задание 6 - группировка
END
*/


/*
Задание 7 - комплексное
*/
--1) Вывести ид и имя категории и суммарную стоимость всех продуктов в ней, который были проданы
SELECT cat.ProductCategoryID, cat.Name, SUM(pd.StandardCost) as Cost
FROM SalesLT.Product As pd
left join SalesLT.ProductCategory AS cat 
ON cat.ProductCategoryID = pd.ProductCategoryID
left join SalesLT.SalesOrderDetail AS orddet
ON orddet.ProductID = pd.ProductID
where pd.ProductID in (select ProductID from SalesLT.SalesOrderDetail)
GROUP BY cat.ProductCategoryID, cat.Name;

select ct.CustomerID,ct.FirstName,ct.LastName, orddet.UnitPriceDiscount from SalesLT.Customer as ct
left join SalesLT.SalesOrderHeader AS ohd
ON ohd.CustomerID = ct.CustomerID
left join SalesLT.SalesOrderDetail AS orddet
ON orddet.SalesOrderID = ohd.SalesOrderID
where orddet.UnitPriceDiscount>=0.40
GROUP BY ct.CustomerID,ct.FirstName,ct.LastName,orddet.UnitPriceDiscount
order by orddet.UnitPriceDiscount;


select ct.CustomerID,ct.FirstName,ct.LastName,SUM(pd.ListPrice) from SalesLT.Customer as ct
left join SalesLT.SalesOrderHeader AS ohd
ON ohd.CustomerID = ct.CustomerID
left join SalesLT.SalesOrderDetail AS orddet
ON orddet.SalesOrderID = ohd.SalesOrderID
left join SalesLT.Product AS pd
ON pd.ProductID=orddet.ProductID
where orddet.UnitPriceDiscount>=0.40
GROUP BY ct.CustomerID,ct.FirstName,ct.LastName
having SUM(pd.ListPrice)>1500
;
/*
Задание 7 - комплексное
END
*/