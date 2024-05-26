CREATE TABLE IF NOT EXISTS sample.streamers
(
    id integer NOT NULL DEFAULT nextval('sample.streamers_id_seq'::regclass),
    name character varying COLLATE pg_catalog."default" NOT NULL,
    explanation text COLLATE pg_catalog."default",
    CONSTRAINT streamers_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS sample.streamers
    OWNER to admin;

INSERT INTO 
    sample.streamers(name, explanation)
VALUES 
    ("神楽めあ", "ばーちゃるゆーちゅーばー！神楽めあです！");