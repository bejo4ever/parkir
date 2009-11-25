use parkir;
COMMIT;
ALTER TABLE tickets ADD COLUMN nopol VARCHAR(15) DEFAULT '' AFTER ticket_number;
COMMIT 