using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInformes
{
    public static class Utils
    {

        public static Boolean CreateFile(List<Persona> listaModelo, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                //Creamos el directorio
                Directory.CreateDirectory(Path.GetDirectoryName(path));

                //StreamWriter sw = new StreamWriter(path);
                //sw = File.AppendText(path);
                StreamWriter sw =  File.AppendText(path);

                foreach (var model in listaModelo.ToList())
                {
                    sw.Write("{0};", model.Id);
                    sw.Write("{0};", model.Nombre);
                    sw.Write("{0};", model.Apellido);
                    sw.Write("{0};", model.Edad);
                    sw.WriteLine(""); 
                    sw.WriteLine("--------"); 
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
