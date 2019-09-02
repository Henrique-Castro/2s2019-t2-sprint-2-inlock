SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;

SELECT J.*, E.* 
FROM Jogos AS J
JOIN Estudios AS E
ON E.EstudioId = J.JogoId

SELECT J.*, E.* 
FROM Jogos AS J
FULL JOIN Estudios AS E
ON E.EstudioId = J.JogoId

SELECT * FROM Usuarios WHERE email = 'Henrique@admin.com'
AND  senha= 'admin'

SELECT * FROM Jogos WHERE NomeDoJogo  = 'Diablo 3'
AND  JogoId = 13

SELECT * FROM Estudios WHERE NomeEstudio = 'Blizzard'
AND  EstudioId= '1'