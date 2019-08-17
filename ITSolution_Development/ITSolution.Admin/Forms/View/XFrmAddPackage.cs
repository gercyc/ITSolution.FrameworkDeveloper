using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Admin.Entidades.DaoManager;
using ITSolution.Framework.Util;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Arquivos;
using ITSolution.Admin.Entidades.TaskManager;
using ITSolution.Framework.Beans.Forms;

namespace ITSolution.Admin.Forms.View
{
    public partial class XFrmAddPackage : XtraForm
    {
        private readonly Package _pacote;
        private TaskPackageManager _taskPackageManager;
        private List<AnexoPackage> _anexos;

        public XFrmAddPackage()
        {
            InitializeComponent();
            _taskPackageManager = new TaskPackageManager();
            _anexos = new List<AnexoPackage>();
        }

        //edição
        public XFrmAddPackage(Package pacote) : this()
        {
            this._pacote = pacote;
            this._anexos = pacote.Anexos.ToList();

            indexarDadosFormulario(pacote);

            this.lblDtPublicacao.Visible = true;
            this.dtEditPublicacao.Visible = true;
        }

        #region Metodos

        private Package indexarPacote()
        {
            var numero = String.Format("{0:000000000}", ParseUtil.ToInt(txtNumPacote.Text)); ;
            DateTime? dtPublicacao = dtEditPublicacao.DateTime;
            if (!DataUtil.IsValidDate(dtPublicacao))
                dtPublicacao = null;

            var dtCriacao = DateTime.Now;
            var descricao = memDescPacote.Text;
            var sintoma = memSintoma.Text;
            var tratamento = memTratamento.Text;
            var novo = new Package(numero, dtCriacao, descricao, sintoma, tratamento, _anexos, dtPublicacao);
            if (_pacote != null)
            {
                novo.IdPacote = _pacote.IdPacote;
            }
            return novo;
        }

        private void indexarDadosFormulario(Package pacote)
        {
            txtNumPacote.Text = pacote.NumeroPacote;
            memDescPacote.Text = pacote.Descricao;
            memSintoma.Text = pacote.Sintoma;
            memTratamento.Text = pacote.Tratamento;
            txtStatus.Text = pacote.Status.ToString();
            txtStatus.Visible = true;
            lbStatus.Visible = true;

            gridControlAnexos.DataSource = this._anexos = pacote.Anexos.ToList();

            gridViewAnexos.RefreshData();
            if (pacote.DataPublicacao != null)
                dtEditPublicacao.DateTime = pacote.DataPublicacao.Value;
        }

        private void refreshGridAnexos()
        {
            gridControlAnexos.DataSource = _anexos;
            gridViewAnexos.RefreshData();

            if (_anexos.Count == 0)
                this.memDescPacote.Text = "";
        }

        #endregion

        #region Eventos 
        private void barBtnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var novo = indexarPacote();
            //edição
            if (this._pacote != null)
            {
                if (new PackageDaoManager().UpdatePackage(novo))
                    XMessageIts.Mensagem("Pacote atualizado com sucesso!");
                //update eu não fecho o form
            }
            //criacao
            else
            {
                if (new PackageDaoManager().SavePackage(novo))
                {
                    XMessageIts.Mensagem("Pacote criado com sucesso!");
                    this.Dispose(); //fechar o form
                }
            }
        }

        private void XFrmAddPacote_Shown(object sender, EventArgs e)
        {
            if (_pacote == null)
            {
                txtNumPacote.Text = new PackageDaoManager().GeneratePackageNumber();
            }
        }

        private void cbAuxUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbAuxUpdate.SelectedIndex;
            //Atualização de DLLs ITE
            //Atualização de DLLs ITSolution
            //Atualização de DLLs ITE/ITSolution
            //Criação de procedures
            //Atualização de procedures
            //Atualização de tabela
            //Script de inserção de dados
            //Script de inserção base do sistema
            //Cria enums interno
            string path = "";

            switch (index)
            {
                case 0:

                    memDescPacote.Text += "Atualização de DLLs ITE\n\r";
                    path = _taskPackageManager.GeneratePackageITEDLLs();
                    addPackageGridView(path);
                    break;
                case 1:
                    memDescPacote.Text += "Atualização de DLLs ITSolution\n\r";

                    path = _taskPackageManager.GeneratePackageITSolutionDLLs();

                    addPackageGridView(path);
                    break;

                case 2:

                    memDescPacote.Text += "Atualização de DLLs ITSolution\n\r";
                    path = _taskPackageManager.GeneratePackageSystemDLLs();
                    addPackageGridView(path);
                    break;


                case 3:
                    memDescPacote.Text += "Criação de procedures\n\r";
                    path = _taskPackageManager.GeneratePackageProcedures();
                    addPackageGridView(path);
                    break;
                case 4:

                    memDescPacote.Text += "Atualização de procedures\n\r";
                    path = _taskPackageManager.GeneratePackageProcedures();
                    addPackageGridView(path);
                    break;

                default:
                    if (cbAuxUpdate.SelectedIndex > 0)
                        memDescPacote.Text = memDescPacote.Text + "\r\n" + cbAuxUpdate.SelectedItem.ToString();
                    break;

            }
            memSintoma.Text = "Pacote de correções";
            memTratamento.Text = "Alterações e melhorias";
        }

        private void addPackageGridView(string path)
        {
            this._anexos.Add(new AnexoPackage(path));
            this.gridControlAnexos.DataSource = this._anexos;
            //gridViewAnexos.RefreshData();
            refreshGridAnexos();
        }

        private void gridViewAnexos_DoubleClick(object sender, EventArgs e)
        {
            barBtnViewAttach_ItemClick(null, null);
        }

        #endregion

        #region Bar Standalone
        private void barBtnAddAttach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (openFileAnexo.ShowDialog() == DialogResult.OK)
            {
                var path = openFileAnexo.FileName;

                this._anexos.Add(new AnexoPackage(path));

                if (string.IsNullOrEmpty(memDescPacote.Text))
                    this.memDescPacote.Text = this._anexos.Last().IdentificacaoAnexo;
                else
                {
                    this.memDescPacote.Text = this.memDescPacote.Text + "\n\r" + this._anexos.Last().IdentificacaoAnexo;
                }
                refreshGridAnexos();
            }
        }

        private void barBtnRemoveAttach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewAnexos.DeleteSelectedRows();
            refreshGridAnexos();
        }

        private void barBtnViewAttach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewAnexos.IsSelectOneRowWarning())
            {
                var row = gridViewAnexos.GetFocusedRow<AnexoPackage>();

                if (row != null)
                {
                    //evita um nome duplicado
                    string file = FileManagerIts.GetTempFile(row.PathFile);
                    FileManagerIts.DeleteFile(file);
                    FileManagerIts.WriteBytesToFile(file, row.DataFile);

                    if (file.EndsWith(".sql"))
                    {
                        var high = new XFrmHighlighting(file, ScintillaNET.Lexer.Sql);
                        high.ShowDialog();

                        if (high.IsTextSave)
                        {
                            row.DataFile = FileManagerIts.GetBytesFromFile(file);
                        }
                    }
                    else
                        //deixe o sistema se virar
                        FileManagerIts.OpenFromSystem(file);

                }
            }
        }
        private void barBtnExportarTo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewAnexos.IsSelectOneRowWarning())
            {
                var anexo = gridViewAnexos.GetFocusedRow<AnexoPackage>();

                string ext = anexo.Extensao;
                //Text Files (*.txt)|*.txt|
                saveFileDialog1.Filter = "ITE Solution Attach (*" + ext + ")| *" + ext;

                saveFileDialog1.FileName = anexo.FileName;
                var op = saveFileDialog1.ShowDialog();


                if (op == DialogResult.OK)
                {

                    if (FileManagerIts.WriteBytesToFile(saveFileDialog1.FileName, anexo.DataFile))
                    {
                        XMessageIts.Mensagem("Arquivo salvo com sucesso!");
                    }
                    else
                    {
                        XMessageIts.Erro("Erro na exportação do relatório!");
                    }
                }
            }

        }

        #endregion

    }

}