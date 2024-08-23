﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_EQUIPAMENTO] (
    [IdEquipamento] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [Quantidade] int NOT NULL,
    [StatusEquipamento] int NOT NULL,
    CONSTRAINT [PK_TB_EQUIPAMENTO] PRIMARY KEY ([IdEquipamento])
);
GO

CREATE TABLE [TB_FUNCIONARIO] (
    [IdFuncionario] int NOT NULL IDENTITY,
    [Nome] varchar(150) NOT NULL,
    [Cargo] varchar(90) NOT NULL,
    [Documento] varchar(11) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Sexo] varchar(10) NULL,
    [Email] varchar(60) NOT NULL,
    [Usuario] varchar(30) NOT NULL,
    [Senha] varchar(16) NOT NULL,
    [StatusPessoa] int NOT NULL,
    [DataRegistro] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_FUNCIONARIO] PRIMARY KEY ([IdFuncionario])
);
GO

CREATE TABLE [TB_ESPORTE] (
    [IdEsporte] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(500) NULL,
    [IdEquipamento] int NOT NULL,
    CONSTRAINT [PK_TB_ESPORTE] PRIMARY KEY ([IdEsporte]),
    CONSTRAINT [FK_TB_ESPORTE_TB_EQUIPAMENTO_IdEquipamento] FOREIGN KEY ([IdEquipamento]) REFERENCES [TB_EQUIPAMENTO] ([IdEquipamento])
);
GO

CREATE TABLE [TB_CONTATO] (
    [IdContato] int NOT NULL IDENTITY,
    [Ddd] int NOT NULL,
    [Ddi] int NOT NULL,
    [Telefone] varchar(20) NOT NULL,
    [TipoContato] int NOT NULL,
    [IdFuncionario] int NOT NULL,
    CONSTRAINT [PK_TB_CONTATO] PRIMARY KEY ([IdContato]),
    CONSTRAINT [FK_TB_CONTATO_TB_FUNCIONARIO_IdFuncionario] FOREIGN KEY ([IdFuncionario]) REFERENCES [TB_FUNCIONARIO] ([IdFuncionario])
);
GO

CREATE TABLE [TB_ENDERECO_FUNCIONARIO] (
    [IdEnderecoFuncionario] int NOT NULL IDENTITY,
    [IdFuncionario] int NOT NULL,
    [Cep] varchar(10) NOT NULL,
    [Estado] varchar(2) NOT NULL,
    [Cidade] varchar(50) NOT NULL,
    [Bairro] varchar(50) NOT NULL,
    [Logradouro] varchar(100) NOT NULL,
    [Numero] int NOT NULL,
    [Complemento] varchar(50) NULL,
    [PontoReferencia] varchar(100) NULL,
    CONSTRAINT [PK_TB_ENDERECO_FUNCIONARIO] PRIMARY KEY ([IdEnderecoFuncionario]),
    CONSTRAINT [FK_TB_ENDERECO_FUNCIONARIO_TB_FUNCIONARIO_IdFuncionario] FOREIGN KEY ([IdFuncionario]) REFERENCES [TB_FUNCIONARIO] ([IdFuncionario])
);
GO

CREATE TABLE [TB_QUADRA] (
    [IdQuadra] int NOT NULL IDENTITY,
    [Nome] varchar(150) NOT NULL,
    [Capacidade] int NOT NULL,
    [TipoQuadra] int NOT NULL,
    [StatusQuadra] int NOT NULL,
    [IdEsporte] int NOT NULL,
    CONSTRAINT [PK_TB_QUADRA] PRIMARY KEY ([IdQuadra]),
    CONSTRAINT [FK_TB_QUADRA_TB_ESPORTE_IdEsporte] FOREIGN KEY ([IdEsporte]) REFERENCES [TB_ESPORTE] ([IdEsporte])
);
GO

CREATE TABLE [TB_ENDERECO_QUADRA] (
    [IdEnderecoQuadra] int NOT NULL IDENTITY,
    [IdQuadra] int NOT NULL,
    [Cep] varchar(10) NOT NULL,
    [Estado] varchar(2) NOT NULL,
    [Cidade] varchar(50) NOT NULL,
    [Bairro] varchar(50) NOT NULL,
    [Logradouro] varchar(100) NOT NULL,
    [Numero] int NOT NULL,
    [Complemento] varchar(50) NULL,
    [PontoReferencia] varchar(100) NULL,
    CONSTRAINT [PK_TB_ENDERECO_QUADRA] PRIMARY KEY ([IdEnderecoQuadra]),
    CONSTRAINT [FK_TB_ENDERECO_QUADRA_TB_QUADRA_IdQuadra] FOREIGN KEY ([IdQuadra]) REFERENCES [TB_QUADRA] ([IdQuadra])
);
GO

CREATE TABLE [TB_RESERVA] (
    [IdReserva] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [HorarioInicio] datetime2 NOT NULL,
    [HorarioFim] datetime2 NOT NULL,
    [StatusReserva] int NOT NULL,
    [IdQuadra] int NOT NULL,
    [IdFuncionario] int NOT NULL,
    CONSTRAINT [PK_TB_RESERVA] PRIMARY KEY ([IdReserva]),
    CONSTRAINT [FK_TB_RESERVA_TB_FUNCIONARIO_IdFuncionario] FOREIGN KEY ([IdFuncionario]) REFERENCES [TB_FUNCIONARIO] ([IdFuncionario]),
    CONSTRAINT [FK_TB_RESERVA_TB_QUADRA_IdQuadra] FOREIGN KEY ([IdQuadra]) REFERENCES [TB_QUADRA] ([IdQuadra])
);
GO

CREATE TABLE [TB_RESERVA_EQUIPAMENTO] (
    [IdReservaEquipamento] int NOT NULL IDENTITY,
    [Quantidade] int NOT NULL,
    [IdReserva] int NOT NULL,
    [IdEquipamento] int NOT NULL,
    CONSTRAINT [PK_TB_RESERVA_EQUIPAMENTO] PRIMARY KEY ([IdReservaEquipamento]),
    CONSTRAINT [FK_TB_RESERVA_EQUIPAMENTO_TB_EQUIPAMENTO_IdEquipamento] FOREIGN KEY ([IdEquipamento]) REFERENCES [TB_EQUIPAMENTO] ([IdEquipamento]),
    CONSTRAINT [FK_TB_RESERVA_EQUIPAMENTO_TB_RESERVA_IdReserva] FOREIGN KEY ([IdReserva]) REFERENCES [TB_RESERVA] ([IdReserva])
);
GO

CREATE INDEX [IX_TB_CONTATO_IdFuncionario] ON [TB_CONTATO] ([IdFuncionario]);
GO

CREATE UNIQUE INDEX [IX_TB_ENDERECO_FUNCIONARIO_IdFuncionario] ON [TB_ENDERECO_FUNCIONARIO] ([IdFuncionario]);
GO

CREATE UNIQUE INDEX [IX_TB_ENDERECO_QUADRA_IdQuadra] ON [TB_ENDERECO_QUADRA] ([IdQuadra]);
GO

CREATE INDEX [IX_TB_ESPORTE_IdEquipamento] ON [TB_ESPORTE] ([IdEquipamento]);
GO

CREATE INDEX [IX_TB_QUADRA_IdEsporte] ON [TB_QUADRA] ([IdEsporte]);
GO

CREATE INDEX [IX_TB_RESERVA_IdFuncionario] ON [TB_RESERVA] ([IdFuncionario]);
GO

CREATE INDEX [IX_TB_RESERVA_IdQuadra] ON [TB_RESERVA] ([IdQuadra]);
GO

CREATE INDEX [IX_TB_RESERVA_EQUIPAMENTO_IdEquipamento] ON [TB_RESERVA_EQUIPAMENTO] ([IdEquipamento]);
GO

CREATE INDEX [IX_TB_RESERVA_EQUIPAMENTO_IdReserva] ON [TB_RESERVA_EQUIPAMENTO] ([IdReserva]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240820175533_MappingModels', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ENDERECO_QUADRA]') AND [c].[name] = N'Numero');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_ENDERECO_QUADRA] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_ENDERECO_QUADRA] ALTER COLUMN [Numero] int NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ENDERECO_FUNCIONARIO]') AND [c].[name] = N'Numero');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_ENDERECO_FUNCIONARIO] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TB_ENDERECO_FUNCIONARIO] ALTER COLUMN [Numero] int NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240822183134_NumberNotNull', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_ESPORTE] DROP CONSTRAINT [FK_TB_ESPORTE_TB_EQUIPAMENTO_IdEquipamento];
GO

DROP INDEX [IX_TB_ESPORTE_IdEquipamento] ON [TB_ESPORTE];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ESPORTE]') AND [c].[name] = N'Descricao');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TB_ESPORTE] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [TB_ESPORTE] DROP COLUMN [Descricao];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ESPORTE]') AND [c].[name] = N'IdEquipamento');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [TB_ESPORTE] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [TB_ESPORTE] DROP COLUMN [IdEquipamento];
GO

ALTER TABLE [TB_EQUIPAMENTO] ADD [IdEsporte] int NOT NULL DEFAULT 0;
GO

CREATE INDEX [IX_TB_EQUIPAMENTO_IdEsporte] ON [TB_EQUIPAMENTO] ([IdEsporte]);
GO

ALTER TABLE [TB_EQUIPAMENTO] ADD CONSTRAINT [FK_TB_EQUIPAMENTO_TB_ESPORTE_IdEsporte] FOREIGN KEY ([IdEsporte]) REFERENCES [TB_ESPORTE] ([IdEsporte]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240823201127_ChangesEquipamentoEsporte', N'8.0.8');
GO

COMMIT;
GO
