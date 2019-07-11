# Dapper.AspNetCore

You don't need repository pattern if you choose dapper as data access library, just a DB connection factory is enough.

This repo let you using dapper in asp.net core project by easy way.

## How to use

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDapper("connectionString");
    ...
}
```

with Dependency injection in ASP.NET Core, injection the IUnitOfWork in your data access layer or domain layer directly.

```csharp
public class DemoService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public DemoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<dynamic>> QueryAsync()
    {
        return await _unitOfWork.Connection.QueryAsync("sql");
    }
    
    public async Task<IEnumerable<dynamic>> QueryWithTransactionAsync()
    {
        IEnumerable<dynamic> result; 
        _unitOfWork.ExecuteTransaction((trans) =>
                                       {
                                           trans.Connection.Execute("sql");
                                           result = trans.Connection.Query("sql");
                                       });
        return result;
    }
}
```

