CREATE TABLE [dbo].[Character] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (100) NOT NULL,
    [ClassId]          INT           NOT NULL,
    [ExperiencePoints] INT           NOT NULL,
    [CurrentHealth]    INT           NOT NULL,
    [Strength]         INT           NOT NULL,
    [Dexterity]        INT           NOT NULL,
    [Intellect]        INT           NOT NULL,
    [ActionPoints]     INT           NOT NULL,
    [UserId]           INT           NOT NULL,
    [Active] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Character_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Player_Class] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Class] ([Id])
);

