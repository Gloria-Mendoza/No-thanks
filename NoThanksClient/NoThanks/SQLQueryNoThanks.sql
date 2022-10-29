create table Games(
	idGame int identity (1,1) primary key,
	result int
)

create table Players(
	idPlayer int identity (1,1) primary key,
	nickname nvarchar(45),
	password nvarchar (128),
	email nvarchar (100),
	totalScore int,
	name nvarchar,
	lastName nvarchar,
	constraint uniqueNickname unique(nickname)
	
)

create table Friends(
	idFriend int identity (1,1) primary key,
	idPlayer1 int foreign key references Players,
	idPlayer2 int foreign key references Players
)

create table MatchsHistory(
	idMatch int primary key,
	point int,
	result varchar (8),
	idGame int foreign key references Games,
	idPlayer int foreign key references Players,
)