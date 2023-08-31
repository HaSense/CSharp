Validation Attributes
Built-in attributes
- [Required] : Validates that the field is not null

- [StringLength] : Validates that a string property value doesn't exceed a specified length limit

- [EmailAddress] : Validates that the property has email format

- [Range] : Validates that the property value falls within a specified range

- [RegularExpress] : Validates that the property value matches a specified regular expression

- [Compare] : Validates that two properties in a model match

- [Phone]

- [Url]: Validates that the property has a URL format

- [MinLength] : Min

- [MaxLength] : Max

- All these validation attributes are located in 
	- System.ComponentModel.DataAnnotations



**[Reg Express]**

**Email Regular Express Code**

^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$

Alpha-Numeric

[a-zA-Z0-9]

8자리 PassWord

(?=.*[a-zA-Z])(?=.*[0-9]).{8,25}$      

Strong password

(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z](?=.*[a-z]).*$

CNIC

^[0-9]{5}-[0-9]{7}-[0-9]$

영문 숫자 조합 8자리 이상
let reg = /^(?=.*[a-zA-Z])(?=.*[0-9]).{8,25}$/
영문 숫자 특수기호 조합 8자리 이상
let reg = /^(?=.*[a-zA-Z])(?=.*[!@#$%^*+=-])(?=.*[0-9]).{8,15}$/
해당 정규식은 다음과 같이 작동합니다.

^ : 문자열의 시작을 나타냅니다.
(?=.*\d) : 문자열에 숫자가 적어도 1개 이상 포함되어야 함을 나타냅니다.
(?=.*[a-zA-Z]) : 문자열에 영문자가 적어도 1개 이상 포함되어야 함을 나타냅니다.
(?=.*[\W_]) : 문자열에 특수문자가 적어도 1개 이상 포함되어야 함을 나타냅니다.
[a-zA-Z0-9\W_]{8,15} : 영문, 숫자, 특수문자 조합으로 이루어진 8~15자의 문자열을 나타냅니다.
$ : 문자열의 끝을 나타냅니다.
[!@#$%^*+=-] 이 부분이 특수문자까지 허용됩니다.
따라서, 해당 정규식은 영문, 숫자, 특수문자 조합으로 이루어진 8~15자의 문자열에 대해 검증을 수행합니다.
