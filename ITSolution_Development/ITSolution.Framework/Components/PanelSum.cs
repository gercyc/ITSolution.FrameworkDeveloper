using System;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ITSolution.Framework.Eventos.GridViewEvents;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Components
{
    public partial class PanelSum : PanelControl
    {
        /// Contagem de células ( Cálculo da média ).
        private long contagemDeCalculo;
        /// Contagem de células selecionadas ( Contagem Visual ).
        private long contagem;
        /// Média a ser calcula a partir da somatória.
        private Decimal media;
        /// Somátorio do cálculo das células selecionadas.
        private Decimal soma;

        public PanelSum()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adicionar o controle do somatório no gridControl
        /// Vincular os eventos no gridControl e gridView - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// <param name="gridControl"></param>GridControl
        /// <param name="gridView"></param>GridView
        public void AddSomatorio(GridControl gridControl, GridView gridView)
        {

            this.gridControl = gridControl;
            this.gridView = gridView;
            if (this.gridControl != null && this.gridView != null)
            {
                // 
                // gridControl garante que o grid se preencha automaticamente na tela
                // 
                this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                 | System.Windows.Forms.AnchorStyles.Left)
                 | System.Windows.Forms.AnchorStyles.Right)));

                // 
                // gridView ativa a selecao de multiplas de celulas na tabela
                // 
                this.gridView.OptionsSelection.MultiSelect = true;
                this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;

                //sempre q mudar de celula capture as celulas selecionadas
                this.gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_SelectionChanged);

                //toda vez q a celula foi alterada
                this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);

                //pinte os valores das celulas tipo decimal de vermelho
                RowCellStyleEvent.AddPaintCellDecimalValue(gridView);

                //atualiza o somatorio qndo o numero de linhas mudar
                this.gridView.RowCountChanged += new System.EventHandler(this.gridView_RowCountChanged);

            }
        }

        /// <summary>
        ///Seta o cálculo das células selecionadas no label
        /// Calculo em tempo de execução á medida em que as células são selecionadas.
        /// </summary>
        public void Somatorio()
        {
            //atualiza a barra
            AtualizarSomatorio();

            var selectedCells = gridView.GetSelectedCells();

            //se houver uma célula selecionada
            if (selectedCells != null)
            {
                //percorrer a array de celulas selecionadas 
                foreach (GridCell item in selectedCells)
                {
                    string columnName = item.Column.FieldName;
                    int index = item.RowHandle;

                    //numero de linhas e colunas selecionadas
                    contagem++;
                    //pega o valor linha selecionada e coluna especifica
                    var valueAt = gridView.GetRowCellValue(index, columnName);

                    if (valueAt != null)
                        //pegue o valores específicos para cálculo
                        if (ParseUtil.InstanceOfDecimal(valueAt) ||
                            ParseUtil.InstanceOfDouble(valueAt) ||
                            ParseUtil.InstanceOfFloat(valueAt) ||
                            ParseUtil.InstanceOfLong(valueAt) ||
                            ParseUtil.InstanceOfInt(valueAt))
                        {

                            //FlyoutPanelSomatorio
                            soma += ParseUtil.ToDecimal(valueAt);

                            //contagem para cálculo da média separada para os tipos de objetos especificos
                            contagemDeCalculo++;


                        }

                }
            }

            //cacule a media somente se 
            if (contagemDeCalculo > 0)
            {
                try
                {
                    media = soma / contagemDeCalculo;
                }
                catch (DivideByZeroException)
                {
                    media = 0;
                }
            }

            //seta a media calculada
            lblMedia.Text = media.ToString("N2");

            //a contagem eh o numero de linhas e colunas selecionadas percorridas no laco total
            lblContagem.Text = contagem.ToString("N2");

            //seta a soma
            lblSoma.Text = soma.ToString("N2");
        }

        /// Zera os valores do somatório.
        ///
        ///contagem
        /// media
        ///somátorio com o valor 0.0.
        public void AtualizarSomatorio()
        {

            this.contagem = 0L;
            this.contagemDeCalculo = 0L;
            this.media = 0.0m;
            this.soma = 0.0m;

            //zera a media 
            lblMedia.Text = media.ToString("N2");
            //zera contagem 
            lblContagem.Text = contagem.ToString("N2");
            //zera a soma
            lblSoma.Text = soma.ToString("N2");

        }
        /// <summary>
        /// Disparado ao iniciar o GridControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    //pinte os valores das celulas tipo decimal de vermelho
        //    XGridViewUtil.PaintCellDecimalValue(e);

        //}

        #region Eventos do gridview

        /// <summary>
        /// Ação de mudar de celula.
        /// Seta o calculo do somatório das células selecionadas nos labels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            this.Somatorio();
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.Somatorio();
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            this.Somatorio();
        }

        #endregion Eventos do gridview

    }
}
