--Create database and use it 
create database BookStoreDB;
go

use BookStoreDB;
go

-- creating tables 

--Authors Table 
create table Authors(
	AuthorID int identity(1,1) primary key,
	Name varchar(100) not null,
	Country varchar(50) not null
);
go

--Books Table 
create table Books(
	BookID int identity(1,1) primary key,
	Title varchar(255) not null,
	AuthorID int not null,
	Price decimal(10,2) check(Price>=0),
	PublishedYear int check(PublishedYear >=1500 and PublishedYear <=year(getdate())),
	constraint FK_Books_Author foreign key (AuthorID) references Authors(AuthorID) on delete cascade on update cascade
);
go


--Customers Table 
create table Customers (
	CustomerID int identity(1,1) primary key,
	Name varchar(100) not null,
	Email varchar(255) unique not null,
	PhoneNumber varchar(20) unique not null
);
go



--Orders Table 
create table Orders(
	OrderID int identity(1,1) primary key,
	CustomerID int not null,
	OrderDate datetime default getdate(),
	TotalAmount decimal(10,2) check(TotalAmount>=0),
	constraint FK_Orders_Customer foreign key (CustomerID) references Customers(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE
);
go

--OrderItems Table
create table OrderItems(
	OrderItemID int identity(1,1) primary key,
	OrderID int not null,
	BookID int not null,
	Quantity int check(Quantity>0) not null,
	SubTotal decimal(10,2) check(SubTotal>=0) not null,
	constraint FK_OrderItems_Order FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_OrderItems_Book FOREIGN KEY (BookID) REFERENCES Books(BookID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

--1. Insert at least 5 records into each table

-- Insert into Authors Table
INSERT INTO Authors (Name, Country) VALUES 
('Robert C. Martin', 'USA'),
('Martin Fowler', 'UK'),
('Kent Beck', 'USA'),
('Andrew Hunt', 'Canada'),
('David Thomas', 'Canada');

-- Insert into Books Table
INSERT INTO Books (Title, AuthorID, Price, PublishedYear) VALUES 
('Clean Code', 1, 2500.00, 2008),
('Refactoring', 2, 2200.50, 2019),
('Test-Driven Development', 3, 1800.75, 2002),
('SQL Mastery', 4, 2100.00, 2021),
('The Pragmatic Programmer', 5, 3000.99, 2019);

-- Insert into Customers Table
INSERT INTO Customers (Name, Email, PhoneNumber) VALUES 
('Alice Johnson', 'alice@example.com', '1234567890'),
('John Doe', 'john@example.com', '9876543210'),
('Jane Smith', 'jane@example.com', '5556667777'),
('Alex Brown', 'alex@example.com', '4445556666'),
('James White', 'james@example.com', '3332221111');

-- Insert into Orders Table
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES 
(1, '2024-03-01', 5000.00),
(2, '2024-03-02', 2200.50),
(3, '2024-03-03', 1800.75),
(4, '2024-03-04', 2100.00),
(5, '2024-03-05', 3000.99);

-- Insert into OrderItems Table
INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal) VALUES 
(1, 1, 2, 5000.00),
(2, 2, 1, 2200.50),
(3, 3, 1, 1800.75),
(4, 4, 1, 2100.00),
(5, 5, 1, 3000.99);
go

select * from Authors;
select * from Books;
select * from Customers;
select * from Orders;
select * from OrderItems;
go

--2. Update the price of a book titled "SQL Mastery" by increasing it by 10%.

Update Books 
set Price = Price * 1.10
Where Title='SQL Mastery';

select * from Books; --Price of Book "SQL Mastery" is increased by 10%
go

--3.  Delete a customer who has not placed any orders.
select * from orders;
select * from Customers;


Delete from Customers
where CustomerID not in (select distinct CustomerID from orders);

select * from orders;
select * from Customers;
go

--Operators
--1. Retrieve all books with a price greater than 2000
SELECT * FROM Books WHERE Price > 2000;

--2. Find the total number of books available.
select count(*) as TotalBooksCount from Books;

--3. Find books published between 2015 and 2023.
select * from books where PublishedYear between 2015 and 2023;

--4. Find all customers who have placed at least one order.
select distinct c.*
from Customers c
join Orders o ON c.CustomerID=o.CustomerID;

--5.  Retrieve books where the title contains the word "SQL"
Select * from Books where Title Like '%SQL%';

--6. Find the most expensive book in the store
select * from Books where Price=(select MAX(Price) from Books);

--7. Retrieve customers whose name starts with "A" or "J"
select * from Customers where Name Like 'A%' or Name Like 'J%';

--8. Calculate the total revenue from all orders.
select sum(TotalAmount) as TotalRevenue from Orders;

select sum(SubTotal) as TotalRev from OrderItems;
go


--1. Retrieve all book titles along with their respective author names.
select b.Title, a.Name 
from Books b
join Authors a On b.AuthorID=a.AuthorID;

--2. List all customers and their orders (if any).
select c.CustomerID, c.Name, o.OrderID, o.OrderDate, o.TotalAmount
from Customers c
left join Orders o ON c.CustomerID=o.CustomerID;

--3. Find all books that have never been ordered.
select b.BookID, b.Title
from Books b
left join OrderItems oi ON b.BookID=oi.BookID
where oi.BookID IS NULL;

--4. Retrieve the total number of orders placed by each customer.
select c.Name, count(o.OrderID) as TotalOrders
from Customers c
left join Orders o on c.CustomerID=o.CustomerID
group by c.Name;

--5. Find the books ordered along with the quantity for each order.
select b.Title, sum(oi.Quantity) as TotalQuantity
from Books b
join OrderItems oi on b.BookID=oi.BookID
group by b.Title;


--6. Display all customers, even those who haven’t placed any orders.
SELECT Customers.CustomerID, Customers.Name, Orders.OrderID, Orders.OrderDate 
FROM Customers 
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID;

--7. Find authors who have not written any books 
select a.AuthorID, a.Name
from Authors a
left join Books b on a.AuthorID=b.AuthorID
where b.BookID is null;

--Sub-Queries
--1. Find the customer(s) who placed the first order (earliest OrderDate).
select * from Customers 
where CustomerID=(Select CustomerID from Orders where OrderDate=(Select MIN(OrderDate) from Orders ));

--2. Find the customer(s) who placed the most orders.
Select CustomerID, Name 
from Customers 
Where CustomerID = (SELECT TOP 1 CustomerID FROM Orders GROUP BY CustomerID ORDER BY COUNT(OrderID) DESC);

--3. Find customers who have not placed any orders
Select * from Customers 
Where CustomerID NOT IN (select DISTINCT CustomerID from Orders);


--4. Retrieve all books cheaper than the most expensive book written by( any author based on your data)
Select * from Books 
Where Price < (select MAX(Price) from Books);

--5. List all customers whose total spending is greater than the average spending of all customersselect c.CustomerID, c.Name, sum(o.TotalAmount) as TotalSpendingfrom Customers cjoin Orders o ON c.CustomerID=o.CustomerIDgroup by c.CustomerID, c.Namehaving sum(o.TotalAmount)>(select avg(TotalAmount) from orders);go







