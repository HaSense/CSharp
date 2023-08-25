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
