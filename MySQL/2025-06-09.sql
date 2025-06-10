select first_name, last_name from actor
where first_name = "Penelope";

select first_name, last_name from actor
where first_name like "_nn%";

select first_name, last_name from actor
where first_name like "ma%" or first_name like "%a";

select title, description, rating, rental_rate from film
where rating = "G" and (rental_rate = 0.99 or rental_rate = 4.99);


-- LIVELLO 1

select * from film;

select title, length from film;

select title, rating from film where length > 120;

select * from customer where address_id = 312;

select * from payment where amount = 5.99;


-- LIVELLO 2

select * from film where length > 90 and rating = "PG";

select * from customer where address_id = 312 or address_id = 459;

select * from film where length < 80 or length > 180;

select * from film where rating != "R";

select * from payment where amount < 2 or amount > 5;


-- LIVELLO 3

select * from film where rating between "PG" and "R";

select * from film where rating like "%G%";

select * from film where title like "THE %";

select * from customer where first_name like "A%";

select * from rental where return_date is null;


-- LIVELLO 4

select * from film 
order by -length 
limit 10;

select * from customer 
order by -create_date 
limit 5;

select distinct rating from film;

select distinct amount from payment 
order by -amount;

select * from film 
where rating = "PG-13" 
order by -length 
limit 3;


-- LIVELLO 1

select title, length(title) as title_length from film;

select upper(first_name), upper(last_name) from customer;

select lower(title) from film 
limit 10;


-- LIVELLO 2

select concat(title, " (", rating, ")") as titolo_completo from film;

select left(title, 10) from film;

select right(title, 5) from film
limit 10;

select left(last_name, 3) from customer;

select substring(title, 5, locate(" ", title, 5) - 5) as second_word from film
where title like "the %";

select 
substring_index(title, " ", 1) as prima_parola, 
count(*) as occorrenze 
from film 
group by prima_parola 
order by occorrenze desc;

-- LIVELLO 3

select 
	first_name, 
	last_name, 
    create_date, 
    now() as curr_date 
from customer;

select 
	first_name, 
	last_name, 
	datediff(curdate(), create_date) as active_for 
from customer;

select 
	first_name, 
    last_name, 
    year(create_date) as create_year 
from customer;

select * from rental 
where year(rental_date) = 2005;

select 
	first_name, 
    last_name, 
    datediff(now(), create_date) as giorni_registrato 
from customer 
limit 10;
