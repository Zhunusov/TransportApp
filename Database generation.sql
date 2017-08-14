CREATE DATABASE [Transport] ON  PRIMARY 

USE [Transport]
GO 

CREATE TABLE TransportBodyType (
       Name                 nvarchar(256) NOT NULL,
       Description          nvarchar(MAX) NULL,
       TransportBodyId      int IDENTITY(1,1),
       PRIMARY KEY (TransportBodyId)
)
go


CREATE TABLE Unions (
       Name                 nvarchar(MAX) NOT NULL,
       UnionId              int IDENTITY(1,1),
       PRIMARY KEY (UnionId)
)
go


CREATE TABLE Countries (
       CountryName          ntext NOT NULL,
       ISOCode2             nvarchar(128) NULL,
       ISOCode3             nvarchar(128) NULL,
       PhoneCode            nvarchar(128) NULL,
       CountryId            int IDENTITY(1,1),
       UnionId              int NULL,
       PRIMARY KEY (CountryId), 
       FOREIGN KEY (UnionId)
                             REFERENCES Unions
)
go

CREATE INDEX XIF110Countries ON Countries
(
       UnionId
)
go


CREATE TABLE Regions (
       CountryId            int NOT NULL,
       RegionId             int IDENTITY(1,1),
       RegionName           nvarchar(MAX) NOT NULL,
       PRIMARY KEY (RegionId), 
       FOREIGN KEY (CountryId)
                             REFERENCES Countries
)
go

CREATE INDEX XIF6Regions ON Regions
(
       CountryId
)
go


CREATE TABLE Cities (
       RegionId             int NOT NULL,
       CityId               int IDENTITY(1,1),
       CountryId            int NOT NULL,
       CityName             nvarchar(256) NOT NULL,
       Latitude             decimal(18,2) NULL,
       Longitude            decimal(18,2) NULL,
       PRIMARY KEY (CityId), 
       FOREIGN KEY (RegionId)
                             REFERENCES Regions, 
       FOREIGN KEY (CountryId)
                             REFERENCES Countries
)
go

CREATE INDEX XIF5Cities ON Cities
(
       CountryId
)
go

CREATE INDEX XIF7Cities ON Cities
(
       RegionId
)
go


CREATE TABLE Roles (
       Name                 nvarchar(256) NOT NULL,
       RoleId               int IDENTITY(1,1),
       PRIMARY KEY (RoleId),
       UNIQUE (
              Name
       )
)
go


CREATE TABLE Users (
       Email                nvarchar(256) NULL,
       UserId               int IDENTITY(1,1),
       EmailConfirmed       bit NOT NULL,
       PasswordHash         nvarchar(max) NULL,
       SecurityStamp        nvarchar(max) NULL,
       PhoneNumber          nvarchar(max) NULL,
       PhoneNumberConfirmed bit NOT NULL,
       TwoFactorEnabled     bit NOT NULL,
       LockoutEndDateUtc    datetime NULL,
       LockoutEnabled       bit NOT NULL,
       AccessFailedCount    int NOT NULL,
       UserName             nvarchar(256) NOT NULL,
       RoleId               int NULL,
       PRIMARY KEY (UserId), 
       FOREIGN KEY (RoleId)
                             REFERENCES Roles,
       UNIQUE (
              UserName
       )
)
go

CREATE INDEX XIF60Users ON Users
(
       RoleId
)
go


CREATE TABLE Transports (
       UserId               int NOT NULL,
       IsTransportDeactivated bit NOT NULL,
       TransportId          int IDENTITY(1,1),
       PRIMARY KEY (TransportId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF12Transports ON Transports
(
       UserId
)
go


CREATE TABLE TransportRoutes (
       CityArrivalld        int NOT NULL,
       TransportId          int NOT NULL,
       CityShipmentId       int NOT NULL,
       IsRouteDeactivated   bit NOT NULL,
       PRIMARY KEY (CityArrivalld, TransportId, CityShipmentId), 
       FOREIGN KEY (CityShipmentId)
                             REFERENCES Cities, 
       FOREIGN KEY (TransportId)
                             REFERENCES Transports
)
go

CREATE INDEX XIF55TransportRoutes ON TransportRoutes
(
       TransportId
)
go

CREATE INDEX XIF56TransportRoutes ON TransportRoutes
(
       CityShipmentId
)
go


CREATE TABLE Currencies (
       CurrencyName         nvarchar(128) NULL,
       CurrencyId           int IDENTITY(1,1),
       ISOCode3             nvarchar(16) NULL,
       Symbol               nvarchar(8) NULL,
       PRIMARY KEY (CurrencyId)
)
go


CREATE TABLE Cargoes (
       UserId               int NOT NULL,
       CityShipmentId       int NULL,
       CargoId              int IDENTITY(1,1),
       CityArrivalId        int NULL,
       IsCargoDeactivated   bit NOT NULL,
       PRIMARY KEY (CargoId), 
       FOREIGN KEY (CityShipmentId)
                             REFERENCES Cities,
	   FOREIGN KEY (CityArrivalId)
                             REFERENCES Cities, 
       FOREIGN KEY (UserId)
                             REFERENCES Users      
)
go

CREATE INDEX XIF6Cargoes ON Cargoes
(
       UserId
)
go

CREATE INDEX XIF99Cargoes ON Cargoes
(
       CityShipmentId
)
go


CREATE TABLE CargoPayments (
       IsCostKnown          bit NOT NULL,
       SumOfPayment         int NULL,
       CurrencyId           int NULL,
       CostUnit             nvarchar(64) NULL,
       PaymentMethod        nvarchar(128) NULL,
       IsVATApplicable      bit NOT NULL,
       CargoId              int NOT NULL,
       PrePayment           real NULL,
       TimeOfPayment        nvarchar(128) NULL,
       PRIMARY KEY (CargoId), 
       FOREIGN KEY (CurrencyId)
                             REFERENCES Currencies, 
       FOREIGN KEY (CargoId)
                             REFERENCES Cargoes
)
go

CREATE INDEX XIF52CargoPayments ON CargoPayments
(
       CurrencyId
)
go


CREATE TABLE UserEmployees (
       UserId               int NOT NULL,
       Name                 nvarchar(256) NULL,
       Position             nvarchar(256) NULL,
       EmployeeId           nvarchar(128) NOT NULL,
       Age                  char(18) NULL,
       PRIMARY KEY NONCLUSTERED (UserId, EmployeeId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF35UserEmployees ON UserEmployees
(
       UserId
)
go


CREATE TABLE UserBizInformations (
       IsAuthorized         bit NOT NULL,
       BizUniqueNumber      nvarchar(128) NULL,
       UserId               int NOT NULL,
       CityId               int NULL,
       Address              nvarchar(MAX) NULL,
       BizStatus            nvarchar(256) NULL,
       BizDescription       nvarchar(MAX) NULL,
       BizName              nvarchar(MAX) NOT NULL,
       PRIMARY KEY (UserId), 
       FOREIGN KEY (CityId)
                             REFERENCES Cities, 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF54UserBizInformations ON UserBizInformations
(
       CityId
)
go


CREATE TABLE Phones (
       CountryId            int NOT NULL,
       PhoneID              int IDENTITY(1,1),
       PhoneNumber          nvarchar(128) NOT NULL,
       UserId               int NOT NULL,
       IsViberSupported     bit NOT NULL,
       EmployeeId           nvarchar(128) NULL,
       IsWhatUpSupported    bit NOT NULL,
       PRIMARY KEY (PhoneID), 
       FOREIGN KEY (UserId, EmployeeId)
                             REFERENCES UserEmployees, 
       FOREIGN KEY (CountryId)
                             REFERENCES Countries, 
       FOREIGN KEY (UserId)
                             REFERENCES UserBizInformations
)
go

CREATE INDEX XIF111Phones ON Phones
(
       UserId,
       EmployeeId
)
go

CREATE INDEX XIF48Phones ON Phones
(
       UserId
)
go

CREATE INDEX XIF50Phones ON Phones
(
       CountryId
)
go


CREATE TABLE DocumentTypes (
       Description          nvarchar(MAX) NULL,
       DocumentId           int IDENTITY(1,1),
       DocumentType         nvarchar(MAX) NOT NULL,
       PRIMARY KEY (DocumentId)
)
go

/*
CREATE TABLE Markets (
       UserId               int NOT NULL,
       PRIMARY KEY NONCLUSTERED (UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go


CREATE TABLE ForumTopics (
       UserId               int NOT NULL,
       PRIMARY KEY NONCLUSTERED (UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go
*/

CREATE TABLE StateActivities (
       ActivityId           int IDENTITY(1,1),
       CountryId            int NOT NULL,
       ActivityName         nvarchar(MAX) NOT NULL,
       Description          nvarchar(MAX) NULL,
       PRIMARY KEY (ActivityId), 
       FOREIGN KEY (CountryId)
                             REFERENCES Countries
)
go

CREATE INDEX XIF26StateActivities ON StateActivities
(
       CountryId
)
go


CREATE TABLE UserServices (
       ActivityId           int NOT NULL,
       UserServiceId        int IDENTITY(1,1),
       UserId               int NOT NULL,
       IsActiveActivity     binary NOT NULL,
       PRIMARY KEY (UserServiceId), 
       FOREIGN KEY (ActivityId)
                             REFERENCES StateActivities, 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF36UserServices ON UserServices
(
       UserId
)
go

CREATE INDEX XIF47UserServices ON UserServices
(
       ActivityId
)
go

/*
CREATE TABLE Specifications (
       UserId               int NOT NULL,
       PRIMARY KEY NONCLUSTERED (UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go


CREATE TABLE Statistics (
       UserId               int NOT NULL,
       PRIMARY KEY NONCLUSTERED (UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go


CREATE TABLE Commercial (
       UserId               int NULL,
       CurrencyId           int NULL, 
       FOREIGN KEY (CurrencyId)
                             REFERENCES Currency, 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF34Commercial ON Commercial
(
       CurrencyId
)
go

CREATE INDEX XIF39Commercial ON Commercial
(
       UserId
)
go


CREATE TABLE Services (
)
go


CREATE TABLE Prices (
       UserId               int NULL,
       CurrencyId           int NULL, 
       FOREIGN KEY (UserId)
                             REFERENCES Users, 
       FOREIGN KEY (CurrencyId)
                             REFERENCES Currency
)
go

CREATE INDEX XIF31Prices ON Prices
(
       CurrencyId
)
go

CREATE INDEX XIF38Prices ON Prices
(
       UserId
)
go


CREATE TABLE PricePackages (
)
go
*/

CREATE TABLE TransportImages (
       TransportId          int NOT NULL,
       ImageId              int IDENTITY(1,1),
       ImageData            varbinary(MAX) NULL,
       ImageMimeType        nvarchar(128) NULL,
       PRIMARY KEY (ImageId), 
       FOREIGN KEY (TransportId)
                             REFERENCES Transports
)
go

CREATE INDEX XIF68TransportImages ON TransportImages
(
       TransportId
)
go


CREATE TABLE CargoImages (
       CargoId              int NOT NULL,
       ImageId              int IDENTITY(1,1),
       ImageData            varbinary(MAX) NULL,
       ImageMimeType        nvarchar(128) NULL,
       PRIMARY KEY (ImageId), 
       FOREIGN KEY (CargoId)
                             REFERENCES Cargoes
)
go

CREATE INDEX XIF26CargoImages ON CargoImages
(
       CargoId
)
go


CREATE TABLE TransportDates (
       DateOfFormation      datetime NOT NULL,
       ShipmentDate         datetime NULL,
       ArrivalDate          datetime NULL,
       TransportId          int NOT NULL,
       PRIMARY KEY (TransportId), 
       FOREIGN KEY (TransportId)
                             REFERENCES Transports
)
go


CREATE TABLE TransportDocuments (
       TransportId          int NOT NULL,
       DocumentId           int NOT NULL,
       IsDocumentActive     bit NOT NULL,
       PRIMARY KEY (TransportId, DocumentId), 
       FOREIGN KEY (DocumentId)
                             REFERENCES DocumentTypes, 
       FOREIGN KEY (TransportId)
                             REFERENCES Transports
)
go

CREATE INDEX XIF54TransportDocuments ON TransportDocuments
(
       DocumentId
)
go

CREATE INDEX XIF69TransportDocuments ON TransportDocuments
(
       TransportId
)
go


CREATE TABLE TransportInfo (
       TransportBodyId      int NULL,
       TransportId          int NOT NULL,
       Length               decimal(18,2) NULL,
       Width                decimal(18,2) NULL,
       Height               decimal(18,2) NULL,
       Carrying             decimal(18,2) NULL,
       Capacity             real NULL,
       IsTrailerAvailable   bit NOT NULL,
       ADR                  nchar(16) NULL,
       PRIMARY KEY (TransportId), 
       FOREIGN KEY (TransportBodyId)
                             REFERENCES TransportBodyType, 
       FOREIGN KEY (TransportId)
                             REFERENCES Transports
)
go

CREATE INDEX XIF55TransportInfo ON TransportInfo
(
       TransportBodyId
)
go


CREATE TABLE LoadTypes (
       Name                 nvarchar(256) NOT NULL,
       LoadTypeId           int IDENTITY(1,1),
       Description          nvarchar(MAX) NULL,
       PRIMARY KEY (LoadTypeId)
)
go


CREATE TABLE CargoTransports (
       CargoId              int NOT NULL,
       LoadTypeId           int NOT NULL,
       IsLoadtypeRequired   bit NOT NULL,
       PRIMARY KEY (CargoId, LoadTypeId), 
       FOREIGN KEY (LoadTypeId)
                             REFERENCES LoadTypes, 
       FOREIGN KEY (CargoId)
                             REFERENCES Cargoes
)
go

CREATE INDEX XIF27CargoTransports ON CargoTransports
(
       CargoId
)
go

CREATE INDEX XIF56CargoTransports ON CargoTransports
(
       LoadTypeId
)
go


CREATE TABLE NearestCities (
       NearestCityId        int NOT NULL,
       Distance             int NULL,
       CityId               int NOT NULL,
       PRIMARY KEY (NearestCityId, CityId), 
       FOREIGN KEY (CityId)
                             REFERENCES Cities
)
go

CREATE INDEX XIF105NearestCities ON NearestCities
(
       CityId
)
go


CREATE TABLE CargoDates (
       ShipmentDateStart    datetime NULL,
       ShipmentDateFinished datetime NULL,
       CargoId              int NOT NULL,
       DateOfFormation      datetime NOT NULL,
       PRIMARY KEY (CargoId), 
       FOREIGN KEY (CargoId)
                             REFERENCES Cargoes
)
go


CREATE TABLE TransportTypes (
       LoadTypeId           int NOT NULL,
       IsLoadtypeActive     bit NOT NULL,
       TransportId          int NOT NULL,
       PRIMARY KEY (LoadTypeId, TransportId), 
       FOREIGN KEY (LoadTypeId)
                             REFERENCES LoadTypes, 
       FOREIGN KEY (TransportId)
                             REFERENCES Transports
)
go

CREATE INDEX XIF57TransportTypes ON TransportTypes
(
       LoadTypeId
)
go

CREATE INDEX XIF64TransportTypes ON TransportTypes
(
       TransportId
)
go


CREATE TABLE CargoInfoes (
       Name                 nvarchar(MAX) NOT NULL,
       CargoId              int NOT NULL,
       ADR                  nchar(16) NULL,
       Length               decimal(18,2) NULL,
       Height               decimal(18,2) NULL,
       Width                decimal(18,2) NULL,
       WeightMin            decimal(18,2) NOT NULL,
       WeightMax            decimal(18,2) NOT NULL,
       SizeMin              int NULL,
       SizeMax              int NULL,
       AdditionalInfo       nvarchar(MAX) NULL,
       RequiredCountOfTransport real NULL,
       CargoFrequency       nvarchar(256) NULL,
       PRIMARY KEY (CargoId), 
       FOREIGN KEY (CargoId)
                             REFERENCES Cargoes
)
go


CREATE TABLE CargoDocuments (
       CargoId              int NOT NULL,
       IsDocumentRequired   bit NOT NULL,
       DocumentId           int NOT NULL,
       PRIMARY KEY (CargoId, DocumentId), 
       FOREIGN KEY (DocumentId)
                             REFERENCES DocumentTypes, 
       FOREIGN KEY (CargoId)
                             REFERENCES Cargoes
)
go

CREATE INDEX XIF112CargoDocuments ON CargoDocuments
(
       DocumentId
)
go

CREATE INDEX XIF24CargoDocuments ON CargoDocuments
(
       CargoId
)
go


CREATE TABLE UserPartners (
       PartnerId            nvarchar(128) NOT NULL,
       IsPartnershipActive  bit NOT NULL,
       UserId               int NOT NULL,
       IsPartnershipAccepted bit NOT NULL,
       PRIMARY KEY (PartnerId, UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF32UserPartners ON UserPartners
(
       UserId
)
go


CREATE TABLE UserNotes (
       UserId               int NOT NULL,
       NoteId               int IDENTITY(1,1),
       NoteText             nvarchar(MAX) NOT NULL,
       PRIMARY KEY (NoteId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF34UserNotes ON UserNotes
(
       UserId
)
go


CREATE TABLE UserComments (
       UserId               int NOT NULL,
       CommentId            int IDENTITY(1,1),
       CommentText          nvarchar(MAX) NOT NULL,
       UserCommentedId      nvarchar(128) NOT NULL,
       PRIMARY KEY (CommentId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF33UserComments ON UserComments
(
       UserId
)
go


CREATE TABLE UserMessages (
       UserId               int NOT NULL,
       MessageId            int IDENTITY(1,1),
       MessageText          nvarchar(MAX) NOT NULL,
       RecipientId          nvarchar(128) NOT NULL,
       PRIMARY KEY (MessageId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF30UserMessages ON UserMessages
(
       UserId
)
go


CREATE TABLE UserDocuments (
       DocumentId           int NOT NULL,
       UserDocumentId       int IDENTITY(1,1),
       UserId               int NOT NULL,
       DocumentName         nvarchar(MAX) NULL,
       ImageData            varbinary(MAX) NULL,
       ImageMimeType        nvarchar(128) NULL,
       PRIMARY KEY (UserDocumentId), 
       FOREIGN KEY (DocumentId)
                             REFERENCES DocumentTypes, 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF31UserDocuments ON UserDocuments
(
       UserId
)
go

CREATE INDEX XIF46UserDocuments ON UserDocuments
(
       DocumentId
)
go


CREATE TABLE UserRatings (
       UserId               int NOT NULL,
       RatingId             int IDENTITY(1,1),
       Rating               int NOT NULL,
       UserRatedId          nvarchar(128) NOT NULL,
       PRIMARY KEY (RatingId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF28UserRatings ON UserRatings
(
       UserId
)
go

/*
CREATE TABLE News (
       UserId               int NOT NULL,
       PRIMARY KEY NONCLUSTERED (UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go
*/

CREATE TABLE UserLogins (
       LoginProvider        nvarchar(128) NOT NULL,
       ProviderKey          nvarchar(128) NOT NULL,
       UserId               int NOT NULL,
       PRIMARY KEY (LoginProvider, ProviderKey, UserId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF5UserLogins ON UserLogins
(
       UserId
)
go


CREATE TABLE UserClaims (
       UserId               int NOT NULL,
       UserClaimId          int IDENTITY(1,1),
       ClaimType            nvarchar(max) NULL,
       ClaimValue           nvarchar(max) NULL,
       PRIMARY KEY (UserClaimId), 
       FOREIGN KEY (UserId)
                             REFERENCES Users
)
go

CREATE INDEX XIF4UserClaims ON UserClaims
(
       UserId
)
go

-- Constrains
ALTER TABLE dbo.Users
ADD CONSTRAINT DF_Users_EmailConfirmed DEFAULT 'false' FOR [EmailConfirmed];
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT DF_Users_PhoneNumberConfirmed DEFAULT 'false' FOR [PhoneNumberConfirmed];
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT DF_Users_TwoFactorEnabled DEFAULT 'false' FOR [TwoFactorEnabled];
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT DF_Users_LockoutEnabled DEFAULT 'false' FOR [LockoutEnabled];
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT DF_Users_AccessFailedCount DEFAULT '0' FOR [AccessFailedCount];
GO

ALTER TABLE dbo.UserBizInformations
ADD CONSTRAINT DF_UserBizInfo_IsAuthorized DEFAULT 'false' FOR [IsAuthorized];
GO

ALTER TABLE dbo.Phones
ADD CONSTRAINT  DF_Phones_IsViberSupported DEFAULT 'false' FOR [IsViberSupported];
GO

ALTER TABLE dbo.Phones
ADD CONSTRAINT  DF_Phones_IsWhatUpSupported DEFAULT 'false' FOR [IsWhatUpSupported];
GO

ALTER TABLE dbo.Cargoes
ADD CONSTRAINT DF_Cargoes_IsCargoDeactivated DEFAULT 'false' FOR [IsCargoDeactivated];
GO

ALTER TABLE dbo.CargoPayments
ADD CONSTRAINT DF_CargoPayments_IsCostKnown DEFAULT 'false' FOR [IsCostKnown];
GO

ALTER TABLE dbo.CargoPayments
ADD CONSTRAINT DF_CargoPayments_IsVATApplicable DEFAULT 'false' FOR [IsVATApplicable];
GO

-- Присваивамем роль Пользователя по умолчанию (id 2 из таблицы ролей)
ALTER TABLE dbo.Users
ADD CONSTRAINT DF_Users_RoleId DEFAULT '2' FOR [RoleId];
GO




