CREATE TABLE [dbo].[Task] (
    [TaskId]      INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (256)  NOT NULL,
    [Description] NVARCHAR (1024) NOT NULL,
    [Completed]   BIT             DEFAULT ((0)) NOT NULL,
    [CreatedBy] INT NULL, 
    PRIMARY KEY CLUSTERED ([TaskId] ASC), 
    CONSTRAINT [FK_CreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User](UserId)    
);

