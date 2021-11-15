-- [+] create + drop db : (only enable Once)
--CREATE DATABASE bai1_SQL;
--DROP DATABASE bai1_SQL;
-- [+] drop tables : (only enable to reset)
--DROP TABLE TBLKhoa;
--DROP TABLE TBLGiangVien;
--DROP TABLE TBLSinhVien;
--DROP TABLE TBLDeTai;
--DROP TABLE TBLHuongDan;

--Create 5 Table (Khoa, GiangVien, SinhVien, DeTai, HuongDan)
CREATE TABLE TBLKhoa(makhoa char(10), tenkhoa char(30), dienthoai char(10));
CREATE TABLE TBLGiangVien(magv int, hotengv char(30), luong decimal(5,2), makhoa char(10));
CREATE TABLE TBLSinhVien(masv int, hotensv char(30), makhoa char(10), namsinh int, quequan char(30));
CREATE TABLE TBLDeTai(madt char(10), tendt char(30), kinhphi int, NoiThucTap char(30));
CREATE TABLE TBLHuongDan(masv int, madt char(10), magv int, ketqua decimal(5,2));

--Insert Data into Tables
INSERT INTO TBLKhoa VALUES
('Geo','Dia ly',3855413),
('Math','Toan hoc',3855411),
('Bio','Cong nghe sinh hoc',3855412);

INSERT INTO TBLGiangVien VALUES 
(11,'Thanh Binh',700,'Geo'),
(12,'Thu Huong',500,'Math'),
(13,'Chu Vinh',650,'Geo'),
(14,'Le Thi Ly',500,'Bio'),
(15,'Tran Son',900,'Math');

--has nulls
INSERT INTO TBLSinhVien VALUES
(1,'Le Van Son','Bio',1990,'Nghe An'),
(2,'Nguyen Thi Mai','Geo',1990,'Thanh Hoa'),
(3,'Bui Xuan Duc','Math',1992,'Ha Noi'),
(4,'Nguyen Van Tung','Bio',null,'Ha Tinh'),
(5,'Le Khanh Linh','Bio',1989,'Ha Nam'),
(6,'Tran Khac Trong','Geo',1991,'Ninh Binh'),
(7,'Le Hong Van','Math',null,'null'),
(8,'Hoang Anh Duc','Bio',1992,'Nghe An');

INSERT INTO TBLDeTai VALUES
('Dt01','GIS',100,'Nghe An'),
('Dt02','ARC GIS',500,'Vinh Phuc'),
('Dt03','Spatial DB',100,'Ha Tinh'),
('Dt04','MAP',300,'Quang Binh');

--has nulls
INSERT INTO TBLHuongDan VALUES
(1,'DT01',13,8),
(2,'DT03',14,0),
(3,'DT03',12,10),
--missing col4
(5,'DT04',14,7),
(6,'DT01',13,null),
(7,'DT04',11,10),
(8,'DT03',15,6);

SELECT * FROM TBLKhoa;
SELECT * FROM TBLGiangVien;
SELECT * FROM TBLSinhVien;
SELECT * FROM TBLDeTai;
SELECT * FROM TBLHuongDan;