USE [KinoPoisk]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05.07.2022 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 05.07.2022 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 05.07.2022 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 05.07.2022 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PremiereYear] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoviesAndActors]    Script Date: 05.07.2022 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesAndActors](
	[Movie_actor_id] [int] IDENTITY(1,1) NOT NULL,
	[Movie_id] [int] NOT NULL,
	[Actor_id] [int] NOT NULL,
 CONSTRAINT [PK_MoviesAndActors] PRIMARY KEY CLUSTERED 
(
	[Movie_actor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoviesAndGenres]    Script Date: 05.07.2022 19:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesAndGenres](
	[Movie_actor_id] [int] IDENTITY(1,1) NOT NULL,
	[Movie_id] [int] NOT NULL,
	[Genre_id] [int] NOT NULL,
 CONSTRAINT [PK_MoviesAndGenres] PRIMARY KEY CLUSTERED 
(
	[Movie_actor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220701190608_initial', N'3.1.26')
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (2, N'Tim', N'Robbins')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (3, N'Morgan', N'Freeman')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (4, N'Bob', N'Gunton')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (5, N'Marlon', N'Brando')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (6, N'Al', N'Pacino')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (7, N'James', N'Caan')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (8, N'Christian', N'Bale')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (9, N'Heath', N'Ledger')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (10, N'Aaron', N'Eckhart')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (11, N'Robert', N'De Niro')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (12, N'Robert', N'Duvall')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (13, N'Henry', N'Fonda')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (14, N'Lee', N'J. Cobb')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (15, N'Martin', N'Balsam')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (16, N'Liam', N'Neeson')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (17, N'Ralph', N'Fiennes')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (18, N'Ben', N'Kingsley')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (19, N'Eliijah', N'Wood')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (20, N'Viggo', N'Mortensen')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (21, N'Ian', N'McKellen')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (22, N'John', N'Travolta')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (23, N'Uma', N'Thurman')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (24, N'Orlando', N'Bloom')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (25, N'Clint', N'Eastwood')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (26, N'Tom', N'Hanks')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (27, N'Robin', N'Wright')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (28, N'Gary', N'Sinise')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (29, N'Brad', N'Pitt')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (30, N'Edward', N'Norton')
INSERT [dbo].[Actors] ([Id], [Name], [Surname]) VALUES (31, N'Meat', N'Loaf')
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Title]) VALUES (1, N'Drama')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (2, N'Comedy')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (3, N'Musical')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (4, N'Romance')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (5, N'Comedy')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (6, N'Crime')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (7, N'Action')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (8, N'Thriller')
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (9, N'Horror')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (2, N'The Shawshank Redemption', N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 1994)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (3, N'Forrest Gump', N'The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.', 1994)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (4, N'The Lord of the Rings: The Fellowship of the Ring', N'A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.', 2001)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (5, N'Pulp Fiction', N'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', 1994)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (6, N'The Lord of the Rings: The Return of the King', N'Gandalf and Aragorn lead the World of Men against Sauron''s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.', 2003)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (7, N'Schindler''s List', N'In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.', 1993)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (8, N'12 Angry Men', N'The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.', 1957)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (9, N'The Godfather', N'The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.', 1972)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (10, N'The Dark Knight', N'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.', 2008)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (11, N'The Godfather Part II', N'The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.', 1974)
INSERT [dbo].[Movies] ([Id], [Title], [Description], [PremiereYear]) VALUES (12, N'Fight Club', N'An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.', 1999)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[MoviesAndActors] ON 

INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (2, 2, 2)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (3, 2, 4)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (4, 2, 3)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (5, 3, 28)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (6, 3, 26)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (7, 3, 27)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (8, 4, 19)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (9, 4, 21)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (10, 4, 24)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (11, 5, 23)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (12, 5, 22)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (13, 6, 20)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (14, 6, 21)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (15, 6, 19)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (16, 7, 16)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (17, 7, 17)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (18, 7, 18)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (19, 8, 13)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (20, 8, 14)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (21, 8, 15)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (22, 9, 6)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (23, 9, 5)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (24, 9, 7)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (25, 10, 8)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (26, 10, 10)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (27, 10, 9)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (28, 11, 6)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (29, 11, 12)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (30, 11, 11)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (31, 12, 29)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (32, 12, 30)
INSERT [dbo].[MoviesAndActors] ([Movie_actor_id], [Movie_id], [Actor_id]) VALUES (33, 12, 31)
SET IDENTITY_INSERT [dbo].[MoviesAndActors] OFF
GO
SET IDENTITY_INSERT [dbo].[MoviesAndGenres] ON 

INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (3, 2, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (4, 3, 4)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (5, 3, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (6, 4, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (7, 4, 7)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (8, 5, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (9, 5, 6)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (10, 6, 7)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (11, 6, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (12, 7, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (13, 8, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (14, 8, 6)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (15, 9, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (16, 9, 6)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (17, 10, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (18, 10, 7)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (19, 10, 6)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (20, 11, 1)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (21, 11, 6)
INSERT [dbo].[MoviesAndGenres] ([Movie_actor_id], [Movie_id], [Genre_id]) VALUES (22, 12, 1)
SET IDENTITY_INSERT [dbo].[MoviesAndGenres] OFF
GO
