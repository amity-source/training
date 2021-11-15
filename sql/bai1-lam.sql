--1. Đưa ra thông tin gồm mã số, họ tên và tên khoa của tất cả các giảng viên

SELECT magv AS magv_1,hotengv,tenkhoa 
FROM TBLGiangVien
INNER JOIN TBLKhoa ON TBLGiangVien.makhoa = TBLKhoa.makhoa;


--2. Đưa ra thông tin gồm mã số, họ tên và tên khoa của các giảng viên của khoa ‘Dia ly’
SELECT magv,hotengv,tenkhoa 
FROM TBLGiangVien 
INNER JOIN TBLKhoa ON TBLGiangVien.makhoa = TBLKhoa.makhoa
WHERE tenkhoa = 'Dia ly';

--3. Cho biết số sinh viên của khoa ‘Cong nghe sinh hoc’
SELECT COUNT(masv) AS sv_sinhhoc
FROM TBLSinhVien
INNER JOIN TBLKhoa ON TBLSinhVien.makhoa = TBLKhoa.makhoa
WHERE tenkhoa = 'Cong nghe sinh hoc';

--4. Đưa ra danh sách gồm mã số, họ tên và tuổi của các sinh viên khoa ‘Toan hoc’

SELECT masv,hotensv,YEAR(GETDATE()) - namsinh AS tuoi
FROM TBLSinhVien
INNER JOIN TBLKhoa ON TBLSinhVien.makhoa = TBLKhoa.makhoa
WHERE tenkhoa = 'Toan hoc'; 

--5. Cho biết số giảng viên của khoa ‘Cong nghe sinh hoc’
SELECT COUNT(magv) AS gv_sinhhoc
FROM TBLGiangVien 
INNER JOIN TBLKhoa ON TBLGiangVien.makhoa = TBLKhoa.makhoa
WHERE tenkhoa = 'Cong nghe sinh hoc';

--6. Cho biết thông tin về sinh viên không tham gia thực tập

SELECT TBLSinhVien.* 
FROM TBLSinhVien
WHERE TBLSinhVien.masv 
NOT IN (SELECT TBLHuongDan.masv FROM TBLHuongDan);

--7. Đưa ra mã khoa, tên khoa và số giảng viên của mỗi khoa
  
SELECT TBLKhoa.tenkhoa,
TBLGiangVien.makhoa,
COUNT (magv) AS gv
FROM TBLGiangVien 
INNER JOIN TBLKhoa ON TBLGiangVien.makhoa = TBLKhoa.makhoa
GROUP BY TBLKhoa.tenkhoa,TBLGiangVien.makhoa ;

--8. Cho biết số điện thoại của khoa mà sinh viên có tên ‘Le Van Son’ đang theo học

SELECT dienthoai ,TBLKhoa.makhoa ,hotensv
FROM TBLHuongDan
INNER JOIN TBLSinhVien ON TBLHuongDan.masv = TBLSinhVien.masv 
INNER JOIN TBLKhoa ON TBLSinhVien.makhoa = TBLKhoa.makhoa
WHERE hotensv LIKE 'Le Van Son';