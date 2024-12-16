-- Terminate all active connections to the database
USE master;
GO
IF DB_ID('GroceryStoreDB') IS NOT NULL
BEGIN
ALTER DATABASE GroceryStoreDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE GroceryStoreDB;
END;
GO
-- Make a database
CREATE DATABASE GroceryStoreDB;
GO
USE GroceryStoreDB;
GO
-- Users Table
CREATE TABLE Users (
userID INT IDENTITY PRIMARY KEY,
username NVARCHAR(50) NOT NULL UNIQUE,
firstName NVARCHAR(50) NOT NULL,
lastName NVARCHAR(50) NOT NULL,
address NVARCHAR(255),
email NVARCHAR(100) NOT NULL UNIQUE,
phoneNumber NVARCHAR(15),
password NVARCHAR(255) NOT NULL
);
-- Products Table
CREATE TABLE Products (
productID INT IDENTITY PRIMARY KEY,
name NVARCHAR(100) NOT NULL,
description NVARCHAR(255),
price DECIMAL(10, 2) NOT NULL,
images NVARCHAR(MAX),
manufacturer NVARCHAR(100),
dimensions NVARCHAR(50),
weight DECIMAL(10, 2),
rating DECIMAL(3, 2) CHECK (rating BETWEEN 0 AND 5),
SKU NVARCHAR(50) UNIQUE NOT NULL,
categoryID INT,
stock INT NOT NULL CHECK (stock >= 0)
);
-- Discounts Table
CREATE TABLE Discounts (
discountID INT IDENTITY PRIMARY KEY,
discountCategory NVARCHAR(100),
specificProductDiscount INT REFERENCES Products(productID) ON DELETE CASCADE,
discountPercent DECIMAL(5, 2) CHECK (discountPercent BETWEEN 0 AND 100),
discountStartDate DATE NOT NULL,
discountEndDate DATE NOT NULL,
discountCode NVARCHAR(255)
);
-- Checkout Cart Table
CREATE TABLE CheckoutCart (
cartID INT IDENTITY PRIMARY KEY,
userID INT NOT NULL REFERENCES Users(userID) ON DELETE CASCADE,
productID INT NOT NULL REFERENCES Products(productID) ON DELETE CASCADE,
quantity INT NOT NULL CHECK (quantity >= 0),
);
-- Categories Table
CREATE TABLE Categories (
categoryID INT IDENTITY PRIMARY KEY,
categoryName NVARCHAR(100) NOT NULL UNIQUE
);
-- Add Foreign Key to Products Table
ALTER TABLE Products
ADD FOREIGN KEY (categoryID) REFERENCES Categories(categoryID) ON DELETE SET NULL;
-- Sample Data Insertion
-- Insert Categories
INSERT INTO Categories (categoryName)
VALUES ('Fruit'), ('Vegetables'), ('Bread'), ('Meat');

-- Insert Users
INSERT INTO Users (username, firstName, lastName, address, email, phoneNumber, password) VALUES
('jdoe', 'John', 'Doe', '123 Elm Street', 'jdoe@gmail.com', '555-1234', 'password123'),
('asmith', 'Alice', 'Smith', '456 Maple Avenue', 'asmith@gmail.com', '555-5678', 'alicepwd'),
('bwilliams', 'Bob', 'Williams', '789 Oak Lane', 'bwilliams@gmail.com', '555-9012', 'bobsecure'),
('mjohnson', 'Mary', 'Johnson', '101 Pine Road', 'mjohnson@gmail.com', '555-3456', 'marypass'),
('tjones', 'Tom', 'Jones', '202 Cedar Drive', 'tjones@gmail.com', '555-7890', 'tompwd'),
('lkhan', 'Liam', 'Khan', '303 Birch Blvd', 'lkhan@gmail.com', '555-6789', 'liamsecure'),
('pclark', 'Patricia', 'Clark', '404 Oakwood St', 'pclark@gmail.com', '555-2345', 'patpass'),
('edavis', 'Evan', 'Davis', '505 Spruce Ave', 'edavis@gmail.com', '555-5679', 'evanpwd'),
('nlewis', 'Nora', 'Lewis', '606 Maple Lane', 'nlewis@gmail.com', '555-4321', 'norapass'),
('rhall', 'Ryan', 'Hall', '707 Walnut Way', 'rhall@gmail.com', '555-8765', 'ryansecure');
-- Insert Products
-- Insert data for Fruit category
-- Insert data for Fruit category
INSERT INTO Products (name, rating, categoryID, dimensions, weight, price, description, manufacturer, SKU, images, stock) VALUES
  ('Fresh Gala Apples', 4, 1, '3 x 2 x 4', 3.0, 3.86, '3 lb bag of Fresh Gala Apples', 'Freshness Guaranteed', 10000000, 'https://i5.walmartimages.com/seo/Fresh-Gala-Apples-3-lb-Bag_eebbaadc-2ca6-4e25-a2c0-c189d4871fea.bcbe9a9c422a1443b7037548bb2c54c3.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 50),
  ('Fresh Honeycrisp Apples', 5, 1, '3 x 2 x 4', 3.0, 4.48, '3 lb bag of Honeycrisp Apples', 'Orchard Delight', 10001000, 'https://i5.walmartimages.com/seo/Fresh-Honeycrisp-Apples-3-lb-Bag_3c15af5a-f051-40e8-a8cf-7005d68b1f68.8f7361db8c364fb7c7a367348b51d26d.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 40),
  ('Fresh Bananas', 4, 1, '2 x 2 x 3', 3.0, 2.16, 'Bundle of Fresh Bananas', 'Marketside', 10002000, 'https://i5.walmartimages.com/asr/3bbb1151-d69a-43fb-b132-47e0bc066307.1f28c1acf3df725a6a39ba4c8738e025.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 60),
  ('Fresh Oranges', 5, 1, '4 x 3 x 3', 4.0, 4.99, '4 lb bag of Navel Oranges', 'Citrus World', 10004000, 'https://i5.walmartimages.com/seo/Fresh-Navel-Oranges-4-lb-Bag_fde3a905-a587-489d-baf8-399c6a685b03.30b341eb36f6f629e51f36434db8015f.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 30),
  ('Fresh Pineapple', 5, 1, '5 x 5 x 10', 2.0, 3.49, 'Whole Fresh Pineapple', 'Tropical Farms', 10005000, 'https://i5.walmartimages.com/seo/Fresh-Pineapple-Each_1d2b3723-b31f-481d-ae30-c82fcbb59e20.d2e4de8d8b987f98a6e9da93a7e8c752.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 20),
  ('Fresh Blueberries', 5, 1, '2 x 2 x 2', 0.5, 3.99, '1 pint of Blueberries', 'Berry Fresh', 10006000, 'https://i5.walmartimages.com/seo/Fresh-Blueberries-18-oz-Container_66ee489f-0ddc-43b4-99ce-07c0a7bf886e_1.b805f72f3cafb54c77a036a6ab6f4ed4.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 50),
  ('Fresh Raspberries', 4, 1, '2 x 2 x 2', 0.5, 4.99, '1 pint of Raspberries', 'Berry Delight', 10007000, 'https://i5.walmartimages.com/seo/Fresh-Raspberries-6-oz-Container_1728165a-48ac-46d7-98d2-71daa67f615b_1.626e0ec13971f8220e13b80030c8089f.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 40),
  ('Fresh Strawberries', 5, 1, '2 x 2 x 2', 1.0, 5.99, '2 lb box of Strawberries', 'Berry Delight', 10008000, 'https://i5.walmartimages.com/seo/Fresh-Strawberries-2-lb-Container_dd2bcd97-25af-4a91-9258-989853e16b2f_1.36dd4f1579a25d423741d9970de3ddac.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 50),
  ('Fresh Grapes', 4, 1, '3 x 2 x 3', 2.0, 3.99, '2 lb bag of Red Grapes', 'Grape Vineyard', 10009000, 'https://i5.walmartimages.com/seo/Fresh-Red-Seedless-Grapes-Bag-2-25-lbs-Bag-Est_8e59c7de-1534-42f6-8ac7-9460aa0b45c4.f17a453b10f3c60533eef3abb0d7519a.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 30),
  ('Fresh Watermelon', 4, 1, '10 x 10 x 10', 10.0, 5.99, 'Whole Seedless Watermelon', 'Tropical Farms', 10012000, 'https://i5.walmartimages.com/seo/Fresh-Personal-Watermelon-Each_14487aaf-d86a-4b46-acaf-7621b90286bb.fb737768267fcdc95c33f355b730ad15.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 15),
  ('Fresh Cantaloupe', 5, 1, '6 x 6 x 6', 5.0, 3.29, 'Whole Fresh Cantaloupe', 'Melon Farms', 10013000, 'https://i5.walmartimages.com/seo/Cantaloupe-each_fb4c18a5-9367-4770-b99f-7518c72db482.5609c32e87a3110b734aad048bf9fe35.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 20),
  ('Fresh Kiwi', 5, 1, '2 x 2 x 2', 1.0, 4.49, '1 lb bag of Kiwi', 'Tropical Farms', 10014000, 'https://i5.walmartimages.com/seo/Fresh-Bluey-Kiwi-Fruit-1-lb-Clamshell_26a01767-b95e-4fc6-b3c5-9203a35d0495.932ffc123d5b7300a358e6c6fc812148.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 30);

-- Insert data for Vegetables category
INSERT INTO Products (name, rating, categoryID, dimensions, weight, price, description, manufacturer, SKU, images, stock) VALUES
  ('Fresh Roma Tomatoes', 4, 2, '3 x 2 x 2', 1.0, 2.49, '1 lb of Roma Tomatoes', 'Farm Fresh', 20004000, 'https://i5.walmartimages.com/seo/Fresh-Roma-Tomato-Each_ecef8a3e-ab96-445e-a16a-d639b40eb5fb.93fcc627f542f02488e5ee9d8e26f152.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 40),
  ('Fresh Bell Peppers', 4, 2, '3 x 3 x 4', 2.0, 3.99, '3-pack of Mixed Bell Peppers', 'Pepper Patch', 20005000, 'https://i5.walmartimages.com/seo/Fresh-Green-Bell-Pepper-Each_15c8fcf1-7b73-429e-8a7c-802091d818f1.4730164455d5cc0a04d2b1f675971dd1.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 25),
  ('Fresh Spinach', 5, 2, '2 x 2 x 2', 1.0, 2.99, '10 oz Baby Spinach', 'Green Farms', 20006000, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Spinach-10-oz-Bag-Fresh_62efef42-e5dc-4b42-8bc0-ea95ed9403ab_2.0ea9c53c1c78078f37025b698ad2acce.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 30),
  ('Fresh Kale', 4, 2, '2 x 2 x 2', 1.0, 3.29, '1 lb bag of Kale', 'Healthy Greens', 20007000, 'https://i5.walmartimages.com/seo/Fresh-Green-Kale-Bunch-Each_27276b36-591d-4d09-8435-90b168297b91.72f415f09f357b3f9cd5d090ec022b90.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 50),
  ('Fresh Cucumbers', 5, 2, '2 x 2 x 2', 1.0, 2.29, '3-pack of Cucumbers', 'Green Harvest', 20008000, 'https://i5.walmartimages.com/seo/Fresh-Cucumber-Each_5985ccc8-109e-411d-aca7-556ab217e1da.e3770028b0d00b3fa4e6a40c4e630ef9.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 40),
  ('Fresh Broccoli', 5, 2, '2 x 2 x 2', 2.0, 3.49, '1 lb of Fresh Broccoli', 'Green Harvest', 20009000, 'https://i5.walmartimages.com/seo/Fresh-Broccoli-Crowns-Each_c721459d-3826-4461-9e79-c077d5cf191e_3.ca214f10bb3c042f473588af8b240eca.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 30),
  ('Fresh Cauliflower', 4, 2, '2 x 2 x 2', 2.0, 3.99, '1 lb of Fresh Cauliflower', 'Farm Fresh', 20010000, 'https://i5.walmartimages.com/seo/Fresh-Cauliflower-Each_3a5c8c12-4743-477d-894f-bec416048e55_1.5d63fc6518c9cfe44cb50c0048481915.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 25),
  ('Fresh Carrots', 4, 2, '3 x 3 x 4', 2.0, 2.89, '1 lb bag of Baby Carrots', 'Green Fields', 20011000, 'https://i5.walmartimages.com/seo/Fresh-Whole-Carrots-1-lb-Bag_a6c9eb5f-51b2-465e-aaf4-502d4a905604.1bdb1d7098cc222b894d86f999f81579.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 60),
  ('Fresh Zucchini', 5, 2, '2 x 2 x 2', 1.0, 2.79, '1 lb of Fresh Zucchini', 'Farm Fresh', 20012000, 'https://i5.walmartimages.com/seo/Fresh-Zucchini-Squash-Each_7d7a2618-ed85-45bd-bf30-11b14b289c34.d484064e9e02e1132b6a3da45c871632.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 30),
  ('Fresh Green Beans', 5, 2, '3 x 2 x 4', 1.0, 3.29, '1 lb of Green Beans', 'Green Harvest', 20013000, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Green-Beans-12-oz_103b22cf-1823-4c22-bea5-fdd627641db8.143d5bcd166225f7f545acc62faf158e.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 40);

-- Insert data for Bread category
-- Insert Bread Products (categoryID = 3)
INSERT INTO Products (name, rating, categoryID, dimensions, weight, price, description, manufacturer, SKU, images, stock) VALUES
  ('Great Value White Sandwich Bread', 4, 3, '3 x 3 x 9', 20.0, 1.28, 'Classic white sandwich bread, 20 oz loaf.', 'Great Value', 30002001, 'https://i5.walmartimages.com/seo/Great-Value-White-Round-Top-Bread-20-oz_2e2a0e48-fecf-4b00-9ce4-64486788a22e.76317f2bfb5207c437cb7ccd4115589d.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 100),
  ('Natures Own Honey Wheat Bread', 5, 3, '3 x 3 x 9', 20.0, 2.99, 'Honey wheat bread, soft and delicious, 20 oz loaf.', 'Nature''s Own', 30002002, 'https://i5.walmartimages.com/seo/Nature-8217-s-Own-Sliced-Honey-Wheat-Bread-20-oz_1441502f-b035-417b-a3fd-618aa8fa3b25_1.fcc5d03a0ddcd7561137229bc3370d8a.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 90),
  ('Sara Lee Artesano Original Bread', 5, 3, '3 x 3 x 9', 20.0, 3.49, 'Thick-sliced artisan-style white bread, 20 oz loaf.', 'Sara Lee', 30002003, 'https://i5.walmartimages.com/seo/Sara-Lee-Artesano-Style-Bread-20-oz_093a3270-61dd-4cb1-a528-abc30e15fad9.1610b69a0a0adafdcb220ef41d5df443.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 80),
  ('Sunbeam Giant White Bread', 4, 3, '3 x 3 x 9', 24.0, 1.98, 'Soft, giant slices of white bread, 24 oz loaf.', 'Sunbeam', 30002004, 'https://i5.walmartimages.com/seo/Sunbeam-Giant-Sliced-Bread-24-Oz_593a0557-a408-4efd-88c0-4df8b4ca6ec2.9133732de2b0a2f7c78d1e7ef6b824af.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 70),
  ('Pepperidge Farm Farmhouse Sourdough Bread', 5, 3, '3 x 3 x 9', 24.0, 3.99, 'Tangy sourdough bread, 24 oz loaf.', 'Pepperidge Farm', 30002005, 'https://i5.walmartimages.com/seo/Pepperidge-Farm-Farmhouse-Sourdough-Bread-24-Oz_c8c23134-43ab-4ce5-b600-2b53ce0ca658.1e6f1d50e7fdd5ab5118f5dacea563ab.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 60),
  ('Great Value 100% Whole Wheat Bread', 4, 3, '3 x 3 x 9', 20.0, 1.48, 'Whole wheat sandwich bread, 20 oz loaf.', 'Great Value', 30002006, 'https://i5.walmartimages.com/seo/Great-Value-100-Whole-Wheat-Bread-20-oz_087c7ba1-b2ab-491c-aac1-7a22a7769f27.29dc3af7a24b0acccc6ac7ca57ad9264.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 110),
  ('Wonder Bread Classic White Sandwich Bread', 4, 3, '3 x 3 x 9', 20.0, 2.79, 'Classic white sandwich bread, 20 oz loaf.', 'Wonder Bread', 30002007, 'https://i5.walmartimages.com/seo/Wonder-Classic-White-Bread-20-oz_3b2fab80-7223-4bb5-bdf6-9d27a51497ad.3cfd7e9d53da6795a41493c155c92c01.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 85),
  ('Sara Lee Honey Wheat Bread', 5, 3, '3 x 3 x 9', 20.0, 2.89, 'Honey wheat sandwich bread, 20 oz loaf.', 'Sara Lee', 30002008, 'https://i5.walmartimages.com/seo/Sara-Lee-Honey-Wheat-Bakery-Bread-20-oz_caf672d9-b740-4027-824c-3d8cea3df473.ddd4dffff533c7fca617cefad1f1e0da.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 75),
  ('Nature''s Own Butterbread', 5, 3, '3 x 3 x 9', 20.0, 3.19, 'Soft, buttery white bread, 20 oz loaf.', 'Nature''s Own', 30002009, 'https://i5.walmartimages.com/seo/Nature-8217-s-Own-Sliced-Butter-Bread-20-oz_2f758726-5f4c-44aa-919e-cca7990d4e23.38413aee25e6899a8f77e1ab0e8b0da2.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 65),
  ('Great Value Multi Grain Bread', 4, 3, '3 x 3 x 9', 24.0, 2.48, 'Multi grain sandwich bread, 24 oz loaf.', 'Great Value', 30002010, 'https://i5.walmartimages.com/seo/Great-Value-Multi-Grain-Bread-24-oz_d1f58866-847f-4770-83e4-49f0b2818f61.0ec8ad5b4bc840f8ed93a52c52ecf629.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 95);

-- Insert Meat Products (categoryID = 4)
INSERT INTO Products (name, rating, categoryID, dimensions, weight, price, description, manufacturer, SKU, images, stock) VALUES
  ('80% Lean / 20% Fat Ground Beef Chuck', 5, 4, '5 x 5 x 2', 16.0, 4.99, 'All-natural ground beef, 1 lb tray.', 'Beef Farm', 40002001, 'https://i5.walmartimages.com/seo/All-Natural-80-Lean-20-Fat-Ground-Beef-Chuck-2-25-lb-Tray_063fa4cd-988e-48e8-82e5-c5810db581aa.06a7300c507134dee73ea657dadfa7a7.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 120),
  ('Great Value Hickory Smoked Bacon', 5, 4, '5 x 5 x 1', 12.0, 3.99, 'Hickory smoked bacon slices, 12 oz pack.', 'Great Value', 40002002, 'https://i5.walmartimages.com/seo/Great-Value-Hickory-Smoked-Bacon-0-75-lb_c39ae16c-0ec2-4409-9540-36b10a2a6485.10f748de04a96ba7b81f920fc2726d2e.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 100),
  ('Boneless, Skinless Chicken Breasts', 4, 4, '10 x 10 x 3', 80.0, 9.99, 'Fresh boneless, skinless chicken breasts, 4.7-6.1 lb tray.', 'Farm Fresh', 40002003, 'https://i5.walmartimages.com/seo/Boneless-Skinless-Chicken-Breasts-4-7-6-1-lb-Tray_4693e429-b926-4913-984c-dd29d4bdd586.780145c264e407b17e86cd4a7106731f.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 75),
  ('Great Value Chicken WIngs', 4, 4, '12 x 10 x 3', 80.0, 10.99, 'Family pack of fresh chicken wings, 4.0-5.3 lb tray.', 'Sanderson Farms', 40002004, 'https://i5.walmartimages.com/seo/Tyson-All-Natural-Fresh-Chicken-Wings-Family-Pack-4-25-5-3-lb-Tray_8b0ba553-9190-436b-a2c1-3c99b17397dc.6f880537f42688242d314f1b0ff5ad97.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 80),
  ('Johnsonville Beddar with Cheddar Smoked Sausage', 5, 4, '7 x 4 x 1', 14.0, 4.49, 'Smoked sausage links with cheddar, 14 oz pack.', 'Johnsonville', 40002005, 'https://i5.walmartimages.com/seo/Johnsonville-Beddar-With-Cheddar-Smoked-Sausage-12-Links-1-lb-12-oz_f5998e43-b124-49f4-a9bd-4fc048894441.2a12a542fdd9c7561400e4d4905ae6b3.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 90),
  ('Great Value Frozen Peeled Tail-On Extra Large Shrimp', 4, 4, '10 x 6 x 2', 12.0, 6.99, 'Frozen extra large shrimp, 12 oz bag.', 'Great Value', 40002006, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Peeled-Tail-on-Extra-Large-Shrimp-12-oz-26-30-Count-per-lb_8f6a9394-9329-4b0d-91d6-c4377e91b993.4ba127b5110694ff4a534eac7a9747ec.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 70),
  ('Oscar Mayer Classic Wieners Hot Dogs', 3, 4, '6 x 4 x 1', 16.0, 2.99, 'Classic hot dog wieners, 1 lb pack.', 'Oscar Mayer', 40002007, 'https://i5.walmartimages.com/seo/Oscar-Mayer-Classic-Wieners-Hot-Dogs-10-ct-Pack_d7ffb3f7-2548-4ec6-b737-5867bd7a9a10.52872f618145da0357938f83cbda4d09.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 85),
  ('Smithfield Marinated Pork Tenderloin', 5, 4, '8 x 4 x 2', 32.0, 7.99, 'Marinated pork tenderloin, 2 lb pack.', 'Smithfield', 40002008, 'https://i5.walmartimages.com/seo/Smithfield-Marinated-Roasted-Garlic-Cracked-Black-Pepper-Fresh-Pork-Tenderloin-0-5-1-85lb_47d624b5-150e-4c7c-ac16-9627371d66e0.81cc2d5f87156712307540c188c9cac9.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 60),
  ('Great Value All Natural Chicken Wing Sections', 4, 4, '10 x 8 x 3', 64.0, 12.99, 'Frozen chicken wing sections, 4 lb bag.', 'Great Value', 40002009, 'https://i5.walmartimages.com/seo/Great-Value-All-Natural-Chicken-Wing-Sections-4-lb-Frozen_566c4713-d023-4ccf-a6dc-5504b62b31c3.7a0b253eea5de44861a5a80fbb328e3f.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 90),
  ('80% Lean / 20% Fat Ground Beef Patties', 4, 4, '8 x 8 x 1', 36.0, 8.99, 'Fresh ground beef patties, 12 count (2.25 lb tray).', 'Beef Farm', 40002010, 'https://i5.walmartimages.com/seo/All-Natural-80-Lean-20-Fat-Ground-Beef-Patties-4-Count-2-lb-Tray_f71ebdd2-dee2-46ff-9e1b-67ac851756b3.cf680c5c6a6804cbde7dd07a0e8c0940.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF', 100);



-- Insert Checkout Cart
INSERT INTO CheckoutCart (userID, productID, quantity) VALUES
(1, 1, 1),
(2, 3, 2),
(3, 5, 1),
(4, 7, 2),
(5, 9, 3);
-- Show All Tables
-- COMMENT IF NEEDED
select * from Users;
select * from Products;
select * from Discounts;
select * from CheckoutCart;
select * from Categories;
