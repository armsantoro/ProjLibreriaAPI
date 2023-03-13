--DECLARE @ID NVARCHAR(50) = '1087A5F3-05BC-4B05-9BB0-16DAAAC4BDAB'
SELECT[Nome_Libro] AS 'Nome Libro'
      , CatLib.Genere
      ,[Anno_Pubblicazione] AS 'Anno Pubblicazione'
      ,[ISBN]
      , StatLib.Stato
      ,[Numero_Copie_Presenti] AS 'Numero Copie Presenti'
  FROM [dbo].[Libro] Libro
  JOIN[dbo].[Categoria_Libro] CatLib ON CatLib.ID = Libro.ID_Categoria_Libro
  JOIN [dbo].[Stato_Libro] StatLib ON StatLib.ID = Libro.ID_Stato_Libro
  WHERE Stato_Record = 1 AND @ID = Libro.ID