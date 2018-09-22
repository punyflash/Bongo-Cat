using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BongoCat
{
    public partial class Settings : Form
    {
        private App app;
        private bool right_trigger = false;
        private bool left_trigger = false;
        private ColorDialog color = new ColorDialog();

        public Settings(App app)
        {
            this.app = app;
            Location = new Point(app.Location.X + 25, app.Location.Y + 25);
            InitializeComponent();
            foreach (string s in Properties.Settings.Default.Right)
                Right.Items.Add(s);
            foreach (string s in Properties.Settings.Default.Left)
                Left.Items.Add(s);
            Background.BackColor = Properties.Settings.Default.Background;
            Instrument.Text = Properties.Settings.Default.Instrument;
            if (Properties.Settings.Default.Table) Table.Checked = true;
            if (Properties.Settings.Default.Mouse) Mouse.Checked = true;

            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Settings_KeyDown);
            this.Right.MouseDoubleClick += new MouseEventHandler(Right_DoubleClick);
            this.Left.MouseDoubleClick += new MouseEventHandler(Left_DoubleClick);
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
        }
        private void AddRight_Click(object sender, EventArgs e)
        {
            DisableTriggers();
            right_trigger = true;
            AddRight.Text = "*Press Key";
        }
        private void AddLeft_Click(object sender, EventArgs e)
        {
            DisableTriggers();
            left_trigger = true;
            AddLeft.Text = "*Press Key";
        }
        private void Background_Click(object sender, EventArgs e)
        {
            if (color.ShowDialog() == DialogResult.OK)
            {
                Background.BackColor = color.Color;
                Properties.Settings.Default.Background = color.Color;
                Properties.Settings.Default.Save();
                app.Cat.BackColor = color.Color;
            }
        }
        private void Instrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Instrument = Instrument.Text;
            Properties.Settings.Default.Save();
            app.SetInstrument(Instrument.Text);
        }
        private void Mouse_CheckedChanged(object sender, EventArgs e)
        {
            if (Mouse.Checked)
            {
                Properties.Settings.Default.Mouse = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Mouse = false;
                Properties.Settings.Default.Save();
            }
        }
        private void Table_CheckedChanged(object sender, EventArgs e)
        {
            if (Table.Checked)
            {
                Properties.Settings.Default.Table = true;
                Properties.Settings.Default.Save();
                app.TransparentTable(true);
            }
            else
            {
                Properties.Settings.Default.Table = false;
                Properties.Settings.Default.Save();
                app.TransparentTable(false);
            }
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (right_trigger)
            {
                right_trigger = false;
                if (!Properties.Settings.Default.Right.Contains(e.KeyCode.ToString()))
                {
                    Properties.Settings.Default.Right.Add(e.KeyCode.ToString());
                    Properties.Settings.Default.Save();
                    Right.Items.Add(e.KeyCode.ToString());
                }
                AddRight.Text = "<= Add";
            }
            if (left_trigger)
            {
                left_trigger = false;
                if (!Properties.Settings.Default.Left.Contains(e.KeyCode.ToString()))
                {
                    Properties.Settings.Default.Left.Add(e.KeyCode.ToString());
                    Properties.Settings.Default.Save();
                    Left.Items.Add(e.KeyCode.ToString());
                }
                AddLeft.Text = "Add =>";
            }
        }
        private void Right_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = Right.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Properties.Settings.Default.Right.RemoveAt(index);
                Properties.Settings.Default.Save();
                Right.Items.RemoveAt(index);
            }
        }
        private void Left_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = Left.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Properties.Settings.Default.Left.RemoveAt(index);
                Properties.Settings.Default.Save();
                Left.Items.RemoveAt(index);
            }
        }
    }
}
