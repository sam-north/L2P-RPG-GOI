CREATE TABLE [dbo].[User] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [DiscordUserId] DECIMAL (18)  NOT NULL,
    [Username]      VARCHAR (100) NOT NULL,
    [Discriminator] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_DiscordUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

