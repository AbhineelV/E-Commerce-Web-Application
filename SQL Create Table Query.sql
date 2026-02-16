

CREATE TABLE productDB(
id int IDENTITY(1,1),
name varchar(100),
cost int,
photo varchar(100)
);

SELECT * FROM productDB;


 
CREATE TABLE cardDB(
id int IDENTITY(1,1),
name varchar(100),
cost int,
quantity int,
total int
);

SELECT * FROM cardDB;

CREATE TABLE payDB(
quantity int,
total int
);

SELECT * FROM payDB;

CREATE TABLE customerDB(
name varchar(100),
email varchar(100) UNIQUE,
mobile varchar(50),
address varchar(100),
total int
);


SELECT * FROM customerDB;

