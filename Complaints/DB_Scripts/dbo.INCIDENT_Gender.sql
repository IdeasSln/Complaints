USE [ComplaintsContext-20180325194636]
GO

/****** Object: Table [dbo].[INCIDENT_Gender] Script Date: 5/6/2018 12:03:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[INCIDENT_Gender] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Description]        NVARCHAR (MAX) NULL,
    [Active]             BIT            NOT NULL,
    [Audit_createdby]    NVARCHAR (MAX) NULL,
    [Audit_modifiedby]   NVARCHAR (MAX) NULL,
    [Audit_createddate]  DATETIME       NULL,
    [Audit_modifieddate] DATETIME       NULL
);


