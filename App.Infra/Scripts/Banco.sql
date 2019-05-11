CREATE TABLE "Customer"
(
    "Id" serial PRIMARY KEY NOT NULL,
    "FirstName" character varying(30) NOT NULL,
    "LastName" character varying(30) NOT NULL,
    "Email" character varying(60) NOT NULL,
    "Document" character(11) NOT NULL
)
create table "User"
(
	"Id" serial primary key not null,
	"UserName" character varying(50) not null,
	"Password" character varying(100) not null,
	"Active" boolean not null,
	"Customer" int references "Customer" on delete restrict
)
create table "Product"
(
	"Id" serial primary key not null,
	"Title" character varying(150) not null,
	"Price" Money not null,
	"QuantityOnHand" decimal not null,
	"Image" character varying(1024)
)
create table "OrderItem"
(
	"Id" serial primary key not null,
	"Quantity"  decimal not null,
	"Price" Money not null,
	"Product" int not null references "Product" on delete restrict,
	"Order" int not null references "Order" on delete restrict
)
create table "Order"
(
	"Id" serial primary key not null,
	"Customer"  int not null references "Customer" on delete restrict,
	"CreateDate" date not null,
	"Number" character varying(50) not null,
	"Status" int not null,
	"Deliveryfee" decimal not null,
	"Discount" decimal not null
)

