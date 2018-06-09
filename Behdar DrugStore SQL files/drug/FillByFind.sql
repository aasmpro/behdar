SELECT        id, name, type, price, dfactory, amount
FROM            drug
WHERE        (id = @org_id)