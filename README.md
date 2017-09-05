# [Teste Torre de Hanoi] - Bem vindo!
Implementação de uma WebAPI.

# Script do Banco de Dados Mysql

CREATE TABLE `db_historico` (
  `idHistorico` int(11) NOT NULL AUTO_INCREMENT,
  `Id` varchar(45) DEFAULT NULL,
  `Movimentacao` varchar(255) DEFAULT NULL,
  `DataHora` datetime DEFAULT NULL,
  `De` int(11) DEFAULT NULL,
  `Para` int(11) DEFAULT NULL,
  PRIMARY KEY (`idHistorico`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

By Marcos Araújo
