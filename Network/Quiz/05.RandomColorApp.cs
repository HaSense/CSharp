using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace RandomColorApp
{
    public partial class Form1 : Form
    {
        private Random rand;
        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            MouseClick += RandomColorForm_MouseClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rand = new Random();
        }
        private void RandomColorForm_MouseClick(object sender, MouseEventArgs e)
        {
            int red = rand.Next(0, 256);
            int green = rand.Next(0, 256);
            int blue = rand.Next(0, 256);
            BackColor = Color.FromArgb(red, green, blue);
        }
    }
}
