
// Developed by:
//  Özlem ELMALI 
//  Ahmet Melih KARA 
//  Ekinsu Eylül ASLAN 

namespace TurlamaOyunuApp
{
    public partial class Form1 : Form
    {

        static int sayac = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGrid();
        }

        Button[,] buttons = new Button[8, 8];
        List<Button> buttonList = new List<Button>();
        private void CreateGrid()
        {
            int left = 110;
            int top = 50;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Click += new EventHandler(OnClick);
                    button.Tag = "0";
                    button.Width = 64;
                    button.Height = 64;
                    button.BackColor = Color.White;
                    buttons[i, j] = button;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j].Left = left + j * 64;
                    buttons[i, j].Top = top + i * 64;
                    buttonList.Add(buttons[i, j]);
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void OnClick(object? sender, EventArgs e)
        {
            bool running = false;
            Button buttonClicked = (Button)sender;
            buttonClicked.Tag = sayac.ToString();
            buttonClicked.Text = sayac.ToString();
            sayac++;
            List<Button> buttonChoose = new List<Button>();

            foreach (Button button in buttonList)
            {
                button.Enabled = false;
                button.BackColor = Color.White;
                if (button.Tag == "0")
                    buttonChoose.Add(button);
            }

            for (int i = 0; i < buttonChoose.Count; i++)
            {
                if (((buttonClicked.Location.X) - 128) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) - 64) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
                if (((buttonClicked.Location.X) - 128) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) + 64) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].Enabled = true;
                    buttonChoose[i].BackColor = Color.Red;
                }
                if (((buttonClicked.Location.X) - 64) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) - 128) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
                if (((buttonClicked.Location.X) - 64) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) + 128) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
                if (((buttonClicked.Location.X) + 64) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) - 128) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
                if (((buttonClicked.Location.X) + 64) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) + 128) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
                if (((buttonClicked.Location.X) + 128) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) - 64) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
                if (((buttonClicked.Location.X) + 128) == buttonChoose[i].Location.X && ((buttonClicked.Location.Y) + 64) == buttonChoose[i].Location.Y)
                {
                    buttonChoose[i].BackColor = Color.Red;
                    buttonChoose[i].Enabled = true;
                }
            }
            foreach (Button button in buttonList)
            {
                if (button.BackColor == Color.Red)
                    running = true;
            }

            if (running == false || sayac == 64)
            {
                label1.Text = "OYUN BÝTTÝ\nSkor: " +(sayac-1);
            }
        }

    }
}