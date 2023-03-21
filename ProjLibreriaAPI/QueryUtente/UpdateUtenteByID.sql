UPDATE [dbo].[Utenti_Tesserati] SET 
[Nome] = @NewNome, 
[Cognome] = @NewCognome,
[Indirizzo] = @NewIndirizzo,
[ID_Libro] = (SELECT ID FROM [dbo].[Libro] WHERE ISBN = @NewISBN),
[Stato_Record] = @NewStatoRecord
WHERE @ID = ID