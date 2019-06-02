CREATE TABLE Music4
(
	MusicID int PRIMARY KEY,
	MusicName varchar(max) NOT NULL,
	MusicSummary varchar(max),
	MusicAuthor varchar(max)NOT NULL,
	MusicAlbum varchar(max)NOT NULL,
	MusicDuration varchar(max)NOT NULL,
	MusicSize varchar(max)NOT NULL,
	MusicCover varchar(max)NOT NULL,
    MusicBigCover varchar(max)NOT NULL,
	MusicPath varchar(max)NOT NULL,
	LoveTag int NOT NULL,
	ListenFrequency int NOT NULL
	
);