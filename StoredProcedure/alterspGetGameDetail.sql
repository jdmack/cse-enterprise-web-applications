USE [cse136]
GO
/****** Object:  StoredProcedure [dbo].[spGetGameDetail]    Script Date: 09/07/2012 23:11:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetGameDetail]
	@game_id int
as
begin
 begin try
  begin tran
select
    id,
    matchup,
    time,
    length,
    player1,
    player2,
    winner,
    map,
    player1_race,
    player2_race,
    download_count
from
    game
where
	id = @game_id
  
   commit
 end try
 begin catch
  IF (@@TRANCOUNT > 0)
   rollback
   RAISERROR ('Error while trying to select', -- Message text.
     	16, -- Severity.
     	1 -- State.
     	);
  
 end catch
end
