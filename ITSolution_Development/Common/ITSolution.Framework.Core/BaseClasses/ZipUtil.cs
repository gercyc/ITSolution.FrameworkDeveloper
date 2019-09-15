using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ITSolution.Framework.Core.BaseClasses
{
    /// <summary>
    /// Nem tudo nessa classe foi testado
    /// </summary>
    public class ZipUtil
    {
        /// <summary>
        /// Compacta uma um arquivo para .zip
        /// </summary>
        /// <param name="files"></param>Arquivos
        /// <param name="zipOut"></param>Arquivo .zip de saida
        /// <returns></returns>true compactado ou false erro
        public static bool CompressFile(string file, string dirOut = null)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException("Arquivo a ser compactado \"" + file + "\" não existe.");
            }

            //se informei um diretorio check se ele existe
            if (dirOut != null && !Directory.Exists(dirOut))
            {
                throw new DirectoryNotFoundException("Diretório de saída \"" + dirOut + "\" para o arquivo compactado não existe.");
            }


            if (dirOut == null)
            {
                //use o diretorio onde esta o arquivo a compactado
                dirOut = Path.GetDirectoryName(file);
            }

            //cria o arquivo zip de saida
            //pegue o nome do arquivo sendo compactado
            string zipName = Path.GetFileNameWithoutExtension(file);

            //gera o path de saida pro arquivo zip
            //combine o nome gerado com o diretorio
            string zipOut = Path.Combine(dirOut, zipName + ".zip");

            //se existe o arquivo zip
            for (int i = 1; File.Exists(zipOut); i++)
            {
                //gera um novo nome
                //gera o novo nome pro arquivo zip
                zipOut = Path.Combine(dirOut, zipName + "_" + i + ".zip");
            }

            return CompressFiles(new string[] { file }, zipOut);

        }

        /// <summary>
        /// Compacta uma lista de arquivo em um arquivo .zip
        /// </summary>
        /// <param name="files"></param>Arquivos
        /// <param name="zipOut"></param>Arquivo .zip de saida
        /// <returns></returns>true compactado ou false erro
        public static bool CompressFiles(string[] files, string zipOut)
        {
            return false;

            //using (Ionic.Zlib..ZlibStream zip = new Ionic.Zlib.ZlibStream())
            //{
            //    try
            //    {
            //        // percorre todos os arquivos da lista
            //        foreach (string f in files)
            //        {
            //            // se o item é um arquivo
            //            if (File.Exists(f))
            //            {
            //                // Adiciona o arquivo na pasta raiz dentro do arquivo zip
            //                zip.AddFile(f, "");

            //            }
            //            // se o item é uma pasta
            //            else if (Directory.Exists(f))
            //            {
            //                // Adiciona a pasta no arquivo zip com o nome da pasta 
            //                zip.AddDirectory(f, new DirectoryInfo(f).Name);

            //            }
            //        }

            //        // Salva o arquivo zip para o destino
            //        zip.Save(zipOut);

            //        //tudo certo
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.ShowExceptionStack(ex);
            //        //deu merda
            //        return false;
            //    }
            //}
        }

        /// <summary>
        /// Compacta uma lista de arquivo em um arquivo .zip
        /// </summary>
        /// <param name="files"></param>Arquivos
        /// <param name="zipOut"></param>Arquivo .zip de saida
        /// <returns></returns>true compactado ou false erro
        public static void CompressFileList(List<string> files, string zipOut)
        {

            //using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            //{

            //    // percorre todos os arquivos da lista
            //    foreach (string item in files)
            //    {
            //        // se o item é um arquivo
            //        if (File.Exists(item))
            //        {
            //            try
            //            {
            //                // Adiciona o arquivo na pasta raiz dentro do arquivo zip
            //                zip.AddFile(item, "");
            //            }
            //            catch (Exception ex)
            //            {
            //                throw ex;
            //            }
            //        }
            //        // se o item é uma pasta
            //        else if (Directory.Exists(item))
            //        {
            //            try
            //            {
            //                // Adiciona a pasta no arquivo zip com o nome da pasta 
            //                zip.AddDirectory(item, new DirectoryInfo(item).Name);
            //            }
            //            catch
            //            {
            //                throw;
            //            }
            //        }
            //    }
            //    // Salva o arquivo zip para o destino
            //    try
            //    {
            //        zip.Save(zipOut);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }

        /// <summary>
        /// Zipa um diretório
        /// </summary>
        /// <param name="dirTarjet"></param>Diretório a ser compactado
        /// <param name="dirOrZipOut"></param>Arquivo zip de saida se for nulo usa o do arquivo sendo compactado
        public static void ZipDirectory(string dirTarjet, string dirOrZipOut = null)
        {
            if (!Directory.Exists(dirTarjet))
            {
                throw new DirectoryNotFoundException("Diretório a ser compactado \"" + dirTarjet + "\" não existe.");
            }
            //se informei um diretorio check se ele existe
            //se tbm nao existe um extensao entao o arquivo tem alguma treta
            if (dirOrZipOut != null && !Directory.Exists(dirOrZipOut) && Path.GetExtension(dirOrZipOut) == null)
                throw new DirectoryNotFoundException("Arquivo de saída \"" + dirOrZipOut + "\" para o arquivo compactado não existe.");

            string zipName;
            string zip;
            if (dirOrZipOut == null)
            {
                //use o diretorio sendo compactado
                dirOrZipOut = dirTarjet;
                //cria o arquivo zip de saida
                //pegue o nome do diretorio sendo compactado
                zipName = FileManagerIts.GetDirectoryName(dirTarjet);

                //gera o path de saida pro arquivo zip
                //combine o nome gerado com o diretorio
                zip = Path.Combine(dirOrZipOut, zipName + ".zip");

            }
            else
            {
                //use o nome informado
                zipName = Path.GetFileName(dirOrZipOut);
                zip = dirOrZipOut;
            }


            //se existe o arquivo zip
            for (int i = 1; File.Exists(zip); i++)
            {
                //gera um novo nome
                //gera o novo nome pro arquivo zip
                zip = Path.Combine(Path.GetDirectoryName(dirOrZipOut), Path.GetFileNameWithoutExtension(zipName) + "_" + i + ".zip");
            }
            //compactando o pathFile pro diretorio de saida
            System.IO.Compression.ZipFile.CreateFromDirectory(dirTarjet, zip);

        }

        /// <summary>
        /// Compressão dos bytes recebidos
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ZipFromBytes(byte[] bytes)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                using (GZipStream gZip = new GZipStream(mStream, CompressionMode.Compress, true))
                {
                    gZip.Write(bytes, 0, bytes.Length);
                }
                return mStream.ToArray();
            }
        }

        /// <summary>
        /// Unzip nos bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] UnzipFromBytes(byte[] bytes)
        {

            using (GZipStream stream = new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }

        public static void ExtractZip(string zipFile, string destino)
        {
            if (File.Exists(zipFile))
            {
                //recebe a localização do arquivo zip
                //using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipFile))
                //{
                //    //verifica se o destino existe
                //    if (Directory.Exists(destino))
                //    {
                //        try
                //        {
                //            //extrai o arquivo zip para o destino
                //            zip.ExtractAll(destino);
                //        }
                //        catch(Exception ex)
                //        {
                //            throw new Exception("Falha na extração do zip " + zipFile, ex);
                //        }
                //    }
                //    else
                //    {
                //        //lança uma exceção se o destino não existe
                //        throw new DirectoryNotFoundException("O arquivo destino não foi localizado");
                //    }
                //}
            }
            else
            {
                //lança uma exceção se a origem não existe
                throw new FileNotFoundException("O Arquivo Zip não foi localizado");
            }
        }

        /// <summary>
        /// Extrai um arquivo zip para o diretório (O diretório precisa existir)
        /// </summary>
        /// <param name="zipPath"></param>
        /// <param name="extractPath"></param>
        public static bool ExtractToDirectory(string zipPath, string extractPath = null)
        {
            if (extractPath == null)
                extractPath = Path.GetDirectoryName(zipPath);

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                return true;
            }
            catch (Exception ex)
            {

                throw new IOException("Falha na extração do arquivo " + zipPath + " para " + extractPath
                    + "\n" + ex.Message);
            }
        }

        public static void ExtractZip(string zipPath, string extractPath, string ext)
        {

            using (ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                    }
                }
            }
        }
        //Nao vou usar essa lib externa por agora
        /* public void CompressWithPassword(string path, string zipOut = null)

         {
             int LENGHT_STREAM = int.MaxValue;

             FileStream objStreamDestino =
              new FileStream("c:\\ArquivoCompactado.zip", FileMode.Create, FileAccess.Write);
             //Arquivo que vai ser gerado               

             FileStream arquivo = new FileStream("c:\\arquivo.doc", FileMode.Open, FileAccess.Read);
             //Arquivo que será compactado

             ZipOutputStream objZipDestino = new ZipOutputStream(objStreamDestino);

             objZipDestino.Password = "123456";
             // Aqui informamos qual será a senha para acesso ao arquivo zip

             try

             {
                 Byte[] buffer = new Byte[LENGHT_STREAM];
                 //Criando um array para servir como armazenador durante a iteração sobre o objeto.

                 ZipEntry entrada = new ZipEntry("arquivo.doc");
                 //Criando uma nova entrada de arquivos, 
                 //já já entenderemos melhor o que isso significa. 
                 //Devemos passar como parâmetro o nome do arquivo que será inserido no .zip, 
                 //NÃO devemos colocar o caminho do arquivo que será compactado somente o nome.

                 objZipDestino.PutNextEntry(entrada);
                 // Aqui adicionamos no arquivo destino à entrada de arquivo que criamos na linha acima.

                 objZipDestino.Password = "123456";
                 // Aqui informamos qual será a senha para acesso ao arquivo zip

                 int bytesLidos = 0;

                 do
                 {

                     // bytesLidos = arquivo.Read(buffer, 0, LENGHT_STREAM);
                     //lendo o arquivo a ser compactado, 
                     // os bytes lidos são colocados no array buffer e a da quantidade e 
                     //bytes lidos é inserida na variável bytesLidos o valor do terceiro 
                     //parâmetro deve ser o mesmo que colocamos no tamanho do array buffer 


                     // objZipDestino.Write(buffer, 0, bytesLidos);
                     //escrevendo no arquivo zipado, 
                     //o buffer contém os dados que devem ser inseridos e a variável bytesLidos 
                     //informa ao método quantos bytes contidos no buffer ele deve realmente inserir.
                     // Tendo em vista que: digamos que só haja 2 bytes no arquivo de origem, 
                     // as duas primeiras posições do array buffer seriam preenchidas as outras
                     // permaneceriam vazias, você não quer que bytes vazios sejam inseridos no seu 
                     //.ZIP pois estes podem corrompe-lo, portando é de suma importância saber realmente 
                     //quantos bytes são relevantes dentro do array 


                 }

                 while (bytesLidos > 0);
                 // enquanto o número de bytes lidos é maior que zero faz-se o loop


                 //é importante entender que a informação é lida e escrita em blocos, nesse caso ele

                 // Lê 4096 bytes

                 // Insere 4096 bytes

                 // Lê 4096 bytes

                 // Insere 4096 bytes

                 // E assim vai até não haver mais bytes a serem lidos.




             }

             catch (Exception e)

             {
                 throw e; // Aqui devemos tratar se algum erro ocorrer neste
                          //caso estou repassando a bucha para o método que chamou.

             }

             finally

             {

                 //fechando as comunicações.

                 arquivo.Close();

                 objZipDestino.Close();

                 objStreamDestino.Close();


             }



         }


         public void Uncompreess()

         {
             int LENGHT_STREAM = int.MaxValue;

             //arquivo zipado de origem

             FileStream objStreamOrigem =
             new FileStream("c:\\ArquivoCompactado.zip", FileMode.Open, FileAccess.Read);

             //Cria um novo stream para manipulação do ZIP, 
             //enviando como parâmetro o zip criado anteriormente

             ZipInputStream objZipOrigem = new ZipInputStream(objStreamOrigem);

             //senha para abrir o arquivo zip

             objZipOrigem.Password = "123456";

             //Criamos aqui a variável de referência que indicará o arquivo descompactado

             FileStream objStreamDestino = null;

             //diretório onde irá ser colocado o arquivo descompactado

             string diretorioDestino = "c:\\descompactados\\";

             byte[] buffer = new byte[LENGHT_STREAM];

             int bytesLidos = 0;

             try

             {

                 //podem existir vários arquivos dentro do zip,
                 //o GetNextEntry pega o proximo arquivo da lista, a cada vez que 
                 //ele for chamado retorna o proximo da fila

                 ZipEntry entrada = objZipOrigem.GetNextEntry();

                 // criando o Stream para escrever no arquivo descompactado, entrada.
                 //Name pega o nome do arquivo que está dentro do zip

                 objStreamDestino =
                 new FileStream(diretorioDestino + entrada.Name, FileMode.Create, FileAccess.Write);

                 do
                 {

                     bytesLidos = objZipOrigem.Read(buffer, 0, LENGHT_STREAM);

                     objStreamDestino.Write(buffer, 0, bytesLidos);


                 }

                 while (bytesLidos > 0);


             }

             catch (Exception e)

             {
                 throw e;

             }
             finally

             {
                 objStreamDestino.Close();

                 objZipOrigem.Close();

                 objStreamOrigem.Close();

             }

         }*/



    }
}
