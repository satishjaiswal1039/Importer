--SQL command to derive the answer

--1. Select users whose id is either 3,2 or 4
-- Please return at least: all user fields

SELECT id, first_name, last_name,email,`status`,created from users WHERE id IN(3,2,4);


--2. Count how many basic and premium listings each active user has
-- Please return at least: first_name, last_name, basic, premium

SELECT u.first_name, u.last_name, sum(case when l.`status` = 2 then 1 else 0 END) basic, sum(case when l.`status` = 3 then 1 else 0 END) premium
FROM listings AS l INNER JOIN users AS u ON u.id=l.user_id WHERE u.`status`=2 GROUP BY l.user_id;



--3. Show the same count as before but only if they have at least ONE premium listing
-- Please return at least: first_name, last_name, basic, premium

SELECT u.first_name, u.last_name, sum(case when l.`status` = 2 then 1 else 0 END) basic, sum(case when l.`status` = 3 then 1 else 0 END) premium
FROM listings AS l INNER JOIN users AS u ON u.id=l.user_id WHERE u.`status`=2 GROUP BY l.user_id HAVING premium > 0


--4. How much revenue has each active vendor made in 2013
-- Please return at least: first_name, last_name, currency, revenue

SELECT u.first_name, u.last_name, c.currency, SUM(c.price) AS revenue FROM clicks AS c
INNER JOIN listings AS l ON c.listing_id=l.id
INNER JOIN users AS u ON u.id=l.user_id
WHERE u.`status`=2 AND  EXTRACT(YEAR FROM c.created) =2013
GROUP BY l.user_id, c.currency;


--5. Insert a new click for listing id 3, at $4.00
-- Find out the id of this new click. Please return at least: id

INSERT INTO clicks (listing_id,price,currency,created ) VALUES (3,4,'USD', NOW()); SELECT LAST_INSERT_ID() AS id_value;

--6. Show listings that have not received a click in 2013
-- Please return at least: listing_name

SELECT DISTINCT l.NAME listing_name FROM listings AS l 
LEFT JOIN clicks  AS c ON c.listing_id=l.id 
WHERE EXTRACT(YEAR FROM c.created) !=2013;


--7. For each year show number of listings clicked and number of vendors who owned these listings
-- Please return at least: date, total_listings_clicked, total_vendors_affected

SELECT EXTRACT(YEAR FROM c.created) `DATE`, COUNT(c.listing_id) total_listing_clicked, COUNT(DISTINCT l.user_id) total_venders_affected FROM listings AS l
INNER JOIN clicks AS c ON c.listing_id=l.id GROUP BY `DATE`;


--8. Return a comma separated string of listing names for all active vendors
-- Please return at least: first_name, last_name, listing_names

SELECT u.first_name, u.last_name , GROUP_CONCAT(l.NAME) listing_names FROM  listings AS l 
INNER JOIN users AS u ON u.id=l.user_id WHERE u.`status`=2 GROUP BY u.id;