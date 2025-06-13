Create DATABASE libreria;

Create Table utente(
utente_id int Primary Key auto_increment,
nome varchar(100),
cognome varchar(100),
email varchar(100) UNIQUE NOT NULL,
telefono varchar(15) UNIQUE NOT NULL,
indirizzo_id int,
Foreign key (indirizzo_id) references indirizzo(indirizzo_id)
);

Create table indirizzo(
indirizzo_id int primary key auto_increment,
indirizzo varchar(100) unique Not null,
citta_id int unique,
postal_code varchar(10) Not null,
foreign key (citta_id) references citta(citta_id)
);

Create table citta(
citta_id int primary key auto_increment,
citta varchar(50) unique not null
);

Create table ordine(
ordine_id int primary key auto_increment,
utente_id int,
data_ordine datetime default NOW(),
inventario_id int,
foreign key (utente_id) references utente(utente_id),
foreign key (inventario_id) references inventario(inventario_id)
);

Create table inventario(
inventario_id int primary key auto_increment,
libro_id int,
foreign KEY (libro_id) references libro(libro_id)
);

Create table libro(
libro_id int primary key auto_increment,
titolo varchar(100) not null,
autore_id int,
genere_id int,
anno_uscita date not null
);

Create table autore_libro(
autore_id int,
libro_id int,
primary key(autore_id,libro_id),
foreign key (autore_id) references autore(autore_id),
foreign key (libro_id) references libro(libro_id)
);

Create table autore(
autore_id int primary key auto_increment,
nome varchar(100) not null,
cognome varchar(100) not null
);

Create table genere_libro(
genere_id int,
libro_id int,
primary key(genere_id,libro_id),
foreign key (genere_id) references genere(genere_id),
foreign key (libro_id) references libro(libro_id)
);

Create table genere(
genere_id int primary key auto_increment,
nome varchar(100) not null
);

Create table pagamento(
pagamento_id int primary key auto_increment,
utente_id int, 
ordine_id int unique,
amount float,
foreign key (utente_id) references utente(utente_id),
foreign key (ordine_id) references ordine(ordine_id)
);

alter table libro
add column prezzo float not null;

Insert into genere(genere.nome)
values ("Avventura"), ("Biografia"), ("Commedia"), ("Cucina"), ("Distopia"), ("Epico"), ("Fantasy"), ("Giallo"), ("Horror"), ("Istruzione"), ("Letteratura"), ("Mistero"), ("Narrativa"),
 ("Poesia"), ("Romanzo"), ("Saggistica"), ("Thriller"), ("Viaggio"), ("Western"), ("Young_Adult");
 
Select*from genere;

select * from libro;

alter table libro
modify column titolo varchar(100) unique not null;

select * from inventario;

delete from inventario where libro_id = 2 limit 1;

Select titolo, count(inventario.libro_id) as Quantita from libro join inventario on inventario.libro_id=libro.libro_id group by inventario_id;

Create table utente_password(
utente_id int unique,
username varchar(100) not null,
password_hash varchar(255) not null,
foreign key (utente_id) references utente(utente_id)
);

drop table utente_password;

alter table utente 
add column saldo float not null;

select * from citta