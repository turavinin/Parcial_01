using Libreria.Exceptions;
using Libreria.Exceptions.Enums;

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
                throw new ExceptionsInternas("Error al leer el archivo.", TipoError.ErrorArchivo);
            }
        }

        public void Escribir(string data)
        {
            try
            {
                using(var writer = new StreamWriter(_path))
                {
                    writer.Flush();
                    writer.WriteLine(data);
                }
            }
            catch (Exception)
            {
                throw new ExceptionsInternas("Error al escribir el archivo.", TipoError.ErrorArchivo);
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
