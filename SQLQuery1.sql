

/*  Task 1 */
SELECT ProductID as ID, Name, ProductNumber as Number, Color FROM SalesLT.Product;
SELECT Customer.CustomerID AS ID, Customer.FirstName  + Customer.LastName as FIO, 
Customer.EmailAddress AS Email, Customer.Phone  FROM SalesLT.Customer as Customer;
/*  Task 1 end*/

/*
������� 2 - ���������� ������ (�������� �������������, �������� � ����� �������� + ������� ������� �����������)
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
������� 2 - ���������� ������ (�������� �������������, �������� � ����� �������� + ������� ������� �����������)
END
*/

/*
������� 3 - ����������
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
������� 3 - ����������
END
*/

/*
������� 4 - ��������� (paging, �������� �� ���������)
*/
SELECT top(10) * FROM SalesLT.Product;

SELECT top(10) * FROM SalesLT.Product As pd
order by pd.Weight;

SELECT top(10) * FROM SalesLT.Product As pd
order by pd.Weight desc;

SELECT * FROM SalesLT.Product As pd
order by pd.Weight desc OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;
/*
������� 4 - ��������� (paging, �������� �� ���������)
END
*/
/*
������� 5 - ���������� (joins)
*/
--1) ������� �� ��������, ���, �����, ����, ��� � ����, �� ������� ������� � ������ (� ���������)
SELECT pd.ProductID as ID, pd.Name, pd.ProductNumber as Number, pd.Color, pd.Weight, od.UnitPrice, od.UnitPriceDiscount FROM SalesLT.Product pd
left join SalesLT.SalesOrderDetail as od on od.ProductID= pd.ProductID;

--2) ������� ������������ ���������, ���, ����� � �������, �����, ������, �������� ��� � �����
SELECT C.CustomerID AS ID, C.FirstName  + C.LastName as FIO, 
C.EmailAddress AS Email, C.Phone, Adr.City, Adr.CountryRegion, Adr.PostalCode FROM SalesLT.Customer as C
left join SalesLT.CustomerAddress as CustAdr on C.CustomerID= CustAdr.CustomerID
left join SalesLT.Address as Adr ON CustAdr.AddressID = Adr.AddressID;

--3) ������� �� ��������, ���, �����, ��������� (������������) � ������������ (���� ����)

/*
������� 5 - ���������� (joins)
END
*/

/*
������� 6 - �����������
*/
--1) ���������� ����� ���-�� ���������
SELECT Count(*) FROM SalesLT.Product;

--2) ���������� ���-�� ���������, ������� ������� ���������
SELECT Count(*) FROM SalesLT.Product As pd
WHERE pd.SellEndDate <= SYSDATETIME();

--3) ���������� ���-�� ���������, ��� ������� �� ������
SELECT AVG(pd.Weight) FROM SalesLT.Product As pd
WHERE pd.Weight IS NOT NULL;

--5) ���������� ������� ��� ���� ���������
SELECT AVG(pd.Weight) FROM SalesLT.Product As pd;

--6) ��������� ���� � ��� ��� ��� ���������
SELECT MIN(pd.Weight) as MinWeight, MAX(pd.Weight) as MaxWeight FROM SalesLT.Product As pd;

--7) ������������� �������� �� ����������, ������� �� ���������, 
--�������� � ���-�� ��������� � ���������, ��������� ��� ��������� 
--� ���������, ���� ��� � ���������, ��� ��� � ���������, ������� ��� � ���������
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

--8) ������������� �������� �� ����������, ������� �� ���������, �������� � ��������� ��� ��������� � ���������
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

--9) �� ���������� ����������� ������� ������ ��, ���������, ��� ������� MAX, MIN, SUM ��� AVG NULL
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

--10) �� ���������� ����������� ������� ������ �� ���������, ��� ������� ���� ��� ����� 10000
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
������� 6 - �����������
END
*/


/*
������� 7 - �����������
*/
--1) ������� �� � ��� ��������� � ��������� ��������� ���� ��������� � ���, ������� ���� �������
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
������� 7 - �����������
END
*/