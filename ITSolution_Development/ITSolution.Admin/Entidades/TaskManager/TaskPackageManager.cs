using ITSolution.Framework.Arquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ITSolution.Admin.Entidades.TaskManager
{
    public class TaskPackageManager
    {
        public string GeneratePackageProcedures()
        {
            string raiz = Application.StartupPath;
            //volta dois niveis
            //../..
            string resource = raiz.Replace("bin\\Debug", "SQLs\\procedures");
            //var procedures = FileManagerIts.ToFiles(resource, new string[] { ".sql" });

            //foreach (var p in procedures)
            //{
            //    Console.WriteLine("Atualizando procedure: " + p);
            //    //agora eu tenhos as procedures em mãos
            //}
            string proceduresPackage = Path.Combine(Path.GetTempPath(), "Procedures Package " + DateTime.Now.ToString("dd-MM-yyyy") + ".zip");

            //empacote em um zip
            ZipUtil.ZipDirectory(resource, proceduresPackage);

            return proceduresPackage;
        }

        public string GeneratePackageITEDLLs()
        {

            string raiz = Application.StartupPath;
            //altera o path
            //..\ITSolution\ITSolution.Admin\bin\Debug
            //..\ITE\ITE.Forms\bin\Debug\
            string resource = raiz.Replace(@"\ITSolution\ITSolution.Admin", @"\ITE\ITE.Forms");

            var files = FileManagerIts.ToFiles(resource, new string[] { ".dll", ".pdb", ".exe" });
            var dlls = new List<string>();
            //vai o foreach normal mesmo
            foreach (var f in files)
            {
                string fileName = Path.GetFileName(f);
                if ( fileName.StartsWith("ITE.") )
                {
                    //gera o caminho do arquivo
                    string newSource = Path.Combine(resource, fileName);
                    dlls.Add(newSource);
                }
            }
            string dllsPackage = Path.Combine(Path.GetTempPath(), "ITE DLLs Package " + DateTime.Now.ToString("dd-MM-yyyy") + ".zip");

            ZipUtil.CompressFileList(dlls, dllsPackage);

            return dllsPackage;
        }

        public string GeneratePackageITSolutionDLLs()
        {

            string raiz = Application.StartupPath;
            //altera o path
            //..\ITSolution\ITSolution.Admin\bin\Debug
            //..\ITE\ITE.Forms\bin\Debug\
            string resource = raiz.Replace(@"\ITSolution\ITSolution.Admin", @"\ITE\ITE.Forms");
            

            var files = FileManagerIts.ToFiles(resource, new string[] { ".dll", ".pdb", ".exe" });
            var dlls = new List<string>();
            //vai o foreach normal mesmo
            foreach (var f in files)
            {
                string fileName = Path.GetFileName(f);
                if ( fileName.StartsWith("ITSolution."))
                {
                    //gera o caminho do arquivo
                    string newSource = Path.Combine(resource, fileName);
                    dlls.Add(newSource);
                }
            }
            string dllsPackage = Path.Combine(Path.GetTempPath(), "ITSolution DLLs Package " + DateTime.Now.ToString("dd-MM-yyyy") + ".zip");

            ZipUtil.CompressFileList(dlls, dllsPackage);

            return dllsPackage;
        }

        public string GeneratePackageSystemDLLs()
        {
            string raiz = Application.StartupPath;
            //altera o path
            //..\ITSolution\ITSolution.Admin\bin\Debug
            //..\ITE\ITE.Forms\bin\Debug\
            string resource = raiz.Replace(@"\ITSolution\ITSolution.Admin", @"\ITE\ITE.Forms");


            var files = FileManagerIts.ToFiles(resource, new string[] { ".dll", ".pdb", ".exe" });
            var dlls = new List<string>();
            //vai o foreach normal mesmo
            foreach (var f in files)
            {
                string fileName = Path.GetFileName(f);
                if (fileName.StartsWith("ITE.")||fileName.StartsWith("ITSolution."))
                {
                    //gera o caminho do arquivo
                    string newSource = Path.Combine(resource, fileName);
                    dlls.Add(newSource);
                }
            }
            string dllsPackage = Path.Combine(Path.GetTempPath(), "System DLLs Package " + DateTime.Now.ToString("dd-MM-yyyy") + ".zip");

            ZipUtil.CompressFileList(dlls, dllsPackage);

            return dllsPackage;
        }
        
    }
}
