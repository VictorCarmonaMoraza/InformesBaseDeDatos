using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AppInformes
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexion x = new Conexion();
            List<Persona>listaDeAutores=x.ObtenerConexion();
            
            //string path = ConfigurationManager.AppSettings["PATH"];
            //String nombreArchivo = ConfigurationManager.AppSettings["NameFile"];
            string pathUnificado = ConfigurationManager.AppSettings["PATH"] +"\\"+ConfigurationManager.AppSettings["NameFile"];

            //List<Autores> listaAutores = new List<Autores>()
            //{
            //    //new Autores()
            //    //{
            //    //    Id =1,
            //    //    Nombre ="Victor"
            //    //},
            //    //new Autores()
            //    //{
            //    //    Id =2,
            //    //    Nombre="Ana"
            //    //}
            //};
            
            Utils.CreateFile(listaDeAutores, pathUnificado);
        }
    }
}
