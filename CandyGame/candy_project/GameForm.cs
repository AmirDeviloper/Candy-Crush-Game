using candy_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace candy_project
{
    public partial class GameForm : Form
    {
        private PictureBox[,] _buttons;
        private Game _game;
        private PictureBox clicked_btn1, clicked_btn2;

        int clicked = 0;
        DateTime now = DateTime.Now;
        public GameForm()
        {
            InitializeComponent();
            _game = null;
            _buttons = new PictureBox[7, 7];
        }

        private void InitBoard()
        {
            int first_x = 56;
            int first_y = 80;

            for (int i = 0; i < _game.BoardSize; i++)
            {
                for (int j = 0; j < _game.BoardSize; j++)
                {
                    var pictureBox = new PictureBox();
                    pictureBox.Location = new Point(first_x, first_y);
                    pictureBox.Name = $"{i}{j}".ToString();
                    pictureBox.AccessibleName = $"{i}{j}".ToString();

                    pictureBox.Size = new Size(50, 50);
                    Random rnd = new Random();
                    pictureBox.Image = _game[i, j].Image().Image;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    first_x += 56;
                    pictureBox.Visible = true;

                    pictureBox.Click += PictureBox_Click;
                    _buttons[i, j] = pictureBox;
                    Controls.Add(_buttons[i, j]);
                }
                first_x = 56;
                first_y += 56;

            }
        }

        private void UpdateButtonsColor()
        {
            for (int i = 0; i < _game.BoardSize; i++)
            {
                for (int j = 0; j < _game.BoardSize; j++)
                {
                    _buttons[i, j].Image = _game[i, j].Image().Image;
                }
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }
        private List<string> GetNeighbours(int i, int j)
        {
            var neighbors = new List<string>();

            neighbors.Add($"{i + 1}{j}");
            neighbors.Add($"{i - 1}{j}");
            neighbors.Add($"{i}{j + 1}");
            neighbors.Add($"{i}{j - 1}");

            neighbors.RemoveAll(n => n.Contains("7"));
            
            return neighbors;
        }

        private void ResetClickedButtons()
        {
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                pictureBox.BorderStyle = BorderStyle.None;
            }
        }
        private Point ArrayPosition(string buttonName)
        {
            int row = int.Parse(buttonName[0].ToString());
            int col = int.Parse(buttonName[1].ToString());

            return new Point(row, col);
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
            var total_seconds = Math.Round((DateTime.Now - now).TotalSeconds);
            timer_label.Text = $"Total Times Left: {total_seconds.ToString("0000")}";
            if (_game.isLose((int)total_seconds))
            {
                game_timer.Enabled = false;
                EndGame(Color.DarkRed, "You Lose");
            }

            if (_game.isWin())
            {
                game_timer.Enabled = false;
                EndGame(Color.Lime, "You Win");
            }
        }

        private void EndGame(Color color, string message)
        {
            timer_label.Enabled = false;

            foreach (var button in Controls.OfType<Button>())
            {
                button.BackColor = color;
                button.Enabled = false;
            }
            MessageBox.Show(message);

        }
        
        private void StartNewGame()
        {
            _game = new Game(7, (int)point_value.Value, (int)time_value.Value, new Player());
            _game.GenerateCandies();
            InitBoard();

        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            start_btn.Enabled = false;
            time_value.Enabled = point_value.Enabled = false;
            StartNewGame();
            game_timer.Start();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            foreach (var button in _buttons)
                button.Dispose();

            StartNewGame();
        }

        private async void PictureBox_Click(object sender, EventArgs e)
        {
            var btn = (PictureBox)sender;
            
            btn.BorderStyle = BorderStyle.Fixed3D;
            

            if (clicked == 0)
            {
                clicked++;
                clicked_btn1 = ((PictureBox)sender);
            }

            else if (clicked == 1)
            {
                clicked_btn2 = ((PictureBox)sender);

                var point_2 = ArrayPosition(clicked_btn2.Name);
                var neighbours = GetNeighbours(point_2.X, point_2.Y);

                foreach (var neighbor in neighbours)
                {
                    if (neighbor == clicked_btn1.AccessibleName) 
                    {
                        var temp = clicked_btn1.Image;
                        clicked_btn1.Image = clicked_btn2.Image;
                        clicked_btn2.Image = temp;

                        var point_1 = ArrayPosition(clicked_btn1.Name);

                        _game.Swap(point_1.X, point_1.Y, point_2.X, point_2.Y);
                        _game.CheckAllCandies();
                        await Task.Delay(1000);
                        UpdateButtonsColor();
                        break;
                    }
                }

                point_label.Text = $"Points: {_game.CurrentScore}";
                clicked = 0;
                clicked_btn1 = clicked_btn2 = null;
                ResetClickedButtons();
            }

            
        }
    }
}
