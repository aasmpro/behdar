SELECT        prescription, drug, amount
FROM            presdrug
WHERE        (prescription = @prescription)