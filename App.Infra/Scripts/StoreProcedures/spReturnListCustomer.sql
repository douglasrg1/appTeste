CREATE OR REPLACE FUNCTION spReturnListCustomer()
RETURNS SETOF Public."Customer" AS
 $$
BEGIN
	RETURN QUERY SELECT * FROM Public."Customer"
	RETURN;
END;
$$
 LANGUAGE 'plpgsql'