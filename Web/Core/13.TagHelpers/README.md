Tag Helpers
- Tag helpers are basically special attributes provided by ASP.net Core
- Tag Helpers enable server-side components to participate in creating and rendering HTML elements in Views
- Tag helpers are a new feature and similar to HTML helpers (MVC5), which help us render HTML
- There are many built-in Tag Helpers for common tasks, such as creating forms, hyperlinks, loading assets etc
- Tag Helpers are authored in C#, and they target HTML elements based on the element name
- For example, the built-in LabelTagHelper can target the HTML <label> element when the LabelTaghelper attributes are applied
- Before start working with tag helpers, make sure you have included namespace for tag helpers in your ViewImports file
- Microsoft.AspNetCore.Mvc.TagHelpers
- Add this line in your ViewImports file
- @addTagHelper*, Microsoft.AspNetCore.Mvc.TagHelpers
- @addTagHelper is a directive
- we are going to implement hyperlinks using tag helpers.


Creating Form Using Tag Helper
- The Form Tag Helper
- The Form Action Tag Helper
- The Input Tag Helper
- The Textarea Tag Helper
- The Label Tag Helper
- The Validation Tag Helpers
- The Select Tag Helper
