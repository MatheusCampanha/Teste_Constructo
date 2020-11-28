

SELECT C.Bairro, ISNULL(SUM(m.QuantidadeBichosEstimacao),0) AS 'Bichos de Estimação' 
FROM Condominio C
	LEFT JOIN Familia f
	ON C.Id = F.Id_condominio
	LEFT JOIN Morador M
	ON F.id = M.Id_Familia
	GROUP BY C.Bairro