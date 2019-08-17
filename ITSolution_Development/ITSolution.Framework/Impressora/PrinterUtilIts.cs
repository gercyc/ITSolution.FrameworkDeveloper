using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using WIA;

namespace ITSolution.Framework.Impressora
{

    public abstract class PrinterUtilIts
    {
        public static string DirDefault { get; set; }
        //Objeto para imprmir
        public PrintDocument PrintDocument { get; set; }
        //Objeto apra visualizar
        protected PrintPreviewDialog PrintPreviewDialog { get; }

        /// <summary>
        /// Path dos arquivos digitalizados ou carregados
        /// Os arquivos digitalizados são todos temporários
        /// </summary>
        public List<string> ImagesPath { get; set; }

        public static string LastPathScanning { get; private set; }

        public PrinterUtilIts()
        {
            this.ImagesPath = new List<string>();
            this.PrintDocument = new PrintDocument();
            this.PrintPreviewDialog = new PrintPreviewDialog();
        }

        public PrinterUtilIts(PrintDocument printDocument, PrintPreviewDialog printPreviewDialog)
        {

            this.PrintDocument = printDocument;
            this.PrintPreviewDialog = printPreviewDialog;
        }

        protected static string getPathTemp(string imageFile)
        {
            string dirTemp = Path.GetTempPath();
            string fileName = Path.GetFileName(imageFile);
            //Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".jpeg";

            return Path.Combine(dirTemp, fileName);

        }

        protected static string getPathDigitalizacao()
        {
            string dirDigitalizacao = Path.Combine(Application.StartupPath, "Digitalizacoes");
            string fileName = "Digitalizacao_" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".jpg";

            if (DirDefault != null)
                //use o diretorio informado
                dirDigitalizacao = DirDefault;

            if (!Directory.Exists(dirDigitalizacao))
                //esse eu sei q nao vai falhar
                Directory.CreateDirectory(dirDigitalizacao);

            PrinterUtilIts.LastPathScanning = Path.Combine(dirDigitalizacao, fileName);

            return LastPathScanning;

        }

        /// <summary>
        /// Envia um sinal para impressora imprimir a configuração do seu PrintDocument
        /// </summary>
        /// <param name="printerName"></param>
        /// <param name="printDocument"></param>
        public virtual void Print(string printerName)
        {

            //http://www.andrealveslima.com.br/blog/index.php/2015/09/30/impressao-direto-na-impressora-com-c/
            if (printerName != null)
            {

                this.PrintDocument.PrinterSettings.PrinterName = printerName;
                this.PrintDocument.Print();
            }
            else
            {
                XMessageIts.Advertencia("Informe a impressora antes de imprimir");

            }
        }

        /// <summary>
        /// Imprimi na impressora selecionada ou pedi para selecionar alguma
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="printerName"></param>
        public void PrintToOrSelect(string printerName)
        {
            PrinterUtilIts.PrintTo(printerName, this.PrintDocument);
        }

        /// <summary>
        /// Visualizar Impressão na impressora default do sistema
        /// </summary>
        public virtual bool PrintView(string impressora)
        {
            if (!String.IsNullOrWhiteSpace(impressora))
            {
                this.PrintDocument.PrinterSettings.PrinterName = impressora.ToString();
                return true;
            }
            else
            {
                XMessageIts.Mensagem("Impressora não foi informada");
                return false;
            }
        }

        #region Metódos static

        /// <summary>
        /// Imprimi na impressora selecionada ou exibe caixa de dialogo para selecionar um dispositivo
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="printerName"></param>
        public static void PrintTo(string printerName, PrintDocument printDocument)
        {
            PrintDialog dialogo = new PrintDialog();
            if (printerName != null)
            {
                //define a impressora pros objetos 
                dialogo.PrinterSettings.PrinterName = printerName;
                printDocument.PrinterSettings.PrinterName = printerName;

            }
            //se nao vai selecionar a impressora

            var op = dialogo.ShowDialog();

            if (op == DialogResult.OK)
            {
                try
                {

                    //informe os documentos a serem impressos
                    dialogo.Document = printDocument;
                    //agora imprima
                    printDocument.Print();

                }
                catch (InvalidPrinterException ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Falha na impressão !");
                }

            }
        }

        /// <summary>
        /// Lista de impressoras instaladas no computador
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPrinters()
        {
            var lista = new List<string>();

            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                lista.Add(printer.ToString());
            }
            return lista;

        }

        /// <summary>
        /// Digitaliza uma imagem na impressora padrão
        /// </summary>
        /// <returns></returns>
        public static string Scanning()
        {
            try
            {
                //get list of devices available
                List<string> devices = WIAScanner.GetDevices();
                List<string> devicesNames = new List<string>();
                foreach (string device in devices)
                {
                    devicesNames.Add(device);
                }
                //check if device is not available
                if (devicesNames.Count == 0)
                {
                    XMessageIts.Advertencia("Nenhum dispositivo(s) impressora(s) ativo foi encontrado.", "Aviso");
                    return null;
                }

                var deviceName = devicesNames[0];
                //get images from scanner
                List<Image> images = WIAScanner.Scan(deviceName);

                //nome aleatorio
                string pathDigitalizacao = getPathDigitalizacao();
                string pathTemp = getPathTemp(pathDigitalizacao);

                foreach (Image image in images)
                {
                    //save scanned image into specific folder
                    //salva toda imagem digitalizada no disco ridigo
                    image.Save(pathDigitalizacao, ImageFormat.Jpeg);
                    //salva o temporario
                    image.Save(pathTemp, ImageFormat.Jpeg);

                    return pathTemp;
                }
            }
            catch (NullReferenceException ex)
            {
                //foi cancelado durante a digitalização
                Console.WriteLine("Digitalização cancelada: " + ex.Message);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha na comunicação com a impressora\n\n" +
                    "Certifique que possui uma impressora padrão local e ativa", "Atenção");

                LoggerUtilIts.GenerateLogs(ex);
            }
            catch (Exception exc)
            {
                XMessageIts.ExceptionMessageDetails(exc, "Falha na digitalização", "Falha crítica - Erro não identificado");
                LoggerUtilIts.GenerateLogs(exc);
            }
            return null;
        }


        /// <summary>
        /// Digitaliza uma imagem na impressora selecionada
        /// </summary>
        /// <returns></returns>
        public static string ScanningTo()
        {
            try
            {
                //get list of devices available
                List<string> devices = WIAScanner.GetDevices();
                List<string> devicesNames = new List<string>();
                foreach (string device in devices)
                {
                    devicesNames.Add(device);
                }
                //check if device is not available
                if (devicesNames.Count == 0)
                {
                    XMessageIts.Advertencia("Nenhum dispositivo(s) impressora(s) ativo foi encontrado.", "Aviso");
                    return null;
                }

                var deviceName = devicesNames[0];

                //get images from scanner
                List<Image> images = WIAScanner.Scan();

                //nome aleatorio
                string pathDigitalizacao = getPathDigitalizacao();
                string pathTemp = getPathTemp(pathDigitalizacao);

                foreach (Image image in images)
                {
                    //save scanned image into specific folder
                    //salva toda imagem digitalizada no disco ridigo
                    image.Save(pathDigitalizacao, ImageFormat.Jpeg);
                    //salva o temporario
                    image.Save(pathTemp, ImageFormat.Jpeg);

                    return pathTemp;
                }
            }
            catch (NullReferenceException ex)
            {
                //foi cancelado
                Console.WriteLine("Digitalização cancelada:" + ex.Message);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha na comunicação com a impressora\n\n" +
                    "Certifique que possui uma impressora padrão local e ativa", "Atenção");

                LoggerUtilIts.GenerateLogs(ex);
            }
            catch (Exception exc)
            {
                //se nao eh essa mensagem eh q houve alguma treta
                if (!exc.Message.Contains("Você precisa selecionar um disposito"))
                {
                    XMessageIts.ExceptionMessageDetails(exc, "Falha na digitalização", "Falha crítica - Erro não identificado");
                    LoggerUtilIts.GenerateLogs(exc);
                }
            }
            return null;
        }

        /// <summary>
        /// Seleciona a impressora a ser utilziada para digitalizar um documento
        /// O usuário deve escolher onde salvar a imagem
        /// </summary>
        /// <param name="dialog"></param>
        public static void ScanningToDisk()
        {
            ////http://www.andrealveslima.com.br/blog/index.php/2015/12/16/como-escanear-documentos-com-o-c-digitalizacao-de-documentos/
            CommonDialogClass dialog = new WIA.CommonDialogClass();

            WIA.Device scanner = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, true, false);
            if (scanner != null)
                dialog.ShowAcquisitionWizard(scanner);

        }


        /*

     ///Usa a dll do windows c:\Windows\System32\wiaaut.dll
     /// <summary>
     /// Metodo digitaliza de imagem de alta qualidade => tamanho 11mb
     /// Usa a dll do windows c:\Windows\System32\wiaaut.dll
     /// Digitaliza um documento na impressora selecionada
     /// Essa opção de digitalização de documentos faz uso da API WIA. 
     /// Essa API está disponível desde o Windows 98 até hoje, 
     /// Compatibilidade com todos os scanners. 
     /// A dll utilizada nesse caso é a “wiaaut.dll“, localizada dentro do diretório 
     /// “C:\Windows\System32“. 
     /// Deve-se Adicionar uma referência a essa dll no nosso projeto: 
     /// Essa dll utiliza Interop e, caso não fizermos essa alteração, não conseguiremos utilizar 
     /// os tipos existentes dentro dessa dll de forma razoável (teríamos que fazer um monte de gambiarra 
     /// para conseguir utilizar os tipos). Dessa forma, para conseguirmos utilizar por completo 
     /// as classes dessa dll, temos que alterar a propriedade 
     /// “Embed Interop Types” para false na referência à WIA: 
     /// </summary>
     /// <param name="picImagem"></param>O diretório temporária onde está a imagem ou se null se algo errado
     /// <returns></returns>
     public static string Digitalizar2(string fileName = null)
     {
         //http://www.andrealveslima.com.br/blog/index.php/2015/12/16/como-escanear-documentos-com-o-c-digitalizacao-de-documentos/
         try
         {
             var dialog = new CommonDialogClass();

             Device scanner = dialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType,
                 true, false);
             var ext = ".jpg";
             string temp = "";

             if (fileName != null)
             {
                 temp = Path.GetTempPath() + "\\" + fileName + ext;
                 File.Delete(temp);
             }
             else
                 temp = Path.GetTempFileName() + ext;

             if (scanner != null)
             {

                 //Esse método inicializa a digitalização da página toda (ou do que tiver sido configurado 
                 //anteriormente de forma manual). 
                 //“ShowAcquireImage“,  retorna um “WIA.ImageFile” apontando para a imagem escaneada. 

                 var scannedImage = dialog.ShowTransfer(scanner.Items[1],
                     FormatID.wiaFormatJPEG) as ImageFile;//PNG

                 scannedImage.SaveFile(temp);

             }
             return temp;

         }
         catch (Exception ex)
         {
             XMessageIts.Erro("Erro na digitalização do documento.\n\n" + ex.Message,
                               "Erro");
             return null;
         }
     }


    /// <summary>
    /// Seleciona a impressora a ser utilziada para digitalizar um documento
    /// O usuário deve escolher onde salvar a imagem
    /// </summary>
    /// <param name="dialog"></param>
    public static void DigitalizarPara()
    {
        ////http://www.andrealveslima.com.br/blog/index.php/2015/12/16/como-escanear-documentos-com-o-c-digitalizacao-de-documentos/
        CommonDialogClass dialog = new WIA.CommonDialogClass();

        WIA.Device scanner = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, true, false);
        if (scanner != null)
            dialog.ShowAcquisitionWizard(scanner);

    }

    /// <summary>
    ///Exibe a janela de propriedades do Windows para selecionar dispositivo
    /// </summary>
    /// <returns></returns>O dispositivo selecionado
    public static WIA.Device SelecionarImpressora()
    {
        ////http://www.andrealveslima.com.br/blog/index.php/2015/12/16/como-escanear-documentos-com-o-c-digitalizacao-de-documentos/
        CommonDialogClass dialog = new WIA.CommonDialogClass();
        WIA.Device scanner = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, true, false);

        return scanner;
    }


    /// <summary>
    /// Mostra a janela de propriedades do Windows para o dispositivo especificado:
    /// </summary>
    public static void ExibirPropriedades()
    {
        CommonDialogClass dialog = new WIA.CommonDialogClass();
        WIA.Device scanner = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, true, false);
        dialog.ShowDeviceProperties(scanner);
    }*/

        #endregion Metódos static
    }

}

