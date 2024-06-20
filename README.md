### 1. Open with Visual Studio 클릭 후 pull 혹은 git clone

### 2. 도구 > NuGet 패키지 관리자 >  NuGet 패키지 관리자 콘솔 

### 3. NuGet 패키지 관리자 콘솔 창에 update-database 입력 후 build가 완료되면 실행한다. MSSQLLocalDB에 들어가서 MathoryServerDB가 잘 생성되었는지 확인한다.



> DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MathoryServerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

build fail이 뜰 경우 appsettings.json의 위의 MathoryServerDB 부분을 다른 이름으로 변경 후 
remove-migration으로 기존의 migration을 지운 뒤
add-migration migrationSample을 하고
update-database를 진행한다  

### 4. 서버를 빌드하면 아래와 같은 Swagger 창이 나타난다. 

![swagger.png](https://github.com/Ewha-capstone-ChoiBaeLee/MathoryServer/blob/master/swagger%20%EC%8B%A4%ED%96%89.png)

회원가입의 정보를 전달하는 POST를 실행하여 서버가 정상적으로 실행됨을 확인할 수 있다.

![swagger 실행.png](https://github.com/Ewha-capstone-ChoiBaeLee/MathoryServer/blob/master/swagger%20%EC%8B%A4%ED%96%89.png)

