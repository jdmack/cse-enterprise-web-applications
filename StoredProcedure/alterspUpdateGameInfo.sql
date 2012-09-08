USE [cse136]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateGameInfo]    Script Date: 09/07/2012 23:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spUpdateGameInfo]
 @matchup char(3),
 @time  date,
 @length  varchar(50),
 @player1 int, --takes player id
 @player1_race int,
 @player2 int,
 @player2_race int,
 @winner int, --takes player name
 @map  int,
 @game_id int,
 @download_count int
as
begin
 begin try
  begin tran
   UPDATE game
   SET
    matchup = @matchup,
    time = @time,
    length = @length,
    player1 = @player1,
    player1_race = @player1_race,
    player2 = @player2,
    player2_race = @player2_race,
    winner = @winner,
    map = @map,
    download_count = @download_count
   WHERE
    id = @game_id 
      commit
 end try
 begin catch
  IF (@@TRANCOUNT > 0)
   rollback
   RAISERROR ('Error while trying to update a game.', -- Message text.
     	16, -- Severity.
     	1 -- State.
     	);
  
 end catch
end
