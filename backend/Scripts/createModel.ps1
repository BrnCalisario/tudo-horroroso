$dataSource = "SNCCHLAB01F17\TEW_SQLEXPRESS"
$initialSource = "TudoHorroroso"

$strconn = "Data Source=" + $args[0] + ";Initial Catalog=" + $args[1] + ";Integrated Security=True;TrustServerCertificate=true"
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold $strconn Microsoft.EntityFrameworkCore.SqlServer --force -o Model

// "Data Source=SNCCHLAB01F17\TEW_SQLEXPRESS;Initial Catalog=TudoHorroroso;Integrated Security=True;TrustServerCertificate=true"

// dotnet ef dbcontext scaffold "Data Source=SNCCH01LAB01F18\SQLEXPRESS;Initial Catalog=TudoHorroroso;Integrated Security=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --force -o Model

// do bruno
// dotnet ef dbcontext scaffold "Data Source=SNCCHLAB01F17\TEW_SQLEXPRESS;Initial Catalog=TudoHorroroso;Integrated Security=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --force -o Model