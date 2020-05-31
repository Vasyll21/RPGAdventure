using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Engine;

namespace RPGAdventure
{
    public partial class RPGAdventure : Form
    {
        private Player player;

        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";

        public RPGAdventure()
        {
            InitializeComponent();
            //Створення стартового повідомлення з привітанням і вибору нової гри чи продовження минулої гри
            DialogResult result = MessageBox.Show(
                 "Welcome in RPGAdventure. This program was made by a student of the group PK-41 Kyrychenko V.P. Do you want to continue previous game?",
                 "Welcome!",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
            //вигрузка даних пресонажа з файлу
            if (result == DialogResult.Yes)
            {
                if (File.Exists(PLAYER_DATA_FILE_NAME))
                {
                    player = Player.CreatePlayerFromXmlString(File.ReadAllText(PLAYER_DATA_FILE_NAME));
                }
                else
                {
                    player = Player.CreateDefaultPlayer();
                }
            }
            //створення нової гри
            else
            {
                player = Player.CreateDefaultPlayer();
            }
            //прикріплення зміни кількості здоров'я, грошей, рівня, досвіду до класу Player.cs
            lbHP.DataBindings.Add("Text", player, "CurrentHP");
            lbGold.DataBindings.Add("Text", player, "Gold");
            lbExp.DataBindings.Add("Text", player, "ExpPoint");
            lbLevel.DataBindings.Add("Text", player, "Level");
            //прикріплення зміни предметів у сумці персонажа до класу Player.cs
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoGenerateColumns = false;

            dgvInventory.DataSource = player.Inventory;

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Description"
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });
            //прикріплення зміни завдань персонажа до класу Player.cs
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.AutoGenerateColumns = false;

            dgvQuests.DataSource = player.Quests;

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Name"
            });

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Done?",
                DataPropertyName = "IsCompleted"
            });
            //прикріплення зміни зброї персонажа до класу Player.cs
            cbWeapons.DataSource = player.Weapons;
            cbWeapons.DisplayMember = "Name";
            cbWeapons.ValueMember = "Id";

            if (player.CurrentWeapon != null)
            {
                cbWeapons.SelectedItem = player.CurrentWeapon;
            }

            cbWeapons.SelectedIndexChanged += cbWeapons_SelectedIndexChanged;
            //прикріплення зміни цілющих зіль персонажа до класу Player.cs
            cbPotions.DataSource = player.Potions;
            cbPotions.DisplayMember = "Name";
            cbPotions.ValueMember = "Id";

            player.PropertyChanged += PlayerOnPropertyChanged;
            player.OnMessage += DisplayMessage;

            player.MoveTo(player.CurrentLocation);
        }
        //прикріплення події відображення повідомлення у компонентах RichTextBox до класу Player.cs
        private void DisplayMessage(object sender, MessageEventArgs messageEventArgs)
        {
            rtbMessages.Text += messageEventArgs.Message + Environment.NewLine;

            if (messageEventArgs.AddExtraNewLine)
            {
                rtbMessages.Text += Environment.NewLine;
            }

            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }
        //прикріплення події зміни властивостей з класу Player.cs
        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Weapons")
            {
                cbWeapons.DataSource = player.Weapons;

                if (!player.Weapons.Any())
                {
                    cbWeapons.Visible = false;
                    btnUseWeapon.Visible = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "Potions")
            {
                cbPotions.DataSource = player.Potions;

                if (!player.Potions.Any())
                {
                    cbPotions.Visible = false;
                    btnUsePotion.Visible = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "CurrentLocation")
            {
                btnNorth.Visible = (player.CurrentLocation.LocationToNorth != null);
                btnEast.Visible = (player.CurrentLocation.LocationToEast != null);
                btnSouth.Visible = (player.CurrentLocation.LocationToSouth != null);
                btnWest.Visible = (player.CurrentLocation.LocationToWest != null);
                btnTrade.Visible = (player.CurrentLocation.VendorWorkingHere != null);

                rtbLocation.Text = player.CurrentLocation.Name + Environment.NewLine;
                rtbLocation.Text += player.CurrentLocation.Description + Environment.NewLine;

                if (player.CurrentLocation.EnemyLivingHere == null)
                {
                    cbWeapons.Visible = false;
                    cbPotions.Visible = false;
                    btnUseWeapon.Visible = false;
                    btnUsePotion.Visible = false;
                }
                else
                {
                    cbWeapons.Visible = player.Weapons.Any();
                    cbPotions.Visible = player.Potions.Any();
                    btnUseWeapon.Visible = player.Weapons.Any();
                    btnUsePotion.Visible = player.Potions.Any();
                }
            }
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            player.MoveNorth();
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            player.MoveEast();
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            player.MoveSouth();
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            player.MoveWest();
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

            Weapon currentWeapon = (Weapon)cbWeapons.SelectedItem;

            player.UseWeapon(currentWeapon);

            if (player.dead == true)
            {
                DialogResult result = MessageBox.Show(
                    "You dead! Thanks for playing",
                    "YOU DEAD!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            HealingPotion potion = (HealingPotion)cbPotions.SelectedItem;
        
            player.UsePotion(potion);

            if (player.dead == true)
            {
                DialogResult result = MessageBox.Show(
                    "You dead! Thanks for playing",
                    "YOU DEAD!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if(result==DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void RPGAdventure_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PLAYER_DATA_FILE_NAME, player.ToXmlString());
        }

        private void cbWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            player.CurrentWeapon = (Weapon)cbWeapons.SelectedItem;
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen(player);
            tradeScreen.StartPosition = FormStartPosition.CenterParent;
            tradeScreen.ShowDialog(this);
        }

        
    }
}
