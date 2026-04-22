# 📚 Manajemen Data Murid Kelas - REST API

> **Nama:** Roihan Nadzif | **NIM:** 242410102028 | **Kelas:** PAA B  
> **Mata Kuliah:** Pemrograman Antarmuka Aplikasi

---

## 📝 Deskripsi Project

REST API untuk **manajemen data murid dalam suatu kelas** yang terhubung langsung ke database PostgreSQL. Dibangun menggunakan **ASP.NET Core C#** dengan driver **Npgsql** tanpa ORM, sehingga semua query SQL ditulis dan dikontrol secara langsung.

Domain dipilih karena sederhana, relevan dengan kehidupan sehari-hari, dan mudah dipahami relasi antar datanya.

---

## 🛠️ Teknologi yang Digunakan

| Komponen  | Teknologi             |
|-----------|-----------------------|
| Bahasa    | C#                    |
| Framework | ASP.NET Core (.NET 8) |
| Database  | PostgreSQL            |
| Driver DB | Npgsql (via NuGet)    |
| API Docs  | Swagger / OpenAPI     |
| IDE       | Visual Studio 2022    |

---

## 📁 Struktur Folder

```
PAA_CRUDKELAS_MODUL/
├── Controllers/
│   └── KelasController.cs      # Endpoint CRUD murid
├── Helper/
│   └── SqlDBHelper.cs          # Helper koneksi PostgreSQL
├── Models/
│   ├── Kelas.cs                # Model tabel kelas
│   └── KelasContext.cs         # Logika query SQL
├── database.sql                # DDL + sample data
├── appsettings.json            # Konfigurasi connection string
├── Program.cs                  # Entry point & konfigurasi app
└── README.md
```

---

## ⚙️ Langkah Instalasi & Cara Menjalankan

### Prasyarat
- Visual Studio 2022 (workload ASP.NET)
- .NET 8 SDK
- PostgreSQL + pgAdmin

### 1. Clone Repository
```bash
git clone https://github.com/RoihanNadzif/PAA_CRUDKELAS_MODUL.git
cd PAA_CRUDKELAS_MODUL
```

### 2. Install Dependency via NuGet Package Manager
- `Npgsql`
- `Swashbuckle.AspNetCore`

### 3. Konfigurasi `appsettings.json`
File sudah tersedia di repository:
```json
{
  "ConnectionStrings": {
    "koneksi": "Host=localhost; port=5433; database=modulapi1; username=postgres; password=roihan22"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
> Sesuaikan `port`, `username`, dan `password` jika berbeda dengan konfigurasi lokalmu.

### 4. Jalankan Project
Tekan **F5** di Visual Studio → browser otomatis membuka Swagger UI.

---
```

---

## 🗄️ Skema Database

### Relasi Antar Tabel
```
kelas (id_kelas) ──< nilai (id_kelas)
mata_pelajaran (id_mapel) ──< nilai (id_mapel)
```

### Tabel: `kelas`
| Kolom      | Tipe         | Keterangan        |
|------------|--------------|-------------------|
| id_kelas   | SERIAL (PK)  | Primary key       |
| nama       | VARCHAR(100) | Nama murid        |
| nis        | VARCHAR(20)  | Nomor Induk Siswa |
| alamat     | TEXT         | Alamat murid      |
| created_at | TIMESTAMP    | Waktu dibuat      |
| updated_at | TIMESTAMP    | Waktu diperbarui  |

### Tabel: `mata_pelajaran`
| Kolom      | Tipe         | Keterangan          |
|------------|--------------|---------------------|
| id_mapel   | SERIAL (PK)  | Primary key         |
| nama_mapel | VARCHAR(100) | Nama mata pelajaran |
| created_at | TIMESTAMP    | Waktu dibuat        |
| updated_at | TIMESTAMP    | Waktu diperbarui    |

### Tabel: `nilai`
| Kolom      | Tipe         | Keterangan                             |
|------------|--------------|----------------------------------------|
| id_nilai   | SERIAL (PK)  | Primary key                            |
| id_kelas   | INT (FK)     | Referensi ke `kelas.id_kelas`          |
| id_mapel   | INT (FK)     | Referensi ke `mata_pelajaran.id_mapel` |
| nilai      | DECIMAL(5,2) | Nilai murid (0–100)                    |
| created_at | TIMESTAMP    | Waktu dibuat                           |
| updated_at | TIMESTAMP    | Waktu diperbarui                       |

---

## 🔌 Daftar Endpoint

| Method | URL         | Keterangan                       | Status Sukses |
|--------|-------------|----------------------------------|---------------|
| GET    | /Kelas      | Ambil semua data murid           | 200           |
| GET    | /Kelas/{id} | Ambil murid berdasarkan id       | 200           |
| POST   | /Kelas      | Tambah murid baru                | 201           |
| PUT    | /Kelas/{id} | Update data murid berdasarkan id | 200           |
| DELETE | /Kelas/{id} | Hapus murid berdasarkan id       | 200           |

> Semua endpoint dapat diakses langsung tanpa autentikasi.

---

## 📦 Format Response

### Sukses (list)
```json
{ "status": "success", "total": 5, "data": [ ... ] }
```
### Sukses (data tunggal)
```json
{ "status": "success", "data": { ... } }
```
### Sukses (create / update / delete)
```json
{ "status": "success", "message": "Murid 'Roihan Nadzif' berhasil ditambahkan" }
```
### Error
```json
{ "status": "error", "message": "Murid dengan id 99 tidak ditemukan" }
```

---

## 🎬 Video Presentasi

> 📺 Link video: **https://youtu.be/6bQmsJttZAw?si=DwpGbwJq9LMTR-xW**

---

## 📄 Lisensi
Project ini dibuat untuk keperluan tugas akademik, Fakultas Ilmu Komputer, Universitas Jember.
