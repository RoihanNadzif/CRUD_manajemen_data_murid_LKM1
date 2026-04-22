DROP TABLE IF EXISTS nilai;
DROP TABLE IF EXISTS mata_pelajaran;
DROP TABLE IF EXISTS kelas;

-- TABEL 1: kelas
CREATE TABLE kelas (
    id_kelas   SERIAL PRIMARY KEY,
    nama       VARCHAR(100) NOT NULL,
    nis        VARCHAR(20)  NOT NULL UNIQUE,
    alamat     TEXT         NOT NULL,
    created_at TIMESTAMP    NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMP    NOT NULL DEFAULT NOW()
);

CREATE INDEX idx_kelas_nis  ON kelas(nis);
CREATE INDEX idx_kelas_nama ON kelas(nama);

-- TABEL 2: mata_pelajaran
CREATE TABLE mata_pelajaran (
    id_mapel   SERIAL PRIMARY KEY,
    nama_mapel VARCHAR(100) NOT NULL,
    created_at TIMESTAMP    NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMP    NOT NULL DEFAULT NOW()
);

-- TABEL 3: nilai 
CREATE TABLE nilai (
    id_nilai   SERIAL PRIMARY KEY,
    id_kelas   INT          NOT NULL,
    id_mapel   INT          NOT NULL,
    created_at TIMESTAMP    NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMP    NOT NULL DEFAULT NOW(),
    CONSTRAINT fk_nilai_kelas FOREIGN KEY (id_kelas) REFERENCES kelas(id_kelas) ON DELETE CASCADE,
    CONSTRAINT fk_nilai_mapel FOREIGN KEY (id_mapel) REFERENCES mata_pelajaran(id_mapel) ON DELETE CASCADE
);

CREATE INDEX idx_nilai_kelas ON nilai(id_kelas);
CREATE INDEX idx_nilai_mapel ON nilai(id_mapel);


INSERT INTO kelas (nama, nis, alamat) VALUES
('Tunggul Abdul Majid',   '242410102058', 'Jl. Patrang 67 Glenmore'),
('Rafi Hadianto Aribowo', '242410102006', 'Jl. Mastrip 69 Bandung'),
('Adelio Frisky',         '242410102064', 'Jl. Jawa 99 Surabaya'),
('Roihan Nadzif',         '242410102028', 'Jl. Jawa 12 Kalimantan'),
('Dimas Kurniawan',       '242410102084', 'Jl. Mastrip 10 Jember');

INSERT INTO mata_pelajaran (nama_mapel) VALUES
('PBM'),
('PPL'),
('ADPL'),
('RNS'),
('PAA');

INSERT INTO nilai (id_kelas, id_mapel) VALUES
(1, 1),
(1, 2),
(2, 1),
(3, 3),
(4, 5);


select * from kelas
select * from mata_pelajaran
select * from nilai