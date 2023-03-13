 SELECT 
	   [Nome]
      ,[Cognome]
      ,[Indirizzo]
      ,Libro.Nome_Libro AS 'Libro'
  FROM [biblioteca].[dbo].[Utenti_Tesserati] AS Utenti
  JOIN [dbo].[Libro] Libro ON Libro.ID = Utenti.ID_Libro
  WHERE Utenti.Stato_Record = 1 AND Utenti.ID = @ID