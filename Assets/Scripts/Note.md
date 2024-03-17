Advantage
- Chia các class với các mục đính rõ ràng, dễ bảo trì và mở rộng hơn.
- Clear rõ ràng giữa phần UI và View và Game logic của project
- Sử dựng event để trigger các action khi item di chuyển giúp dễ debug và linh hoạt hơn 
- Sử dụng các constant string giúp giảm cache, tối ưu hiệu năng


Disadvantage
- Một số file code để trong folder chưa hợp lý lắm. 
    - Ví dụ Constants có thể chuyển đến thư mục Utilities để khi scripts này có thể được sử dụng rộng
    - eSwipe cũng có thể di chuyển đến thư mục Board
    - Sử dụng khá nhiều Instantiate và Destroy có thể ảnh hưởng đến hiệu năng