# StudyCafeManagement


## 프로젝트 소개
본 프로젝트는 스터디카페를 운영하는 프랜차이즈 회사에서 여러 가맹점에게 배포할 수 있는 프로그램입니다. 해당 프로그램은 **.NET 프레임워크의 플랫폼 독립적 장점**을 살려 감압식 터치스크린을 이용한 무인 키오스크에 프로그램을 설치 후 사용하게 됩니다. 프로그램은 스터디카페 사용자가 사용할 수 있는 UI가 있고, 카페를 운영하고 있는 점주가 사용할 수 있는 UI로 나뉘어져 있습니다. 본 프로그램을 이용하여 고객은 무인 키오스크를 이용해 스터디카페 좌석을 골라서 이용할 수 있고, 점주는 가격 설정 및 매출 조회를 할 수 있습니다.

## 시스템 기능도
<img width="939" alt="스크린샷 2021-01-04 오후 4 51 31" src="https://user-images.githubusercontent.com/45731301/103513025-214dfd00-4ead-11eb-92f1-07fb35b8d36b.png">

## 사용자 요구 분석
![image02](https://user-images.githubusercontent.com/45731301/103510960-7daf1d80-4ea9-11eb-8942-00d16a2ca42b.png)
![image03](https://user-images.githubusercontent.com/45731301/103510962-7e47b400-4ea9-11eb-96ee-531d9eb99819.png)

## 데이터베이스 ERD (Oracle 11g)
<img width="1525" alt="스크린샷 2021-01-04 오후 4 45 21" src="https://user-images.githubusercontent.com/45731301/103512587-53ab2a80-4eac-11eb-8638-6cb0ba5e220a.png">

## 주요 기능
### 로그인 (AdminLogin.cs)
![image05](https://user-images.githubusercontent.com/45731301/103510968-7f78e100-4ea9-11eb-9f78-92da8a2c4a42.png)
지점의 아이디와 비밀번호로 로그인할 수 있습니다. 하단의 관리자 모드를 체크하고 로그인시 점주를 위한 **관리자 모드**가 실행됩니다. 체크를 해제하고 로그인시 고객이 사용하게 될 키오스크 메인 화면이 실행됩니다.
### 관리자모드
#### 정보 관리
![image06](https://user-images.githubusercontent.com/45731301/103510969-7f78e100-4ea9-11eb-9743-1817dfc0972d.png)
점주가 로그인한 아이디와 비밀번호를 변경할 수 있고 지점 정보 및 요금제도 변경할 수 있습니다. 
#### 좌석 위치 변경
지점마다 좌석의 위치가 다를 수 있기 때문에 점주가 직접 마우스로 좌석의 위치를 변경하고 생성할 수 있습니다. (우측 ListView의 ContextMenu사용)
#### 매출 조회
날짜를 선택하면 우측에는 해당 날짜에 방문자를 알 수 있고 하단에는 해당 날짜의 총 매출금액을 알 수 있습니다. 
