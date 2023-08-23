ViewBag

Passing Data From Controller To View In ASP.net Core 6
- You can use the following objects to pass data between controller and view
  1. ViewData
  2. ViewBag
  3. TempData
  4. Strongly Typed View
- ViewBag is also used to tansfer data from a controller a view
- The general syntax of ViewBag is as follows:
  ViewBag.<PropertyName> = <Value>;
  where,
  Property: Is a String value that represents a property of ViewBag
  Value: Is the value of the property of ViewBag, Value may be a String, object, list, array or a different type, such as int, char, float, double, DateTime etc
- ViewBag is a dynamic data type property of the base class of all the controllers, which is the ControllerBase class
- ViewBag is a dynamic data type, which internally uses ViewData to store values.
- ViewBag exists only for the current request and becomes null if the request is redirected.
- ViewBag is a dynamic property based on the dynamic features introduced in C# 4.0
- ViewBag does not require typecasting when you use complex data type.
- Note: Viewbag does not provide compile time error checking  For Example - if you mis-spell keys you wouldn't get any compile time errors. You get to know about the error only at runtime

TempData

- It passes data form a controller to a view
- TempData is used only for current or subsequent requests as it is a very short-lived instance.
- Redirectiong is the only case when users can rely on TempData
- When redirecting, current request is killed, and a new request is created on the server to serve the redirected view.
- Sharing data between the controller actions are done through the ASP.NET MVC TempData dictionary
- TempData is a Dictionary object derived form the TempDataDictionary class
- TempData stores data as key-value pairs
- TempData value must be type cast before use
- TempData allows passing data form the current request to the subsequent request duing request redirection.
- The general syntax of TempData is Follows:
  - TempData[Key] = <Value>
  - Key: is a string value to identify the object present in TempData
  - Value: Is the object present in TempData
- TempData in ASP.net MVC can be used to store temporary data which can be used in the subsequent request
- TempData will be cleared out after the completion of a subsequent request
- Call TempData.Keep() to keep all the values of TempData in a third request
