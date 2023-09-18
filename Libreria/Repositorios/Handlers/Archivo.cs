using Libreria.Exceptions;

namespace Libreria.Repositorios.Handlers
{
    public class Archivo
    {
        private readonly string _path;

        public Archivo(string path)
        {
            _path = path;
        }

        public string Leer()
        {
            try
            {
                var datos = string.Empty;

                using (var reader = new StreamReader(_path))
                {
                    datos = reader.ReadToEnd();
                }

                return datos;
            }
            catch (Exception)
            {
                throw new ExceptionsInternas("Error al leer el archivo.");
            }
        }

        public static DirectoryInfo? ObtenerDirectorioSolucion()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }
    }
}
