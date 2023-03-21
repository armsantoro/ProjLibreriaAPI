--DECLARE @Categoria NVARCHAR(50) = 'Informatica'
SELECT [Nome_Libro] AS 'Nome Libro'
      ,CatLib.Genere
      ,[Anno_Pubblicazione] AS 'Anno Pubblicazione'
      ,[ISBN]
      ,StatLib.Stato
      ,[Numero_Copie_Presenti] AS 'Numero Copie Presenti'
  FROM [dbo].[Libro] Libro
  JOIN [dbo].[Categoria_Immagine_Libro] CatLib ON CatLib.ID = Libro.ID_Categoria_Libro
  JOIN [dbo].[Stato_Libro] StatLib ON StatLib.ID = Libro.ID_Stato_Libro
  WHERE Stato_Record = 1 AND @Categoria = CatLib.Genere