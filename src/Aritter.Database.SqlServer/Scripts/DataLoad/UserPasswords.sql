SET IDENTITY_INSERT [dbo].[UserPasswords] ON
GO

MERGE INTO [UserPasswords] AS Target 
USING
(
	VALUES (1, 1, GETDATE(), 'AUi+QOPBNrXf9R2UTB7gWQ==', NEWID())
) 
AS Source ([Id], [UserId], [Date], [PasswordHash], [Guid]) 
ON Target.[Id] = Source.[Id]

-- Atualiza registros existentes
WHEN MATCHED THEN 
UPDATE SET
	[UserId] = Source.[UserId],
	[Date] = Source.[Date],
	[PasswordHash] = Source.[PasswordHash],
	[Guid] = Source.[Guid]

-- Insere registros n�o existentes 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [UserId], [Date], [PasswordHash], [Guid]) 
VALUES ([Id], [UserId], [Date], [PasswordHash], [Guid]) 

-- Remove registros que existem na tabela mas que n�o existe na origem
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;

SET IDENTITY_INSERT [dbo].[UserPasswords] OFF
GO