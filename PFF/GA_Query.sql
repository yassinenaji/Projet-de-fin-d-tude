create database GesAbs
create table Groupe
(
   id_G int identity(1,1) primary key,
   nom_G varchar(20),
);

create table Stagiare
(   
   id_S int identity(1,1) primary key,
   nom_S varchar(20),
   prenom_S varchar(20),
   sexe_S varchar(20),
   id_G int foreign key references Groupe(id_G), 
);
create table matiere(
 id_M int identity(1,1) primary key,
 libelle varchar(30),   
);
create table Prof
(  id_P int identity(1,1) primary key,
   nom_P varchar(20),
   prenom_P varchar(20),
   sexe_P varchar(20),
   id_M int foreign key references matiere(id_M)
);
create table Absence(
    id_A  int identity(1,1) primary key,
    DateA date,
    type_Ab varchar(50),
    id_S int foreign key references Stagiare(id_S),
    id_P int foreign key references Prof(id_P),
    justf varchar(5),
);




