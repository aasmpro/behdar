UPDATE       presdrug
SET                amount = @amount
WHERE        (prescription = @org_prescription) AND (drug = @org_drug)