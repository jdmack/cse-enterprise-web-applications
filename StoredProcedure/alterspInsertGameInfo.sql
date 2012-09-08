USE [cse136]
GO
/****** Object:  StoredProcedure [dbo].[spInsertGameInfo]    Script Date: 09/07/2012 22:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spInsertGameInfo]
 @matchup char(3),
 @time  datetime,
 @length  varchar(50),
 @player1 int, --takes player id
 @player1_race int,
 @player2 int,
 @player2_race int,
 @winner int, --takes player name
 @map  int,
 @download_count int
as
begin
 begin try
  begin tran

   insert game
   (
    matchup,
    time,
    length,
    player1,
    player1_race,
    player2,
    player2_race,
    winner,
    map,
    download_count
   )
   select
    @matchup,
    @time,
    @length,
    @player1,
    @player1_race,
    @player2,
    @player2_race,
    @winner,
    @map,
    @download_count
   commit
 end try
 begin catch
  IF (@@TRANCOUNT > 0)
   rollback
   RAISERROR ('Error while trying to create a game id.', -- Message text.
     	16, -- Severity.
     	1 -- State.
     	);
  
 end catch
 
 select @@IDENTITY
end
