UPDATE [dbo].[Libro] SET 
[Nome_Libro] = @NewNome, 
[ID_Categoria_Libro] = (SELECT ID FROM [dbo].[Categoria_Libro] WHERE Genere = @NewCategoria), 
[Anno_Pubblicazione] = @NewAnnoPubblicazione,
[ISBN] = @NewISBN,
[ID_Stato_Libro] = (SELECT ID FROM [dbo].[Stato_Libro] WHERE Stato = @NewStatoLibro),
[Numero_Copie_Presenti] = @NewCopiePresenti
WHERE @ID = Libro.ID