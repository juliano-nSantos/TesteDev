CREATE DATABASE ThomasGregDb

GO

USE ThomasGregDb

GO

-- -----------------------------------------------------
-- Table Perfis
-- -----------------------------------------------------
CREATE TABLE Perfis 
(
  IdPerfil INT NOT NULL IDENTITY,
  NomePerfil VARCHAR(70) NOT NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_Perfis
	PRIMARY KEY (IdPerfil)
)

GO

-- -----------------------------------------------------
-- Table Usuarios
-- -----------------------------------------------------
CREATE TABLE Usuarios 
(
  IdUsuario INT NOT NULL IDENTITY,
  NomeUsuario VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  Senha VARCHAR(300) NOT NULL,
  DataCadastro DATETIME NOT NULL,
  PerfilId INT NOT NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_Usuarios
	PRIMARY KEY (IdUsuario),
  CONSTRAINT UK_Email_Usuario
	UNIQUE (Email ASC),
  INDEX FK_Usuarios_Perfis_idx (PerfilId ASC),
  INDEX EmaolUsuario_idx (Email ASC),
  CONSTRAINT FK_Usuarios_Perfis
		FOREIGN KEY (PerfilId)
			REFERENCES Perfis (IdPerfil)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

GO

-- -----------------------------------------------------
-- Table Clientes
-- -----------------------------------------------------
CREATE TABLE Clientes 
(
  IdCliente INT NOT NULL IDENTITY,
  Nome VARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  Logotipo VARCHAR(500) NULL,
  DataCadastro DATETIME NOT NULL,
  DataAtualizacao DATETIME NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  UsuarioId INT NOT NULL,
  CONSTRAINT PK_Clientes
	PRIMARY KEY (IdCliente),
  INDEX NomeUsuario_idx (Nome ASC),
  INDEX UK_EmailClientes_idx (Email ASC),
  CONSTRAINT UK_EmailClientes
	UNIQUE (Email ASC) ,
  INDEX FK_ClientesUsuarios_idx (UsuarioId ASC),
  CONSTRAINT FK_ClientesUsuarios
    FOREIGN KEY (UsuarioId)
    REFERENCES Usuarios (IdUsuario)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

GO

-- -----------------------------------------------------
-- Table Enderecos
-- -----------------------------------------------------
CREATE TABLE Enderecos 
(
  IdEndereco INT NOT NULL IDENTITY,
  Logradouro VARCHAR(200) NOT NULL,
  NumeroLogradouro VARCHAR(10) NULL,
  Complemento VARCHAR(100) NULL,
  Bairro VARCHAR(100) NOT NULL,
  Cidade VARCHAR(100) NOT NULL,
  Estado CHAR(2) NOT NULL,
  Cep VARCHAR(12) NOT NULL,
  PontoReferencia VARCHAR(200) NULL,
  ClienteId INT NOT NULL,
  DataCadastro DATETIME NOT NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  DescricaoEndereco VARCHAR(100) NULL,
  CONSTRAINT PK_Enderecos
	PRIMARY KEY (IdEndereco),
  INDEX FK_Enderecos_Clientes_idx (ClienteId ASC),
  CONSTRAINT FK_Enderecos_Clientes
    FOREIGN KEY (ClienteId)
    REFERENCES Clientes (IdCliente)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

GO

-- -----------------------------------------------------
-- Table Funcionalidades
-- -----------------------------------------------------
CREATE TABLE Funcionalidades 
(
  IdFuncionalidade INT NOT NULL IDENTITY,
  NomeFuncionalidade VARCHAR(80) NOT NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_Funcionalidades
	PRIMARY KEY (IdFuncionalidade)
 )

 GO

-- -----------------------------------------------------
-- Table PerfisFuncionalidades
-- -----------------------------------------------------
CREATE TABLE PerfisFuncionalidades 
(
  IdPerfilFuncionalidade INT NOT NULL IDENTITY,
  DataCadastro DATETIME NOT NULL,
  PerfilId INT NOT NULL,
  FuncionalidadeId INT NOT NULL,
  DataAtualizacao DATETIME NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_PerfisFuncionalidades
	PRIMARY KEY (IdPerfilFuncionalidade),
  INDEX FK_PerfisFuncionalidade_Perfis_idx (PerfilId ASC),
  INDEX FK_PerfisFuncionalidades_Funcionalidades_idx (FuncionalidadeId ASC),
  CONSTRAINT FK_PerfisFuncionalidades_Perfis
    FOREIGN KEY (PerfilId)
    REFERENCES Perfis (IdPerfil)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_PerfisFuncionalidades_Funcionalidades
    FOREIGN KEY (FuncionalidadeId)
    REFERENCES Funcionalidades (IdFuncionalidade)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

GO

-- -----------------------------------------------------
-- Table UsuariosFuncionalidades
-- -----------------------------------------------------
CREATE TABLE UsuariosFuncionalidades 
(
  IdUsuarioFuncionalidade INT NOT NULL IDENTITY,
  DataCadastro DATETIME NOT NULL,
  UsuarioId INT NOT NULL,
  FuncionalidadeId INT NOT NULL,
  DataAtualizacao DATETIME NULL,
  Ativo BIT NOT NULL DEFAULT 1,
  CONSTRAINT PK_UsuariosFuncionalidades
	PRIMARY KEY (IdUsuarioFuncionalidade),
  INDEX FK_UsuariosFuncionalidades_Usuarios_idx (UsuarioId ASC),
  INDEX FK_UsuariosFuncionalidades_Funcionalidades_idx (FuncionalidadeId ASC),
  CONSTRAINT FK_UsuariosFuncionalidades_Usuarios
    FOREIGN KEY (UsuarioId)
    REFERENCES Usuarios (IdUsuario)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_UsuariosFuncionalidades_Funcionalidades
    FOREIGN KEY (FuncionalidadeId)
    REFERENCES Funcionalidades (IdFuncionalidade)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

