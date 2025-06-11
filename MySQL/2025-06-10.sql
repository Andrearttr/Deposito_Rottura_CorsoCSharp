-- --------------------------
-- ESERCIZIO 1
-- --------------------------

select 
	count(*) as numero_film 
from film;

select
	sum(length)/count(*) as durata_media
from film;

select
	min(length) as durata_minima,
    max(length) as durata_massima
from film;

select
	sum(amount) as somma_pagamenti
from payment;

/* LOCATE(substr, str)
Restituisce la posizione della prima occorrenza della sottostringa substr nella stringa str. Se non trova nulla, restituisce 0. */

SELECT title, LOCATE('DOG', title) AS posizione_dog
FROM film
WHERE LOCATE('DOG', title) > 0;

-- TROVARE DOVE SI TROVA IL CARATTERE "A" NEL NOME DEGLI ATTORI --
SELECT first_name, last_name, LOCATE('A', first_name) AS posizione_a
FROM actor
WHERE LOCATE('A', first_name) > 0;

-- SUBSTRING(string, start, length) // SUBSTRING(string FROM start FOR length) --

-- ESTRARRE I PRIMI 5 CARATTERI DEI TITOLI --
SELECT title, SUBSTRING(title, 1, 5) AS primi_cinque
FROM film;

-- Estrarre l'ultima parte del cognome --
SELECT last_name, SUBSTRING(last_name, LENGTH(last_name) - 2, 3) AS ultimi_tre
FROM actor
WHERE LENGTH(last_name) >= 3;

-- LOCATE + SUBSTRING – estrarre tutto dopo “AT” nel titolo --
SELECT
title,
SUBSTRING(title, LOCATE('AT ', title) + 3) AS dopo_at
FROM film
WHERE LOCATE('AT ', title) > 0;


-- Cerca l’ultimo spazio (con REVERSE) e ricava da lì la ultima parola. --
SELECT
title,
SUBSTRING(title, LENGTH(title) - LOCATE(' ', REVERSE(title)) + 2) AS ultima_parola
FROM film
WHERE title LIKE '% %';

-- ------------------------------
-- ESERCIIO 2
-- ------------------------------

select
	rating,
	count(*) as numero_per_rating
from film
group by rating;

select
	rating,
	sum(length)/count(*) as durata_media_per_rating
from film
group by rating;

select
	customer_id,
	count(*) as numero_pagamenti
from payment
group by customer_id;

select
	customer_id,
	sum(amount) as importo_totale
from payment
group by customer_id;

select
	length,
	count(*) as numero_per_durata
from film
group by length
order by length;

-- ---------------------------
-- ESERCIZIO 3
-- ---------------------------

select
	rating,
    avg(length) as durata_media
from film
group by rating
having durata_media > 100;

select
	customer_id,
	sum(amount) as importo_totale
from payment
group by customer_id
having importo_totale > 100;

select
	rating,
    count(*) as numero_film
from film
group by rating
having numero_film > 50;

select
	rating,
    round(avg(length), 1) as durata_media
from film
group by rating;

select
	customer_id,
    count(*) as numero_pagamenti
from payment
group by customer_id
having numero_pagamenti > 10;

-- -------------------------------
-- JOIN
-- -------------------------------

select * from film;

select * from language;

select film.title, language.name as language
from film
join language on film.language_id  = language.language_id;	-- bisogna dare una colonna da comparare per far coincidere i valori

select *
from customer
join store on customer.store_id = store.store_id;

select
	film.title,
    category.name as category
from film
join film_category on film.film_id = film_category.film_id				-- dato che film e category non hanno colonne in comune bisogna prima unire una tabella
join category on film_category.category_id = category.category_id;		-- intemedia che abbia una colonna in comune cosi da collegarle tramite quella

select
	customer.first_name,
    customer.last_name,
    address.address,
    city.city,
    country.country
from customer
join address on customer.address_id = address.address_id
join city on address.city_id = city.city_id
join country on city.country_id = country.country_id;

-- per ogni rental, quale staff e quale customer

select
	rental.rental_id,
    concat(customer.first_name, " ", customer.last_name) as customer,
    concat(staff.first_name, " ", staff.last_name) as staff
from rental
join staff on staff.staff_id = rental.staff_id
join customer on customer.customer_id = rental.customer_id
order by rental_id;

-- order by con join

select
	c.name as categoria,
	count(f.title) as numero_film
from 
	category c
join 
	film_category fc on fc.category_id = c.category_id	-- order by va sul from, non sui join
join 
	film f on f.film_id = fc.film_id
group by 
	c.name
;
    
-- conta i film fatti da ogni attore

select
	a.first_name,
    a.last_name,
    count(f.title) as numero_film
from
	actor a
join
	film_actor fa on fa.actor_id = a.actor_id
join
	film f on f.film_id = fa.film_id
group by
	a.actor_id
;

-- -----------------
-- ESERCIZI JOIN
-- -----------------

select
	film.title,
	category.name,
	group_concat(actor.first_name, " ", actor.last_name separator ", ") as actors
from 
	film
join 
	film_category on film_category.film_id = film.film_id
join
	category on category.category_id = film_category.category_id
join
	film_actor  on film_actor.film_id = film.film_id
join 
	actor on actor.actor_id = film_actor.actor_id
group by
	film.title,
    category.name
;

select
	customer.first_name,
    customer.last_name,
    count(rental.rental_id) as rental_times
from 
	customer
join
	rental on rental.customer_id = customer.customer_id
group by
	customer.customer_id
having
	rental_times > 5
;

select 
	film.title,
    count(rental.rental_id) as rental_times
from 
	film
join
	inventory on inventory.film_id = film.film_id
join
	rental on inventory.inventory_id = rental.inventory_id
group by
	film.title
having 
	rental_times = 0
;

-- --------------------------
-- ESERCIZI AVANZATI
-- --------------------------

select
	flm.title,
    cat.name as category,
    sum(pay.amount) as total_rental_revenue
from
	film flm
join
	film_category flmcat on flm.film_id = flmcat.film_id
join
	category cat on cat.category_id = flmcat.category_id
join
	inventory inv on flm.film_id = inv.film_id
join
	rental rnt on rnt.inventory_id = inv.inventory_id
join 
	payment pay on pay.rental_id = rnt.rental_id
group by
	flm.title,
    cat.name
order by
	total_rental_revenue desc
;

select
	concat(act.first_name, " ", act.last_name) as actor,
    group_concat(distinct cat.name separator ", ") as categories_played
from
	actor act
join 
	film_actor flmact on flmact.actor_id = act.actor_id
join
	film flm on flm.film_id = flmact.film_id
join
	film_category flmcat on flmcat.film_id = flm.film_id
join
	category cat on cat.category_id = flmcat.category_id
group by
	actor
having
	locate("action", categories_played) = 0
order by
	categories_played
;

select
	cat.name,
    count(act.actor_id) / count(distinct flm.film_id) as average_actors_per_film
from
	actor act
join 
	film_actor flmact on flmact.actor_id = act.actor_id
    
join
	film flm on flm.film_id = flmact.film_id
join
	film_category flmcat on flmcat.film_id = flm.film_id
join
	category cat on cat.category_id = flmcat.category_id
group by
	cat.name
order by
	average_actors_per_film desc
;

-- ------------------------
-- ESERCIZI AVANZATI 2
-- ------------------------

-- Clienti con più di 20 noleggi totali, ordinati per spesa totale decrescente
select
	cust.customer_id,
    cust.first_name,
    cust.last_name,
    count(rent.rental_id) as rentals,
    sum(pay.amount) as total_spending
from 
	customer cust
join
	rental rent on rent.customer_id = cust.customer_id
join
	payment pay on pay.rental_id = rent.rental_id
group by
	cust.customer_id,
    cust.first_name,
    cust.last_name
having
	rentals > 20
order by
	total_spending desc
;

-- Numero medio di noleggi per categoria di film
select
	cat.name,
    count(rent.rental_id) / count(distinct film.film_id) as average_rentals,
    count(rent.rental_id) as total_rentals
from 
	category cat
join
	film_category filmcat on cat.category_id = filmcat.category_id
join
	film on film.film_id = filmcat.film_id
join
	inventory inv on inv.film_id = film.film_id
join
	rental rent on rent.inventory_id = inv.inventory_id
group by
	cat.name
having 
	total_rentals > 50
order by
	average_rentals desc
;

-- Attori con più film a catalogo e noleggi totali
select
	act.first_name,
	act.last_name,
    count(distinct inv.film_id) as starring_in,
	count(distinct rent.rental_id) as rentals
from
	actor act
join
	film_actor filmact on filmact.actor_id = act.actor_id
join
	film on film.film_id = filmact.film_id
join
	inventory inv on inv.film_id = film.film_id
join
	rental rent on rent.inventory_id = inv.inventory_id
group by
	act.actor_id
having
	 starring_in >= 10
order by
	rentals desc
;

-- Categorie più "redditizie" per spesa totale media per film
select
	cat.name,
    sum(pay.amount) / count(distinct film.film_id) as revenue_per_film
from 
	category cat
join
	film_category filmcat on filmcat.category_id = cat.category_id
join
	film on film.film_id = filmcat.film_id
join
	inventory inv on inv.film_id = film.film_id
join
	rental rent on rent.inventory_id = inv.inventory_id
join
	payment pay on pay.rental_id = rent.rental_id
group by
	cat.name
order by
	revenue_per_film desc
;
