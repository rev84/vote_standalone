BEGIN TRANSACTION;
DROP TABLE IF EXISTS "users";
CREATE TABLE IF NOT EXISTS "users" (
	"id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"uuid"	TEXT UNIQUE,
	"name"	TEXT,
	"created_at"	TEXT
);
DROP TABLE IF EXISTS "subjects";
CREATE TABLE IF NOT EXISTS "subjects" (
	"user_id"	INTEGER,
	"title"	TEXT,
	"artist"	TEXT,
	"url"	TEXT,
	"comment"	TEXT,
	"created_at"	TEXT
);
DROP TABLE IF EXISTS "infos";
CREATE TABLE IF NOT EXISTS "infos" (
	"key"	TEXT NOT NULL,
	"value"	TEXT,
	PRIMARY KEY("key")
);
COMMIT;
