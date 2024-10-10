using Models;

ProgramaEducativo programa = new ProgramaEducativo();

// Crear asignaturas
Asignatura servidor = new Asignatura("Servidor", 6);
var cliente = new Asignatura("Cliente", 4);
Asignatura diseño = new("Diseño", 8);

// Añadir asignaturas 
programa.AñadirNuevaAsignatura(servidor);
programa.AñadirNuevaAsignatura(cliente);
programa.AñadirNuevaAsignatura(diseño);

//Visualizar asignaturas con sus créditos respectivos
programa.VisualizarAsignaturas();

// Crear estudiantes
var estudiante1 = new Estudiante("Vanessa Llorente");
Estudiante estudiante2 = new Estudiante("Alejandro Giménez");

// Añadir estudiantes al programa educativo
programa.AñadirEstudiante(estudiante1);
programa.AñadirEstudiante(estudiante2);

// Mostrar estudiantes
programa.MostrarEstudiantes();

// Asignar calificaciones
estudiante1.AñadirCalificacion(servidor, 9.5);
estudiante1.AñadirCalificacion(cliente, 8.0);
estudiante1.AñadirCalificacion(diseño, 9.0);

estudiante2.AñadirCalificacion(servidor, 7.5);
estudiante2.AñadirCalificacion(cliente, 8.5);

//Mostrar calificaciones
estudiante1.MostrarCalificaciones();
estudiante2.MostrarCalificaciones();

//Mostrar ranking estudiantes
programa.RankingEstudiantes();

//Mostrar estudiantes con riesgo de suspender
programa.EstudiantesRiesgoSuspender();

// Mostrar calificaciones de un estudiante específico
Estudiante estudianteSeleccionado = programa.ObtenerEstudiante("Vanessa Llorente");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}

// Mostrar calificaciones del segundo estudiante
estudianteSeleccionado = programa.ObtenerEstudiante("Alejandro Giménez");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}
