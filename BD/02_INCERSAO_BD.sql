use T_InLock;

Insert Into Usuarios values  ('admin@admin','admin','ADMINISTRADOR')
							,('cliente@cliente.com','cliente','CLIENTE')
							,('Henrique@admin.com','admin','ADMINISTRADOR')
							,('Lucas@cliente.com','cliente','CLIENTE')
							,('Larissa@admin.com','admin','ADMINISTRADOR');

select * from Usuarios order by UsuarioId;


Insert into Estudios values ('Blizzard','Estados Unidos','1991-02-08',1)
						   ,('Rockstar Studios','Estados Unidos','1998-12-01',2)
						   ,('Aquiris Game Studio','Brasil','2007-05-02',3)

select * from Estudios order by EstudioId;

insert into Jogos values ('Diablo 3','é um jogo que contém bastante ação e é viciante','2012-05-15',99,1),
						('Read Dead Redemption 2','jogo eletrônico de ação-aventura western.','2018-10-26',120,2),
						('Horizon Chaise Turbo',' Jogo de corrida inspirado em outro jogo de corrida antigo','2016-05-02',45,3);

select * from Jogos order by JogoId;