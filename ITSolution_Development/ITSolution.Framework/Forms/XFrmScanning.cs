using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Enumaredores;
using ITSolution.Framework.Impressora;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmScanning : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Controlador da imagens
        private readonly PrinterImageUtil _util;
        //Controle de Zomm
        private int zoomAnt;
        /// <summary>
        /// Path dos arquivos digitalizados ou carregados        
        /// </summary>
        public List<string> DigitalizacoesPath { get { return this._util.ImagesPath; } }
        /// <summary>
        /// Arquivos digitalizados ou carregados
        /// </summary>
        public List<Image> Digitalizacoes { get { return this._util.Images; } }

        public bool IsCancelado { get; private set; }

        public XFrmScanning()
        {
            InitializeComponent();
            openImage.Filter = ImageUtilIts.ImageFilter;
            this._util = new PrinterImageUtil();
            this.zoomAnt = 0;
            this.cbExibicaoImagem.SelectedIndex = 4;
        }

        public void Run()
        {
            this.ShowDialog();
        }

        public Image GetCurrentImage()
        {
            try
            {
                var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;
                return this._util.Images[index];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateCurrentImage(Image img)
        {
            try
            {
                var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;
                //atualiza a imagem atual
                this._util.Images.Insert(index, img);
                //atualiza no view
                this.picImagem.Image = img;
                this.picImagem.Invalidate();
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha ao atualizar imagem");
            }
        }
        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                var file = PrinterUtilIts.Scanning();

                //exibe no picture box
                this.picImagem.Load(file);

                if (chRenameTo.Checked && !string.IsNullOrEmpty(file))
                {
                    string name = XFrmOptionPane.ShowInputDialog("Arquivo digitalizado",
                        "Digite o nome para o arquivo digitalizado:");


                    if (!string.IsNullOrEmpty(name))
                    {
                        string digitalizacao = PrinterUtilIts.LastPathScanning;
                        string ext = Path.GetExtension(digitalizacao);
                        if (FileManagerIts.RenameTo(digitalizacao, name, true))
                        {
                            //obtem o nome do arquivo digitalizado renomeado
                            var path = Path.Combine(Path.GetDirectoryName(digitalizacao), name + ext);
                            //atualiza o path do arquivo de digitalizado
                            this.setImagemPictureImage(path);
                            this.picImagem.ImageLocation = path;
                        }

                        lblFileName.Text = name;
                    }

                }
            }
            catch (Exception)
            {
                XMessageIts.Erro("Falha nos bytes da imagem");
            }
            this.Enabled = true;

        }


        private void barBtnSelecionaArquivo_Click(object sender, EventArgs e)
        {
            var op = openImage.ShowDialog();

            if (op == DialogResult.OK)
            {
                var files = this.openImage.FileNames;

                foreach (var file in files)
                {

                    var temp = FileManagerIts.GetTempFile(file);

                    //copie o arquivo pro temporario
                    FileManagerIts.CopyFile(file, temp);

                    //use o temporario
                    this.setImagemPictureImage(temp);

                }

            }
        }

        private void btnRedimensionar_Click(object sender, EventArgs e)
        {
            //var img = GetCurrentImage();

            if (this.picImagem.Image != null && this.trackBarControl1.Value != this.zoomAnt)
            {
                try
                {
                    //redimensionar
                    var zoom = ParseUtil.ToInt(trackBarControl1.Value);
                    this.zoomAnt = zoom;
                    var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;
                    var path = this._util.ImagesPath[index];

                    //imagem original
                    var bmp = new Bitmap(path);

                    //this.picImagem.Load(path);

                    //redimensiona a imagem
                    var imagem = ImageUtilIts.ResizeImage(bmp, zoom);

                    //salva a alteração 
                    //imagem.Save(path);

                    //atualize o picture box
                    this.picImagem.Image = imagem;

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Memória insuficiente") || ex.Message.Contains("Parâmetro inválido"))
                        XMessageIts.Advertencia("Esta imagem já não pode ser redimensionada !");
                    else
                        XMessageIts.ExceptionMessageDetails(ex, "Falha ao redimensionar a imagem");
                }
            }
        }

        private void btnRotacionar_Click(object sender, EventArgs e)
        {
            if (this.picImagem.Image != null)
            {
                var bmp = ImageUtilIts.RotacionarBitmap(new Bitmap(this.picImagem.Image),
                                            TypeRotacao.Graus90Horario);
                this.UpdateCurrentImage(bmp);

            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;

            //if (this._util.Imagens.Count > 0 && index - 1 >= 0)
            try
            {
                this.DigitalizacoesPath.RemoveAt(index);
                if (this.DigitalizacoesPath.Count < 1)
                {
                    this.picImagem.Image = null;
                    this.lblFileName.Text = "-";
                }
                else
                    showImage(index);

                this.barStaticPagesCount.Caption = this.DigitalizacoesPath.Count.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.DigitalizacoesPath.Clear();
            this.lblFileName.Text = "-";
            this.picImagem.Image = null;
            this.picImagem.Invalidate();
            this.barStaticPageIndex.Caption = "0";
            this.barStaticPagesCount.Caption = this.DigitalizacoesPath.Count.ToString();
        }

        private void cbExibicaoImagem_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Normal
            //Estender
            //Automático
            //Centralizado
            //Zoom
            switch (cbExibicaoImagem.SelectedIndex)
            {
                case 0:
                    picImagem.SizeMode = PictureBoxSizeMode.Normal; break;

                case 1:
                    picImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case 2:
                    picImagem.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;

                case 3:
                    picImagem.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;

                case 4:
                    picImagem.SizeMode = PictureBoxSizeMode.Zoom;
                    break;

                default:
                    picImagem.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            }
            picImagem.Refresh();
        }

        private void showImage(int index)
        {

            if (this.DigitalizacoesPath.Count > 0 && index - 1 >= 0)
            {
                try
                {
                    var path = this.DigitalizacoesPath[index - 1];

                    try
                    {
                        this.picImagem.Load(path);
                        this.lblFileName.Text = Path.GetFileName(path);
                        this.barStaticPageIndex.Caption = index.ToString();
                        this.picImagem.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        XMessageIts.ExceptionMessageDetails(ex, "Falha ao carregar imagem !");

                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }

        }

        /// <summary>
        /// SaveLayout as alteracoes na imagem
        /// </summary>
        private void setChangesImage()
        {
            try
            {
                //se houve alteracao
                var op = XMessageIts.Confirmacao("A imagem foi alterada!\nEfetivar alterações", "SaveLayout alterações");
                //pega o path da imagem q esta selecionada
                var path = this.picImagem.ImageLocation;
                //novo arquivo
                var fileName = Path.GetFileName(Path.GetTempFileName()) + ".jpeg";
                string novo = Path.GetTempPath() + "\\" + fileName;
                var img = this.picImagem.Image;

                img.Save(novo);

                if (File.Exists(novo))
                {
                    //indice da imagem alterada
                    var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;
                    //remove o arquivo atual
                    this.DigitalizacoesPath.RemoveAt(index);
                    //adiciona o novo
                    this.DigitalizacoesPath.Insert(index, novo);
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha ao efetivar alterações");
            }
        }

        private void setImagemPictureImage(string file)
        {
            if (file != null && File.Exists(file))
            {
                try
                {
                    //Carrega imagem no picture box e define a propriedade size da imagem como normal
                    this.picImagem.Load(file);

                    //informe no label
                    this.lblFileName.Text = Path.GetFileName(file);

                    //salva a referencia da imagem
                    this._util.AddImage(file);

                    //Retorna a lagura e altura da imagem
                    string imgSize = "Resolução: " + picImagem.Width + " x " + picImagem.Height;
                    lblResolucao.Text = imgSize;

                    //atualiza o indice da pagina
                    this.barStaticPageIndex.Caption = this.DigitalizacoesPath.Count.ToString();

                    //atualiza o numero de paginas
                    this.barStaticPagesCount.Caption = this.DigitalizacoesPath.Count.ToString();
                }
                catch (ArgumentException ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Falha na digitalização.");
                }

            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;
            showImage(index);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var index = ParseUtil.ToInt(barStaticPageIndex.Caption) + 1;
            showImage(index);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            showImage(1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            showImage(this.DigitalizacoesPath.Count);

        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            //coloque no modo normal
            if (cbExibicaoImagem.SelectedIndex != 0)
                this.cbExibicaoImagem.SelectedIndex = 0;

            //atualiza o label
            this.barStaticItemZoom.Caption = this.trackBarControl1.Value + "%";
            btnRedimensionar_Click(null, null);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (this.trackBarControl1.Value > this.trackBarControl1.Properties.Minimum)
            {
                this.trackBarControl1.Value = this.trackBarControl1.Value - 5;
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (this.trackBarControl1.Value < this.trackBarControl1.Properties.Maximum)
            {
                this.trackBarControl1.Value = this.trackBarControl1.Value + 5;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Digitalizacoes.Clear();
            this.IsCancelado = true;
            this.Dispose();
        }

        private void XFrmDigitalizacaoAvancada_SizeChanged(object sender, EventArgs e)
        {
            int pheight = this.Size.Height - 153;
            this.picImagem.Size = new Size(pheight - 150, pheight);
        }

        private void btnDigitalizarPara_Click(object sender, EventArgs e)
        {
            try
            {
                var file = PrinterUtilIts.ScanningTo();
                this.setImagemPictureImage(file);

            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Erro na digitalização");
            }
        }

        private void btnDigitalizarParaDisco_Click(object sender, EventArgs e)
        {
            PrinterUtilIts.ScanningToDisk();
        }
        private void XFrmDigitalizacaoAvancada_FormClosing(object sender, FormClosingEventArgs e)
        {
            var temp = Path.GetTempPath();
            try
            {
                var files = FileManagerIts.ToFiles(temp, new String[] { ".jpg", ".jpeg", ".tmp" });

                //files.ForEach(File.Delete);
                //usei o delegate pra lembra q ele existe
                files.ForEach(delegate (string file)
                {
                    File.Delete(file);
                });
            }
            catch
            {
                //Whatever apagando ou nao
            }
        }

        private void lblFileName_Click(object sender, EventArgs e)
        {

            try
            {
                string path = this.picImagem.ImageLocation;
                FileManagerIts.OpenFromSystem(Path.GetDirectoryName(path));
                FileManagerIts.OpenFromSystem(path);
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionMessage(ex);
            }

        }

        private void XFrmScanning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Add)
                btnZoomIn_Click(null, null);

            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Subtract)
                btnZoomOut_Click(null, null);
        }
    }
}