SELECT        id, flname, ncode, creator, insurance, date
FROM            prescription
WHERE        (id = @org_id)