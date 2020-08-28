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