-- Departments 테이블 생성
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(50) NOT NULL
);

-- Employees 테이블 생성
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50) NOT NULL,
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE
);

-- Departments 테이블에 데이터 입력
INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES (1, '인사부'), (2, '재무부'), (3, '기술부');

-- Employees 테이블에 데이터 입력
INSERT INTO Employees (EmployeeID, EmployeeName, DepartmentID)
VALUES (1, '홍길동', 1), (2, '김철수', 2), (3, '이영희', 3), (4, '박민수', 1);

-- DepartmentID가 1인 부서 삭제
DELETE FROM Departments
WHERE DepartmentID = 1;

-- Departments 테이블 확인
SELECT * FROM Departments;

-- Employees 테이블 확인
SELECT * FROM Employees;




--------------------------------------------------------------------------------------
-- Students 테이블 생성
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    StudentName VARCHAR(50) NOT NULL
);

-- Courses 테이블 생성
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(50) NOT NULL
);

-- Enrollments 테이블 생성
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE
);

-- Students 테이블에 데이터 입력
INSERT INTO Students (StudentID, StudentName)
VALUES (1, '김철수'), (2, '이영희'), (3, '박민수');

-- Courses 테이블에 데이터 입력
INSERT INTO Courses (CourseID, CourseName)
VALUES (1, '수학'), (2, '영어'), (3, '과학');

-- Enrollments 테이블에 데이터 입력
INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID)
VALUES (1, 1, 1), (2, 1, 2), (3, 2, 2), (4, 3, 3);

-- StudentID가 1인 학생 삭제
DELETE FROM Students
WHERE StudentID = 1;

-- Students 테이블 확인
SELECT * FROM Students;

-- Courses 테이블 확인
SELECT * FROM Courses;

-- Enrollments 테이블 확인
SELECT * FROM Enrollments;

---------------------------------------------------------------------------------------------
-- Categories 테이블 생성
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL
);

-- Products 테이블 생성
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE
);

-- Categories 테이블에 데이터 입력
INSERT INTO Categories (CategoryID, CategoryName)
VALUES (1, '전자제품'), (2, '가구'), (3, '의류');

-- Products 테이블에 데이터 입력
INSERT INTO Products (ProductID, ProductName, Price, CategoryID)
VALUES (1, '스마트폰', 799.99, 1), (2, '노트북', 1299.99, 1), (3, '소파', 499.99, 2), (4, '셔츠', 29.99, 3);

-- CategoryID가 1인 카테고리 삭제
DELETE FROM Categories
WHERE CategoryID = 1;

-- Categories 테이블 확인
SELECT * FROM Categories;

-- Products 테이블 확인
SELECT * FROM Products;


