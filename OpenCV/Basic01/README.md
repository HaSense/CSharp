1. C# 프로젝트 만들기 .Net Framework 윈도우 전용 선택

   - 아쉽게 .Net Core SDK 8.0 모듈이 OpenCV Sharp은 현재 없다.

   - Emgu 라이브러리를 사용하면 .Net Core로 사용할 수도 있지만 객체지향이 

     잘되어 있는 모듈이 OpenCVSharp이라 선정



2. Nuget Package 설치 

   Install-Package OpenCvSharp4 -Version 4.10.0.20240616 

   Install-Package OpenCvSharp4.runtime.win
