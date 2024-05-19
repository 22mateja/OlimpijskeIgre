create database OlimpijskeIgre
use OlimpijskeIgre
create Table Sport(
id INT identity(1,1) PRIMARY KEY,
naziv NVARCHAR(100),
br_faza INT,
vrsta INT,
)
Create Table Drzava(
id INT identity(1,1) PRIMARY KEY,
naziv NVARCHAR(100),
br_medalja INT,
) 
Create Table Ekipa(
id INT identity(1,1) PRIMARY KEY,
drzava_id INT FOREIGN KEY REFERENCES Drzava(id),
sport_id INT FOREIGN KEY REFERENCES Sport(id),
)
Create Table Igraci(
id INT identity(1,1) PRIMARY KEY,
ekipa_id INT FOREIGN KEY REFERENCES Ekipa(id),
br_medalja INT,
)
Create Table Utakmica(
id INT Identity(1,1) PRIMARY KEY,
faza INT,
ekipa_id_1 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_2 INT FOREIGN KEY REFERENCES Ekipa(id),
reultat1 INT,
rezultat2 INT,
id_pobednika INT,
)
 Create Table Trka(
id INT Identity(1,1) PRIMARY KEY,
faza INT,
broj_ekipa INT,
ekipa_id_1 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_2 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_3 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_4 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_5 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_6 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_7 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_8 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_9 INT FOREIGN KEY REFERENCES Ekipa(id),
ekipa_id_10 INT FOREIGN KEY REFERENCES Ekipa(id),
reultat1 INT,
rezultat2 INT,
reultat2 INT,
reultat3 INT,
reultat4 INT,
reultat5 INT,
reultat6 INT,
reultat7 INT,
reultat8 INT,
reultat9 INT,
rezultat10 INT,
)
Create Table Trener(
id INT Identity(1,1) PRIMARY KEY, 
vrsta VARCHAR(20),
ekipa_id INT FOREIGN KEY REFERENCES Ekipa(id),
)
Create Table Sudija(
id INT Identity(1,1) PRIMARY KEY,
drzava_id INT FOREIGN KEY REFERENCES Drzava(id),
)
ALTER TABLE Igraci
ADD ime NVARCHAR(20);

ALTER TABLE Igraci
ADD prezime NVARCHAR(20);

ALTER TABLE Trener
ADD ime NVARCHAR(20);
ALTER TABLE Trener
ADD prezime NVARCHAR(20);

ALTER TABLE Sudija
ADD ime NVARCHAR(20);

ALTER TABLE Sudija
ADD prezime NVARCHAR(20);

ALTER TABLE Sudija
ADD email NVARCHAR(50);

ALTER TABLE Sudija
ADD lozinka NVARCHAR(100);

ALTER TABLE Ekipa
ADD nazivDrzave NVARCHAR(20);

ALTER TABLE Ekipa
ADD nazivSporta NVARCHAR(20);

-- SPORT PROCEDURE

go
CREATE PROC Sport_Insert
@naziv nvarchar(100),
@br_faza int,
@vrsta int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
IF EXISTS (SELECT TOP 1 naziv  FROM Sport
	WHERE naziv = @naziv  )
	Return 1
	else
	Insert Into Sport(naziv, br_faza, vrsta)
	Values(@naziv,@br_faza,@vrsta)
		RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
go
GO
Create PROC Sport_Update
@id int,
@naziv nvarchar(20),
@br_faza int,
@vrsta int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
	IF EXISTS (SELECT TOP 1 naziv FROM Sport
	WHERE id = @id )

	BEGIN
	
	Update Sport  Set naziv=@naziv,br_faza=@br_faza,vrsta=@vrsta    where id=@id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
go
CREATE PROC Sport_Delete
@id int
AS
BEGIN TRY
    DELETE FROM Sport WHERE id = @id;
    RETURN 0; -- Uspešno brisanje
END TRY
BEGIN CATCH
    RETURN @@ERROR; -- Greška prilikom izvršavanja
END CATCH
GO
-- DRZAVA PROCEDURE
go
CREATE PROC Drzava_Insert
@naziv nvarchar(100),
@br_medalja int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
IF EXISTS (SELECT TOP 1 naziv  FROM Drzava
	WHERE naziv = @naziv  )
	Return 1
	else
	Insert Into Drzava(naziv, br_medalja)
	Values(@naziv,@br_medalja)
		RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
go
GO
Create PROC Drzava_Update
@id int,
@naziv nvarchar(20),
@br_medalja int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 naziv FROM Drzava
	WHERE id = @id )

	BEGIN
	
	Update Drzava  Set naziv=@naziv,br_medalja=@br_medalja    where id=@id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
Create Proc Drzava_Delete
@id int
as
Begin TRY
Delete from Drzava where id=@id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
--IGRACI PROCEDURE
CREATE PROC Igraci_Insert
@ime nvarchar(20),
@prezime nvarchar(20),
@nazivDrzave nvarchar(100),
@nazivSporta nvarchar(100),
@br_medalja int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
    IF EXISTS (SELECT TOP 1 ime, prezime FROM Igraci
                WHERE ime = @ime AND prezime = @prezime)
    BEGIN
        RETURN 1; -- Igrač već postoji
    END
    ELSE
    BEGIN
        DECLARE @ekipa_id INT
        SELECT @ekipa_id = Ekipa.id
        FROM Ekipa
        INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
        INNER JOIN Sport ON Ekipa.sport_id = Sport.id
        WHERE Drzava.naziv = @nazivDrzave AND Sport.naziv = @nazivSporta

        IF @ekipa_id IS NULL
        BEGIN
            RETURN -1; -- Ekipa ne postoji
        END
        ELSE
        BEGIN
            INSERT INTO Igraci(ime, prezime, ekipa_id, br_medalja)
            VALUES(@ime, @prezime, @ekipa_id, @br_medalja)
            RETURN 0; -- Uspešno dodavanje igrača
        END
    END
END TRY
BEGIN CATCH
    RETURN @@ERROR;
END CATCH
GO
CREATE PROC Igraci_Update
@id int,
@ime nvarchar(20),
@prezime nvarchar(20),
@nazivDrzave nvarchar(100),
@nazivSporta nvarchar(100),
@br_medalja int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
    IF EXISTS (SELECT TOP 1 ime,prezime FROM Igraci
    WHERE id = @id )
    BEGIN
        DECLARE @ekipa_id INT
        SELECT @ekipa_id = Ekipa.id
        FROM Ekipa
        INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
        INNER JOIN Sport ON Ekipa.sport_id = Sport.id
        WHERE Drzava.naziv = @nazivDrzave AND Sport.naziv = @nazivSporta

        IF @ekipa_id IS NOT NULL
        BEGIN
            UPDATE Igraci  
            SET ime=@ime,prezime=@prezime,ekipa_id=@ekipa_id,br_medalja=@br_medalja    
            WHERE id=@id
            RETURN 0;
        END
        ELSE
        BEGIN
            RETURN -2; -- Ekipa ne postoji
        END
    END
    ELSE
    BEGIN
        RETURN -1; -- Igrac ne postoji
    END
END TRY
BEGIN CATCH
    RETURN @@ERROR;
END CATCH
go
Create Proc Igraci_Delete
@id int
as
Begin TRY
Delete from Igraci where id=@id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
EXEC Igraci_Insert 'Bogdan', 'Bogdanovic';
-- TRENER PROCEDURE
go
CREATE PROC Trener_Insert
@ime nvarchar(20),
@prezime nvarchar(20),
@nazivDrzave nvarchar(100),
@nazivSporta nvarchar(100),
@vrsta nvarchar(20)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
    IF EXISTS (SELECT TOP 1 ime, prezime FROM Igraci
                WHERE ime = @ime AND prezime = @prezime)
    BEGIN
        RETURN 1; -- Igrač već postoji
    END
    ELSE
    BEGIN
        DECLARE @ekipa_id INT
        SELECT @ekipa_id = Ekipa.id
        FROM Ekipa
        INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
        INNER JOIN Sport ON Ekipa.sport_id = Sport.id
        WHERE Drzava.naziv = @nazivDrzave AND Sport.naziv = @nazivSporta

        IF @ekipa_id IS NULL
        BEGIN
            RETURN -1; -- Ekipa ne postoji
        END
        ELSE
        BEGIN
            INSERT INTO Trener(ime, prezime, ekipa_id,vrsta)
            VALUES(@ime, @prezime, @ekipa_id,@vrsta)
            RETURN 0; -- Uspešno dodavanje igrača
        END
    END
END TRY
BEGIN CATCH
    RETURN @@ERROR;
END CATCH
GO
GO
Create PROC Trener_Update
@id int,
@ime nvarchar(20),
@prezime nvarchar(20),
@ekipa_id int,
@vrsta nvarchar(20)
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
	IF EXISTS (SELECT TOP 1 ime,prezime FROM Trener
	WHERE id = @id )

	BEGIN
	
	Update Trener  Set ime=@ime,prezime=@prezime,ekipa_id=@ekipa_id,vrsta=@vrsta    where id=@id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
GO
CREATE PROCEDURE Trener_Delete
@id int 
AS
BEGIN TRY
    DELETE FROM Trener WHERE id = @id 
    RETURN 0
END TRY
BEGIN CATCH
    RETURN @@ERROR;
END CATCH
GO
--SUDIJA PROCEDURE
go
CREATE PROC Sudija_Insert
@ime nvarchar(20),
@prezime nvarchar(20),
@email nvarchar(50),
@lozinka nvarchar(20),
@naziv_drzave nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
    DECLARE @drzava_id INT;
    SELECT @drzava_id = id FROM Drzava WHERE naziv = @naziv_drzave;
    IF EXISTS (SELECT TOP 1 ime, prezime,email, lozinka FROM Sudija
                WHERE ime = @ime AND prezime = @prezime AND email=@email AND lozinka=@lozinka)
    BEGIN
        RETURN 1; 
    END
    ELSE
    BEGIN
        Insert Into Sudija(ime, prezime, drzava_id,email,lozinka) 
        Values(@ime, @prezime, @drzava_id,@email,@lozinka);
        RETURN 0; 
    END
END TRY
BEGIN CATCH
    RETURN @@ERROR; 
END CATCH
go
go
CREATE PROC Sudija_Insert1
@email nvarchar(50),
@lozinka nvarchar(20)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
    IF EXISTS (SELECT TOP 1 email, lozinka FROM Sudija
                WHERE email=@email AND lozinka=@lozinka)
    BEGIN
        RETURN 1; 
    END
    ELSE
    BEGIN
        Insert Into Sudija(email,lozinka) 
        Values(@email,@lozinka);
        RETURN 0; 
    END
END TRY
BEGIN CATCH
    RETURN @@ERROR; 
END CATCH
go
GO
Create PROC Sudija_Update
@id int,
@ime nvarchar(20),
@prezime nvarchar(20),
@email nvarchar(50),
@lozinka nvarchar(20),
@drzava_id int
AS
SET LOCK_TIMEOUT 3000;

BEGIN TRY
	IF EXISTS (SELECT TOP 1 ime,prezime,email,lozinka FROM Sudija
	WHERE id = @id )

	BEGIN
	
	Update Sudija  Set ime=@ime,prezime=@prezime,drzava_id=@drzava_id,email=@email,lozinka=@lozinka   where id=@id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
CREATE PROCEDURE Sudija_Delete
@ime_prezime nvarchar(50) 
AS
BEGIN TRY
    DECLARE @ime nvarchar(20)
    DECLARE @prezime nvarchar(20)
    SET @ime = LEFT(@ime_prezime, CHARINDEX(' ', @ime_prezime) - 1)
    SET @prezime = SUBSTRING(@ime_prezime, CHARINDEX(' ', @ime_prezime) + 1, LEN(@ime_prezime) - CHARINDEX(' ', @ime_prezime))
    DELETE FROM Sudija WHERE ime = @ime AND prezime = @prezime

    RETURN 0
END TRY
BEGIN CATCH
    RETURN @@ERROR;
END CATCH
GO
GO
Create PROC dbo.Sudija_Email
@email nvarchar(50),
@lozinka nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 email FROM Sudija
	WHERE email = @email and lozinka=@lozinka)
	Begin
	RETURN 0
	end
	RETURN 1
END TRY
BEGIN CATCH
	RETURN @@error;
END CATCH
GO
GO
Create Proc Sve_Sudije
as
go
-- AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
exec Sudija_Insert @ime = 'Gera', @prezime='Alek', @email = 'gera.alek@prvabeogim.edu.rs', @lozinka = 'lozinka1',@naziv_drzave='Srbija';
exec Sudija_Delete @ime_prezime = 'Gera Alek';
EXEC Sve_Sudije;
-- EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
-- Ekipa - PROCEDURE
go
CREATE PROCEDURE Ekipa_Insert
@nazivDrzave NVARCHAR(100),
@nazivSporta NVARCHAR(100)
AS
BEGIN
    DECLARE @nazivEkipe NVARCHAR(200)
    SET @nazivEkipe = @nazivDrzave + '-' + @nazivSporta

    DECLARE @drzava_id INT
    SELECT @drzava_id = id FROM Drzava WHERE naziv = @nazivDrzave
    DECLARE @sport_id INT
    SELECT @sport_id = id FROM Sport WHERE naziv = @nazivSporta

    INSERT INTO Ekipa (drzava_id, sport_id, nazivDrzave, nazivSporta, nazivEkipe)
    VALUES (@drzava_id, @sport_id, @nazivDrzave, @nazivSporta, @nazivEkipe) 
END
GO
go
CREATE PROCEDURE Ekipa_Update
@id INT,
@noviNazivDrzave NVARCHAR(100),
@noviNazivSporta NVARCHAR(100)
AS
BEGIN
    DECLARE @noviNazivEkipe NVARCHAR(200)
    SET @noviNazivEkipe = @noviNazivDrzave + '-' + @noviNazivSporta

    DECLARE @drzava_id INT
    SELECT @drzava_id = id FROM Drzava WHERE naziv = @noviNazivDrzave
    DECLARE @sport_id INT
    SELECT @sport_id = id FROM Sport WHERE naziv = @noviNazivSporta

    UPDATE Ekipa
    SET drzava_id = @drzava_id, sport_id = @sport_id, nazivDrzave = @noviNazivDrzave, nazivSporta = @noviNazivSporta, nazivEkipe = @noviNazivEkipe
    WHERE id = @id
END
go
go
create PROCEDURE Ekipa_Delete
@id int
AS
BEGIN
    DELETE FROM Ekipa 
    WHERE id = @id
END
go
--Utakmica - PROCEDURE
go
CREATE PROCEDURE Utakmica_InsertPocetak
@nazivSporta NVARCHAR(100),
@faza INT
AS
BEGIN
    DECLARE @sport_id INT
    SELECT @sport_id = id FROM Sport WHERE naziv = @nazivSporta
    INSERT INTO Utakmica (faza)
    VALUES (@faza)
END
go
go
Create PROCEDURE Utakmica_Insert
@ekipa_id_1 INT,
@ekipa_id_2 INT,
@faza INT
AS
BEGIN
    INSERT INTO Utakmica (faza, ekipa_id_1, ekipa_id_2)
    VALUES (@faza, @ekipa_id_1, @ekipa_id_2)
END
go
go
CREATE PROCEDURE Utakmica_Update
@utakmica_id INT,
@rezultat1 INT,
@rezultat2 INT
AS
BEGIN
    UPDATE Utakmica
    SET reultat1 = @rezultat1,
        rezultat2 = @rezultat2,
        id_pobednika = CASE 
                            WHEN @rezultat1 > @rezultat2 THEN ekipa_id_1
                            WHEN @rezultat1 < @rezultat2 THEN ekipa_id_2
                            ELSE NULL
                        END
    WHERE id = @utakmica_id
END
go
go
CREATE PROCEDURE Utakmica_Delete
@utakmica_id INT
AS
BEGIN
    DELETE FROM Utakmica WHERE id = @utakmica_id
END
go
go
CREATE TRIGGER MoveWinnerToNextPhase
ON Utakmica
AFTER UPDATE
AS
BEGIN
    IF UPDATE(reultat1) OR UPDATE(rezultat2)
    BEGIN
        DECLARE @pobednikID INT
        DECLARE @faza INT
        SELECT @pobednikID = id_pobednika, @faza = faza FROM inserted
        DECLARE @sledecaFaza INT
        SET @sledecaFaza = @faza + 1
        DECLARE @sledecaUtakmicaID INT
        SELECT TOP 1 @sledecaUtakmicaID = id FROM Utakmica WHERE faza = @sledecaFaza AND (ekipa_id_1 IS NULL OR ekipa_id_2 IS NULL)
        IF @sledecaUtakmicaID IS NOT NULL
        BEGIN
            IF (SELECT ekipa_id_1 FROM Utakmica WHERE id = @sledecaUtakmicaID) IS NULL
            BEGIN
                UPDATE Utakmica SET ekipa_id_1 = @pobednikID WHERE id = @sledecaUtakmicaID
            END
            ELSE
            BEGIN
                UPDATE Utakmica SET ekipa_id_2 = @pobednikID WHERE id = @sledecaUtakmicaID
            END
        END
    END
END
go
-- Trka Procedure
go
CREATE PROCEDURE Trka_InsertPocetak
@nazivSporta NVARCHAR(100),
@faza INT
AS
BEGIN
    DECLARE @sport_id INT
    SELECT @sport_id = id FROM Sport WHERE naziv = @nazivSporta
    INSERT INTO Trka  (faza)
    VALUES (@faza)
END
go
go
CREATE PROCEDURE Trka_Insert
@drzava1 NVARCHAR(100),
@drzava2 NVARCHAR(100),
@drzava3 NVARCHAR(100),
@drzava4 NVARCHAR(100),
@drzava5 NVARCHAR(100),
@drzava6 NVARCHAR(100),
@drzava7 NVARCHAR(100),
@drzava8 NVARCHAR(100),
@drzava9 NVARCHAR(100),
@drzava10 NVARCHAR(100),
@nazivSporta NVARCHAR(100),
@faza INT
AS
BEGIN
    DECLARE @idPrveEkipe INT
    DECLARE @idDrugeEkipe INT
	DECLARE @idTreceEkipe INT
	DECLARE @idCetvrteEkipe INT
	DECLARE @idPeteEkipe INT
	DECLARE @idSesteEkipe INT
	DECLARE @idSedmeEkipe INT
	DECLARE @idOsmeEkipe INT
	DECLARE @idDeveteEkipe INT
	DECLARE @idDeseteEkipe INT
    SELECT @idPrveEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava1 AND Sport.naziv = @nazivSporta
    SELECT @idDrugeEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava2 AND Sport.naziv = @nazivSporta
	SELECT @idTreceEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava3 AND Sport.naziv = @nazivSporta
	SELECT @idCetvrteEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava4 AND Sport.naziv = @nazivSporta
	SELECT @idPeteEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava5 AND Sport.naziv = @nazivSporta
	SELECT @idSesteEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava6 AND Sport.naziv = @nazivSporta
	SELECT @idSedmeEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava7 AND Sport.naziv = @nazivSporta
	SELECT @idOsmeEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
	 WHERE Drzava.naziv = @drzava8 AND Sport.naziv = @nazivSporta
	SELECT @idDeveteEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava9 AND Sport.naziv = @nazivSporta
	SELECT @idDeseteEkipe = Ekipa.id
    FROM Ekipa
    INNER JOIN Drzava ON Ekipa.drzava_id = Drzava.id
    INNER JOIN Sport ON Ekipa.sport_id = Sport.id
    WHERE Drzava.naziv = @drzava10 AND Sport.naziv = @nazivSporta
    INSERT INTO Trka (faza, ekipa_id_1, ekipa_id_2,ekipa_id_3, ekipa_id_4, ekipa_id_5, ekipa_id_6, ekipa_id_7, ekipa_id_8, ekipa_id_9, ekipa_id_10)
    VALUES (@faza, @idPrveEkipe, @idDrugeEkipe, @idTreceEkipe, @idCetvrteEkipe, @idPeteEkipe, @idSesteEkipe, @idSedmeEkipe, @idOsmeEkipe, @idDeveteEkipe, @idDeseteEkipe)
END
go
CREATE PROCEDURE Trka_Update
@trka_id INT,
@rezultat1 INT,
@rezultat2 INT,
@rezultat3 INT,
@rezultat4 INT,
@rezultat5 INT,
@rezultat6 INT,
@rezultat7 INT,
@rezultat8 INT,
@rezultat9 INT,
@rezultat10 INT
AS
BEGIN
    -- Provera da li postoji trka sa datim ID-jem
    IF EXISTS (SELECT * FROM Trka WHERE id = @trka_id)
    BEGIN
        -- Ažuriranje rezultata za datu trku
        UPDATE Trka
        SET rezultat1 = @rezultat1,
            rezultat2 = @rezultat2,
            rezultat3 = @rezultat3,
            rezultat4 = @rezultat4,
            rezultat5 = @rezultat5,
            rezultat6 = @rezultat6,
            rezultat7 = @rezultat7,
            rezultat8 = @rezultat8,
            rezultat9 = @rezultat9,
            rezultat10 = @rezultat10
        WHERE id = @trka_id;
        
        PRINT 'Rezultati trke su uspešno ažurirani.';
    END
    ELSE
    BEGIN
        PRINT 'Ne postoji trka sa datim ID-jem.';
    END
END

--TEST PROCEDURE
EXEC Sport_Insert @naziv = 'Fudbal', @br_faza = 3, @vrsta = 1;
EXEC Sport_Insert @naziv = 'Kosarka', @br_faza = 3, @vrsta = 1;
EXEC Sport_Update @id = 3, @naziv = 'Stoni tenis', @br_faza = 2, @vrsta = 1;
EXEC Sport_Delete @naziv = 'Fudbal';
EXEC Drzava_Insert @naziv = 'Srbija', @br_medalja = 10;
EXEC Drzava_Insert @naziv = 'Spanija', @br_medalja = 9;
EXEC Drzava_Delete @naziv = 'Srbija';
EXEC Igraci_Insert @ime = 'Novak', @prezime = 'Djokovic';
EXEC Igraci_Delete @ime_prezime = 'Novak Djokovic';
select * from Igraci;
EXEC Trener_Insert @ime = 'Zinedin', @prezime = 'Zidan', @vrsta = 'Fudbal';
EXEC Trener_Delete @ime_prezime = 'Zinedin Zidan';
select * from Trener;
EXEC Sudija_Insert @ime = 'Martin', @prezime = 'Vulic', @naziv_drzave = 'Hrvatska';
EXEC Sudija_Delete @ime_prezime = 'Martin Vulic';
select * from Sudija;
EXEC Ekipa_Insert @nazivDrzave='Srbija', @nazivSporta='Kosarka';
EXEC Ekipa_Insert @nazivDrzave='Spanija', @nazivSporta='Kosarka';
EXEC Utakmica_Insert @drzava1='Srbija',@drzava2='Spanija',@nazivSporta='Kosarka',@faza=1;
EXEC Utakmica_Delete	@utakmica_id = 1;
select * from Utakmica;