# Guía de Implementación de Entity Framework Core

1. **Instalar los paquetes NuGet necesarios** (Entity Framework Core).

2. **Crear la cadena de conexión** en el archivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "StoreConnection": "Server=USHKAN\\THAIZIRLAP; Database=store; Trusted_Connection=True; Trust Server Certificate=True"
   }
   ```

3. **Crear el modelo de datos**:
   - Define las clases que representarán tus entidades en la base de datos.

4. **Configurar el contexto de la base de datos**:
   - Crea una clase que herede de `DbContext`.
   - Agrega `DbSet<T>` para cada entidad.
   ```csharp
   public class StoreContext : DbContext
   {
       public StoreContext(DbContextOptions<StoreContext> options): base(options) { }
   
       public DbSet<Users> Users { get; set; }
   }
   ```

5. **Agregar el DbContext a la configuración de servicios**:
   ```csharp
   builder.Services.AddDbContext<StoreContext>(options =>
   {
   options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
   });
   ```

6. **Hacer la migración inicial**:
   - En la consola de NuGet, ejecutar:
     ```
     Add-Migration InitDb
     ```

7. **Crear la base de datos en SQL Server**:
   - Crear manualmente la base de datos en SQL Server.
   - En la consola de NuGet, ejecutar:
     ```
     Update-Database
     ```

8. **Crear los DTOs necesarios** en la carpeta DTOs para mostrar, agregar y modificar las entidades.

9. **Crear los controladores**:
   - Implementar métodos para cada operación CRUD.

10. **Crear carpeta de Repository con su interfaz repository**:
    - Crear la interfaz y la clase `BeerRepository` que utilizará la interfaz `IRepository`.
    - `IRepository` será el molde de las consultas a la BD.
    - En `BeerRepository`, inyectar el contexto de la BD para hacer las solicitudes.
    - Crear los métodos en `BeerRepository` para agregar, eliminar, buscar data.

11. **Crear carpeta de Services que utilice el Repository**:
    - Los servicios se encargan de la lógica de negocio.
    - Crear los archivos `ICommonService.cs` y `BeerService.cs`.
    - `ICommonService.cs` es la interfaz de servicio que define los métodos del CRUD y utiliza generics.
    - Declaración del servicio:
      ```csharp
      builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeertInsertDto, BeerUpdateDto>, BeerService>("beerService");
      ```
    - Inyectar en el controlador.

## Diagrama de Inyección de Dependencias



```mermaid
graph LR A(Start)-->B{Is it true?} B--Yes-->C[End] B--No-->D[End]

## Nota:
El contexto de la BD se inyecta en repositorio para hacer la consulta a la BD.
El repositorio se inyecta en el servicio para utilizar los métodos del repositorio.
El servicio se inyecta en el controlador para usar la lógica de negocio en el endpoint.
