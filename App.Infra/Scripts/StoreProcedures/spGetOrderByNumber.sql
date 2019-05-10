create or replace function spGetOrderByNumber(character varying)
returns setof Order_Customer as
$$
begin
    RETURN QUERY SELECT concat("Customer"."FirstName",' ',"Customer"."LastName") as Name,"Order"."CreateDate","Order"."Number","Order"."Status","Order"."Deliveryfee","Order"."Discount"
	FROM Public."Order"
	inner join Public."Customer"
	on Public."Order"."Customer" = public."Customer"."Id"
    where Public."Order"."Number" = $1;
end;
$$
 LANGUAGE 'plpgsql'