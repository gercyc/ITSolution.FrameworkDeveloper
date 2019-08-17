using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ITSolution.Framework.Util;
using System.IO;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Impressora;
using System.Collections.Generic;

/// <summary>
/// Carregar, digitalizar, visualizar e imprimir imagens
/// </summary>
namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmPrinterImage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Controlador
        private PrinterImageUtil util;

        public List<string> Files { get { return this.util.ImagesPath; } }

        public XFrmPrinterImage()
        {
            InitializeComponent();
            indexarImpressoraComboBox();

            openImage.Filter = ImageUtilIts.ImageFilter;
            this.util = new PrinterImageUtil();
        }

        public void Run()
        {
            this.ShowDialog();
        }

        private void indexarImpressoraComboBox()
        {
            cbImpressoras.Properties.Items.Clear();

            PrinterUtilIts.GetPrinters().ForEach(delegate (string impressora)
            {
                cbImpressoras.Properties.Items.Add(impressora);
            });
            cbImpressoras.SelectedIndex = 0;

        }

        private void showImage(int index)
        {

            if (this.Files.Count > 0 && index - 1 >= 0)
            {
                try
                {
                    var path = this.Files[index - 1];

                    try
                    {
                        this.picImagem.Load(path);
                        this.lblFileName.Text = path;
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

        private void addArquivo(string file)
        {
            if (file != null && File.Exists(file))
            {
                try
                {
                    this.util.ImagesPath.Add( file);

                    //Carrega imagem no picture box e define a propriedade size da imagem como normal
                    this.picImagem.Load(file);
                    this.Files.Add(file);
                    this.lblFileName.Text = file;

                    //atualiza o indice da pagina
                    this.barStaticPageIndex.Caption = this.Files.Count.ToString();

                    //atualiza o numero de paginas
                    this.barStaticPagesCount.Caption = this.Files.Count.ToString();
                }
                catch (ArgumentException ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Falha na digitalização.");
                }

            }
        }

        #region Eventos

        private void barBtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            var impressora = cbImpressoras.SelectedItem;
            
            util.PrintToOrSelect(impressora + "");

        }

        private void barBtnDigitalizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var file = PrinterUtilIts.Scanning();
                if (file != null)
                {
                    this.addArquivo(file);
                }
            }
            catch (Exception)
            {
                XMessageIts.Erro("Falha nos bytes da imagem");
            }
        }

        private void barBtnVisualizarImpressao_ItemClick(object sender, ItemClickEventArgs e)
        {

            var index = ParseUtil.ToInt(barStaticPageIndex.Caption);

            if (this.Files.Count > 0 && index - 1 >= 0)
            {
                try
                {
                    var file = this.Files[index - 1];
                    util.PrintView(file);

                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
            else
            {
                XMessageIts.Mensagem("Nada a ser visualizado");
            }
        }

        private void barBtnSelecionaArquivo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var op = openImage.ShowDialog();

            if (op == DialogResult.OK)
            {
                var files = this.openImage.FileNames;

                foreach (var file in files)
                {
                    this.addArquivo(file);
                }

            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            var index = ParseUtil.ToInt(barStaticPageIndex.Caption) - 1;
            showImage(index);
        }

        private void btnProximo_Click(object sender, EventArgs e)
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
            showImage(this.Files.Count);
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

        private void barBtnRemoveTodasImg_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Files.Clear();
            this.lblFileName.Text = "-";
            this.picImagem.Image = null;
            this.picImagem.Invalidate();
            this.barStaticPageIndex.Caption = "0";
            this.barStaticPagesCount.Caption = this.Files.Count.ToString();
        }

        private void barBtnRemoveImg_ItemClick(object sender, ItemClickEventArgs e)
        {
            var index = ParseUtil.ToInt(barStaticPageIndex.Caption);

            if (this.Files.Count > 0 && index - 1 >= 0)
            {
                try
                {
                    this.Files.RemoveAt(index - 1);

                    if (this.Files.Count < 1)
                    {
                        this.picImagem.Image = null;
                        this.lblFileName.Text = "-";
                    }
                    else
                        showImage(index - 1);

                    this.barStaticPagesCount.Caption = this.Files.Count.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
        }

        private void barBtnDigitalizacaoAvanc_ItemClick(object sender, ItemClickEventArgs e)
        {
            new XFrmScanning().ShowDialog();
        }


        #endregion Eventos
    }
}