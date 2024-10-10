
namespace Models;

class ProgramaEducativo
{
    private List<Estudiante> estudiantes;
    private List<Asignatura> asignaturas;
    
    public ProgramaEducativo()
    {
        estudiantes = new List<Estudiante>();
        asignaturas = new List<Asignatura>();
    }

    public void AñadirEstudiante(Estudiante estudiante)
    {
        if (estudiantes.Exists(e => e.Nombre == estudiante.Nombre))
            {
                Console.WriteLine($"El estudiante {estudiante.Nombre} ya existe en el programa.");
            }
            else
            {
                // Añadir la asignatura a la lista global
                estudiantes.Add(estudiante);
                Console.WriteLine($"El estudiante {estudiante.Nombre} con ha sido añadido.");
            }
    }

    public void MostrarEstudiantes()
    {
        Console.WriteLine("\n--- Lista de Estudiantes ---");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"Estudiante: {estudiante.Nombre}");
        }
    }

    public Estudiante ObtenerEstudiante(string nombre)
    {
        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Nombre == nombre)
            {
                return estudiante;
            }
        }
        return null;
    }

    public List<Estudiante> BuscarEstudiantesPorNombre(string parteDelNombre)
    {
        List<Estudiante> resultados = estudiantes.FindAll(e => e.Nombre.ToLower().Contains(parteDelNombre.ToLower()));
        return resultados;
    }

    public void EliminarEstudiante(string nombre)
    {
        Estudiante estudiante = ObtenerEstudiante(nombre);
        if (estudiante != null)
        {
            estudiantes.Remove(estudiante);
            Console.WriteLine($"El estudiante {nombre} ha sido eliminado.");
        }
        else
        {
            Console.WriteLine($"El estudiante {nombre} no fue encontrado.");
        }
    }

    public double CalcularPromedioGlobal()
    {
        double sumaPromedios = 0;
        int contadorEstudiantes = 0;

        foreach (var estudiante in estudiantes)
        {
            sumaPromedios += estudiante.CalcularPromedio();
            contadorEstudiantes++;
        }


        return contadorEstudiantes > 0 ? sumaPromedios / contadorEstudiantes : 0;
    }

    public void GenerarReporteEstudiante(Estudiante estudiante)
    {
        Console.WriteLine($"\n--- Reporte para {estudiante.Nombre} ---");
        estudiante.MostrarCalificaciones();
        double promedio = estudiante.CalcularPromedio();
        Console.WriteLine($"Promedio final: {promedio:F2}");
    }

    public void AñadirNuevaAsignatura (Asignatura asignatura) {

        if(asignaturas.Exists(e => e.Nombre == asignatura.Nombre)) {
            {
                Console.WriteLine($"La asignatura {asignatura.Nombre} ya existe en el programa.");
            }
        }
        else {
            asignaturas.Add(asignatura); 
            Console.WriteLine($"La asignatura {asignatura.Nombre} ha sido añadida");
        }
    }

    public void RankingEstudiantes () {
        if (estudiantes.Count == 0) {
            Console.WriteLine("No hay estudiantes en el programa");
        }

        var ranking = estudiantes.OrderByDescending(e => e.CalcularPromedio());
        var posicion = 1;
        foreach (var estudiante in ranking) {
            Console.WriteLine($"{posicion} {estudiante.Nombre} - Promedio: {estudiante.CalcularPromedio():F2}");
            posicion++;
        }
    }

    public void EstudiantesRiesgoSuspender() {
        if (estudiantes.Count == 0) {
            Console.WriteLine("No hay estudiantes en el programa");
            return;
        }

        var riesgoSuspenso = estudiantes.Where(e => e.CalcularPromedio() < 5);

        if (!riesgoSuspenso.Any()) {
            Console.WriteLine("No hay estudiantes en riesgo de suspender");
            return;
        }

        Console.WriteLine($"Los estudiantes en riesgo de suspender son: ");

        foreach(var estudiante in riesgoSuspenso) {
            Console.WriteLine($"{estudiante.Nombre} - Con promedio de: {estudiante.CalcularPromedio():F2}");
        }

        }

}