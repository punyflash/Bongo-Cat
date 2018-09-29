using System;
using System.Drawing;
using System.Windows.Forms;

namespace BongoCat
{
    public partial class Settings : Form
    {
        private App app;
        private bool right_trigger = false;
        private bool left_trigger = false;
       
        private bool key1_trigger = false;
        private bool key2_trigger = false;
        private bool key3_trigger = false;
        private bool key4_trigger = false;
        private bool key5_trigger = false;
        private bool key6_trigger = false;
        private bool key7_trigger = false;
        private bool key8_trigger = false;

        private ColorDialog color = new ColorDialog();

        public Settings(App app)
        {
            this.app = app;
            Location = new Point(app.Location.X + 25, app.Location.Y + 25);
            InitializeComponent();
            foreach (string s in Properties.Settings.Default.defaultRight) Right.Items.Add(s);
            foreach (string s in Properties.Settings.Default.defaultLeft) Left.Items.Add(s);
            Background.BackColor = Properties.Settings.Default.defaultBackground;
            Instrument.Text = Properties.Settings.Default.defaultInstrument;
            if (Properties.Settings.Default.defaultTable) Table.Checked = true;
            if (Properties.Settings.Default.defaultMouse) Mouse.Checked = true;

            if (Properties.Settings.Default.pianoTable) pianoTable.Checked = true;
            pianoBackground.BackColor = Properties.Settings.Default.pianoBackground;
            button1.Text = Properties.Settings.Default.pianoKey1;
            button2.Text = Properties.Settings.Default.pianoKey2;
            button3.Text = Properties.Settings.Default.pianoKey3;
            button4.Text = Properties.Settings.Default.pianoKey4;
            button5.Text = Properties.Settings.Default.pianoKey5;
            button6.Text = Properties.Settings.Default.pianoKey6;
            button7.Text = Properties.Settings.Default.pianoKey7;
            button8.Text = Properties.Settings.Default.pianoKey8;

            switch (Properties.Settings.Default.Mode)
            {
                case "Default": Modes.SelectedIndex = 0; break;
                case "Piano": Modes.SelectedIndex = 1; break;
            }

            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Settings_KeyDown);
            this.Right.MouseDoubleClick += new MouseEventHandler(Right_DoubleClick);
            this.Left.MouseDoubleClick += new MouseEventHandler(Left_DoubleClick);
            this.Modes.SelectedIndexChanged += new EventHandler(Mode_IndexChanged);
        }

        // Settings form events
        private void Mode_IndexChanged(object sender, EventArgs e)
        {
            switch (Modes.SelectedIndex)
            {
                case 0:
                    app.SetMode("Default");
                    Properties.Settings.Default.Mode = "Default";
                    Properties.Settings.Default.Save();
                    break;
                case 1:
                    app.SetMode("Piano");
                    Properties.Settings.Default.Mode = "Piano";
                    Properties.Settings.Default.Save();
                    break;
            }
        }
        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (right_trigger)
            {
                right_trigger = false;
                if (!app.right.Contains(e.KeyCode.ToString()))
                {
                    Properties.Settings.Default.defaultRight.Add(e.KeyCode.ToString());
                    app.right.Add(e.KeyCode.ToString());
                    Properties.Settings.Default.Save();
                    Right.Items.Add(e.KeyCode.ToString());
                }
                AddRight.Text = "<= Add";
            }
            if (left_trigger)
            {
                left_trigger = false;
                if (!app.left.Contains(e.KeyCode.ToString()))
                {
                    Properties.Settings.Default.defaultLeft.Add(e.KeyCode.ToString());
                    app.left.Add(e.KeyCode.ToString());
                    Properties.Settings.Default.Save();
                    Left.Items.Add(e.KeyCode.ToString());
                }
                AddLeft.Text = "Add =>";
            }
            if (key1_trigger)
            {
                key1_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey1 = e.KeyCode.ToString();
                    app.key1 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button1.Text = app.key1;
            }
            if (key2_trigger)
            {
                key2_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey2 = e.KeyCode.ToString();
                    app.key2 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button2.Text = app.key2;
            }
            if (key3_trigger)
            {
                key3_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey3 = e.KeyCode.ToString();
                    app.key3 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button3.Text = app.key3;
            }
            if (key4_trigger)
            {
                key4_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey4 = e.KeyCode.ToString();
                    app.key4 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button4.Text = app.key4;
            }
            if (key5_trigger)
            {
                key5_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey5 = e.KeyCode.ToString();
                    app.key5 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button5.Text = app.key5;
            }
            if (key6_trigger)
            {
                key6_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey6 = e.KeyCode.ToString();
                    app.key6 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button6.Text = app.key6;
            }
            if (key7_trigger)
            {
                key7_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey7 = e.KeyCode.ToString();
                    app.key7 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button7.Text = app.key7;
            }
            if (key8_trigger)
            {
                key8_trigger = false;
                if (e.KeyCode.ToString() != app.key1 && e.KeyCode.ToString() != app.key2 && e.KeyCode.ToString() != app.key3 && e.KeyCode.ToString() != app.key4 && e.KeyCode.ToString() != app.key5 && e.KeyCode.ToString() != app.key6 && e.KeyCode.ToString() != app.key7 && e.KeyCode.ToString() != app.key8)
                {
                    Properties.Settings.Default.pianoKey8 = e.KeyCode.ToString();
                    app.key8 = e.KeyCode.ToString();
                    Properties.Settings.Default.Save();
                }
                button8.Text = app.key8;
            }
        }
        private void DisableTriggers()
        {
            if (right_trigger)
            {
                right_trigger = false;
                AddRight.Text = "<= Add";
            }
            if (left_trigger)
            {
                left_trigger = false;
                AddLeft.Text = "Add =>";
            }
            if (key1_trigger)
            {
                key1_trigger = false;
                button1.Text = app.key1;
            }
            if (key2_trigger)
            {
                key2_trigger = false;
                button2.Text = app.key2;
            }
            if (key3_trigger)
            {
                key3_trigger = false;
                button3.Text = app.key3;
            }
            if (key4_trigger)
            {
                key4_trigger = false;
                button4.Text = app.key4;
            }
            if (key5_trigger)
            {
                key5_trigger = false;
                button5.Text = app.key5;
            }
            if (key6_trigger)
            {
                key6_trigger = false;
                button6.Text = app.key6;
            }
            if (key7_trigger)
            {
                key7_trigger = false;
                button7.Text = app.key7;
            }
            if (key8_trigger)
            {
                key8_trigger = false;
                button8.Text = app.key8;
            }
        }

        // Default mode events
        private void AddRight_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            DisableTriggers();
            right_trigger = true;
            AddRight.Text = "*Press Key";
        }
        private void AddLeft_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            DisableTriggers();
            left_trigger = true;
            AddLeft.Text = "*Press Key";
        }
        private void Background_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            if (color.ShowDialog() == DialogResult.OK)
            {
                Background.BackColor = color.Color;
                Properties.Settings.Default.defaultBackground = color.Color;
                Properties.Settings.Default.Save();
                app.Cat.BackColor = color.Color;
            }
        }
        private void Instrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            Properties.Settings.Default.defaultInstrument = Instrument.Text;
            Properties.Settings.Default.Save();
            app.SetInstrument(Instrument.Text);
        }
        private void Mouse_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            if (Mouse.Checked)
            {
                Properties.Settings.Default.defaultMouse = true;
                app.mouse = true;
                Properties.Settings.Default.Save();
            }
            else
            { 
                Properties.Settings.Default.defaultMouse = false;
                app.mouse = false;
                Properties.Settings.Default.Save();
            }
        }
        private void Table_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            if (Table.Checked)
            {
                Properties.Settings.Default.defaultTable = true;
                Properties.Settings.Default.Save();
                app.table = true;
                app.TransparentTable(true);
            }
            else
            {
                Properties.Settings.Default.defaultTable = false;
                Properties.Settings.Default.Save();
                app.table = false;
                app.TransparentTable(false);
            }
        }
        private void Right_DoubleClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            int index = Right.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Properties.Settings.Default.defaultRight.RemoveAt(index);
                app.right.RemoveAt(index);
                Properties.Settings.Default.Save();
                Right.Items.RemoveAt(index);
            }
        }
        private void Left_DoubleClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Default") return;
            int index = Left.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Properties.Settings.Default.defaultLeft.RemoveAt(index);
                app.left.RemoveAt(index);
                Properties.Settings.Default.Save();
                Left.Items.RemoveAt(index);
            }
        }

        // Piano mode events
        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key1_trigger = true;
            button1.Text = "*Press";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key2_trigger = true;
            button2.Text = "*Press";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key3_trigger = true;
            button3.Text = "*Press";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key4_trigger = true;
            button4.Text = "*Press";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key5_trigger = true;
            button5.Text = "*Press";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key6_trigger = true;
            button6.Text = "*Press";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key7_trigger = true;
            button7.Text = "*Press";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            DisableTriggers();
            key8_trigger = true;
            button8.Text = "*Press";
        }

        private void pianoBackground_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            if (color.ShowDialog() == DialogResult.OK)
            {
                pianoBackground.BackColor = color.Color;
                Properties.Settings.Default.pianoBackground = color.Color;
                Properties.Settings.Default.Save();
                app.Cat.BackColor = color.Color;
            }
        }

        private void pianoTable_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode != "Piano") return;
            if (pianoTable.Checked)
            {
                Properties.Settings.Default.pianoTable = true;
                Properties.Settings.Default.Save();
                app.table = true;
                app.TransparentTable(true);
            }
            else
            {
                Properties.Settings.Default.pianoTable = false;
                Properties.Settings.Default.Save();
                app.table = false;
                app.TransparentTable(false);
            }
        }
    }
}
