CREATE TABLE [dbo].[IdentityRole] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.IdentityRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

