CREATE TABLE "Customer"
(
    "Id" serial NOT NULL,
    "FirstName" character varying(30) NOT NULL,
    "LastName" character varying(30) NOT NULL,
    "Email" character varying(60) NOT NULL,
    "Document" character(11) NOT NULL,
    PRIMARY KEY ("Id")
)
create table "User"
(
	"Id" serial not null,
	"UserName" character varying(50) not null,
	"Password" character varying(100) not null,
	"Active" boolean not null,
	primary key ("Id")
)
create table "Product"
(
	"Id" serial not null,
	"Title" character varying(150) not null,
	"Price" Money not null,
	"QuantityOnHand" decimal not null,
	"Image" character varying(1024),
	primary key ("Id")
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

