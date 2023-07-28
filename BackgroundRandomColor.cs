using System;
using System.Drawing;
using System.Windows.Forms;

public class RandomColorForm : Form
{
    private Random rand;

    public RandomColorForm()
    {
        Load += RandomColorForm_Load;
        MouseClick += RandomColorForm_MouseClick;
    }

    private void RandomColorForm_Load(object sender, EventArgs e)
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

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new RandomColorForm());
    }
}
