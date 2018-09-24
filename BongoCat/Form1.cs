using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Gma.System.MouseKeyHook;
using System.Collections.Specialized;

namespace BongoCat
{
    public partial class App : Form
    {
        private IKeyboardMouseEvents hook = Hook.GlobalEvents();
        
        private StringCollection right_pressed = new StringCollection();
        private StringCollection left_pressed = new StringCollection();
        public StringCollection right = new StringCollection();
        public StringCollection left = new StringCollection();
        public bool mouse = Properties.Settings.Default.Mouse;
        public bool table = Properties.Settings.Default.Table;

        public bool settings = false;

        public App()
        {
            InitializeComponent();
            Cat.Controls.Add(Right);
            Cat.Controls.Add(Left);

            hook.KeyDown += new KeyEventHandler(HookKeyDown);
            hook.KeyUp += new KeyEventHandler(HookKeyUp);
            hook.MouseDown += new MouseEventHandler(HookMouseDown);
            hook.MouseUp += new MouseEventHandler(HookMouseUp);
            KeyDown += new KeyEventHandler(AppKeyDown);

            TransparentTable(Properties.Settings.Default.Table);
            SetInstrument(Properties.Settings.Default.Instrument);

            Cat.BackColor = Properties.Settings.Default.Background;

            foreach (string s in Properties.Settings.Default.Right) right.Add(s);
            foreach (string s in Properties.Settings.Default.Left) left.Add(s);

            Winking();
        }

        public void SetInstrument(string Instrument)
        {
            switch (Instrument)
            {
                case "None": Cat.Image = null; break;
                case "Bongo": Cat.Image = Properties.Resources.bongo; break;
                case "Keyboard": Cat.Image = Properties.Resources.keyboard; break;
                case "Controller": Cat.Image = Properties.Resources.controller; break;
            }
            this.Cat.Update();
        }
        public void TransparentTable(bool Value)
        {
            switch (Value)
            {
                case true: this.Cat.BackgroundImage = Properties.Resources.cat; break;
                case false: this.Cat.BackgroundImage = Properties.Resources.cat_table; break;
            }
        }

        private async void Winking()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Random rnd = new Random();
                    await Task.Delay(rnd.Next(3000, 7000));
                    if (table)
                    {
                        Cat.BackgroundImage = Properties.Resources.cat_wink;
                        await Task.Delay(rnd.Next(100, 250));
                        Cat.BackgroundImage = Properties.Resources.cat;
                    }
                    else
                    {
                        Cat.BackgroundImage = Properties.Resources.cat_table_wink;
                        await Task.Delay(rnd.Next(100, 250));
                        Cat.BackgroundImage = Properties.Resources.cat_table;
                    }
                }
            });
        }
        private async void RightHandPress(string Key)
        {
            if (!right_pressed.Contains(Key))
            {
                right_pressed.Add(Key);
                Right.Image = Properties.Resources.pressed_right_wave;
                await Task.Run(async () =>
                {
                    await Task.Delay(100);
                    if(right_pressed.Count>0) Right.Image = Properties.Resources.pressed_right;
                    else Right.Image = Properties.Resources.unpressed_right;
                });
            }
            
        }
        private void RightHandUnpress(string Key)
        {
            right_pressed.Remove(Key);
            if (right_pressed.Count == 0) Right.Image = Properties.Resources.unpressed_right;
        }
        private async void LeftHandPress(string Key)
        {
            if (!left_pressed.Contains(Key))
            {
                left_pressed.Add(Key);
                Left.Image = Properties.Resources.pressed_left_wave;
                await Task.Run(async () =>
                {
                    await Task.Delay(100);
                    if (left_pressed.Count>0) Left.Image = Properties.Resources.pressed_left;
                    else Left.Image = Properties.Resources.unpressed_left;
                });
            }
            
        }
        private void LeftHandUnpress(string Key)
        {
            left_pressed.Remove(Key);
            if (left_pressed.Count == 0) Left.Image = Properties.Resources.unpressed_left;
        }
        private void HookKeyDown(object sender, KeyEventArgs e)
        {
            if (right.Contains(e.KeyCode.ToString())) RightHandPress(e.KeyCode.ToString());
            if (left.Contains(e.KeyCode.ToString())) LeftHandPress(e.KeyCode.ToString());
        }
        private void HookKeyUp(object sender, KeyEventArgs e)
        {
            if (right_pressed.Contains(e.KeyCode.ToString())) RightHandUnpress(e.KeyCode.ToString());
            else if (left_pressed.Contains(e.KeyCode.ToString())) LeftHandUnpress(e.KeyCode.ToString());
        }
        private void HookMouseDown(object sender, MouseEventArgs e)
        {
            if (!mouse) return;
            if (e.Button == MouseButtons.Left) RightHandPress(e.Button.ToString());
            if (e.Button == MouseButtons.Right) LeftHandPress(e.Button.ToString());
        }
        private void HookMouseUp(object sender, MouseEventArgs e)
        {
            if (right_pressed.Contains(e.Button.ToString())) RightHandUnpress(e.Button.ToString());
            else if (left_pressed.Contains(e.Button.ToString())) LeftHandUnpress(e.Button.ToString());
        }
        private void AppKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 79 && Application.OpenForms.Count == 1)
            {
                Settings s = new Settings(this);
                s.Show();
            }
        }
    }
}
