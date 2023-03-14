INSERT INTO [dbo].[Utenti_Tesserati]
           ([ID]
           ,[Nome]
           ,[Cognome]
           ,[Indirizzo]
           ,[ID_Libro]
           ,[Data_Inserimento_Record]
           ,[Stato_Record])
     VALUES
           (NEWID()
		   ,@NewNome
		   ,@NewCognome
		   ,@NewIndirizzo
           ,(SELECT ID FROM [dbo].[Libro] WHERE ISBN = @NewISBN)
           ,GETDATE(),
           @NewStatoRecord)