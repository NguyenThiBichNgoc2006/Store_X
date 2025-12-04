-- Create database
CREATE DATABASE StoreX_SalesDB;
GO
USE StoreX_SalesDB;
GO

-- Create Employee table
CREATE TABLE Employee (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName VARCHAR(100) NOT NULL,
    Position VARCHAR(50) NOT NULL CHECK (Position IN ('Admin', 'Salesperson', 'Warehouse staff')),
    AuthorityLevel INT NOT NULL CHECK (AuthorityLevel BETWEEN 1 AND 3),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Phone VARCHAR(15) NULL
);
GO

-- Create Customer table
CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) NOT NULL UNIQUE,
    Address VARCHAR(200) NULL,
    Email VARCHAR(100) NULL CHECK (Email LIKE '%_@_%._%'),
    RegistrationDate DATE NOT NULL DEFAULT GETDATE()
);
GO

-- Create Category table
CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL UNIQUE,
    Description VARCHAR(255) NULL
);
GO

-- Create Supplier table
CREATE TABLE Supplier (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NULL,
    Phone VARCHAR(15) NULL,
    Email VARCHAR(100) NULL UNIQUE CHECK (Email LIKE '%_@_%._%')
);
GO

-- Create Product table
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    SellingPrice DECIMAL(10,2) NOT NULL CHECK (SellingPrice > 0),
    InventoryQuantity INT NOT NULL CHECK (InventoryQuantity >= 0) DEFAULT 0,
    CategoryID INT NOT NULL FOREIGN KEY REFERENCES Category(CategoryID),
    SupplierID INT NOT NULL FOREIGN KEY REFERENCES Supplier(SupplierID),
    ImagePath VARCHAR(255) NULL
);
GO

-- Create PaymentMethod table
CREATE TABLE PaymentMethod (
    PaymentMethodID INT IDENTITY(1,1) PRIMARY KEY,
    MethodName VARCHAR(50) NOT NULL UNIQUE,
    Description VARCHAR(255) NULL
);
GO

-- Create Order table
CREATE TABLE [Order] (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount > 0),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
    EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID),
    PaymentMethodID INT NOT NULL FOREIGN KEY REFERENCES PaymentMethod(PaymentMethodID)
);
GO

-- Create Order_Details table
CREATE TABLE Order_Details (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES [Order](OrderID),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(ProductID),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice > 0)
);
GO
--INSERT Category
INSERT INTO Category (CategoryName, Description)
VALUES 
('Smartphone', 'Mobile phones'),
('Laptop', 'Laptops and PCs'),
('Accessories', 'Headphones and chargers'),
('Home Appliances', 'Refrigerators and ovens'),
('Fashion', 'Clothing items'),
('Books', 'Novels and textbooks');
GO

-- INSERT Supplier
INSERT INTO Supplier (SupplierName, Address, Phone, Email)
VALUES 
('Supplier Tech1', 'Hanoi', '0111111111', 'tech1@sup.com'),
('Supplier Electro2', 'HCMC', '0222222222', 'electro2@sup.com'),
('Supplier Gadget3', 'Da Nang', '0333333333', 'gadget3@sup.com'),
('Supplier Home4', 'Hanoi', '0444444444', 'home4@sup.com'),
('Supplier Fashion5', 'HCMC', '0555555555', 'fashion5@sup.com'),
('Supplier Book6', 'Da Nang', '0666666666', NULL);  -- NULL OK
GO

--INSERT INTO Product
INSERT INTO Product (ProductName, SellingPrice, InventoryQuantity, CategoryID, SupplierID, ImagePath)
VALUES 
('iPhone 14', 20000000.00, 10, 1, 1, '/images/iphone.jpg'),  -- CategoryID=1, SupplierID=1
('Dell Laptop', 15000000.00, 5, 2, 2, '/images/dell.jpg'),    -- CategoryID=2, SupplierID=2
('Sony Headphones', 2000000.00, 20, 3, 3, '/images/sony.jpg'), -- CategoryID=3, SupplierID=3
('Samsung Fridge', 10000000.00, 8, 4, 4, '/images/samsung.jpg'), -- CategoryID=4, SupplierID=4
('Designer Shirt', 500000.00, 50, 5, 5, '/images/shirt.jpg'),   -- CategoryID=5, SupplierID=5
('Harry Potter Book', 200000.00, 100, 6, 6, '/images/book.jpg'); -- CategoryID=6, SupplierID=6
GO


--INSERT INTO PaymentMethod
INSERT INTO PaymentMethod (MethodName, Description)
VALUES 
('Cash', 'Cash payment'),
('Credit Card', 'Credit card Visa/Master'),
('Bank Transfer', 'Bank transfer'),
('Debit Card', 'Debit card'),
('Momo Wallet', 'Mobile wallet Momo'),
('ZaloPay', 'ZaloPay payment');
GO

--INSERT INTO Employee
INSERT INTO Employee (EmployeeName, Position, AuthorityLevel, Username, Password, Phone)
VALUES 
('Nguyen Van A', 'Admin', 1, 'admin1', HASHBYTES('SHA2_256', 'Pass123'), '0123456789'),
('Tran Thi B', 'Salesperson', 2, 'sales1', HASHBYTES('SHA2_256', 'Pass456'), '0987654321'),
('Le Van C', 'Warehouse staff', 3, 'warehouse1', HASHBYTES('SHA2_256', 'Pass789'), '0111222333'),
('Pham Thi D', 'Salesperson', 2, 'sales2', HASHBYTES('SHA2_256', 'Pass101'), '0444555666'),
('Hoang Van E', 'Admin', 1, 'admin2', HASHBYTES('SHA2_256', 'Pass112'), '0777888999'),
('Vu Thi F', 'Warehouse staff', 3, 'warehouse2', HASHBYTES('SHA2_256', 'Pass131'), '0909090909');
GO

--INSERT INTO Customer
INSERT INTO Customer (CustomerName, Phone, Address, Email, RegistrationDate)
VALUES 
('Customer1', '0912345678', 'Hanoi', 'c1@email.com', '2023-01-01'),
('Customer2', '0923456789', 'HCMC', 'c2@email.com', '2023-02-15'),
('Customer3', '0934567890', 'Da Nang', 'c3@email.com', '2023-03-20'),
('Customer4', '0945678901', 'Hanoi', 'c4@email.com', '2023-04-10'),
('Customer5', '0956789012', 'HCMC', NULL, '2023-05-05'),
('Customer6', '0967890123', 'Da Nang', 'c6@email.com', '2023-06-01');
GO

--INSERT INTO [Order]
INSERT INTO [Order] (OrderDate, TotalAmount, CustomerID, EmployeeID, PaymentMethodID)
VALUES 
('2023-10-01', 22000000.00, 1, 1, 1),
('2023-10-02', 15200000.00, 2, 2, 2),
('2023-10-03', 2500000.00, 3, 3, 3),
('2023-10-04', 10500000.00, 4, 4, 4),
('2023-10-05', 550000.00, 5, 5, 5),
('2023-10-06', 220000.00, 6, 6, 6);
GO

--INSERT INTO Order_Details
INSERT INTO Order_Details (OrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 1, 20000000.00),
(2, 2, 1, 15000000.00),
(3, 3, 1, 2000000.00),
(4, 4, 1, 10000000.00),
(5, 5, 1, 500000.00),
(6, 6, 1, 200000.00);
GO
-- Kiểm tra tổng kết (nên tất cả là 6)
SELECT TableName, Rows FROM (
    SELECT 'Employee' AS TableName, COUNT(*) AS Rows FROM Employee
    UNION ALL SELECT 'Customer', COUNT(*) FROM Customer
    UNION ALL SELECT 'Category', COUNT(*) FROM Category
    UNION ALL SELECT 'Supplier', COUNT(*) FROM Supplier
    UNION ALL SELECT 'Product', COUNT(*) FROM Product
    UNION ALL SELECT 'PaymentMethod', COUNT(*) FROM PaymentMethod
    UNION ALL SELECT 'Order', COUNT(*) FROM [Order]
    UNION ALL SELECT 'Order_Details', COUNT(*) FROM Order_Details
) AS Summary;
GO
-- Xem tất cả các bảng dữ liệu 
SELECT * FROM Employee;
SELECT * FROM Customer;
SELECT * FROM Product;
SELECT * FROM Order_Details;
SELECT * FROM Category;
SELECT * FROM Supplier;
SELECT * FROM PaymentMethod;
SELECT * FROM [Order];

--Truy vấn cơ bản – SELECT Lấy danh sách sản phẩm với thông tin chi tiết về danh mục và nhà cung cấp
SELECT 
    P.ProductID, 
    P.ProductName, 
    P.SellingPrice, 
    P.InventoryQuantity, 
    C.CategoryName, 
    S.SupplierName
FROM Product AS P
JOIN Category AS C ON P.CategoryID = C.CategoryID
JOIN Supplier AS S ON P.SupplierID = S.SupplierID;

--Truy vấn kiểm tra hóa đơn – SELECT + JOIN
SELECT 
    O.OrderID, 
    O.OrderDate, 
    C.CustomerName, 
    E.EmployeeName, 
    O.TotalAmount, 
    PM.MethodName AS PaymentMethod
FROM [Order] AS O
JOIN Customer AS C ON O.CustomerID = C.CustomerID
JOIN Employee AS E ON O.EmployeeID = E.EmployeeID
JOIN PaymentMethod AS PM ON O.PaymentMethodID = PM.PaymentMethodID;

-- Truy vấn chèn dữ liệu – INSERT  Kiểm tra khả năng thêm sản phẩm mới vào hệ thống.
INSERT INTO Product (ProductName, SellingPrice, InventoryQuantity, CategoryID, SupplierID)
VALUES ('Bluetooth Speaker', 1500000.00, 25, 3, 3);
SELECT * FROM Product;

--Truy vấn lọc dữ liệu – WHERE + LIKE Tìm kiếm khách hàng có tên chứa “Nguyen”.
SELECT * 
FROM Customer 
WHERE CustomerName LIKE '%Customer1%';

--Truy vấn tổng hợp – Doanh thu theo tháng
SELECT 
    MONTH(OrderDate) AS [Month],
    SUM(TotalAmount) AS [MonthlyRevenue]
FROM [Order]
GROUP BY MONTH(OrderDate)
ORDER BY [Month];

--Truy vấn thống kê lợi nhuận theo nhân viên – Aggregation
SELECT 
    E.EmployeeName,
    SUM(O.TotalAmount) AS TotalSales
FROM [Order] AS O
JOIN Employee AS E ON O.EmployeeID = E.EmployeeID
GROUP BY E.EmployeeName
ORDER BY TotalSales DESC;

--Truy vấn kiểm tra tồn kho – Validation
SELECT 
    ProductName, 
    InventoryQuantity 
FROM Product 
WHERE InventoryQuantity < 10;

-- TỐI ƯU HÓA CÁC CÂU TRUY VẤN 
--Chỉ chọn các cột cần thiết thay vì sử dụng SELECT *
SELECT ProductName, SellingPrice, InventoryQuantity 
FROM Product;

--Sử dụng chỉ mục (Indexing)
CREATE INDEX IDX_Product_CategoryID ON Product(CategoryID);
CREATE INDEX IDX_Order_OrderDate ON [Order](OrderDate);
CREATE INDEX IDX_Customer_Phone ON Customer(Phone);

-- Giảm truy vấn lồng nhau
SELECT P.ProductName 
FROM Product AS P
JOIN Category AS C ON P.CategoryID = C.CategoryID
WHERE C.CategoryName = 'Laptop';
--Sử dụng điều kiện lọc sớm (Early Filtering)
SELECT * 
FROM Product 
WHERE InventoryQuantity < 10;

select * from  Employee;