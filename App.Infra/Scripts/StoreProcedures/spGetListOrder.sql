create type Order_Customer as (Name text,CreateDate date,Number character varying,Status int,Deliveryfee decimal,Discount decimal);
create or replace function spGetListOrder()
returns setof Order_Customer as
$$
begin
    RETURN QUERY SELECT concat("Customer"."FirstName",' ',"Customer"."LastName") as Name,"Order"."CreateDate","Order"."Number","Order"."Status","Order"."Deliveryfee","Order"."Discount"
	FROM Public."Order"
	inner join Public."Customer"
	on Public."Order"."Customer" = public."Customer"."Id";
end;
$$
 LANGUAGE 'plpgsql'