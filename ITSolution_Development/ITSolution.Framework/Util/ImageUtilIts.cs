using ITSolution.Framework.Enumaredores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;


namespace ITSolution.Framework.Util
{
    public static class ImageUtilIts
    {

        /// <summary>
        /// Filtro de imagens  jpg, jpeg, png, gif
        /// </summary>
        public static string ImageFilter
        {
            get
            {

                /*string filter = "Imagens (*.jpg)|*.jpg|" +
                                    "Imagens (*.jpeg)|*.jpeg|" +
                                    "Imagens (*.png)|*.png|" +
                                    "Imagens (*.gif)|*.gif";*/

                string filter = "Images (*.jpg, *.jpeg, *.png, *.bmp, *.gif, *.tiff) | *.jpg; *.jpeg; *.png; *.bmp; *.gif; *.tiff|" +
                                "JPG (*.jpg) | *.jpg|" +
                                "JPEG (*.jpeg) | *.jpeg|" +
                                "PNG (*.png) | *.png|" +
                                "BMP (*.bmp) | *.bmp|" +
                                "GIF (*.gif) | *.gif|" + 
                                "TIFF (*.tiff) | *.tiff";
                return filter;
                //"Imagens (*.gif)|*.gif|All files (*.*)|*.*"
            }
        }

        /// <summary>
        /// Obtém um objeto Image a partir de uma array de bytes
        /// </summary>
        /// <param name="stream">bytes[]</param>
        /// <returns></returns>
        public static Image GetImageFromBytes(byte[] stream)
        {
            try
            {
                if (stream != null)
                {
                    MemoryStream ms = new MemoryStream(stream);

                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Imagem invalida => " + ex.Message);
            }
            return null;

        }

        /// <summary>
        /// Obtém um objeto Image a partir de um Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public static Image GetImageFromStream(Stream stream)
        {
            try
            {
                if (stream != null)
                {
                    MemoryStream ms = new MemoryStream(GetBytesFromStream(stream));
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;
        }

        /// <summary>
        /// Obtem uma array de bytes a partir de um Stream
        /// </summary>
        /// <param name="streamByte">fileStream</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBytesFromStream(Stream streamByte)
        {
            try
            {
                if (streamByte != null)
                {
                    MemoryStream ms = new MemoryStream();
                    streamByte.CopyTo(ms);
                    byte[] retBytes = ms.ToArray();
                    return retBytes;
                }
            }
            catch (System.ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (System.NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (System.ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Retorna os bytes do arquivo
        /// </summary>
        /// <param name="file"></param>Arquivo
        /// <returns></returns>bytes do arquivo
        public static byte[] GetBytesFromFile(string file)
        {
            try
            {
                //Create a file stream from an existing file.
                FileInfo fi = new FileInfo(file);
                FileStream fs = fi.OpenRead();

                return GetBytesFromStream(fs);
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                return null;
            }
        }

        public static byte[] GetBytesFromImage(Image image)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static byte[] GetBytesFromImage(Image image, ImageFormat imfFormart)
        {
            try
            {
                if (imfFormart == null)
                    imfFormart = System.Drawing.Imaging.ImageFormat.Jpeg;
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, imfFormart);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionMessage(ex);
                return null;
            }

        }

        /// <summary>
        /// Cria uma imagem a partir do arquivo informado.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Image CreateImage(string file)
        {
            try
            {
                
                using (var ms = new MemoryStream())
                {
                    var imfFormart = System.Drawing.Imaging.ImageFormat.Jpeg;
                    var bmp = new Bitmap(file);
                    return bmp;
                }
            }

            //  The System.Drawing.Image this method creates.
            //T: System.OutOfMemoryException:
            //T: System.IO.FileNotFoundException:
            //T: System.ArgumentException:
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                return null;
            }
        }
        /// <summary>
        /// Obtem a imagem do arquivo
        /// Metodo nativo
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Image GetImageFromFile(string file)
        {
            try
            {
                return Image.FromFile(file);
            }

            //  The System.Drawing.Image this method creates.
            //T: System.OutOfMemoryException:
            //T: System.IO.FileNotFoundException:
            //T: System.ArgumentException:
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                return null;
            }
        }

        /// <summary>
        /// Rotaciona uma imagem informada
        /// </summary>
        /// <param name="bmp"></param>Bitmap
        /// <param name="rotation"></param>Tipo de rotação a ser realizada
        public static Bitmap RotacionarImage(Image image, TypeRotacao rotation = TypeRotacao.Graus90Horario)
        {
            Bitmap bmp = new Bitmap(image);
            RotacionarBitmap(bmp, rotation);
            return bmp;
        }

        /// <summary>
        /// Rotaciona o bitmap informado
        /// </summary>
        /// <param name="bmp"></param>Bitmap
        /// <param name="rotation"></param>Tipo de rotação a ser realizada
        public static Bitmap RotacionarBitmap(Bitmap bmp, TypeRotacao rotation = TypeRotacao.Graus90Horario)
        {
            RotateFlipType rotacao;

            switch (rotation)
            {
                /**
                * Sentido Horario
                */
                //	Especifica uma rotação de 90 graus no sentido horário sem inversão.
                case TypeRotacao.Graus90Horario://90
                    rotacao = RotateFlipType.Rotate90FlipNone;
                    break;

                //Especifica uma rotação de 180 graus no sentido horário sem inversão.
                case TypeRotacao.Graus180Horario://180
                    rotacao = RotateFlipType.Rotate180FlipNone;
                    break;

                //Especifica uma rotação de 270 graus no sentido horário sem inversão.
                case TypeRotacao.Graus270Horario://270
                    rotacao = RotateFlipType.Rotate270FlipNone;
                    break;

                /**
                * Sentido Anti-horario
                */

                //Especifica uma rotação de 90 graus no sentido horário seguida por uma inversão horizontal.
                case TypeRotacao.Graus90AntiHorario://90
                    rotacao = RotateFlipType.Rotate90FlipXY;
                    break;

                //Especifica uma rotação de 180 graus no sentido horário seguida por uma inversão horizontal.
                case TypeRotacao.Graus180AntiHorario://180
                    rotacao = RotateFlipType.Rotate180FlipXY;
                    break;

                //Especifica uma rotação de 270 graus no sentido horário seguida por uma inversão horizontal.
                case TypeRotacao.Graus270AntiHorario://270
                    rotacao = RotateFlipType.Rotate270FlipXY;
                    break;

                /**
                 * Inverter
                 */
                //Especifica uma rotação de 180 graus no sentido horário seguida por um horizontal e vertical Inverter.
                case TypeRotacao.InverterHorizontalmente:
                    //Inverter horizontalmente
                    rotacao = RotateFlipType.Rotate180FlipY;
                    break;

                //Especifica uma rotação de 180 graus no sentido horário sem inversão.
                case TypeRotacao.InverterVerticalmente:
                    //Inverter Verticalmente
                    rotacao = RotateFlipType.Rotate180FlipX;
                    break;

                //Especifica uma rotação de 90 graus no sentido horário seguida por uma inversão vertical.
                default://nada a fazer
                    rotacao = RotateFlipType.RotateNoneFlipNone;
                    break;
            }

            bmp.RotateFlip(rotacao);

            return bmp;

        }

        /// <summary>
        /// Redimensiona a imagem
        /// </summary>
        /// <param name="image"></param>Image a ser reduzida
        /// <param name="porcentagem"></param>Valor referente ao novo tamanho da imagem Ex: 10 => Seria 10% o valor total da imagem
        /// <returns></returns>A imagem redimensionada
        public static Image ResizeImage(Image image, int porcentagem)
        {

            float nPorcentagem = ((float)porcentagem / 100);

            int fonteLargura = image.Width;     //armazena a largura original da imagem origem
            int fonteAltura = image.Height;   //armazena a altura original da imagem origem
            int origemX = 0;        //eixo x da imagem origem
            int origemY = 0;        //eixo y da imagem origem

            int destX = 0;          //eixo x da imagem destino
            int destY = 0;          //eixo y da imagem destino
            //Calcula a altura e largura da imagem redimensionada
            int destWidth = (int)(fonteLargura * nPorcentagem);
            int destHeight = (int)(fonteAltura * nPorcentagem);

            //Cria um novo objeto bitmap
            Bitmap bm = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            //Define a resolução do bitmap.
            bm.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            //Crima um objeto graphics e defina a qualidade
            Graphics grImagem = Graphics.FromImage(bm);
            grImagem.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //Desenha a imge usando o método DrawImage() da classe grafica
            grImagem.DrawImage(image,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(origemX, origemY, fonteLargura, fonteAltura),
                GraphicsUnit.Pixel);

            grImagem.Dispose();  //libera o objeto grafico

            return bm;
        }

        /// <summary>
        /// Redimensiona a imagem de maneira assincrona
        /// </summary>
        /// <param name="image"></param>Image a ser reduzida
        /// <param name="porcentagem"></param>Valor referente ao novo tamanho da imagem Ex: 10 => Seria 10% o valor total da imagem
        /// <returns></returns>A imagem redimensionada
        public async static Task<Image> ResizeImageAsync(Image image, int porcentagem)
        {

            return await Task.Run(() => ResizeImage(image, porcentagem));
        }


    }
}
