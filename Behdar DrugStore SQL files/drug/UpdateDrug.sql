UPDATE       drug
SET                name = @name, type = @type, price = @price, dfactory = @dfactory, amount = @amount
WHERE        (id = @org_id)