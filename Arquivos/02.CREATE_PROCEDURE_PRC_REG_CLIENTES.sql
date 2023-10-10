CREATE PROCEDURE PRC_REG_CLIENTES
(
	@NOME VARCHAR(100),
	@EMAIL VARCHAR(100),
	@LOGOTIPO VARCHAR(500),
	@DATA_CADASTRO DATETIME,
	@ATIVO BIT,
	@USUARIO INT
)
AS
BEGIN
	INSERT INTO Clientes
	(
	    Nome,
	    Email,
	    Logotipo,
	    DataCadastro,
	    DataAtualizacao,
	    Ativo,
	    UsuarioId
	)
	VALUES
	(   
		@NOME,
	    @EMAIL,
	    @LOGOTIPO,
	    @DATA_CADASTRO,
	    NULL,
	    @ATIVO,
	    @USUARIO
	 )

	 SELECT SCOPE_IDENTITY()
END


