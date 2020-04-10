# Dapper.SimpleRepository 

Dapper.SimpleRepository creates a Dapper repository that reduces CRUD operations to a single line of code. It also greatly simplifies executing CRUD operations with filters, executing full queries, and executing stored procedures. It supports Async and non-Async in Framework, Standard and Core.

### Quick Look:
(Scroll down for full working examples.)

Dapper.SimpleRepository can be used stronlgly or weakly typed. Create your repository by injecting the connection string and defining the type

```csharp
Dapper.SimpleRepository.IRepositoryStrong<type> repoStrong = new Dapper.SimpleRepository.Repository<myObject>("your connection string");
```

Or

```csharp
Dapper.SimpleRepository.IRepositoryGeneric repoGeneric = new Dapper.SimpleRepository.Repository("your connection string");
```


Then your data access is as easy as:

```csharp
repoStrong.Insert(myObject);    // Add a record to the database
repoStrong.Get(55);             // Get a sinlge item from the database by Id
repoStrong.Update(myObject);    // Update a record in the database
repoStrong.Delete(55);          // Delete a single object from the database by Id
```

Or

```csharp
repoGeneric.Insert<type>(myObject);    // Add a record to the database
repoGeneric.Get<type>(55);             // Get a sinlge item from the database by Id
repoGeneric.Update<type>(myObject);    // Update a record in the database
repoGeneric.Delete<type>(55);          // Delete a single object from the database by Id
```

Expand basic CRUD operations with filters:

```csharp
string where = "WHERE Name = @Name";
Dictionary<string, object> parms =   // define your parameters
repoStrong.Get(where, parms);
```

Quickly and easily execute custom queries with (optional) parameters:

```csharp
string query = "SELECT * FROM Pets WHERE Name = @Name";
Dictionary<string, object> parms =  // define your parameters
repoStrong.ExecuteQuery(query, parms);
```

Quickly and easily execute stored procedures with (optional) parameters:

```csharp
Dictionary<string, object> parms =  // define your parameters
repoStrong.ExecuteSP("StoredProcName", parms);
```

And more.

Creating and executing the SQL queries is handled for you by Dapper. Opening and closing database connections is handled for you by Dapper.SimpleRepository. All methods are available in both async and non-async. 

### Dependencies & Suggestions
-------
##### Dapper
https://github.com/StackExchange/Dapper

Dapper.SimpleRepository depends on Dapper, which is a Micro-ORM tool that is a light-weight alternative to larger ORM's such a Entity Framework.

##### Dapper.SimpleCrud
https://github.com/ericdc1/Dapper.SimpleCRUD

Dapper.SimpleRepository also depends on Dapper.SimpleCrud, which helps to simplify CRUD operations.

##### Dapper.SimpleCRUD.ModelGenerator
https://www.nuget.org/packages/Dapper.SimpleCRUD.ModelGenerator

I strongly recomend using this model generator to quickly and simply generate C# models from all of the tables in your database. It will make you happy.

### Why Dapper.SimpleRepository?
-------
While Dapper.SimpleCrud goes a long ways to greatly simplifying the code needed to use Dapper, I still craved an even EASIER and FASTER way to crank out my data access layers. And so in every project, I found myself creating a Resposity to take care of *all* of the busy work for me. 

The repository handles the tedious task of opening and closing the database connection every time you call the database, while at the same time exposing the CRUD, Query and Store Procedure methods you need to create the app.

### How It Works
-------
When using Dapper.SimpleRepository, you have two options.

1. Create a Respository instance that is pre-set to a specific type (or class) when creating the repository.
2. Create a Respository instance that has no type when created, and the type is specified when calling each method.

Assume we have the following `Pet` class which mirrors a table in our database:

```csharp
public class Pet
{
    public int PetId{ get; set; }
    public int PetTypeId { get; set; }
    public string Name { get; set; }
    public double? Weight { get; set; }
}
```
### Option 1: Create a Strongly Typed Repository
-------
Create an instance of `Dapper.SimpleRepository` and assign it the type of `Pet`. We'll call it `petRepo` and inject the required connection string.

```csharp
readonly Dapper.SimpleRepository.Repository<Pet> petRepo = new Dapper.SimpleRepository.Repository<Pet>(connectionString);
```
Now, using the strongly typed repository `petRepo`, we can easily and quickly perform any of the following CRUD actions.

### Basic CRUD with a Strongly Typed Repository:
-------
Because the type of `Pet` was specified when creating `petRepo`, we do not need to again define the type when calling each method.
###### Create:
```csharp
Pet pet = new Pet                       // Create a new pet and name him Fletcher
{
    PetTypeId = 5,
    Name = "Fletcher",
    Weight = 55.2
};
int newId = petRepo.Insert(pet);       // Insert Fletcher into the Pet table
```
In the example above, `newId` is the newly created `Pet.PetId`.

###### Read Single:
```csharp
Pet pet = PetRepo.Get(1);                   // Get Fletcher's unique record
```

###### Read All:
```csharp
IEnumerable<Pet> pets = petRepo.GetAll();   // Get all pets
```

###### Update:
```csharpa
pet.Weight = 60                            // Fletcher grew!
int rowsAffected = petRepo.Update(pet);    // Update Fletcher's record in the Pet table
```

###### Delete:
```csharp
int rowsAffected = petRepo.Delete(1);    // Delete Fletcher
```

### Option 2: Create a Non-Strongly Typed Repository
-------
Create another instance of `Dapper.SimpleRepository` that is NOT strongly typed and inject the connection string. We'll just call this one `repo`.

```csharp
readonly Dapper.SimpleRepository.Repository repo = new Dapper.SimpleRepository.Repository(connectionString);
```
### Basic CRUD with a Non-Strongly Typed Repository:
-------
Because the type of `Pet` was NOT specified when creating `repo`, we will specify the type when calling each method.
###### Create:
```csharp
Pet pet = new Pet                       // Create a new pet and name him Fletcher
{
    PetTypeId = 5,
    Name = "Fletcher",
    Weight = 55.2
};
int newId = repo.Insert<Pet>(pet);     // Insert Fletcher into the Pet table
```
In the example above, `newId` is the newly created `Pet.PetId`.

###### Read Single:
```csharp
Pet pet = repo.Get<Pet>(1);                   // Get Fletcher's unique record
```

###### Read All:
```csharp
IEnumerable<Pet> pets = repo.GetAll<Pet>();   // Get all pets
```

###### Update:
```csharpa
pet.Weight = 60                               // Fletcher grew!
int rowsAffected = repo.Update<Pet>(pet);     // Update Fletcher's record in the Pet table
```

###### Delete:
```csharp
int rowsAffected = repo.Delete<Pet>(1);     // Delete Fletcher
```

# Going Beyond Basic CRUD:
-------
In addition to the basic CRUD methods above, the following methods are also available. Each of these examples assumes that `petRepo` was created as strongly-typed to `Pet`. But, each can also be used with the non-strongly-typed option as well.

### SELECT Methods
-------
###### Select a Single Record with a WHERE Clause:
```csharp
string where = "WHERE Name = 'Fletcher'";
Pet pet = petRepo.Get(where);
```

###### Select a Single Record with a Parameterized WHERE Clause:  
```csharp
string where = "WHERE Name = @Name";
Dictionary<string, object> parms = new Dictionary<string, object>()
    {
        {"Name", "Fletcher"}
    };
Pet pet = petRepo.Get(where, parms);
```

###### Select a Single Record with a Parameterized Query:
```csharp
string query = "SELECT * FROM Pet WHERE PetId = @PetId";
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetId", 1}
};
Pet pet = petRepo.GetFromQuery(query, parms);
```
###### Select a List of Records with a Parameterized WHERE Clause:
```csharp
string where = "WHERE Name = @Name";
Dictionary<string, object> parms = new Dictionary<string, object>() 
{
    {"Name", "Fletcher"}
};
IEnumerable<Pet> pets = petRepo.GetList(where, parms);
```

###### Select a List of Records with a Parameterized Query:
```csharp
string query = "SELECT * FROM Pet WHERE PetId = @PetId";
Dictionary<string, object> parms = new Dictionary<string, object>()
{
     {"PetId", 1}
};
IEnumerable<Pet> pets = petRepo.GetListFromQuery(query, parms);
```

###### Select a Paged List of Records:
```csharp
string where = "WHERE PetTypeId = @PetTypeId";
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetTypeId", 3}
};
IEnumerable<Pet> pets = petRepo.GetListPaged(2, 10, where, "Name", parms);
```
The example above will return: Page 2; 10 results per page; ordered by "Name".
 
### DELETE Method
-------
###### Delete a Record with a Parameterized WHERE clause:
```csharp
string where = "WHERE PetTypeId = @PetTypeId";
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetTypeId", 3}
};
int rowsAffected = petRepo.Delete(where, parms);
```
The example above will delete all records where `PetTypeId` = 3. It will return the number of affected rows.

### EXECUTE QUERY Methods
-------

###### Execute a Parameterized Query with No Return Object
```csharp
string query = "UPDATE Pet SET Name = @Name WHERE PetId = @PetId";
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"Name", "Fluffy"},
    {"PetId", 5},
};
petRepo.ExecuteQuery(query, parms);
```

###### Execute a Parameterized Query with a Single Return Object
```csharp
string query = "SELECT * FROM Pet WHERE PetId = @PetId";
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetId", 5},
};
Pet pet = petRepo.ExecuteScalar(query, parms);
```

### STORED PROCEDURE Methods
-------
###### Execute a Parameterized Stored Procedure where no Return is Expected:
```csharp
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetId", 5},
    {"Name", "Fletcher"},
};
petRepo.ExecuteSP("SpName", parms);
```

###### Execute a Parameterized Stored Procedure where a Single Object is Expected in Return:
```csharp
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetId", 5},
    {"Name", "Fletcher"},
};
Pet pet = petRepo.ExecuteSPSingle("SpName", parms);
```

###### Execute a Parameterized Stored Procedure where a List of Objects is Expected in Return:
```csharp
Dictionary<string, object> parms = new Dictionary<string, object>()
{
    {"PetId", 5},
    {"Name", "Fletcher"},
};
IEnumerable<Pet> pets = petRepo.ExecuteSPList("spName", parms);
```
