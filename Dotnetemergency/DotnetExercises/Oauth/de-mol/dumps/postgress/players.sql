CREATE TABLE public.app_players
(
	id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    name character varying(100) COLLATE pg_catalog."default",
    age integer,
    gender character varying(1) COLLATE pg_catalog."default",
    profession character varying(255) COLLATE pg_catalog."default",
    photo character varying(120) COLLATE pg_catalog."default",
    CONSTRAINT app_players_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)

INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('salim', 1, 28, 'm', 'shopmanager bioscoop', 'salim.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('els', 2, 51, 'v', 'lerares', 'els.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('bart', 3, 43, 'm', 'advocaat', 'bart.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('laure', 4, 46, 'v', 'management assistant', 'laure.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('dorien', 5, 27, 'v', 'sauna uitbaatster', 'dorien.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('alina', 6, 20, 'v', 'studente logopedie', 'alina.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('jolien', 7, 26, 'v', 'bankbediende', 'jolien.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('christian', 8, 26, 'm', 'consultant', 'christian.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('gilles', 9, 29, 'm', 'horeca uitbater', 'gilles.jpg');
INSERT INTO public.app_players (name, id, age, gender, profession, photo) OVERRIDING SYSTEM VALUE VALUES ('bruno', 10, 50, 'm', 'technisch directeur', 'bruno.jpg');
SELECT pg_catalog.setval('public.app_players_id_seq', 10, true);