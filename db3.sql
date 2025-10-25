use Ql_NhanSu;
create table tbl_Department(
	DeptId int primary key,
	Name nvarchar(50)
)
create table tbl_Employee(
	Id int primary key,
	Name nvarchar(50),
	Gender nvarchar(10),
	City nvarchar(50),
	DeptId int,
	constraint fk_emp foreign key (DeptId) references tbl_Department(DeptId)
)
insert into tbl_Department values
(1,N'Khoa CNTT'),
(2,N'Khoa Ngoại Ngữ'),
(3,N'Khoa Tài Chính'),
(4,N'Khoa Thực Phẩm'),
(5,N'Khoa Đào Tạo');

insert into tbl_Employee values
(1,N'Nguyễn Hải Yến',N'Nữ',N'Đà Lạt',1),
(2,N'Trương Mạnh Hùng',N'Nam',N'TP.HCM',1),
(3,N'Đinh Duy Minh',N'Nam',N'Thái Bình',2),
(4,N'Ngô Thị Nguyệt',N'Nữ',N'Long An',2),
(5,N'Đào Minh Châu',N'Nữ',N'Bạc Liêu',3),
(14,N'Phan Thị Ngọc Mai',N'Nữ',N'Bến Tre',3),
(15,N'Trương Nguyễn Quỳnh Anh',N'Nữ',N'TP.HCM',4),
(16,N'Lê Thanh Liêm',N'Nữ',N'TP.HCM',5);

--DBeaver , Navicat : DB
go
create procedure sp_DemSoNV(@DeptId int)
as
begin
	select count(*)
	from tbl_Employee
	where DeptId=@DeptId
end
drop procedure sp_DemSoNV;
go