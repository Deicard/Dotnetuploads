CREATE TABLE public.app_votes
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    player_id bigint NOT NULL,
    user_id text COLLATE pg_catalog."default" NOT NULL,
    episode integer NOT NULL,
    CONSTRAINT app_votes_pkey PRIMARY KEY (id),
    CONSTRAINT unique_vote UNIQUE (player_id, user_id, episode)
        INCLUDE(player_id, user_id, episode)
)
WITH (
    OIDS = FALSE
)