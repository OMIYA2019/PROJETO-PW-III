create database bdClinOdonto;

Use bdClinOdonto;



create table tblogin(

usuario varchar(50) primary key,

senha varchar(10),

tipo int

);



create table tbPaciente(

codPac int primary key,

nomePac varchar(50),

telPac varchar(13)

);







create table tbDentista(

codDentista int primary key,

NomeDentista varchar(50),

TelDentista  varchar(20),

EmailDentista varchar(50)

);





create table tbAtendimento(

codAtendimento int primary key,

dataAtend varchar(8),

horaAtend varchar(8),

codDentista int references tbDentista(codDentista),

codPac int references tbPaciente(codPac)

);



insert into tblogin values('Omiya','628398',1);
insert into tblogin values('Mario','01091950',2);

select * from tblogin;

