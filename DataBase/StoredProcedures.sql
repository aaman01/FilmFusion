CREATE PROCEDURE usp_insert_movie @MovieName     VARCHAR(50),
                                  @YearOfRelease INT,
                                  @Plot          VARCHAR(100),
                                  @Post          VARCHAR(500),
                                  @CreatedAt     VARCHAR(30),
                                  @UpdatedAt   VARCHAR(30),
                                  @Language      VARCHAR(40),
                                  @Profit        INT,
                                  @ProducerID    VARCHAR(max),
                                  @ActorIDs      VARCHAR(max),
                                  @GenreIDs      VARCHAR(max)
AS
  BEGIN
      INSERT foundation.movies
      VALUES (@MovieName,
              @YearOfRelease,
              @Plot,
              @Post,
              CAST(@ProducerID as INT),
              @CreatedAt,
              @UpdatedAt,
              @Language,
              @Profit)
      SELECT Id=SCOPE_IDENTITY()
      DECLARE @MovieID INT

      SET @MovieID=Scope_identity()


INSERT INTO foundation.movies_actors (MovieID, ActorID)
SELECT @MovieID, CAST(value AS INT) AS ActorID
FROM STRING_SPLIT(@ActorIDs, ',')

INSERT INTO [Foundation].[Movies_Genres] (MovieId,GenreId)
SELECT @MovieID , CAST(value AS INT) AS GenreId
FROM string_split(@GenreIDs,',')

  END 

EXECUTE usp_insert_movie 
'Happy New Year',
2016,
'SRK STEAL',
'https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fen%2Ff%2Ff0%2FHappy_New_Year_Poster_%25282014_film%2529.jpg&tbnid=-kZU4_2U-VqraM&vet=12ahUKEwjx98q74oKFAxUwzDgGHdvKAu0QMygAegQIARBu..i&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FHappy_New_Year_(2014_film)&docid=U6TgCzh2G8mREM&w=262&h=379&q=HAPPY%20NEW%20YEAR%20SRK&ved=2ahUKEwjx98q74oKFAxUwzDgGHdvKAu0QMygAegQIARBu',
NULL,
NULL,
'HINDI',
250000,
'1',
'1,4' 

--2
CREATE PROCEDURE usp_delete_MovieById @MovieID INT
AS
  BEGIN
      DELETE FROM Foundation.Movies_Actors
      WHERE  MovieID = @MovieID

      DELETE FROM Foundation.Movies
      WHERE  Id = @MovieID
  END

EXECUTE usp_delete_MovieById 1010

CREATE PROCEDURE usp_delete_ProducerById @ProducerID INT
AS
BEGIN

DELETE MA
FROM Foundation.Movies_Actors AS MA
INNER JOIN Foundation.Movies AS M
ON MA.MovieID=M.Id
WHERE M.ProducerId=@ProducerID

DELETE FROM Foundation.Movies
WHERE ProducerId=@ProducerID

DELETE FROM Foundation.Producers
WHERE Id=@ProducerID
END


EXECUTE usp_delete_ProducerById 4

CREATE PROCEDURE usp_delete_ActorById @ActorID INT
AS
BEGIN
       DELETE FROM Foundation.Movies_Actors
       WHERE ActorID=@ActorID

       DELETE FROM Foundation.Actors 
       WHERE  Id=@ActorID
END

EXECUTE usp_delete_ActorById 10

CREATE PROCEDURE usp_update_movie @MovieId       INT,
                                  @MovieName     VARCHAR(50),
                                  @YearOfRelease INT,
                                  @Plot          VARCHAR(100),
                                  @Post          VARCHAR(500),
                                  @CreatedAt     VARCHAR(30),
                                  @UpdatedAt   VARCHAR(30),
                                  @Language      VARCHAR(40),
                                  @Profit        INT,
                                  @ProducerID    VARCHAR(max),
                                  @ActorIDs      VARCHAR(max),
                                  @GenreIDs      VARCHAR(max)
AS
BEGIN
	UPDATE [Foundation].[Movies]
	SET MovieName = @MovieName
		,YearOfRelease = @YearOfRelease
		,Plot = @Plot
		,Post = @Post
		,ProducerId = CAST(@ProducerID AS INT)
	WHERE Id = @MovieId

	DELETE
	FROM [Foundation].[Movies_Actors]
	WHERE MovieID = @MovieId

	DELETE
	FROM [Foundation].[Movies_Genre]
	WHERE MovieId = @MovieId

	INSERT INTO [Foundation].[Movies_Actors] (
		MovieID
		,ActorID
		)
	SELECT @MovieID
		,CAST(value AS INT) AS ActorID
	FROM STRING_SPLIT(@ActorIDs, ',')

	INSERT INTO [Foundation].[Movies_Genres] (
		MovieId
		,GenreId
		)
	SELECT @MovieID
		,CAST(value AS INT) AS GenreId
	FROM string_split(@GenreIDs, ',')
END