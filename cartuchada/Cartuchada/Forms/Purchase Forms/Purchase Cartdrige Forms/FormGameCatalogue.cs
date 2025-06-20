﻿
using _3_Data.Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Repository.Query_Objects;
using Microsoft.Extensions.DependencyInjection;

namespace Cartuchada.Forms.Purchase_Forms.Purchase_Cartdrige_Forms
{
    public partial class FormGameCatalogue : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly FilterGameCatalogueQuery _filterGameCatalogueQuery;
        private readonly GetAllSoldOrSpottedUniqueGameIdsQuery _getAllSoldOrSpottedUniqueGameIdsQuery;

        private IEnumerable<GameCatalogueModel> _filteredGames;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormGameCatalogue(FilterGameCatalogueQuery filterGameCatalogueQuery,
            IServiceProvider serviceProvider,
            GetAllSoldOrSpottedUniqueGameIdsQuery getAllSoldOrSpottedUniqueGameIdsQuery)
        {
            InitializeComponent();
            _filterGameCatalogueQuery = filterGameCatalogueQuery;
            _serviceProvider = serviceProvider;
            _getAllSoldOrSpottedUniqueGameIdsQuery = getAllSoldOrSpottedUniqueGameIdsQuery;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormPurchaseCartdrige_Load(object sender, EventArgs e)
        {
            CreateColumns();
        }

        private void CreateColumns()
        {
            dgv_gameCatalogue.AutoGenerateColumns = false;
            dgv_gameCatalogue.Columns.Clear();
            dgv_gameCatalogue.DefaultCellStyle.SelectionBackColor = dgv_gameCatalogue.DefaultCellStyle.BackColor;
            dgv_gameCatalogue.DefaultCellStyle.SelectionForeColor = dgv_gameCatalogue.DefaultCellStyle.ForeColor;

            var purchaseButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colPurchase",
                Text = "Comprar",
                UseColumnTextForButtonValue = true,
                Width = 79
            };
            purchaseButtonColumn.DefaultCellStyle.BackColor = Color.LimeGreen;
            purchaseButtonColumn.DefaultCellStyle.SelectionBackColor = Color.LimeGreen;
            dgv_gameCatalogue.Columns.Add(purchaseButtonColumn);

            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                DataPropertyName = "Id",
                Name = "colId",
                Width = 45
            };
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_gameCatalogue.Columns.Add(idColumn);

            dgv_gameCatalogue.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 580
            });

            var infoColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colInfo",
                Text = "+ Info",
                UseColumnTextForButtonValue = true,
                Width = 45
            };
            dgv_gameCatalogue.Columns.Add(infoColumn);

            var spotButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colSpot",
                Text = "Spot",
                UseColumnTextForButtonValue = true,
                Width = 45
            };
            spotButtonColumn.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            spotButtonColumn.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv_gameCatalogue.Columns.Add(spotButtonColumn);
        }

        private async Task RefreshColumns()
        {
            int gamesCount = _filteredGames.Count();
            AdjustTableSize(gamesCount);

            dgv_gameCatalogue.DataSource = _filteredGames;

            await HighlightInfoButtonsForSoldOrSpottedGamesAsync();
        }

        private void AdjustTableSize(int gamesCount)
        {
            if (gamesCount > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }

        public async Task HighlightInfoButtonsForSoldOrSpottedGamesAsync()
        {
            HashSet<int> soldOrSpottedUniqueGameIds = await _getAllSoldOrSpottedUniqueGameIdsQuery.ExecuteQueryAsync();

            foreach (DataGridViewRow row in dgv_gameCatalogue.Rows)
            {
                int currentIdGame = (int)row.Cells["colId"].Value;

                if (!soldOrSpottedUniqueGameIds.Contains(currentIdGame)) { continue; }

                var cell = row.Cells["colInfo"];
                cell.Style.BackColor = Color.PapayaWhip;
                cell.Style.SelectionBackColor = Color.PapayaWhip;
            }
        }



        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- SEARCH TEXTBOX -----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;

                string input = txt_search.Text;
                if (string.IsNullOrWhiteSpace(input)) { return; }

                await FilterGameCAtalogueAsync();
            }
        }

        private async Task FilterGameCAtalogueAsync()
        {
            string filter = txt_search.Text;
            var filteredGames = await _filterGameCatalogueQuery.ExecuteQueryAsync(filter);

            _filteredGames = filteredGames;

            await RefreshColumns();
        }


        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------- PURCHASE / INFO / SPOT BUTTON --------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void dgv_gameCatalogue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            string gameName = dgv_gameCatalogue.Rows[e.RowIndex].Cells["colName"].Value.ToString();
            var gameModel = _filteredGames.FirstOrDefault(g => g.Name == gameName);

            var cartdrigePurchaseDto = new CartdrigePurchaseDto
            {
                IdProductType = gameModel.IdProductType,
                IdGame = gameModel.Id,
                Name = gameModel.Name,
                JAP = gameModel.JAP,
                NA = gameModel.NA,
                PAL = gameModel.PAL,
                ProductType = gameModel.ProductType.Name
            };

            // PURCHASE:
            if (dgv_gameCatalogue.Columns[e.ColumnIndex].Name == "colPurchase")
            {
                var frm = _serviceProvider.GetRequiredService<FormPurchaseSpotCartdrige>();
                frm.SetInfo(cartdrigePurchaseDto);
                frm.ShowDialog();

                txt_search.Focus();
            }
            // INFO:
            else if (dgv_gameCatalogue.Columns[e.ColumnIndex].Name == "colInfo")
            {
                this.Hide();

                var frm = _serviceProvider.GetRequiredService<FormRecommendedCartdrigePrice>();
                frm.Location = new Point(this.Location.X, this.Location.Y);
                frm.SetInfo(cartdrigePurchaseDto);
                frm.ShowDialog();

                if (frm.IsClosing) 
                {
                    _isClosing = true;
                    return; 
                }

                this.Location = new Point(frm.Location.X, frm.Location.Y);
                this.Show();
            }
            // SPOT:
            else if (dgv_gameCatalogue.Columns[e.ColumnIndex].Name == "colSpot")
            {
                var frm = _serviceProvider.GetRequiredService<FormPurchaseSpotCartdrige>();
                frm.IsSpotting = true;
                frm.SetInfo(cartdrigePurchaseDto);
                frm.ShowDialog();

                txt_search.Focus();
            }
        }





        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- BACK ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormPurchaseCartdrige_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _isClosing = true;
                Application.Exit();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
