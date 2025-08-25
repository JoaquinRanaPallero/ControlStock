# ControlStock

Aplicación de escritorio en **C# / WinForms** para la gestión de artículos de un catálogo de comercio.  
Pensada de manera genérica, para que se adapte a distintos rubros y que los datos puedan ser consumidos por otros servicios (webs, e-commerce, apps, etc.).
Proyecto académico / de práctica en C#, orientado a arquitectura en capas y manejo de datos en SQL Server.

##  Funcionalidades
- Listado de artículos con DataGridView.
- Búsqueda y filtrado por distintos criterios.
- Alta, modificación y baja de artículos.
- Visualización de detalle de artículo (incluye imagen).
- Persistencia en base de datos SQL Server existente.

##  Arquitectura
- **Dominio**: Entidades (Articulo, Marca, Categoria).  
- **Datos**: Acceso a base de datos con ADO.NET.  
- **Negocio**: Lógica de negocio y validaciones.  
- **UI**: Interfaz gráfica con WinForms.

##  Requisitos
- .NET Framework (4.7.2 o superior recomendado).  
- SQL Server con la base `CATALOGO_DB` provista.  

##  Ejecución
1. Clonar el repositorio.  
2. Configurar la cadena de conexión en `App.config`.  
3. Compilar y ejecutar desde Visual Studio.  



