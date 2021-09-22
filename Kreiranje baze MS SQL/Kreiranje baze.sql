use master
go
create database Banka
go

use Banka
go

create table Osoba
(	
	ID int identity(1,1),
	Ime nvarchar(30),
	Prezime nvarchar(30),
	TipKorisnika nvarchar(10),
	RacunID smallint
)
go

create table Racun
(	
	ID int identity(1,1),
	TipRacuna nvarchar(30),
	NazivKartice nvarchar(30),
	BrojRacuna nvarchar(30),
	StanjeRacuna decimal(30,2),
	PIN smallint,
	OsobaID smallint
)
go

create table Transakcije
(
	RacunID int not null,
	Uplata decimal(30,2) null,
	Isplata decimal(30,2) null,
	DatumTransakcije date
)
go

alter table Osoba
add constraint OsobaID
primary key (ID)
go

alter table Racun
add constraint RacunID
primary key (ID)
go

/*alter table Transakcije
add constraint TransakcijeID
primary key (RacunID)
go*/

alter table Racun
add constraint Osoba_ID
foreign key (ID) references Osoba(ID)
go

alter table Transakcije
add constraint Racun_ID_Transakcije
foreign key (RacunID) references Racun(ID)
go

create procedure Osoba_Insert
(
	@ime nvarchar(30),
	@prezime nvarchar(30),
	@tipKorisnika nvarchar(10),
	@racunID smallint
)
as
begin
begin transaction
	insert into Osoba(Ime, Prezime, TipKorisnika, RacunID)
	values (@ime, @prezime, @tipKorisnika, @racunID)
	if @@error<> 0
	begin
		rollback
	end
	else
	begin
		commit
	end
end
go

create procedure Racun_Insert
(
	@TipRacuna nvarchar(30),
	@NazivKartice nvarchar(30),
	@BrojRacuna nvarchar(30),
	@StanjeRacuna decimal(30,2),
	@PIN smallint,
	@OsobaID smallint
)
as
begin
begin transaction
	insert into Racun(TipRacuna, NazivKartice, BrojRacuna, StanjeRacuna, PIN, OsobaID)
	values (@TipRacuna, @NazivKartice, @BrojRacuna, @StanjeRacuna, @PIN, @OsobaID)
	if @@error<> 0
	begin
		rollback
	end
	else
	begin
		commit
	end
end
go

create procedure Transakcije_Insert
(
	@RacunID int,
	@Uplata decimal(30,2),
	@Isplata decimal(30,2),
	@DatumTransakcije date
)
as
begin
begin transaction
	insert into Transakcije(RacunID, Uplata, Isplata,DatumTransakcije)
	values (@RacunID, @Uplata, @Isplata, @DatumTransakcije)
	if @@error<> 0
	begin
		rollback
	end
	else
	begin
		commit
	end
end
go

create procedure RacunUpdate
(
	@Iznos decimal (30,2),
	@PIN smallint
)
as
begin
begin transaction
	update Racun
	set StanjeRacuna -= @Iznos
	where PIN = @PIN
	if @@error<> 0
	begin
		rollback
	end
	else
	begin
		commit
	end
end
go

exec Osoba_Insert N'Marko',N'Markovic',N'Fizicko', 1
exec Osoba_Insert N'Nikola',N'Nikolic',N'Fizicko', 2
exec Osoba_Insert N'Bosko',N'Pavlovic',N'Pravno', 3
exec Osoba_Insert N'Jelena',N'Markovic',N'Fizicko', 4
exec Osoba_Insert N'Danijela',N'Ostojic',N'Pravno', 5
exec Osoba_Insert N'Teodora',N'Matic',N'Fizicko', 6
exec Osoba_Insert N'Petar',N'Petrovic',N'Fizicko', 7
exec Osoba_Insert N'Srdjan',N'Petrovic',N'Pravno', 8
exec Osoba_Insert N'Todor',N'Andric',N'Fizicko', 9
exec Osoba_Insert N'Martin',N'Meric',N'Fizicko', 10

exec Racun_Insert N'Stedni', N'VISA', N'10-15245813-01', 35650.00, 1234, 1
exec Racun_Insert N'Tekuci', N'VISA', N'11-12458265-02', 65600.00, 2345, 2
exec Racun_Insert N'Tekuci', N'MasterCard', N'12-02124569-03', 85112.00, 3456, 3
exec Racun_Insert N'Kreditni', N'Dina', N'13-05871136-04', 154900.00, 4567,4
exec Racun_Insert N'Tekuci', N'VISA', N'14-03365008-05', 739522.00, 5678, 5
exec Racun_Insert N'Kreditni', N'MasterCard', N'15-45013103-06', 250260.00, 6789, 6
exec Racun_Insert N'Kreditni', N'MasterCard', N'16-45002103-07', 250260.00, 7891, 7
exec Racun_Insert N'Kreditni', N'MasterCard', N'17-45882103-08', 250260.00, 8911, 8
exec Racun_Insert N'Kreditni', N'MasterCard', N'18-55022103-09', 250260.00, 9111, 9
exec Racun_Insert N'Tekuci', N'VISA', N'15-45022103-15', 250260.00, 1011, 10

exec Transakcije_Insert 1, 18000.02, 6500.00, N'2021-03-02'
exec Transakcije_Insert 3, 25000.00, 9000.00, N'2021-09-05'
exec Transakcije_Insert 5, 55000.60, 5500.00, N'2021-10-08'
exec Transakcije_Insert 6, null, 9500.00, N'2021-11-12'
exec Transakcije_Insert 4, 35731.09, 7000.00, N'2021-03-08'
exec Transakcije_Insert 2, 15100.14, 3000.00, N'2021-01-10'
exec Transakcije_Insert 1, 35731.09, null, N'2021-03-08'
exec Transakcije_Insert 5, 15100.14, 3000.00, N'2021-01-10'
exec Transakcije_Insert 6, null, 5500.00, N'2021-10-08'
exec Transakcije_Insert 9, 17520.18, 9500.00, N'2021-11-12'
exec Transakcije_Insert 8, 35731.09, null, N'2021-03-08'
exec Transakcije_Insert 10, 45730.00, null, N'2021-08-02'

exec Transakcije_Insert 10, 45730.00, null, N'2021-08-02'

--exec Transakcije_Insert 4730.00, null, N'2021-10-07', 1

/*
select * from Racun
select * from Osoba
select * from Transakcije
delete from Racun
drop database Banka

select * from Transakcije as t
inner join Osoba as o on o.ID = 1 and t.RacunID = 1

select * from Transakcije where RacunID = 5*/
-- select * from Racun where ID = 1
--exec RacunUpdate 650, 1234

--select * from Transakcije
/*
SELECT o.Ime, o.Prezime, o.TipKorisnika, t.RacunID, t.Uplata, t.Isplata, t.DatumTransakcije FROM Osoba as o INNER JOIN Transakcije as t on o.RacunID = t.RacunID WHERE o.RacunID = 5
*/