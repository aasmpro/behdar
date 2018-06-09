DELETE FROM presdrug
WHERE        (prescription = @prescription) AND (drug = @drug)