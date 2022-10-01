CREATE TABLE [dbo].[car_info] (
    [car_name]   VARCHAR (15) NULL,
    [car_make]   VARCHAR (30) NULL,
    [car_model]  INT          NULL,
    [car_number] VARCHAR (7)  NOT NULL, 
    CONSTRAINT [PK_car_info] PRIMARY KEY ([car_number])
);

