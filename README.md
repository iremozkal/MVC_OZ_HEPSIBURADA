## MVC_OZ_HEPSIBURADA

Creates a basic Ecommerce Structure with Category operations in Asp.Net MVC4.  
DATA Layer contains model entites. IdentityUser and IdentityRole classes from Microsoft.AspNet.Identity.EntityFramework have been used.  
DAL Layer contains Context, Mappings, Migrations, Repository and Unit Of Work structures. Code First Database approach is used. The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context. That way, when a unit of work is complete you can call the SaveChanges method on that instance of the context and be assured that all related changes will be coordinated. All that the class needs is a Save method and a property for each repository. Each repository property returns a repository instance that has been instantiated using the same database context instance as the other repository instances.    
IOC Layer contains Unity Container that is a lightweight, extensible dependency injection container.  
BLL Layer contains business services.   
UI Layer contains both general and admin sides of web application. Basic Add/Update/Delete operations on categories and export/import them to an excel file run successfully. Login and Register work with IdentityRole and IdentityUser classes from Microsoft.AspNet.Identity.EntityFramework.   

### Technologies  

+ Asp.Net Web Application with .Net Framework 4.5 
+ Entity Framework 6.4.4
+ Microsoft.Aspnet.Identity.Core  2.2.3
+ Microsoft.Aspnet.EntityFramework 2.2.3
+ Microsoft.Owin 4.1.1
+ Owin 1.0
+ Unity.MVC4 1.6.0.0
+ Unity 4.0.1
+ Bootstrap 4.5.3
+ Jquery 3.5.1
+ Microsoft.Office.Interop.Excel 15.0.4795.1000
+ Visual Studio 2012


### Usage

```python
PM> update-database 	# creates database for the first time and
                        # updates the database when code changes.
```
