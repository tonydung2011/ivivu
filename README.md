Đồ Án CSDL nâng cao:

Đặc điểm của source code này:
 - sử dụng MVC .Net web để thực hiện
 - kết nối với database ms sql

Tài Liệu đã tham khảo và sử dụng:
 - kết nối với database thông qua Entity Framework: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

 - Tutorial dạng video: https://www.youtube.com/watch?v=E7Voso411Vs

 - Creating Form bằng HTML helper: 
    https://www.codeproject.com/Articles/1078491/Creating-Forms-in-ASP-NET-MVC
    http://www.tutorialsteacher.com/mvc/htmlhelper-textbox-
    
 - Authentication cơ bản: https://www.learnmvc.in/aspnet-mvc5-authentication-filters-example.php

 - Thuật toán Hash: đang tìm hiểu thêm - cần cân nhắc việc sinh Id của mỗi tuple dựa trên loại (phòng, khách sạn, khách hàng,...), tên - password (đối với khách hàng).

 - Id cũng có thể cân nhắc taọ trên nguyên tắc: <loại><ngày tháng năm giờ phút giây tạo>

Kết nối với Database:
 - chú ý tại file ivivu/Web.config: 

    <connectionStrings> 
        <add name="QLKS" providerName="System.Data.SqlClient" connectionString="Server=127.0.0.1; Database=QLKS; User Id=SA;Password=p@55w0rd_mssqlserver"/> 
    </connectionStrings> 
    
 chỉnh sủa connectionString thành:
  + Id=<ten dang nhap database cua ban>
  + Password=<password dang nhap database cua ban>

Thiết kế route và các nghiệp vụ cần tin học hoá:

 - <địc chỉ máy, mặc định = 127.0.0.1:8080>/QuanTri/<Controller>/<method name or View name>?<parametter list>
  + thêm/sửa/xoá/chi tiết 1/danh sách  hoá đơn
  + thêm/sửa/xoá/chi tiết 1/danh sách  Phòng: nghiệp vụ này cần thiết kế theo hướng thêm đại trà 1 loạt danh sách nhiều phòng
  + thêm/sửa/xoá/chi tiết 1/danh sách Loại phòng
  + thêm/sửa/xoá/chi tiết 1/danh sách Khách sạn
  + chi tiết 1/danh sách khách hàng

 - <địc chỉ máy, mặc định = 127.0.0.1:8080>/<Controller>/<method name or View name>?<parametter list>
  + thêm/sửa/xoá khách hàng
  + danh sách toàn bộ/chi tiết 1 phòng
  + danh sách toàn bộ/chi tiết 1 loại phòng
  + danh sách toàn bộ/chi tiết 1 khách sạn

Thiết kế source code:
 - thư mục DAL: lớp tương tác với DB
 - thư mục controller: logic server 
 - thư mục View: thiết kế front-end
 - thư mục script: file javascript chạy ở front-end
 - thư mục content: chứa CSS style file, các bạn nhận task về styling học về bootstrap để làm task đơn giản
 - thư mục lib: chứa những function có thể sử dụng rộng rãi (hash, so sánh, sort, ...)
 - thư mục filter: chứa lớp lọc authentication cho quản trị viên và khách hàng

Hiện có:
 - 127.0.0.1/Home/test_db: route test kết nối với DB
 - 127.0.0.1/KhachHang/dang_ky: route thêm một khách hàng mới
 - 127.0.0.1/KhachHang/dang_nhap: route khách hàng đăng nhập
 - 127.0.0.1/QuanTri/dang_nhap: route admin đăng nhập 

Cách đặt tên biến:
 - controller, Models: viết hoa đầu và viết hoa theo kiểu camel case. ví dụ: KhachHang, KhachSan
 - View, Method handle request: viết theo kiểu snake: ví dụ: dang_ky, post_dang_ky
 - biến, function bình thường: viết kiểu camel case. ví dụ: testDatabase, addUser

Làm sao để phối hợp source code:
 B1: bấm vào nút fork repo để copy về repo rieng6 của mình
 B2: tại gitBash trên máy tính: clone về máy
  vd:
	git clone git@github.com:HoangNgocDuc/ivivu.git
  or:
	git clone https://github.com/HoangNgocDuc/ivivu.git

 B3: thêm một remote tên là upstream với địa chỉ gốc là repo này:
	git remote add upstream https://github.com/tonydung2011/ivivu.git
hoặc:
	git remote add upstream git@github.com:tonydung2011/ivivu.git

 B4: checkout một branch riêng để làm việc trên đó:
	git checkout -b F22
	git pull upstream master
 => làm task có số tt 22
	git add <>
	git commit -m "nội dung thông báo cho commit này"
	git push
tại bước này nếu đây là lần push đầu tiên cho branch này. git sẽ thông báo lỗi. Dùng lệnh theo gợi ý của git
	git push --set-upstream upstream F22