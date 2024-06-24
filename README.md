# CSharp

## 구조적 프로그래밍
1. 변수와 상수 개념
2. 제어문
3. 반복문 (2중 구조 이상은 연습이 요구됨)
4. 함수 (Call by Value, Call by Referrence)
5. 자료구조 ( 스택, 큐, 데크, 트리, 그래프 등 많은 자료구조가 있지만 기초는 배열만 잘하면 된다.)
* 소수의 인원으로 알고리즘적인 문제를 해결하고 수정하기에 용이한 프로그래밍


## 객체지향 프로그래밍 3요소

1. 캡슐화
2. 다형성(Polymorphism) 
   - 오버로딩(overloading)
   - 오버라이딩(overriding)
3. 상속(Inheritance)

C# 객체지향(OOP)을 위한 추가개념
1. 래퍼클래스(Wrapper Class) - Int32, Int64 등
2. 박싱(Boxing), 언박싱(UnBoxing)
3. 깊은복사(Deep Copy) 얇은복사(Shallow Copy)


----------------------------------------------------------------------------------------------
Web Programming Stack

Front --> UI/UX / ALL(Full Stack)
             HTML5, CSS, (JavaScript ==> jQuery)
             Angular.js(1, 2), React.js(FaceBook), Vue.js, Svelte.js
             Bootstrap, SemanticUI


BackEnd -->  CGI , Pearl, JSP, ASP, PHP, 
             EJB, Spring, Spring Boot   |  전자정부프레임워크
	     ASP, ASP.Net,  ASP.Net Core

-----------------------------------------------------------------------------------------------
             난이도 쉬움 ---> PHP => Lalabel(PHP 프레임워크)
                             JSP --> WebPage  => Servlet <-- Java
                                      
             Node.js ==> Next.js(Node.js 프레임워크)
-------------------------------------------------------------------------------------
WinForm C# --> 윈도우 프로그램
1. 윈도우 메시지 (메시지 프로퍼티)
- Hwnd : 메시지를 받는 윈도우의 핸들(Handle) 윈도우 객체를
            식별하고 관리하기 위해 O/S가 붙이는 번호
- Msg : 메시지 ID
- LParam : 메시지를 처리하는 정보(값)가 담겨 있습니다.
- WParam : 부가정보(조이스틱, 키보드, 마우스 값)
- Result :  메시지 처리에 대한 응답으로 O/S에 반환되는 값을 지정
              합니다.

2. 마우스 메시지 프로퍼티
 - Button : 마우스의 방향(왼쪽, 오른쪽, 위, 아래)를 나타냄
 - Clicks : 마우스 버튼의 클릭한 횟수를 나타냄, one클릭, 더블클릭..
 - Delta : 휠의 회전방향과 회전한 거리
 - X : X좌표
 - Y : Y좌표
