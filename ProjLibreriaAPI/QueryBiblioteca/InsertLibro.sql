INSERT INTO [dbo].[Libro]
           ([ID]
           ,[Nome_Libro]
           ,[ID_Categoria_Libro]
           ,[Anno_Pubblicazione]
           ,[ISBN]
           ,[ID_Stato_Libro]
           ,[Numero_Copie_Presenti]
           ,[Data_Inserimento_Record]
           ,[Stato_Record])
     VALUES
           (NEWID()
		   ,@NewNome
           ,(SELECT ID FROM [dbo].[Categoria_Immagine_Libro] WHERE Genere = @NewCategoria)
           ,@NewAnnoPubblicazione
           ,@NewISBN
           ,(SELECT ID FROM [dbo].[Stato_Libro] WHERE Stato = @NewStatoLibro)
           ,@NewCopiePresenti
           ,GETDATE(),
           @NewStatoRecord)