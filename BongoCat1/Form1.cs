using System.Windows.Forms;
using System.Drawing;
using Gma.System.MouseKeyHook;

namespace BongoCat1
{
    public partial class Form1 : Form
    {
        public string first_key = Keys.Z.ToString();
        public string second_key = Keys.X.ToString();
        public bool track_mouse = false;
        public bool trigger_both = false;
        public bool table = true;
        public string instrument = "Controller";

        private IKeyboardMouseEvents actHook;

        public Form1()
        {
            InitializeComponent();
            actHook = Hook.GlobalEvents();
            actHook.KeyDown += new KeyEventHandler(Hook_KeyDown);
            actHook.KeyUp += new KeyEventHandler(Hook_KeyUp);
            actHook.MouseDown += new MouseEventHandler(Hook_MouseDown);
            actHook.MouseUp += new MouseEventHandler(Hook_MouseUp);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void press_1()
        {
            this.pictureBox1.Image = Properties.Resources.pressed_1;
            if (this.trigger_both) this.pictureBox2.Image = Properties.Resources.pressed_2;
        }

        private void press_2()
        {
            this.pictureBox2.Image = Properties.Resources.pressed_2;
            if (this.trigger_both) this.pictureBox1.Image = Properties.Resources.pressed_1;
        }

        private void unpress_1()
        {
            this.pictureBox1.Image = Properties.Resources.not_pressed_1;
            if (this.trigger_both) this.pictureBox2.Image = Properties.Resources.not_pressed_2;
        }

        private void unpress_2()
        {
            this.pictureBox2.Image = Properties.Resources.not_pressed_2;
            if (this.trigger_both) this.pictureBox1.Image = Properties.Resources.not_pressed_1;
        }
        private void Hook_MouseDown(object sender, MouseEventArgs e)
        {
            if (!track_mouse) return;
            if (e.Button == MouseButtons.Left) press_1();
            if (e.Button == MouseButtons.Right) press_2();
        }
        private void Hook_MouseUp(object sender, MouseEventArgs e)
        {
            if (!track_mouse) return;
            if (e.Button == MouseButtons.Left) unpress_1();
            if (e.Button == MouseButtons.Right) unpress_2();
        }
        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == first_key) press_1();
            if (e.KeyCode.ToString() == second_key) press_2();
        }
        private void Hook_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == first_key) unpress_1();
            if (e.KeyCode.ToString() == second_key) unpress_2();
        }
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 79)
            {
                Form2 settings = new Form2(this);
                settings.Show();
            }
        }
    }
}
