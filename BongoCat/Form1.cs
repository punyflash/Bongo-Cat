using System.Windows.Forms;
using System.Threading.Tasks;
using Octokit;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Gma.System.MouseKeyHook;
using System.Collections.Specialized;

namespace BongoCat
{
    public partial class App : Form
    {
        string version = "1.3.0";
        private IKeyboardMouseEvents hook = Hook.GlobalEvents();

        private StringCollection right_pressed = new StringCollection();
        private StringCollection left_pressed = new StringCollection();

        private string mode = Properties.Settings.Default.Mode;

        public string key1, key2, key3, key4, key5, key6, key7, key8;
        public StringCollection right = new StringCollection();
        public StringCollection left = new StringCollection();
        public bool mouse, table;

        private Bitmap bg = Properties.Resources.empt;
        private Bitmap front = Properties.Resources.empt;

        public App()
        {
            CheckUpdates();
            InitializeComponent();

            this.KeyPreview = true;
            KeyDown += new KeyEventHandler(AppKeyDown);
            hook.KeyDown += new KeyEventHandler(HookKeyDown);
            hook.KeyUp += new KeyEventHandler(HookKeyUp);
            hook.MouseDown += new MouseEventHandler(HookMouseDown);
            hook.MouseUp += new MouseEventHandler(HookMouseUp);

            Cat.Controls.Add(Hands);
            SetMode(mode);
            Winking();
        }
        
        private async void CheckUpdates()
        {
            await Task.Run(async () =>
            {
                try
                {
                    var client = new GitHubClient(new ProductHeaderValue("Bongo-Cat"));
                    var releases = await client.Repository.Release.GetAll("PunyFlash", "Bongo-Cat");
                    string message = "";
                    for (int i = 0; releases[i].TagName != version; ++i)
                    {
                        message += "\n" + releases[i].TagName + ":\n" + releases[i].Body + "\n";
                    }
                    if (message != "")
                    {
                        var result = MessageBox.Show("Updates avaliable:\n" + message + "\nWould you like to download now?", "Bongo Cat", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://github.com/PunyFlash/Bongo-Cat/releases/download/" + releases[0].TagName + "/BongoCat.rar");
                        }
                    }
                }
                catch
                {
                    return;
                }
            });
        }
        private void AppKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 79)
            {
                Settings s = new Settings(this);
                s.Show();
            }
        }

        private async void Winking()
        {
            await Task.Run(async () =>
            {
                Random rnd = new Random();
                while (true)
                {
                    await Task.Delay(rnd.Next(3000, 7000));
                    if (table) Cat.BackgroundImage = Properties.Resources.cat_wink;
                    else Cat.BackgroundImage = Properties.Resources.cat_table_wink;
                    await Task.Delay(rnd.Next(100, 250));
                    if (table) Cat.BackgroundImage = Properties.Resources.cat;
                    else Cat.BackgroundImage = Properties.Resources.cat_table;
                }
            });
        }

        public void SetInstrument(string Instrument)
        {
            switch (Instrument)
            {
                case "None": Cat.Image = null; break;
                case "Bongo": Cat.Image = Properties.Resources.bongo; break;
                case "Keyboard": Cat.Image = Properties.Resources.keyboard; break;
                case "Controller": Cat.Image = Properties.Resources.controller; break;
                case "Piano": Cat.Image = Properties.Resources.piano; break;
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
        public void SetMode(string mode)
        {
            Hands.Image = Impose(front, Properties.Resources.unpressed_right, 0, 0);
            Hands.Image = Impose(front, Properties.Resources.unpressed_left, 270, 0);
            right_pressed.Clear();
            left_pressed.Clear();
            switch (mode)
            {
                case "Default":
                    this.mode = "Default";
                    right.Clear();
                    left.Clear();
                    foreach (string s in Properties.Settings.Default.defaultRight) right.Add(s);
                    foreach (string s in Properties.Settings.Default.defaultLeft) left.Add(s);
                    mouse = Properties.Settings.Default.defaultMouse;
                    table = Properties.Settings.Default.defaultTable;

                    Cat.BackColor = Properties.Settings.Default.defaultBackground;
                    TransparentTable(Properties.Settings.Default.defaultTable);
                    SetInstrument(Properties.Settings.Default.defaultInstrument);
                    break;
                case "Piano":
                    this.mode = "Piano";
                    key1 = Properties.Settings.Default.pianoKey1;
                    key2 = Properties.Settings.Default.pianoKey2;
                    key3 = Properties.Settings.Default.pianoKey3;
                    key4 = Properties.Settings.Default.pianoKey4;
                    key5 = Properties.Settings.Default.pianoKey5;
                    key6 = Properties.Settings.Default.pianoKey6;
                    key7 = Properties.Settings.Default.pianoKey7;
                    key8 = Properties.Settings.Default.pianoKey8;
                    table = Properties.Settings.Default.pianoTable;
                    mouse = false;

                    Cat.BackColor = Properties.Settings.Default.pianoBackground;
                    TransparentTable(Properties.Settings.Default.pianoTable);
                    SetInstrument("Piano");
                    break;
            }
        }

        private void RightHandPress(string Key)
        {
            if (!right_pressed.Contains(Key))
            {
                right_pressed.Add(Key);
                Hands.Image = Impose(front, Properties.Resources.pressed_right_wave, 0, 0);
                Task.Run(async () =>
                {
                    await Task.Delay(100);
                    if (right_pressed.Count > 0) Hands.Image = Impose(front, Properties.Resources.pressed_right, 0, 0);
                    else Hands.Image = Impose(front, Properties.Resources.unpressed_right, 0, 0);
                });
            }

        }
        private void LeftHandPress(string Key)
        {
            if (!left_pressed.Contains(Key))
            {
                left_pressed.Add(Key);
                Hands.Image = Impose(front, Properties.Resources.pressed_left_wave, 270, 0);
                Task.Run(async () =>
                {
                    await Task.Delay(100);
                    if (left_pressed.Count > 0) Hands.Image = Impose(front, Properties.Resources.pressed_left, 270, 0);
                    else Hands.Image = Impose(front, Properties.Resources.unpressed_left, 270, 0);
                });
            }

        }

        private void RightHandUnpress(string Key)
        {
            right_pressed.Remove(Key);
            if (right_pressed.Count == 0) Hands.Image = Impose(front, Properties.Resources.unpressed_right, 0, 0);
        }
        private void LeftHandUnpress(string Key)
        {
            left_pressed.Remove(Key);
            if (left_pressed.Count == 0) Hands.Image = Impose(front, Properties.Resources.unpressed_left, 270, 0);
        }

        private void HookKeyDown(object sender, KeyEventArgs e)
        {
            switch (mode)
            {
                case "Default":
                    if (right.Contains(e.KeyCode.ToString())) RightHandPress(e.KeyCode.ToString());
                    if (left.Contains(e.KeyCode.ToString())) LeftHandPress(e.KeyCode.ToString());
                    break;
                case "Piano":
                    if (key1 == e.KeyCode.ToString()) Press1();
                    if (key2 == e.KeyCode.ToString()) Press2();
                    if (key3 == e.KeyCode.ToString()) Press3();
                    if (key4 == e.KeyCode.ToString()) Press4();
                    if (key5 == e.KeyCode.ToString()) Press5();
                    if (key6 == e.KeyCode.ToString()) Press6();
                    if (key7 == e.KeyCode.ToString()) Press7();
                    if (key8 == e.KeyCode.ToString()) Press8();
                    break;
            }
        }
        private void HookKeyUp(object sender, KeyEventArgs e)
        {
            switch (mode)
            {
                case "Default":
                    if (right_pressed.Contains(e.KeyCode.ToString())) RightHandUnpress(e.KeyCode.ToString());
                    if (left_pressed.Contains(e.KeyCode.ToString())) LeftHandUnpress(e.KeyCode.ToString());
                    break;
                case "Piano":
                    if (key1 == e.KeyCode.ToString() && right_pressed.Contains(key1)) UnPress1();
                    if (key2 == e.KeyCode.ToString() && right_pressed.Contains(key2)) UnPress2();
                    if (key3 == e.KeyCode.ToString() && right_pressed.Contains(key3)) UnPress3();
                    if (key4 == e.KeyCode.ToString() && right_pressed.Contains(key4)) UnPress4();
                    if (key5 == e.KeyCode.ToString() && left_pressed.Contains(key5)) UnPress5();
                    if (key6 == e.KeyCode.ToString() && left_pressed.Contains(key6)) UnPress6();
                    if (key7 == e.KeyCode.ToString() && left_pressed.Contains(key7)) UnPress7();
                    if (key8 == e.KeyCode.ToString() && left_pressed.Contains(key8)) UnPress8();
                    break;
            }
        }

        private void HookMouseDown(object sender, MouseEventArgs e)
        {
            if (mode != "Default") return;
            if (mouse)
            {
                if (e.Button == MouseButtons.Left) RightHandPress(e.Button.ToString());
                if (e.Button == MouseButtons.Right) LeftHandPress(e.Button.ToString());
            }
        }
        private void HookMouseUp(object sender, MouseEventArgs e)
        {
            if (right_pressed.Contains(e.Button.ToString())) RightHandUnpress(e.Button.ToString());
            if (left_pressed.Contains(e.Button.ToString())) LeftHandUnpress(e.Button.ToString());
        }

        private void Press1()
        {
            if (!right_pressed.Contains(key1))
            {
                right_pressed.Add(key1);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key1, 85, 147);
                Hands.Image = Impose(front, Properties.Resources.pressed_key1, 0, 0);
            }
        }
        private void Press2()
        {
            if (!right_pressed.Contains(key2))
            {
                right_pressed.Add(key2);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key2, 122, 154);
                Hands.Image = Impose(front, Properties.Resources.pressed_key2, 0, 0);
            }
        }
        private void Press3()
        {
            if (!right_pressed.Contains(key3))
            {
                right_pressed.Add(key3);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key3, 161, 162);
                Hands.Image = Impose(front, Properties.Resources.pressed_key3, 0, 0);
            }
        }
        private void Press4()
        {
            if (!right_pressed.Contains(key4))
            {
                right_pressed.Add(key4);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key4, 197, 171);
                Hands.Image = Impose(front, Properties.Resources.pressed_key4, 0, 0);
            }
        }
        private void Press5()
        {
            if (!left_pressed.Contains(key5))
            {
                left_pressed.Add(key5);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key5, 232, 179);
                Hands.Image = Impose(front, Properties.Resources.pressed_key5, 270, 0);
            }
        }
        private void Press6()
        {
            if (!left_pressed.Contains(key6))
            {
                left_pressed.Add(key6);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key6, 268, 187);
                Hands.Image = Impose(front, Properties.Resources.pressed_key6, 270, 0);
            }
        }
        private void Press7()
        {
            if (!left_pressed.Contains(key7))
            {
                left_pressed.Add(key7);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key7, 303, 195);
                Hands.Image = Impose(front, Properties.Resources.pressed_key7, 270, 0);
            }
        }
        private void Press8()
        {
            if (!left_pressed.Contains(key8))
            {
                left_pressed.Add(key8);
                Hands.BackgroundImage = Superimpose(bg, Properties.Resources.key8, 337, 203);
                Hands.Image = Impose(front, Properties.Resources.pressed_key8, 270, 0);
            }
        }
        private void UnPress1()
        {
            right_pressed.Remove(key1);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key1, 85, 147);
            PressLastRight();
        }
        private void UnPress2()
        {
            right_pressed.Remove(key2);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key2, 122, 154);
            PressLastRight();
        }
        private void UnPress3()
        {
            right_pressed.Remove(key3);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key3, 161, 162);
            PressLastRight();
        }
        private void UnPress4()
        {
            right_pressed.Remove(key4);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key4, 197, 171);
            PressLastRight();
        }
        private void UnPress5()
        {
            left_pressed.Remove(key5);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key5, 232, 179);
            PressLastLeft();
        }
        private void UnPress6()
        {
            left_pressed.Remove(key6);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key6, 268, 187);
            PressLastLeft();
        }
        private void UnPress7()
        {
            left_pressed.Remove(key7);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key7, 303, 195);
            PressLastLeft();
        }
        private void UnPress8()
        {
            left_pressed.Remove(key8);
            Hands.BackgroundImage = UnSuperimpose(bg, Properties.Resources.key8, 337, 203);
            PressLastLeft();
        }
        private void PressLastRight()
        {
            try
            {
                string k = right_pressed[right_pressed.Count - 1];
                if (k == key1) Hands.Image = Impose(front, Properties.Resources.pressed_key1, 0, 0);
                else if (k == key2) Hands.Image = Impose(front, Properties.Resources.pressed_key2, 0, 0);
                else if (k == key3) Hands.Image = Impose(front, Properties.Resources.pressed_key3, 0, 0);
                else if (k == key4) Hands.Image = Impose(front, Properties.Resources.pressed_key4, 0, 0);
                else Hands.Image = Impose(front, Properties.Resources.unpressed_right, 0, 0);
            }
            catch
            {
                Hands.Image = Impose(front, Properties.Resources.unpressed_right, 0, 0);
            }
        }
        private void PressLastLeft()
        {
            try
            {
                string k = left_pressed[left_pressed.Count - 1];
                if (k == key5) Hands.Image = Impose(front, Properties.Resources.pressed_key5, 270, 0);
                else if (k == key6) Hands.Image = Impose(front, Properties.Resources.pressed_key6, 270, 0);
                else if (k == key7) Hands.Image = Impose(front, Properties.Resources.pressed_key7, 270, 0);
                else if (k == key8) Hands.Image = Impose(front, Properties.Resources.pressed_key8, 270, 0);
                else Hands.Image = Impose(front, Properties.Resources.unpressed_left, 270, 0);
            }
            catch
            {
                Hands.Image = Impose(front, Properties.Resources.unpressed_left, 270, 0);
            }
        }

        private Bitmap Superimpose(Bitmap largeBmp, Bitmap smallBmp, int x, int y)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            g.CompositingMode = CompositingMode.SourceOver;
            smallBmp.MakeTransparent();
            g.DrawImageUnscaled(smallBmp, new Point(x, y));
            return largeBmp;
        }
        private Bitmap Impose(Bitmap largeBmp, Bitmap smallBmp, int x, int y)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            g.CompositingMode = CompositingMode.SourceCopy;
            g.DrawImageUnscaled(smallBmp, new Point(x, y));
            return largeBmp;
        }
        private Bitmap UnSuperimpose(Bitmap largeBpm, Bitmap smallBpm, int x, int y)
        {
            for (int i = 0; i < smallBpm.Width; i++)
            {
                for (int j = 0; j < smallBpm.Height; j++)
                {
                    if (x + i >= 0 && x + i < largeBpm.Width && y + j >= 0 && y + j < largeBpm.Height && smallBpm.GetPixel(i, j).A != 0)
                    {
                        largeBpm.SetPixel(x + i, j + y, Color.Transparent);
                    }
                }
            }
            return largeBpm;
        }
    }
}
