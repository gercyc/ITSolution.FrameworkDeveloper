using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;


//https://msdn.microsoft.com/pt-br/library/as2f1fez.aspx
namespace ITSolution.Framework.Core.BaseClasses
{
    public class FileManagerIts
    {
        #region Properties

        /// <summary>
        /// Filtro de documentos  "Word Documents| *.doc | Excel Worksheets | *.xls *.xlsx | PowerPoint Presentations | *.ppt | Office Files | *.doc; *.xls; *.ppt | All Files | *.*";
        /// </summary>
        public static string DocumentFilter
        {
            get
            {
                string filter = "Word Documents|*.doc|Excel Worksheets|*.xls; *.xlsx|PowerPoint Presentations|*.ppt|Office Files|*.doc; *.xls; *.ppt | All Files |*.*";
                return filter;
            }
        }

        public static string AttachmentFilter
        {
            get
            {
                string filter = "Arquivos suportados (*.jpg,*.jpeg, *.png, *.bmp, *.gif, *.tiff, *.pdf) | *.jpg; *.jpeg; *.png; *.bmp; *.gif; *.tiff; *.pdf|" +
                    "JPG (*.jpg) | *.jpg|" +
                    "JPEG (*.jpeg) | *.jpeg|" +
                    "PNG (*.png) | *.png|" +
                    "BMP (*.bmp) | *.bmp|" +
                    "GIF (*.gif) | *.gif|" +
                    "TIFF (*.tiff) | *.tiff|" +
                    "PDF (*.pdf) | *.pdf;";
                return filter;
            }
        }

        public static string DocumentFilterExcel
        {
            get { return "Excel Files(*.xls, *.xlsx, *.xlsm) |*.xls; *.xlsx; *.xlsm"; }
        }

        /// <summary>
        /// Retorna o diretorio da area de trabalho
        /// </summary>
        public static string DeskTopPath
        {
            get
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                return desktop;
            }
        }

        /// <summary>
        /// Retorna uma pasta especial do Windows
        /// </summary>
        /// <param name="sf"></param>Enumerador de pastas especiais
        /// <returns></returns>O path da pasta especial
        public static string SpecialFolder(Environment.SpecialFolder sf)
        {
            string sfPath = Environment.GetFolderPath(sf);
            return sfPath;
        }

        public static string[] LogicalDrives
        {
            get
            {
                return Environment.GetLogicalDrives();
            }
        }
        #endregion

        public FileManagerIts()
        {
            this.fileList.Clear();
        }

        /// <summary>
        /// Cria o diretório informado se o mesmo não existir
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns> True se o diretório foi criado caso contrário o diretório é inválido ou já existe
        public static bool CreateDirectory(string folder)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(folder);
                    return true;
                }
            }
            catch (IOException ex)
            {
                string msg = "Falha ao criar o diretório " + folder + "\nDiretório inválido\n";
                foreach (var exStack in Utils.DecompileExceptionStack(ex))
                {
                    msg += exStack;
                }
                Console.WriteLine(msg);
            }
            return false;
        }

        public static FileInfo[] GetFiles(string tarjet)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(tarjet);
                return dir.GetFiles();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// Summary:
        ///     Returns the subdirectories of the current directory.
        public static DirectoryInfo[] GetDirectories(string tarjet)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(tarjet);
                return dir.GetDirectories();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Cria um arquivo
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns>True</returns>  arquivo criado false 
        public static bool CreateFile(string pathFile)
        {
            try
            {
                //se o arquivo nao existe
                if (!File.Exists(pathFile))
                {
                    using (FileStream fs = File.Create(pathFile))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Falha ao criar o arquivo " + pathFile;
                Console.WriteLine(msg + " " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// O conteúdo do arquivo em uma string
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns> Os dados do arquivo ou uma string vazia
        public static string GetDataStringFile(string pathFile)
        {
            string result = "";
            try
            {

                //se o arquivo existe
                if (File.Exists(pathFile))
                {

                    Stream stream = File.OpenRead(pathFile);
                    var sw = new StreamReader(stream);
                    result = sw.ReadToEnd();
                    stream.Close();

                }
            }
            catch (IOException ex)
            {
                string msg = string.Format("Falha ao abrir o arquivo {0}\n{1}", pathFile, ex.Message);
                Console.WriteLine(msg);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Cria um path de arquivo que não existe com o nome do arquivo informado
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetTempFileFromDir(string path)
        {
            int i = 1;

            var dirTemp = Path.GetDirectoryName(path);

            //temp
            var temp = Path.Combine(dirTemp, Path.GetFileName(path));

            //nome do arquivo sem extensao
            string fileName = Path.GetFileNameWithoutExtension(path);

            //extensao do arquivo
            string ext = Path.GetExtension(path);

            while (File.Exists(temp))
            {
                temp = Path.Combine(dirTemp, fileName + "_" + i) + ext;
                i++;
            }
            return temp;
        }

        /// <summary>
        /// Cria um path de arquivo que não existe com o nome do arquivo informado
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetTempFile(string path)
        {
            int i = 1;

            var dirTemp = Path.GetTempPath();

            //temp
            var temp = Path.Combine(dirTemp, Path.GetFileName(path));

            //nome do arquivo sem extensao
            string fileName = Path.GetFileNameWithoutExtension(path);

            //extensao do arquivo
            string ext = Path.GetExtension(path);

            while (File.Exists(temp))
            {
                temp = Path.Combine(dirTemp, fileName + "_" + i) + ext;
                i++;
            }
            return temp;
        }

        /// <summary>
        /// Uma lista com os dados do arquivo
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns> 
        public static List<String> GetDataFile(string pathFile)
        {
            List<String> textList = new List<String>();
            StreamReader sr = null;

            try
            {

                //se o arquivo existe
                if (File.Exists(pathFile))
                {
                    sr = new StreamReader(pathFile);
                    String text = sr.ReadLine();

                    while (text != null)
                    {
                        if (text != null)
                        {
                            textList.Add(text);
                        }
                        text = sr.ReadLine();

                    }
                }
            }
            catch (IOException ex)
            {
                string msg = string.Format("Falha ao abrir o arquivo {0}\n{1}", pathFile, ex.Message);
                Trace.WriteLine(msg);
                throw ex;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return textList;
        }

        public static string GetDirectoryName(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Diretório não existe: " + directory);
                return null;
            }
            string parent = Directory.GetParent(directory).ToString();

            //pegue o nome do diretorio
            string directoryName = directory.Replace(parent, "").Replace("\\", "");

            //ultimo nome do diretorio eh o nome dele
            return directoryName;
        }

        /// <summary>
        /// Concatenar linhas no arquivo, sem quebra de linha
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool AppendText(string pathFile, string text)
        {
            try
            {
                File.AppendAllText(pathFile, text);

                return true;
            }
            catch (ArgumentException aex)
            {
                Utils.ShowExceptionStack(aex);
            }
            catch (IOException exio)
            {
                Utils.ShowExceptionStack(exio);
            }
            return false;
        }

        /// <summary>
        /// Escreve com quebra de linha
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static bool AppendLines(string pathFile, params string[] lines)
        {
            try
            {
                //cria o arquivo se ele nao existir
                File.AppendAllLines(pathFile, lines);

                return true;
            }
            catch (ArgumentException aex)
            {
                Utils.ShowExceptionStack(aex);
            }
            catch (IOException exio)
            {
                Utils.ShowExceptionStack(exio);
            }
            return false;
        }

        /// <summary>
        /// Copia um arquivo para um diretorio ou substitui um arquivo existente
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>Arquivo a ser copiado
        /// <param name="file"></param>Destino do arquivo copiado
        /// <param name="overWrite"></param>
        /// <returns></returns>true para ser reescrito false nao sobreescreve
        public static bool CopyFile(string sourceFile, string file, bool overWrite = true)
        {
            try
            {
                //permissao para copiar
                File.SetAttributes(sourceFile, FileAttributes.Normal);

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                File.Copy(sourceFile, file, overWrite);

                return true;

            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
                return false;
            }
        }

        /// <summary>
        /// Copia um diretorio para outro
        /// </summary>
        /// <param name="sourceDirName"></param>Diretorio a ser copiado
        /// <param name="destDirName"></param>Destino da copia
        /// <param name="copySubDirs"></param>Copiar arquivos de subpastas
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    //chamada recursiva
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// Escrever os dados do pathFile no tarjetFile
        /// O diretório precisa existir.
        /// O conteúdo será sobreescrito.
        /// </summary>
        /// <param name="tarjetFile"></param>
        /// <param name="pathFile"></param>
        public static bool OverWriteFile(string tarjetFile, string pathFile)
        {
            try
            {
                var data = GetDataFile(tarjetFile);

                if (File.Exists(tarjetFile))
                    File.SetAttributes(tarjetFile, FileAttributes.Normal);

                File.WriteAllLines(tarjetFile, data);

                return true;
            }
            catch (ArgumentException aex)
            {
                Utils.ShowExceptionStack(aex);
            }
            catch (IOException exio)
            {
                Utils.ShowExceptionStack(exio);
            }
            return false;

        }

        /// <summary>
        /// Gera um arquivo com os dados do vetor de string.
        /// O diretório precisa existir.
        /// O conteúdo será sobreescrito.
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="lines"></param>
        public static bool OverWriteOnFile(string pathFile, params string[] lines)
        {
            try
            {
                if (File.Exists(pathFile))
                    //permissao total
                    File.SetAttributes(pathFile, FileAttributes.Normal);

                File.WriteAllLines(pathFile, lines);
                return true;
            }
            catch (ArgumentException aex)
            {
                Utils.ShowExceptionStack(aex);
            }
            catch (IOException exio)
            {
                Utils.ShowExceptionStack(exio);
            }
            return false;

        }

        /// <summary>
        /// Gera um arquivo com os dados do vetor de string.
        /// O diretório precisa existir.
        /// O conteúdo será sobreescrito.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="lines"></param>
        public static bool OverWriteOnFile(string pathFile, List<string> lines)
        {
            try
            {
                if (File.Exists(pathFile))
                    //permissao total
                    File.SetAttributes(pathFile, FileAttributes.Normal);

                File.WriteAllLines(pathFile, lines);
                return true;
            }
            catch (ArgumentException aex)
            {
                Utils.ShowExceptionStack(aex);
            }
            catch (IOException exio)
            {
                Utils.ShowExceptionStack(exio);
            }
            return false;

        }

        // <summary>
        // Verifica se o arquivo informado está vazio
        // Lança exceção se o arquivo não existe : FileNotFoundException 
        // </summary>
        // <param name="path"></param>Path
        // <returns></returns>true vazio ou false não existe
        public static bool IsEmpty(string pathFile)
        {
            try
            {
                FileInfo file = new FileInfo(pathFile);

                if (file.Length <= 0)
                    return true;
                else
                    return false;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///Todas as unidade do disco rigido possiveis
        /// </summary>
        /// <returns></returns>string[]
        public static string[] ToDiskUnit()
        {
            string[] letters = new string[26];

            for (int i = 0; i < 26; i++)
            {
                //monta a letra da unidade
                string letter = string.Format("{0}:", Convert.ToChar('A' + i));

                letters[i] = letter;
            }
            return letters;
        }

        /// <summary>
        /// Gera um arquivo com os dados da exceção.
        /// O diretório precisa existir.
        /// Caso o arquivo exista o conteúdo é adicionado ao final do arquivo.
        /// Lines são adcionados primeiro
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="ex"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static bool AppendTextFileException(string pathFile, Exception ex, string[] lines = null)
        {
            try
            {
                DateTime dataAtual = DateTime.Now;

                //Verifico se o arquivo que desejo abrir existe e passo como parâmetro a respectiva variável
                if (File.Exists(pathFile))
                {
                    //escreve as linhas no arquivo
                    AppendTextFile(pathFile, lines);

                    //Crio um using, dentro dele instancio o StreamWriter, uso a classe File e o método
                    //AppendText para concatenar o texto, passando como parâmetro a variável pathFile
                    using (StreamWriter sw = File.AppendText(pathFile))
                    {
                        var inner = ex.InnerException == null
                            ? "Nenhuma exceção interna"
                            : ex.InnerException.Message + "";

                        //Uso o método Write para escrever o arquivo que será adicionado no arquivo texto
                        sw.Write(
                            "\nMensagem: " + ex.Message + "\n" +
                            "Classe: " + ex.GetType() + "\n" +
                            "Exceção interna: " + inner + "\n" +
                            "Pilha de erros: " + ex.StackTrace + "\n");
                    }
                    return true;

                }
                else
                {
                    if (CreateFile(pathFile))
                    {
                        return AppendTextFileException(pathFile, ex, lines);
                    }
                }
            }
            catch (IOException exio)
            {
                Utils.ShowExceptionStack(exio);
            }
            return false;
        }

        /// <summary>
        /// Escreve no arquivo
        /// O arquivo deve existe.
        /// </summary>
        /// <param name="pathFile"></param>Path do arquivo
        /// <param name="lines"></param>Conteúdo a ser adicionado no arquivo
        /// <returns></returns>
        public static bool AppendTextFile(string pathFile, params string[] lines)
        {
            if (lines == null || pathFile == null)
            {
                return false;
            }
            try
            {
                if (File.Exists(pathFile))
                {
                    using (StreamWriter sw = File.AppendText(pathFile))
                    {
                        foreach (var text in lines)
                        {
                            //escrever no final do arquivo
                            sw.Write(text + '\n');
                        }
                        sw.Close();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
            }
            return false;
        }

        //http://cbsa.com.br/post/directorygetfiles---filtrar-multiplas-extensoes-com-c.aspx
        /// <summary>
        /// Lista os arquivos e pastas do diretório
        /// </summary>
        /// <param name="pathFile"></param>Diretório a ser varrido
        /// <param name="filter"></param>Filtro para procurar arquivos com determinadas extensões
        /// <param name="recursive"></param>true : Listar somente os arquivos e diretório false : todos os arquivos e pasta (recursivo) e todas as subpastas.
        /// <returns></returns>A lista dos path dos arquivo
        public static List<string> ToFiles(string pathFile, string[] filter = null, bool recursive = false)
        {
            if (!Directory.Exists(pathFile))
            {
                Console.WriteLine("Arquivo " + pathFile + " não existe.");
                return null;
            }
            var searchOption = SearchOption.TopDirectoryOnly;

            if (recursive)
                searchOption = SearchOption.AllDirectories;

            if (filter != null)
            {
                var lista = new List<string>();
                //Retornar uma lista de arquivos com várias extensões
                //Directory.GetFiles(caminho, todos os arquivos, pesquisa em subdiretórios)
                foreach (var f in filter)
                {


                    if (f == string.Empty)
                    {
                        var arquivos = Directory.GetFiles(pathFile, "*.*", searchOption)
                                            .Where(s => Path.GetExtension(s) == string.Empty).ToList();
                        lista.AddRange(arquivos);
                    }
                    else
                    {

                        var arquivos = Directory.GetFiles(pathFile, "*.*", searchOption)
                                        .Where(s => s.EndsWith(f)).ToList();
                        lista.AddRange(arquivos);
                    }

                }

                return lista;


            }
            else
            {
                return Directory.GetFiles(pathFile, "*.*", searchOption).ToList();

            }
        }

        /// <summary>
        /// Lista somentes os diretórios do diretório informado
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public static List<string> ToDirs(string pathFile)
        {
            if (!Directory.Exists(pathFile))
            {
                Console.WriteLine("Arquivo " + pathFile + " não existe.");
                return null;
            }

            List<String> lista = new List<String>();

            try
            {
                //Marca o diretório a ser listado
                DirectoryInfo diretorio = new DirectoryInfo(@pathFile);
                //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
                var diretorios = diretorio.GetDirectories();

                //Começamos a listar os arquivos
                foreach (var fileinfo in diretorios)
                {
                    lista.Add(fileinfo.FullName);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
            }
            return lista;
        }

        /// <summary>
        /// Faz a leitura dos bytes do arquivo informado e carrega para um array
        /// </summary>
        /// <param name="pathFile"></param>Path do arquivo
        /// <returns></returns>
        public static byte[] ReadBytesFromFile(string pathFile)
        {
            //http://www.cambiaresearch.com/articles/17/how-do-i-read-a-file-as-an-array-of-bytes-in-csharp
            //se o arquivo existe, continue
            if (File.Exists(pathFile))
            {
                FileStream stream = File.OpenRead(pathFile);
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                //Begins the process of writing the byte array back to a file

                using (Stream file = File.OpenWrite(pathFile))
                {
                    file.Write(fileBytes, 0, fileBytes.Length);
                }
                return fileBytes;
            }
            else
                return null;
        }

        /// Summary:
        ///     Opens a binary file, reads the contents of the file into a byte array, and then
        ///     closes the file.
        ///
        /// Parameters:
        ///   path:
        ///     The file to open for reading.
        ///
        /// Returns:
        ///     A byte array containing the contents of the file.
        ///
        /// Exceptions:
        ///   T:System.ArgumentException:
        ///     path is a zero-length string, contains only white space, or contains one or more
        ///     invalid characters as defined by System.IO.Path.InvalidPathChars.
        ///
        ///   T:System.ArgumentNullException:
        ///     path is null.
        ///
        ///   T:System.IO.PathTooLongException:
        ///     The specified path, file name, or both exceed the system-defined maximum length.
        ///     For example, on Windows-based platforms, paths must be less than 248 characters,
        ///     and file names must be less than 260 characters.
        ///
        ///   T:System.IO.DirectoryNotFoundException:
        ///     The specified path is invalid (for example, it is on an unmapped drive).
        ///
        ///   T:System.IO.IOException:
        ///     An I/O error occurred while opening the file.
        ///
        ///   T:System.UnauthorizedAccessException:
        ///     This operation is not supported on the current platform.-or- path specified a
        ///     directory.-or- The caller does not have the required permission.
        ///
        ///   T:System.IO.FileNotFoundException:
        ///     The file specified in path was not found.
        ///
        ///   T:System.NotSupportedException:
        ///     path is in an invalid format.
        ///
        ///   T:System.Security.SecurityException:
        ///     The caller does not have the required permission.
        public static byte[] GetBytesFromFile(string path)
        {
            try
            {
                return File.ReadAllBytes(path);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Faz a leitura dos bytes e carrega para uma lista de string
        /// </summary>
        /// <param name="pathFile"></param>Path do arquivo
        /// <returns></returns>
        public static List<string> GetDataFromBytes(byte[] bytes)
        {

            try
            {
                //pega os dados
                string result = StringUtilIts.GetStringFromBytes(bytes);
                //arquivo temporario
                var temp = Path.GetTempFileName();
                //escrever em um arquivo temporario
                FileManagerIts.WriteBytesToFile(temp, bytes);
                //transforma em uma lista
                var data = FileManagerIts.GetDataFile(temp);
                //elimina o temporario
                File.Delete(temp);

                //pega o resultado;
                return data;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao obter string dos bytes =>\n=>" + ex.Message);
            }

        }

        /// <summary>
        /// Escreve um array de bytes no arquivo selecionado
        /// </summary>
        /// <param name="pathFile"></param>Arquivo a ser escrito
        /// <param name="_ByteArray"></param>bytes a ser escritos
        /// <returns></returns>true se escrito com sucesso caso contrário false
        public static bool WriteBytesToFile(string pathFile, byte[] _ByteArray)
        {
            //http://www.digitalcoding.com/Code-Snippets/C-Sharp/C-Code-Snippet-Save-byte-array-to-file.html
            try
            {
                // Open file for reading
                FileStream fs = new FileStream(pathFile, FileMode.Create, FileAccess.Write);

                // Writes a block of bytes to this stream using data from a byte array.
                fs.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                fs.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());

                Utils.ShowExceptionStack(_Exception);
                // error occured, return false
                return false;
            }


        }

        /// <summary>
        /// Carrega o arquivo selecionado para um objeto Stream
        /// </summary>
        /// <param name="pathFile">Arquivo</param>
        /// <returns>System.IO.Stream</returns>
        public static Stream GetStreamFromFile(string pathFile)
        {
            if (pathFile != null)
            {
                MemoryStream stream = new MemoryStream(ReadBytesFromFile(pathFile));

                return stream;
            }
            else
                return null;
        }

        /// <summary>
        /// Apaga um arquivo ou diretorio
        /// Para tratar problemas de acesso ao negado ao copiar e excluir
        /// 
        /// Delete
        ///     File.SetAttributes(file, FileAttributes.Normal);
        ///     File.Delete(file);
        ///Copy
        ///     File.Copy(file, dest, true);
        ///     File.SetAttributes(dest, FileAttributes.Normal);
        /// 
        /// Para diretorios use
        ///     File.SetAttributes(d, FileAttributes.Directory);
        /// </summary>
        /// <param name="path"></param>Arquivo ou pasta a ser apagada.
        /// <returns></returns>true se apagado caso contrário false
        public static bool DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }

                else if (Directory.Exists(path))
                    return DeleteDirectory(path);

                return false;
            }
            catch (DirectoryNotFoundException notFoundDir)
            {
                Utils.ShowExceptionStack(notFoundDir);
                return false;
            }
            catch (FileNotFoundException notFoundDir)
            {
                Utils.ShowExceptionStack(notFoundDir);
                return false;
            }
            catch (UnauthorizedAccessException accessDenied)
            {
                Utils.ShowExceptionStack(accessDenied);
                return false;
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
                return false;
            }
        }

        /// <summary>
        /// Exclui o diretório informado
        /// Para tratar problemas de acesso ao negado ao copiar e excluir
        ///    Delete
        ///  File.SetAttributes(file, FileAttributes.Normal);
        ///    File.Delete(file);
        ///Copy
        ///File.Copy(file, dest, true);
        ///    File.SetAttributes(dest, FileAttributes.Normal);
        /// 
        /// Para diretorios use
        /// File.SetAttributes(d, FileAttributes.Directory);
        /// 
        ///Todas as pasta, subpastas e arquivos serão removidos
        /// </summary>
        /// <param name="path"></param>Path do arquivo
        /// <returns></returns>
        public static bool DeleteDirectory(string path, bool recursive = true)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Directory);
                    // Apaga tudo o que estiver
                    // lá dentro (arquivos, sub-pastas, etc...)
                    Directory.Delete(path, recursive);
                    return true;
                }
            }
            catch (DirectoryNotFoundException notFoundDir)
            {
                Utils.ShowExceptionStack(notFoundDir);
            }
            catch (UnauthorizedAccessException accessDenied)
            {
                Utils.ShowExceptionStack(accessDenied);
            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
            }
            return false;
        }

        /// <summary>
        /// Executa ou abre um arquivo. A decisão é do sistema operacional
        /// </summary>
        public static void OpenFromSystem(string pathFile)
        {
            try
            {
                Process.Start(pathFile);
            }
            catch (Exception ex)
            {
                if (pathFile == null)
                {
                    Utils.ShowExceptionStack(ex);
                }
                else
                {
                    Utils.ShowExceptionStack(ex);
                }
            }
        }

        private HashSet<string> fileList = new HashSet<String>();

        /// <summary>
        /// Lista todos os arquivos e pasta do diretório. Usa chamada recursiva
        ///  
        /// </summary>
        /// <param name="pathDir"></param>
        /// <returns></returns>
        public HashSet<string> ToFilesRecursive(string pathDir)
        {
            try
            {
                foreach (var f in Directory.GetFiles(pathDir))
                {
                    fileList.Add(f);

                }
                foreach (var d in Directory.GetDirectories(pathDir))
                {
                    fileList.Add(d);

                    ToFilesRecursive(d);
                }


            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
                throw ex;
            }
            return fileList;
        }

        /// <summary>
        /// Renomea um arquivo ou diretorio
        /// </summary>
        /// <param name="dirOrFile"></param>Arquivo ou diretorio a ser renomeado
        /// <param name="fileSource"></param>Nome do arquivo ou pasta
        public static bool RenameTo(string dirOrFile, string fileSource, bool generate = false)
        {
            try
            {
                string path = Path.GetDirectoryName(dirOrFile);
                if (File.Exists(fileSource) || fileSource.Contains("\\"))
                {
                    throw new IOException("Para renomear um diretório informe apenas o nome do arquivo e não path.\n" +
                        "Path informado" + fileSource);
                }
                if (File.Exists(dirOrFile))
                {


                    string ext = Path.GetExtension(dirOrFile);

                    string newFile = Path.Combine(path, fileSource + ext);

                    if (generate)
                    {
                        while (File.Exists(newFile))
                        {
                            newFile = Path.Combine(path, fileSource + fileSource + "_1" + ext);
                        }
                    }

                    //renomear o arquivo
                    //é mover pro mesmo destino com outro nome
                    //@"C:\arquivo.txt", "C:\arquivo_renomeado.txt");
                    File.Move(dirOrFile, Path.Combine(newFile));
                    return true;
                }

                if (Directory.Exists(dirOrFile))
                {

                    var sections = dirOrFile.Split('\\');
                    path = Path.GetPathRoot(dirOrFile);
                    int lenght = sections.Length;
                    if (path.EndsWith("\\"))
                        lenght--;

                    for (int i = 1; i < lenght; i++)
                    {
                        string name = sections[i];
                        Console.WriteLine(name);
                        if (!string.IsNullOrEmpty(name))
                        {
                            if (i == lenght - 1)
                                name = fileSource;

                            path = path + name + "\\";
                        }
                        Console.WriteLine(path);


                    }

                    //renomear o arquivo
                    //é mover pro mesmo destino com outro nome
                    //@"C:\dir", "C:\new_dir");
                    Directory.Move(dirOrFile, path);
                    return true;
                }


                throw new IOException("Arquivo/Pasta : " + dirOrFile + " não existe.");

            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
                throw ex;
            }

        }

        /// <summary>
        /// Move um diretorio para outro diretório
        /// </summary>
        /// <param name="tarjet"></param>Arquivo diretorio a ser movido
        /// <param name="destiny"></param>Local onde sera movido os arquivos
        /// </summary>
        /// <param name="tarjet"></param>
        /// <param name="destiny"></param>
        public static void MoveDirectories(string tarjet, string destiny)
        {
            try
            {
                Directory.Move(tarjet, destiny);

            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
                throw ex;
            }

        }

        /// <summary>
        /// Move todos os arquivos do diretório informado "tarjet" para o diretório "destiny"
        /// Se os arquivos existirem serão substituídos
        /// </summary>
        /// <param name="tarjet"></param>Arquivo diretorio a ser movido
        /// <param name="destiny"></param>Local onde sera movido os arquivos
        public static void MoveFiles(string tarjet, string destiny)
        {
            string alvo = "";
            string destino = "";
            try
            {

                //demorei a chegar a essa logica
                //.net complicou muito as coisas

                var files = FileManagerIts.GetFiles(tarjet);
                var directories = FileManagerIts.GetDirectories(tarjet);

                foreach (var d in directories)
                {
                    alvo = d.FullName;
                    destino = Path.Combine(destiny, d.Name);

                    if (Directory.Exists(destino))
                        Directory.Delete(destino);

                    Directory.Move(alvo, destino);
                }

                foreach (var f in files)
                {
                    alvo = f.FullName;
                    destino = Path.Combine(destiny, f.Name);

                    if (File.Exists(destino))
                        File.Delete(destino);
                    File.Move(alvo, destino);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha ao mover " + alvo + " para " + destino);
                Utils.ShowExceptionStack(ex);
                throw ex;
            }
        }


    }
}
