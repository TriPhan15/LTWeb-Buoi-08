create database ql_hanghoa
use ql_hanghoa
create table tacgia(
	matg char(10) not null primary key,
	tentg nvarchar(50),
	diachi nvarchar(50),
	tieusu nvarchar(50),
	dienthoai nchar(13)
)
create table chude(
	macd char(10) not null primary key,
	tenchude nvarchar(50)
)
create table nhaxuatban(
	manxb char(10) not null primary key,
	tennxh nvarchar(50),
	diachi nvarchar(50),
	dienthoai nchar(13)
)
create table sach (
	masach char(10) not null primary key,
	tensach nvarchar(50),
	giaban decimal(10,2),
	mota nvarchar(50),
	anhbia nvarchar(50),
	ngaycapnhat date,
	soluongton int,
	macd char(10),
	manxb char(10),
	constraint fk_sach_chude foreign key(macd) references chude(macd),
	constraint fk_sach_nxb foreign key(manxb) references nhaxuatban(manxb),
)
create table khachhang(
	makh char(10) not null primary key,
	hoten  nvarchar(50),
	taikhoan  nvarchar(50),
	matkhau  nvarchar(50),
	email  nvarchar(50),
	diachi  nvarchar(50),
	dienthoai nchar(13),
	ngaysinh date
)
create table dondathang (
	madonhang char(10) not null primary key,
	datthanhtoan nvarchar(50),
	tinhtrangdonhang nvarchar(50),
	ngaydat date,
	ngaygiao date,
	makh char(10),
	constraint fk_dondathang_khachhang foreign key(makh) references khachhang(makh)
)
create table vietsach(
	matg char(10),
	masach char(10),
	vaitro nvarchar(50),
	vitri nvarchar(50),
	constraint pk_vietsach primary key (matg,masach),
	constraint fk_vietsach_tacgia foreign key(matg) references tacgia(matg),
	constraint fk_vietsach_sach foreign key(masach) references sach(masach)

)
create table chitietdonhang(
	madonhang char(10),
	masach char(10),
	soluong int,
	dongia decimal(10,2),
	constraint pk_chitietdonhang primary key (madonhang,masach),
	constraint fk_chitietdonhang_dondathang foreign key(madonhang) references dondathang(madonhang),
	constraint fk_chitietdonhang_sach foreign key(masach) references sach(masach)
)
-- tacgia
INSERT INTO tacgia(matg, tentg, diachi, tieusu, dienthoai) VALUES
(N'TG001', N'Nguyễn Văn A', N'Hà Nội', N'Tác giả nổi tiếng', N'0123456789012'),
(N'TG002', N'Trần Thị B', N'Hồ Chí Minh', N'Tác giả trẻ', N'0987654321098'),
(N'TG003', N'Lê Văn C', N'Đà Nẵng', N'Tác giả kinh nghiệm', N'0912345678901');

-- chude
INSERT INTO chude(macd, tenchude) VALUES
(N'CD001', N'Tiểu thuyết'),
(N'CD002', N'Khoa học'),
(N'CD003', N'Tâm lý');

-- nhaxuatban
INSERT INTO nhaxuatban(manxb, tennxh, diachi, dienthoai) VALUES
(N'NXB01', N'Nhà xuất bản Trẻ', N'Hà Nội', N'02412345678'),
(N'NXB02', N'Nhà xuất bản Giáo dục', N'Hồ Chí Minh', N'02887654321'),
(N'NXB03', N'Nhà xuất bản Văn hóa', N'Đà Nẵng', N'02351234567');

-- sach
INSERT INTO sach(masach, tensach, giaban, mota, anhbia, ngaycapnhat, soluongton, macd, manxb) VALUES
(N'S001', N'Tiểu thuyết ABC', 120000.00, N'Cuốn tiểu thuyết hấp dẫn', N'abc.jpg', '2025-10-18', 100, N'CD001', N'NXB01'),
(N'S002', N'Khoa học vui', 150000.00, N'Sách khoa học dành cho trẻ em', N'khoahoc.png', '2025-09-10', 50, N'CD002', N'NXB02'),
(N'S003', N'Tâm lý học cơ bản', 130000.00, N'Sách tâm lý học dễ hiểu', N'tamly.jpg', '2025-08-05', 75, N'CD003', N'NXB03');
update sach
set anhbia=N'abc.jpg'
where masach=N'S001'
-- khachhang
INSERT INTO khachhang(makh, hoten, taikhoan, matkhau, email, diachi, dienthoai, ngaysinh) VALUES
(N'KH001', N'Nguyễn Văn X', N'nguyenvanx', N'pass123', N'nguyenvanx@example.com', N'Hà Nội', N'0123456789', '1990-01-01'),
(N'KH002', N'Trần Thị Y', N'tranthiy', N'pass456', N'tranthiy@example.com', N'Hồ Chí Minh', N'0987654321', '1992-05-10'),
(N'KH003', N'Lê Văn Z', N'levanz', N'pass789', N'levanz@example.com', N'Đà Nẵng', N'0912345678', '1985-12-25');

-- dondathang
INSERT INTO dondathang(madonhang, datthanhtoan, tinhtrangdonhang, ngaydat, ngaygiao, makh) VALUES
(N'DDH001', N'Chưa thanh toán', N'Đang xử lý', '2025-10-15', '2025-10-20', N'KH001'),
(N'DDH002', N'Đã thanh toán', N'Đã giao hàng', '2025-10-10', '2025-10-12', N'KH002'),
(N'DDH003', N'Chưa thanh toán', N'Đang xử lý', '2025-10-12', '2025-10-18', N'KH003');

-- vietsach
INSERT INTO vietsach(matg, masach, vaitro, vitri) VALUES
(N'TG001', N'S001', N'Tác giả chính', N'Chính'),
(N'TG002', N'S002', N'Đồng tác giả', N'Phụ'),
(N'TG003', N'S003', N'Tác giả chính', N'Chính');

-- chitietdonhang
INSERT INTO chitietdonhang(madonhang, masach, soluong, dongia) VALUES
(N'DDH001', N'S001', 2, 120000.00),
(N'DDH002', N'S002', 1, 150000.00),
(N'DDH003', N'S003', 3, 130000.00);

select * from sach
