CREATE TABLE Authors( 
  ID int Not Null, 
  Name nvarchar (120),
  CONSTRAINT PK_Authors PRIMARY KEY(ID)
)
CREATE TABLE Publisher( 
  ID int Not Null, 
  Title nvarchar (120),
  CONSTRAINT PK_Publisher PRIMARY KEY(ID)
)
CREATE TABLE Serias( 
  ID int Not Null, 
  Title nvarchar (120),
  TomCount int,
  CONSTRAINT PK_Serias PRIMARY KEY(ID)
)
CREATE TABLE Book( 
  ID int Not Null,
  Title nvarchar (120),
  SeriaID int,
  ISBN int NOT NULL UNIQUE,
  AuthorID int Not Null,
  PublisherID int,
  LangCode nvarchar (10),
  CONSTRAINT PK_Book_BookID PRIMARY KEY(ID),
  CONSTRAINT FK_Book_Serias FOREIGN KEY(SeriaID) REFERENCES Serias(ID),
  CONSTRAINT FK_Book_Publisher FOREIGN KEY(PublisherID) REFERENCES Publisher(ID)
)

CREATE TABLE BookAuthors( 
  BookID int Not Null, 
  AuthorID int Not Null,
  CONSTRAINT PK_BookAuthors_BookID PRIMARY KEY(BookID,AuthorID),
  CONSTRAINT FK_BookAuthors_Authors FOREIGN KEY(AuthorID) REFERENCES Authors(ID),
  CONSTRAINT FK_BookAuthors_Book FOREIGN KEY(BookID) REFERENCES Book(ID)
)

