CREATE TABLE IF NOT EXISTS sample.streamer_urls
(
    id integer NOT NULL DEFAULT nextval('sample.streamer_urls_id_seq'::regclass),
    site character varying COLLATE pg_catalog."default" NOT NULL,
    url character varying COLLATE pg_catalog."default" NOT NULL,
    streamer_id integer NOT NULL,
    CONSTRAINT streamer_urls_pkey PRIMARY KEY (id),
    CONSTRAINT streamer_urls_streamer_id_fkey FOREIGN KEY (streamer_id)
        REFERENCES sample.streamers (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS sample.streamer_urls
    OWNER to admin;

INSERT INTO 
    sample.streamers(site, url, streamer_id)
VALUES 
    ("YouTube", "https://www.youtube.com/@KaguraMea", 1),
    ("Twitter", "https://twitter.com/KaguraMea_VoV", 1);;