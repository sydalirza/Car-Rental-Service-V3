CREATE TABLE [dbo].[login_info] (
    [user_id]  VARCHAR (15) NULL,
    [password] VARCHAR (30) NULL,
    [login_id] INT          NULL, 
    CONSTRAINT [PK_login_info] PRIMARY KEY ([login_id])
);

