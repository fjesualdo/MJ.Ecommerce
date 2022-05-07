USE [Latelier]
GO
INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataValidade], [Ativo], [Utilizado]) VALUES (N'7fb4c94f-6317-45bc-97ec-1af9e7bf9e98', N'150-OFF-GERAL', null,	CAST(150.00 AS Decimal(18, 2)), 50, 1, '06-05-2022 00:00:00', '01-01-2023 00:00:00', 1, 0)
INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataValidade], [Ativo], [Utilizado]) VALUES (N'28fd88f5-6361-4ea0-bf25-49063a227fde', N'50-OFF-GERAL',  CAST( 50.00 AS Decimal(18, 2)), null, 50, 0, '06-05-2022 00:00:00', '01-01-2023 00:00:00', 1, 0)
INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataValidade], [Ativo], [Utilizado]) VALUES (N'dbe590c3-b72c-4eb4-8d6c-4b0d831f5a58', N'10-OFF-GERAL',  CAST( 10.00 AS Decimal(18, 2)), null, 50, 0, '06-05-2022 00:00:00', '01-01-2023 00:00:00', 1, 0)

select * from Vouchers