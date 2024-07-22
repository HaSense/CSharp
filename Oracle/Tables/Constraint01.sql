-- Departments 테이블 생성
CREATE TABLE Departments (
    DepartmentID NUMBER PRIMARY KEY,
    DepartmentName VARCHAR2(50) NOT NULL
);

-- Employees 테이블 생성
CREATE TABLE Employees (
    EmployeeID NUMBER PRIMARY KEY,
    EmployeeName VARCHAR2(50) NOT NULL,
    DepartmentID NUMBER,
    CONSTRAINT fk_Department
        FOREIGN KEY (DepartmentID)
        REFERENCES Departments(DepartmentID)
        ON DELETE CASCADE
);
-- Departments 테이블에 데이터 입력
INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES (1, '인사부');

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES (2, '재무부');

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES (3, '기술부');

-- Employees 테이블에 데이터 입력
INSERT INTO Employees (EmployeeID, EmployeeName, DepartmentID)
VALUES (1, '홍길동', 1);

INSERT INTO Employees (EmployeeID, EmployeeName, DepartmentID)
VALUES (2, '김철수', 2);

INSERT INTO Employees (EmployeeID, EmployeeName, DepartmentID)
VALUES (3, '이영희', 3);

INSERT INTO Employees (EmployeeID, EmployeeName, DepartmentID)
VALUES (4, '박민수', 1);

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
    StudentID NUMBER PRIMARY KEY,
    StudentName VARCHAR2(50) NOT NULL
);

-- Courses 테이블 생성
CREATE TABLE Courses (
    CourseID NUMBER PRIMARY KEY,
    CourseName VARCHAR2(50) NOT NULL
);

-- Enrollments 테이블 생성
CREATE TABLE Enrollments (
    EnrollmentID NUMBER PRIMARY KEY,
    StudentID NUMBER,
    CourseID NUMBER,
    CONSTRAINT fk_Student
        FOREIGN KEY (StudentID)
        REFERENCES Students(StudentID)
        ON DELETE CASCADE,
    CONSTRAINT fk_Course
        FOREIGN KEY (CourseID)
        REFERENCES Courses(CourseID)
        ON DELETE CASCADE
);


-- Students 테이블에 데이터 입력
INSERT INTO Students (StudentID, StudentName)
VALUES (1, '김철수');

INSERT INTO Students (StudentID, StudentName)
VALUES (2, '이영희');

INSERT INTO Students (StudentID, StudentName)
VALUES (3, '박민수');

-- Courses 테이블에 데이터 입력
INSERT INTO Courses (CourseID, CourseName)
VALUES (1, '수학');

INSERT INTO Courses (CourseID, CourseName)
VALUES (2, '영어');

INSERT INTO Courses (CourseID, CourseName)
VALUES (3, '과학');

-- Enrollments 테이블에 데이터 입력
INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID)
VALUES (1, 1, 1);

INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID)
VALUES (2, 1, 2);

INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID)
VALUES (3, 2, 2);

INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID)
VALUES (4, 3, 3);


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
    CategoryID NUMBER PRIMARY KEY,
    CategoryName VARCHAR2(50) NOT NULL
);

-- Products 테이블 생성
CREATE TABLE Products (
    ProductID NUMBER PRIMARY KEY,
    ProductName VARCHAR2(100) NOT NULL,
    Price NUMBER(10, 2) NOT NULL,
    CategoryID NUMBER,
    CONSTRAINT fk_Category
        FOREIGN KEY (CategoryID)
        REFERENCES Categories(CategoryID)
        ON DELETE CASCADE
);

-- Categories 테이블에 데이터 입력
INSERT INTO Categories (CategoryID, CategoryName)
VALUES (1, '전자제품');

INSERT INTO Categories (CategoryID, CategoryName)
VALUES (2, '가구');

INSERT INTO Categories (CategoryID, CategoryName)
VALUES (3, '의류');

-- Products 테이블에 데이터 입력
INSERT INTO Products (ProductID, ProductName, Price, CategoryID)
VALUES (1, '스마트폰', 799.99, 1);

INSERT INTO Products (ProductID, ProductName, Price, CategoryID)
VALUES (2, '노트북', 1299.99, 1);

INSERT INTO Products (ProductID, ProductName, Price, CategoryID)
VALUES (3, '소파', 499.99, 2);

INSERT INTO Products (ProductID, ProductName, Price, CategoryID)
VALUES (4, '셔츠', 29.99, 3);


-- CategoryID가 1인 카테고리 삭제
DELETE FROM Categories
WHERE CategoryID = 1;

-- Categories 테이블 확인
SELECT * FROM Categories;

-- Products 테이블 확인
SELECT * FROM Products;

