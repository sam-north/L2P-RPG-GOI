CREATE TABLE [dbo].[MessageAudit] (
    [Id]      BIGINT             IDENTITY (1, 1) NOT NULL,
    [UserId]  INT                NOT NULL,
    [Message] VARCHAR (250)      NOT NULL,
    [Time]    DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_MessageAudit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

