INSERT INTO actor (first_name, last_name, last_update)
VALUES ('Mario', 'Rossi', NOW());

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
JOIN film_actor fa ON a.actor_id = fa.actor_id
JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';	-- mario non ha partecipato a nessun film quindi non compare nell'intersezione tra le due tabelle

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a			-- left table = right table
LEFT JOIN film_actor fa ON a.actor_id = fa.actor_id
LEFT JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';	-- con left join viene preso anche se non ha corrispondenza nella tabella a destra o viceversa

-- --------------------------------
-- SUBQUERY
-- --------------------------------

select
	title,
    length
from
	film
where
	length > (	-- parentesi tonde per aprire una subquery
		select
			avg(length)
		from
			film
		)
;

select
	f.title,
	actor_count
from (
	select
		fa.film_id,
        count(*) as actor_count
	from
		film_actor fa
    group by
		fa.film_id
	) as film_actor_count
join
	film f on film_actor_count.film_id = f.film_id -- film_actor_count.film_id preso da select della subquery
order by
	actor_count desc
;

-- tutti i film che hanno un rental rate maggiore della media del rental rate stesso
select
	f.title,
    f.rental_rate
from
	film f
where
	f.rental_rate > (
		select
			avg(f.rental_rate)
		from
			film f
		)
;

-- Elenca i nomi e cognomi degli attori che hanno recitato in almeno un film della categoria "Action".
select
	a.first_name,
    a.last_name
from actor a
where actor_id in (	-- prende actor_id dalla subquery
	select
		fa.actor_id
	from
		film_actor fa
	join
		film f on f.film_id = fa.film_id
	join
		film_category fc on fc.film_id = f.film_id
	join
		category c on c.category_id = fc.category_id
	where
		c.name = "action"	-- la subquery prende solo gli attori con c.name action
    )
;

-- -------------------------
-- ESERCIZI SUBQUERY
-- -------------------------

-- Trova i titoli dei film che hanno lo stesso numero di attori del film "ACADEMY DINOSAUR".
select 
	f.title,
    count(a.actor_id) as actor_count
from 
	film f
join
	film_actor fa on f.film_id = fa.film_id
join
	actor a on a.actor_id = fa.actor_id
group by
	f.title
having
	actor_count = (
		select
			count(a.actor_id) as actor_count
		from
			film_actor fa
		join
			actor a on fa.actor_id = a.actor_id
		join
			film f on f.film_id = fa.film_id
		where
			f.title = "ACADEMY DINOSAUR"
		group by
			fa.film_id
		)
order by
	f.title
;

-- trova la traccia a partire dall'esercizio
-- trova le categorie che hanno un numero di film maggiore della media dei film per categoria
SELECT 
	c.name, 
    COUNT(fc.film_id) AS num_film
FROM 
	category c
JOIN 
	film_category fc ON c.category_id = fc.category_id
GROUP BY 
	c.category_id
HAVING 
	COUNT(fc.film_id) > (
		SELECT 
			AVG(film_count)
		FROM (
			SELECT 
				COUNT(*) AS film_count
			FROM film_category
			GROUP BY category_id
			) AS sub
		);

-- Trova i clienti che hanno speso più della media delle spese totali dei clienti.
select
	c.first_name,
    c.last_name,
    sum(p.amount) as total_spent
from
	customer c
join
	payment p on c.customer_id = p.customer_id
group by
	c.first_name,
    c.last_name
having
	total_spent > (
		select
			sum(p.amount) / count(distinct p.customer_id)
		from
			payment p
		)
order by
	total_spent desc
;

-- Trova i titoli dei film che non sono mai stati noleggiati.
select
	f.title
from
	film f
where
	film_id not in (
		select
			i.film_id
		from
			inventory i
		left join
			rental r on i.inventory_id = r.inventory_id
		where
			r.rental_date is not null
		)
;

-- -----------------------
-- traccia personale
-- -----------------------

-- 2 - trova gli attori i cui film sono stati noleggiati di meno della media dei noleggi per tutti gli attori
select
	a.first_name,
    a.last_name,
    count(r.rental_id) as rental_times
from
	actor a
join
	film_actor fa on fa.actor_id = a.actor_id
join
	film f on f.film_id = fa.film_id
join
	inventory i on i.film_id = f.film_id
join
	rental r on r.inventory_id = i.inventory_id
group by
	a.first_name,
    a.last_name
having
	rental_times < (
		select
			count(r.rental_id) / count(distinct a.actor_id) as average_rental_per_actor
		from
			actor a
		join
			film_actor fa on fa.actor_id = a.actor_id
		join
			film f on f.film_id = fa.film_id
		join
			inventory i on i.film_id = f.film_id
		join
			rental r on r.inventory_id = i.inventory_id
		)
order by
	rental_times asc
;


-- 1 - Trova i film che hanno la durata più lunga per ogni categoria NON FINITO
select
	f.title,
    f.length,
    c.name
from 
	film f
join
	film_category fc on fc.film_id = f.film_id
join
	category c on c.category_id = fc.category_id
where 
	f.length = (
		select
			max(f2.length)
		from
			film f2
		join
			film_category fc2 on fc2.film_id = f2.film_id
		where
			fc.category_id = fc2.category_id
		)
;


-- 3 - Trova il paese i cui i clienti noleggiano più film rispetto alla media degli altri paesi, in aggiunta anche il numero totale di clienti in ciascun paese.
select
	country.country,
    count(distinct customer.customer_id) as total_customers,
    count(rental.rental_id) as total_rentals
from
	country
join
	city on city.country_id = country.country_id
join
	address on address.city_id = city.city_id
join
	customer on customer.address_id = address.address_id
join
	rental on rental.customer_id = customer.customer_id
group by
	country.country
having 
	total_rentals > (
		select
			count(rental.rental_id) / count(distinct country.country_id)
		from
			country
		join
			city on city.country_id = country.country_id
		join
			address on address.city_id = city.city_id
		join
			customer on customer.address_id = address.address_id
		join
			rental on rental.customer_id = customer.customer_id
		)
order by
	total_rentals desc
;

-- 4 - Trova i titoli dei film e il loro rental_rate che hanno un costo di noleggio (rental_rate) superiore al rental_rate medio di tutti i film che appartengono alla stessa categoria di rating
select
	f.title,
    f.rental_rate,
    f.rating
from 
	film f
where
	f.rental_rate > (
		select
			avg(f2.rental_rate)
		from
			film f2
		where
			f.rating = f2.rating
		)
order by
	f.rating
;