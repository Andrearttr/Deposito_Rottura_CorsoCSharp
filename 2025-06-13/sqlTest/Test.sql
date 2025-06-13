create database agenzia_viaggi;

create table paese (
paese_id int auto_increment primary key,
paese varchar(100) unique not null
);

create table citta (
citta_id int auto_increment primary key,
citta varchar(100) not null,
paese_id int not null,
foreign key(paese_id) references paese(paese_id)
);

create table luogo (
luogo_id int auto_increment primary key,
luogo varchar(100) not null,
citta_id int not null,
foreign key(citta_id) references citta(citta_id)
);

create table utente (
utente_id int auto_increment primary key,
nome varchar(100) not null,
cognome varchar(100) not null,
email varchar(100) not null,
username varchar(100) unique not null,
password varchar(100) not null
);

create table prenotazione (
prenotazione_id int auto_increment primary key,
utente_id int not null,
luogo_id int not null,
data date,
foreign key (utente_id) references utente(utente_id),
foreign key (luogo_id) references luogo(luogo_id)
);

create table admin (
admin_id int auto_increment primary key,
username varchar(100) unique not null,
password varchar(100) not null
);

insert into admin(username, password) values('admin', 'admin');


-- --------------------------
-- query di prova
-- --------------------------

select * from utente;

select
	p.paese,
    c.citta,
    l.luogo
from
	paese p
join
	citta c on c.paese_id = p.paese_id
join
	luogo l on l.citta_id = c.citta_id
;

select
	pr.prenotazione_id,
    pr.data,
	concat(u.nome, ' ', u.cognome) as nome_cognome,
    p.paese,
    c.citta,
    l.luogo
from
	paese p
join
	citta c on c.paese_id = p.paese_id
join
	luogo l on l.citta_id = c.citta_id
join
	prenotazione pr on pr.luogo_id = l.luogo_id
join
	utente u on u.utente_id = pr.utente_id
;

select 
	pr.prenotazione_id, 
    pr.data, concat(u.nome, ' ', u.cognome) as nome_cognome, 
    p.paese, 
    c.citta, 
    l.luogo
from 
	paese p 
join 
	citta c on c.paese_id = p.paese_id
join 
	luogo l on l.citta_id = c.citta_id
join
	prenotazione pr on pr.luogo_id = l.luogo_id
join
	utente u on u.utente_id = pr.utente_id
where
	u.utente_id = 2;