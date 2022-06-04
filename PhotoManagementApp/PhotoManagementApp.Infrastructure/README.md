### How to update EF context?

dotnet ef dbcontext scaffold "Data Source=.\SQLEXPRESS;Initial Catalog=PhotoManagementDb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities -c Context -f --schema dbo