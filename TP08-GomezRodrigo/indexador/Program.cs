namespace indexador
{
    internal class Program
    {
        const string csv = @"C:\Users\gomez\OneDrive\Escritorio\carpetapocha\index.csv";
        static void mostrarArchivos(string path)
        {
            var files = Directory.GetFiles(path,"*.*",SearchOption.TopDirectoryOnly).ToList();
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        static void mostrarDirectorios(string path)//podría hacer una class para hacer un overload donde si le mando un parametro mas además de escribir los directorios cree el archivo?
        {
            var dirs = Directory.GetDirectories(path,"*",SearchOption.AllDirectories).ToList();
            mostrarArchivos(path);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
                mostrarArchivos((string)dir);
            }
        }
        static void escribirArchivos(string path)
        {
            int contador = 1;
            var files = Directory.GetFiles(path,"*",SearchOption.AllDirectories).ToList();
            using (var sw = new StreamWriter(csv))
            {
                foreach (var file in files)
                {
                    sw.WriteLine($"{contador};{Path.GetFileNameWithoutExtension(file)};{Path.GetExtension(file)}\n");
                    contador++;
                }
            }
        }
        static void Main(string[] args)
        {
            string path;

            Console.WriteLine("Ingrese una ruta para listar los archivos: ");
            path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                Console.Clear();
                Console.WriteLine("Archivos encontrados en la ruta:\n");
                mostrarDirectorios(path);
            }
            escribirArchivos(path);
            Console.ReadLine();
        }
    }
}