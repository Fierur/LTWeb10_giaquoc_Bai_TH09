CREATE DATABASE QuanLyMuaHang;
GO
USE QuanLyMuaHang;
GO

-- Bảng Khách Hàng
CREATE TABLE tblKhachHang (
    MaKhachHang varCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(50),
    DiaChi NVARCHAR(100),
    SoDienThoai VARCHAR(15),
    MatKhau VARCHAR(50) -- thêm để đăng nhập
);

-- Bảng Sản Phẩm
CREATE TABLE tblSanPham (
    MaSanPham varCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(50),
    DonGia INT,
    HinhAnh VARCHAR(255),
    MoTa NVARCHAR(255),
    SoLuongTon INT
);

-- Bảng Hóa Đơn
CREATE TABLE tblHoaDon (
    MaHoaDon varCHAR(10) PRIMARY KEY,
    NgayHoaDon DATE,
    MaKH varCHAR(10),
    FOREIGN KEY (MaKH) REFERENCES tblKhachHang(MaKhachHang)
);

-- Bảng Chi Tiết Hóa Đơn
CREATE TABLE tblChiTiet (
    MaHD varCHAR(10),
    MaSP varCHAR(10),
    SoLuong INT,
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES tblHoaDon(MaHoaDon),
    FOREIGN KEY (MaSP) REFERENCES tblSanPham(MaSanPham)
);
INSERT INTO tblKhachHang VALUES
(101, N'Nguyễn Văn An', N'Hà Nội', '0912345678', '123'),
(102, N'Trần Thị Bình', N'Hải Phòng', '0988123456', '456'),
(103, N'Lê Minh Hoàng', N'Đà Nẵng', '0909988776', '789');
INSERT INTO tblSanPham VALUES
(1001, N'Điện thoại Samsung', 5000000, 'samsung.jpg', N'Hàng mới 100%', 20),
(1002, N'Laptop Dell', 15000000, 'dell.jpg', N'Hiệu năng cao', 10),
(1003, N'Chuột Logitech', 200000, 'logitech.jpg', N'Dùng văn phòng', 50);
INSERT INTO tblHoaDon VALUES
(10001, '2025-01-01', 101),
(10002, '2025-01-05', 102),
(10003, '2025-01-10', 103);
INSERT INTO tblChiTiet VALUES
(10001, 1001, 1),
(10002, 1002, 1),
(10003, 1003, 2);
-- Sửa SP01 thành sách
UPDATE tblSanPham
SET TenSP = N'Doraemon Tập 1',
    DonGia = 35000,
    HinhAnh = 'doraemon1.jpg',
    MoTa = N'Truyện tranh thiếu nhi nổi tiếng của Nhật Bản',
    SoLuongTon = 100
WHERE MaSanPham = 1001;


-- Sửa SP02 thành sách
UPDATE tblSanPham
SET TenSP = N'Truyện Cổ Tích Việt Nam',
    DonGia = 42000,
    HinhAnh = 'cotichvn.jpg',
    MoTa = N'Tổng hợp những câu chuyện dân gian Việt Nam ý nghĩa',
    SoLuongTon = 80
WHERE MaSanPham = 1002;


-- Sửa SP03 thành sách
UPDATE tblSanPham
SET TenSP = N'Truyện Kiều',
    DonGia = 55000,
    HinhAnh = 'truyenkieu.jpg',
    MoTa = N'Tác phẩm nổi tiếng của Nguyễn Du - Văn học Việt Nam',
    SoLuongTon = 60
WHERE MaSanPham = 1003;

select *from tblHoaDon
select *from tblChiTiet