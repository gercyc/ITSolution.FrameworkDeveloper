using BoletoNet;
using ITSolution.Framework.Ticket.Bancos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ITSolution.Framework.Enumeradores;

namespace ITSolution.Framework.Ticket
{
    /// <summary>
    /// Geração de boleto bancário
    /// 
    /// Deus ta vendo => Há sofrer
    /// </summary>
    public partial class XFrmBoleto_DEV : DevExpress.XtraEditors.XtraForm
    {
        private readonly XFrmViewBoleto  xFrmBoletoView;
        private XFrmProgressBoleto xFrmProgressBoleto;
        private string pathLayout;
        private bool boletoValidado;
        private AbstractBank banco;

        public XFrmBoleto_DEV()
        {
            InitializeComponent();
            this.dtEditVencimento.DateTime = DateTime.Now.AddDays(6);
            this.radioGroupCedente.SelectedIndex = 0;
            this.radioGroupSacado.SelectedIndex = 0;
            this.xFrmBoletoView = new XFrmViewBoleto ();

            this.cepControlSacado.AddController(txtCidade, txtUf);

            this.cpfCnpjControlCedente.AddController(this.txtNomeCedente);
            this.cpfCnpjControlSacado.AddController(this.txtNomeSacado);
            testeArdocolor();

        }

        private void testeArdocolor()
        {
            //sacado
            txtNomeSacado.Text = "FILIPE REZENDE CAMPOS";
            txtEndereco.Text = "Rua Manoel Pinto";
            txtBairro.Text = "Centro";
            cepControlSacado.TextCep.Text = "35669-000";
            txtValorBoleto.Text = "500";
            this.dtEditVencimento.DateTime = DateTime.Now;
            cpfCnpjControlSacado.MaskedTxtCpfCnpj.Text = "108.849.726-82";

            //cedente

            radioGroupCedente.SelectedIndex = 1;
            cpfCnpjControlCedente.MaskedTxtCpfCnpj.Text = "03.644.644/0001-00";
            txtNomeCedente.Text = "ARDOCOLOR DO BRASIL LTDA ME";
            txtAgencia.Text = "3159";
            txtNumeroConta.Text = "1289";
            txtDvConta.Text = "0";
            this.txtCodigoCedente.Text = "000000000220942";


            this.txtNumeroDocumento.Text = "MAB00000001";
            this.txtNossoNumero.Text = "81372379067";

        }

        #region Metodos

        private Cedente getCedente()
        {
            string cpfCnpj = cpfCnpjControlCedente.MaskedTxtCpfCnpj.Text;
            string nome = txtNomeCedente.Text;
            string agencia = txtAgencia.Text;
            string conta = txtNumeroConta.Text + txtDvConta.Text;
            string codCendete = txtCodigoCedente.Text;
            var ced = new Cedente(cpfCnpj, nome, agencia, conta);
            ced.Codigo = codCendete;
            return ced;
        }
        private Sacado getSacado()
        {

            var cpfCnpj = cpfCnpjControlSacado.Text;
            var nome = txtNomeSacado.Text;
            var end = getEndereco();

            //sacado.Endereco.End = end.End + "," + end.Numero;
            //sacado.Endereco.Bairro = end.Bairro;
            //sacado.Endereco.Cidade = end.Cidade;
            //sacado.Endereco.CEP = end.CEP;
            //sacado.Endereco.UF = end.UF;

            return new Sacado(cpfCnpj, nome, end);
        }
        private Endereco getEndereco()
        {
            Endereco end = new Endereco();

            end.End = txtEndereco.Text;
            end.Numero = "0";
            end.Bairro = txtBairro.Text;
            end.Cidade = txtCidade.Text;
            end.UF = txtUf.Text;

            end.CEP = cepControlSacado.Text;

            return end;
        }
        private void gerarBoletosBancario(AbstractBank banco)
        {
            this.banco = banco;
            try
            {
                decimal valorBoleto = ParseUtil.ToDecimal(txtValorBoleto.Text);
                string nossoNumero = txtNossoNumero.Text;
                string numeroDocumento = txtNumeroDocumento.Text;
                string instrucoes = memoInstrucoes.Text.ToUpper();
                DateTime vencimento = dtEditVencimento.DateTime;
                var cedente = getCedente();
                var sacado = getSacado();
                int qtde = ParseUtil.ToInt(spinEditQuantidade.Value);

                //cria os boletos
                banco.CreateBoletos(qtde, vencimento, valorBoleto,
                    nossoNumero, numeroDocumento, cedente, sacado, instrucoes);

                //criar o layout do boleto 
                pathLayout = BoletoUtil.GenerateTicketLayout(banco.BoletosBancario);

                this.boletoValidado = true;

                //BoletoUtil.ShowBoletoPDF(banco.BoletosBancario[0]);

            }
            catch (Exception ex)
            {
                this.boletoValidado = false;
                this.backgroundWorker.CancelAsync();
                Console.WriteLine(ex);
            }
        }

        #endregion

        #region Eventos
        private void btnGerarBoleto_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker.IsBusy)
                XMessageIts.Mensagem("Boleto sendo gerado aguarde");
            else
            {
                this.backgroundWorker.RunWorkerAsync();
                this.xFrmProgressBoleto = new XFrmProgressBoleto();
                this.xFrmProgressBoleto.ShowDialog();

            }
        }

        private void radioGroupCedente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroupCedente.SelectedIndex == (int)TypeClassificaoCliente.Cliente)
            {
                cpfCnpjControlCedente.SetMaskCPF();
            }
            else
            {
                cpfCnpjControlCedente.SetMaskCNPJ();
            }
        }

        private void radioGroupSacado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroupSacado.SelectedIndex == (int)TypeClassificaoCliente.Cliente)
            {
                cpfCnpjControlSacado.SetMaskCPF();
            }
            else
            {
                cpfCnpjControlSacado.SetMaskCNPJ();
            }
        }

        #endregion

        #region BackgroundWorker

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var index = (TypeCodigoBanco)radioGroupBancos.SelectedIndex;

            switch (index)
            {
                case TypeCodigoBanco.BancoBrasil:
                    gerarBoletosBancario(new BancoBrasil());
                    break;

                case TypeCodigoBanco.BancoBancoob:
                    gerarBoletosBancario(new BancoBancoob());
                    break;

                case TypeCodigoBanco.BancoReal:
                    gerarBoletosBancario(new BancoReal());
                    break;


                case TypeCodigoBanco.BancoBradesco:
                    gerarBoletosBancario(new BancoBradesco());
                    break;

                case TypeCodigoBanco.Caixa:
                    gerarBoletosBancario(new BancoCaixa());
                    break;

                case TypeCodigoBanco.HSBC:
                    gerarBoletosBancario(new BancoHSBC());
                    break;

                case TypeCodigoBanco.Itau:
                    gerarBoletosBancario(new BancoItau());
                    break;

                case TypeCodigoBanco.Safra:
                    gerarBoletosBancario(new BancoSafra());
                    break;

                case TypeCodigoBanco.Sudameris:
                    gerarBoletosBancario(new BancoSudameris());
                    break;

                default:
                    XMessageIts.Mensagem("Banco não selecionado", "Aviso");
                    return;
            }


        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //encerra o progress
                this.xFrmProgressBoleto.Dispose();

                if (this.boletoValidado)
                {
                    // Cria um formulário com um componente WebBrowser
                     this.xFrmBoletoView.ShowBoleto(pathLayout);
                    this.xFrmBoletoView.ShowDialog();

                    foreach (var bb in banco.BoletosBancario)
                    {

                        BoletoUtil.ShowBoletoHtml(bb);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        #endregion

        #region Enum
        private enum TypeCodigoBanco
        {

            BancoBrasil = 0,
            BancoReal = 1,
            BancoBradesco = 2,
            Caixa = 3,
            Itau = 4,
            HSBC = 5,
            Safra = 6,
            Sudameris = 7,
            BancoBancoob = 8
        }
        #endregion
    }
}
