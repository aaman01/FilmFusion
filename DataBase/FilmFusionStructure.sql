CREATE DATABASE IMDB

CREATE SCHEMA Foundation 

CREATE TABLE [Foundation].[Actors]
(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ActorName  VARCHAR(50) NOT NULL ,
    Sex VARCHAR(10)NOT NULL,
    DateOfBirth Date NOT NULL,
    Bio VARCHAR(100) NOT NULL
)


CREATE TABLE [Foundation].[Producers]
(
    Id INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
    ProducerName  VARCHAR(50) NOT NULL ,
    Sex VARCHAR(10)NOT NULL,
    Bio VARCHAR(100) NOT NULL
)

CREATE TABLE [Foundation].[Movies]
(
    Id INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
    MovieName  VARCHAR(50) NOT NULL ,
    YearOfRelease INT NOT NULL,
    Plot VARCHAR(500)NOT NULL,
    Post VARCHAR(500) NOT NULL,
    ProducerId INT NOT NULL ,
    CONSTRAINT FK_Movies_Producers FOREIGN KEY (ProducerId) REFERENCES [Foundation].[Producers](Id)
)


CREATE TABLE [Foundation].[Movies_Actors]
(
     MovieID INT NOT NULL ,
     ActorID INT NOT NULL ,
     CONSTRAINT PK_Movies_Actors PRIMARY KEY (MovieID,ActorID),
     CONSTRAINT FK_Movies_Actors_Movies FOREIGN KEY (MovieID) REFERENCES [Foundation].[Movies](Id),
     CONSTRAINT FK_Movies_Actors_Actors FOREIGN KEY (ActorID) REFERENCES [Foundation].[Actors](Id),
)

CREATE TABLE [Foundation].[Genres]
(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    GenreName VARCHAR(50) NOT NULL 
)

CREATE TABLE [Foundation].[Reviews]
(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    MovieId INT NOT NULL ,
    Message VARCHAR(150) NOT NULL,
    CONSTRAINT FK_Movies_Reviews FOREIGN KEY (MovieId) REFERENCES [Foundation].[Movies](Id)
)

CREATE TABLE [Foundation].[Movies_Genres]
(
    MovieId INT NOT NULL,
    GenreId INT NOT NULL,
    CONSTRAINT PK_Movies_Genres PRIMARY KEY (MovieId,GenreId),
    CONSTRAINT FK_Movies_Genre_Movies FOREIGN KEY (MovieId) REFERENCES [Foundation].[Movies](Id),
    CONSTRAINT FK_Movies_Genre_Genres FOREIGN KEY (GenreId) REFERENCES [Foundation].[Genres](Id)

)


 INSERT INTO [Foundation].[Actors]
 VALUES('C Bale ','Male','1961-05-12','Performed in various movies'),
       ('Heath Ledger','Male','1969-07-22','Joker'),
       ('Matt Damon ','Male','1971-12-06','known for the martian'),
       ('Robert Downey Jr','Male','1970-06-01','American actor best known for the ironman'),
       ('Tom Holland','Male','1970-06-01','European actor'),
       ('Gwyneth Paltrow','Female','1972-09-27','American actress and businesswoman'),
       ('John David Washington','Male','1984-07-28','American actor and former american football player')

INSERT INTO [Foundation].[Producers]
VALUES('C Nolan','Male','1970-07-30','INNOVATIVE THINKER'),
       ('Kevin Feige','Male','1973-06-02','American film and television producer'),
       ('James Mangold','Male','1963-12-16','merican film director, producer and screenwriter')


INSERT INTO [Foundation].[Movies] 
VALUES('Dark Knight',2014,'Batman has a new foe, the Joker, who is an accomplished criminal hell-bent on decimating Gotham City. Together with Gordon and Harvey Dent, Batman struggles to thwart the Joker before it is too late.','https://www.google.com/imgres?imgurl=https%3A%2F%2Fw0.peakpx.com%2Fwallpaper%2F578%2F765%2FHD-wallpaper-dark-knight-poster-batman-dark-knight.jpg&tbnid=TAJfGJpw-05zJM&vet=12ahUKEwj13fa6pvmEAxV91TgGHWOfCcAQMygBegQIARBU..i&imgrefurl=https%3A%2F%2Fwww.peakpx.com%2Fen%2Fhd-wallpaper-desktop-aebmm&docid=2wf4dPiSiihQyM&w=800&h=711&q=dark%20knight%20poster%204k&ved=2ahUKEwj13fa6pvmEAxV91TgGHWOfCcAQMygBegQIARBU',1),
      ('Ford vs Ferrari',2019,'American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws of physics to build a revolutionary race car for Ford in order to defeat Ferrari at the 24 Hours of Le Mans in 1966.','https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fen%2Fa%2Fa4%2FFord_v._Ferrari_%25282019_film_poster%2529.png&tbnid=ZOLsAYhzxiTHtM&vet=12ahUKEwjzhcOHqPmEAxU8-jgGHcZiCMYQMygAegQIARBP..i&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FFord_v_Ferrari&docid=yk1zo6GEcPdpnM&w=240&h=356&q=ford%20vs%20ferrari%20%2Cmovie%20year&ved=2ahUKEwjzhcOHqPmEAxU8-jgGHcZiCMYQMygAegQIARBP',3),
      ('Iron Man',2007,'After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.','https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.media-amazon.com%2Fimages%2FM%2FMV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw%40%40._V1_.jpg&tbnid=zB_H2cmKJbvm9M&vet=12ahUKEwi4rpKHrfmEAxVm7TgGHYOYDXoQMygAegQIARBO..i&imgrefurl=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt1345836%2F&docid=7lVgZVyPfY6uMM&w=486&h=720&q=dark%20knight%20risese%20poster%204k&ved=2ahUKEwi4rpKHrfmEAxVm7TgGHYOYDXoQMygAegQIARBO',2),
      ('Spider Man',2019,'With Spider-Mans identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.','https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.media-amazon.com%2Fimages%2FM%2FMV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw%40%40._V1_.jpg&tbnid=zB_H2cmKJbvm9M&vet=12ahUKEwi4rpKHrfmEAxVm7TgGHYOYDXoQMygAegQIARBO..i&imgrefurl=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt1345836%2F&docid=7lVgZVyPfY6uMM&w=486&h=720&q=dark%20knight%20risese%20poster%204k&ved=2ahUKEwi4rpKHrfmEAxVm7TgGHYOYDXoQMygAegQIARBO',2),
      ('Tenet',2018,'Armed with only the word Tenet, and fighting for the survival of the entire world, CIA operative, The Protagonist, journeys through a twilight world of international espionage on a global mission that unfolds beyond real time.','https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.media-amazon.com%2Fimages%2FM%2FMV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw%40%40._V1_.jpg&tbnid=zB_H2cmKJbvm9M&vet=12ahUKEwi4rpKHrfmEAxVm7TgGHYOYDXoQMygAegQIARBO..i&imgrefurl=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt1345836%2F&docid=7lVgZVyPfY6uMM&w=486&h=720&q=dark%20knight%20risese%20poster%204k&ved=2ahUKEwi4rpKHrfmEAxVm7TgGHYOYDXoQMygAegQIARBO',1)
      
INSERT INTO [Foundation].[Movies_Actors]
  VALUES(1,1),
        (1,2),
        (2,1),
        (2,3),
        (3,4),
        (3,6),
        (4,4),
        (4,5),
        (5,7)



ALTER TABLE [Foundation].[Actors]
ADD CreatedAt DATE  NULL,
UpdatedAt DATE NULL

ALTER TABLE [Foundation].[Movies]
ADD CreatedAt DATE  NULL,
UpdatedAt DATE NULL

ALTER TABLE [Foundation].[Producers]
ADD CreatedAt DATE  NULL,
UpdatedAt DATE NULL

ALTER TABLE [Foundation].[Actors]
ADD CONSTRAINT DF_Actors_CreatedAt 
DEFAULT GETDATE()  FOR CreatedAt

ALTER TABLE [Foundation].[Movies]
ADD CONSTRAINT DF_Movies_CreatedAt 
DEFAULT GETDATE()  FOR CreatedAt

ALTER TABLE [Foundation].[Producers]
ADD CONSTRAINT DF_Producers_CreatedAt 
DEFAULT GETDATE()  FOR CreatedAt

ALTER TABLE [Foundation].[Movies]
ADD Language VARCHAR(50)  NULL,
Profit INT NULL




