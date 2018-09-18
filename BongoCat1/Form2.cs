using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BongoCat1
{
    public partial class Form2 : Form
    {
        Form1 app;
        ColorDialog dialog = new ColorDialog();
        private bool button1_trigger = false;
        private bool button2_trigger = false;

        public Form2(Form1 app)
        {
            this.Location = new Point(app.Location.X+10, app.Location.Y+10);
            InitializeComponent();
            this.app = app;
            this.button1.Text = app.first_key;
            this.button2.Text = app.second_key;
            this.comboBox2.Text = app.instrument;
            this.button3.BackColor = app.BackColor;
            if (app.track_mouse) this.checkBox1.Checked = true;
            if (app.trigger_both) this.checkBox2.Checked = true;
            if (!app.table) this.checkBox3.Checked = true;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form2_KeyPress);
        }

        private void disable_triggers()
        {
            if (this.button1_trigger)
            {
                this.button1_trigger = false;
                this.button1.Text = app.first_key;
            }
            if (this.button2_trigger)
            {
                this.button2_trigger = false;
                this.button2.Text = app.second_key;
            }
        }

        private void Form2_KeyPress(object sender, KeyEventArgs e)
        {
            if (this.button1_trigger)
            {
                this.button1_trigger = false;
                if (e.KeyCode.ToString() != app.second_key)
                    app.first_key = e.KeyCode.ToString();
                this.button1.Text = app.first_key;
            }
            if (this.button2_trigger)
            {
                this.button2_trigger = false;
                if (e.KeyCode.ToString() != app.first_key)
                    app.second_key = e.KeyCode.ToString();
                this.button2.Text = app.second_key;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                app.track_mouse = true;
            }
            else
            {
                app.track_mouse = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                app.trigger_both = true;
            }
            else
            {
                app.trigger_both = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                app.table = false;
            }
            else
            {
                app.table = true;
            }
            update_cat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disable_triggers();
            this.button1_trigger = true;
            this.button1.Text = "*Press Key";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disable_triggers();
            this.button2_trigger = true;
            this.button2.Text = "*Press Key";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = dialog.Color;
                app.BackColor = dialog.Color;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            app.instrument = comboBox2.Text;
            update_cat();
        }

        private void update_cat()
        {
            if (app.table)
            {
                switch (app.instrument)
                {
                    case "Controller": app.BackgroundImage = Properties.Resources.cat_table_controller; break;
                    case "Keyboard": app.BackgroundImage = Properties.Resources.cat_table_keyboard; break;
                    case "Bongos": app.BackgroundImage = Properties.Resources.cat_table_bongo; break;
                }
            }
            else
            {
                switch (app.instrument)
                {
                    case "Controller": app.BackgroundImage = Properties.Resources.cat_controller; break;
                    case "Keyboard": app.BackgroundImage = Properties.Resources.cat_keyboard; break;
                    case "Bongos": app.BackgroundImage = Properties.Resources.cat_bongo; break;
                }
            }
        }
    }
}
