CREATE TABLE [dbo].[Class] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (20) NOT NULL,
    [PassiveAbility1] VARCHAR (50) NULL,
    [Proficiencies]   VARCHAR (50) NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED ([Id] ASC)
);

