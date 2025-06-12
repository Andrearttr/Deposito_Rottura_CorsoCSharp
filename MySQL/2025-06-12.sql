create database ristorante;		-- crea un database
-- drop database ristorante;	-- elimina un database

create table utente (			-- crea una tabella nel database
	utente_id int,
    nome varchar(255),
    cognome varchar(255),
    email varchar(255),
    telefono varchar(15)		-- non usare int per numeri di telefono o simili perche sql tronca gli zero iniziali negli int
);

select * from utente;

create table film_rating (		-- crea una tabella a partire dalle colonne di un'altra
	select
		title,
		rating
	from
		film
);

drop table film_rating;

select * from film_rating;

-- drop table film_rating		-- elimina la tabella e tutti i contenuti
-- truncate table film_rating	-- elimina tutti i dati ma non la tabella

alter table utente
-- add password varchar(255)	-- aggiunge una colonna
-- drop column password 		-- elimina una colonna
	modify column telefono int
;

alter table utente
	drop column telefono,
	add telefono varchar(15)
;

select * from utente;

-- CONSTRAINTS
-- NOT NULL - non ci può essere un valore NULL;
-- UNIQUE - tutti i valori in una colonna sono differenti;
-- PRIMARY KEY - identifica in modo univoco ogni riga di una tabella;
-- FOREIGN KEY - identifica una chiave esterna;
-- CHECK - i valori in una colonna devono soddisfare una condizione;
-- DEFAULT - imposta un valore di default;
-- CREATE INDEX - crea un index er recu erare dati iù velocemente.

alter table utente
	modify column utente_id int primary key;
    
alter table utente
	modify column email varchar(255) unique not null;
    
alter table utente
	modify column telefono varchar(15) unique not null;

describe utente;				-- stampa una descrizione della tabella con le proprietà delle colonne

create table persona(
	persona_id int auto_increment primary key,
    nome varchar(100)
);

create table carta_identita(	-- rapporto one to one
	documento_id int auto_increment primary key,
    numero_documento int unique,
    persona_id int unique,		-- unique su foreign key assicura che non ci siano piu carte d'identità associate a una persona
	foreign key (persona_id) references persona(persona_id)	-- collega la foreign key alla primary key di persona
);

create table ordine(	-- rapporto many to one
	ordine_id int auto_increment primary key,
    persona_id int,		-- la foreign key non è unique quindi una persona può avere più ordini, ma ogni ordine ha una sola persona
    data_ordine date,
    foreign key (persona_id) references persona(persona_id)
);

create table attore(	-- rapporto many to many
	attore_id int auto_increment primary key,
    nome varchar(100)
);

create table film(
	film_id int auto_increment primary key,
    titolo varchar(100)
);

create table film_attore(		-- creiamo una cartella terza che accomuna le primary key delle due precedenti
	attore_id int,
    film_id int,
    primary key (attore_id, film_id),	-- la primary key è un'unione delle due per essere unica per ogni combo film/attore
    foreign key (attore_id) references attore(attore_id),
    foreign key (film_id) references film(film_id)
);

drop table utente;


-- -----------------------
-- ESERCIZIO RISTORANTE
-- -----------------------

create table address (
	address_id int auto_increment primary key,
    address varchar(100) unique not null,
    city varchar(100) default "napoli",
    postal_code varchar(10) not null
);

create table utente (
	utente_id int auto_increment primary key,
    nome varchar(100),
    cognome varchar(100),
    email varchar(100) unique not null,
    telefono varchar(15) unique not null,
    address_id int,
    foreign key (address_id) references address(address_id)
);

create table ordine (
	ordine_id int auto_increment primary key,
    utente_id int,
    data_ordine datetime default now(),
    foreign key (utente_id) references utente(utente_id)
);

create table ordine_piatto (
	ordine_id int,
    piatto_id int,
    primary key (ordine_id, piatto_id),
    foreign key (ordine_id) references ordine(ordine_id),
    foreign key (piatto_id) references piatto(piatto_id)
);
    
create table piatto (
	piatto_id int auto_increment primary key,
    piatto_nome varchar(100) unique not null,
    piatto_costo float not null
);

create table ingrediente (
	ingrediente_id int auto_increment primary key,
    ingrediente_nome varchar(100) unique not null
);

create table piatto_ingrediente (
	piatto_id int,
    ingrediente_id int,
    primary key (piatto_id, ingrediente_id),
    foreign key (piatto_id) references piatto(piatto_id),
    foreign key (ingrediente_id) references ingrediente(ingrediente_id)
);

create table pagamento (
	pagamento_id int auto_increment primary key,
    utente_id int,
    ordine_id int unique,
    amount float,
    foreign key (utente_id) references utente(utente_id),
    foreign key (ordine_id) references ordine(ordine_id)
);


-- esempi query

-- seleziona tutti i piatti contenenti l'ingrediente "pomodoro"
select
	p.piatto_nome,
    group_concat(i.ingrediente_nome separator ", ") as lista_ingredienti
from
	piatto p
join
	piatto_ingrediente pi on pi.piatto_id = p.piatto_id
join
	ingrediente i on i.ingrediente_id = pi.ingrediente_id
group by
	p.piatto_id
having
	lista_ingredienti like "%pomodoro%"
;

-- seleziona gli utenti che hanno una media di spesa per ordine maggiore della media
select
	concat(u.nome, " ", u.cognome) as utente,
    sum(p.amoutn) / count(distinct o.ordine_id) as spesa_media_per_ordine
from
	utente u
join
	pagamento p on p.utente_id = u.utente_id
join
	ordine o on o.utente_id = u.utente_id
    