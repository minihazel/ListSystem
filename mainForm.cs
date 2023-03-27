using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ListSystem
{
    public partial class mainForm : Form
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        string[] _Items = {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5",
            "Item 6",
            "Item 7"
        };

        string currentDir = Environment.CurrentDirectory;

        int default_item_height = 22;
        int default_item_loc_x = 1;
        int default_item_loc_y = 16;
        int default_item_spacer = 22;

        public Color idleText = Color.Black;
        public Color idleColor = SystemColors.Control;
        public Color hoverColor = Color.FromArgb(255, 230, 230, 230);
        public Color selectColor = Color.FromArgb(255, 220, 220, 220);
        public Color selectText = Color.DodgerBlue;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            bool jsonExists = File.Exists($"C:\\Users\\JSON.json");
            if (jsonExists)
            {
                string jsonFile = File.ReadAllText($"C:\\Users\\JSON.json");
                dynamic obj = serializer.Deserialize<dynamic>(jsonFile);
                var arrayList = obj["array"] as object[];
                string[] stringArray = arrayList.Select(x => x.ToString()).ToArray();

                listSystem(stringArray);
            }
        }

        private void clearUI()
        {
            // server box
            for (int i = list.Controls.Count - 1; i >= 0; i--)
            {
                Label selected = list.Controls[i] as Label;
                if (selected != null)
                {
                    try
                    {
                        list.Controls.RemoveAt(i);
                        selected.Dispose();
                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine($"ERROR: {err.Message.ToString()}");
                        MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{err.Message.ToString()}", this.Text, MessageBoxButtons.OK);
                    }
                }
            }
        }

        public void listSystem(string[] insertArray)
        {
            clearUI();
            for (int i = 0; i < insertArray.Length; i++)
            {
                Label lbl = new Label();
                lbl.Text = $" {insertArray[i]}";
                lbl.AutoSize = false;
                lbl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Size = new Size(list.Size.Width - 2, default_item_height);
                lbl.Location = new Point(default_item_loc_x, default_item_loc_y + (i * default_item_spacer));
                lbl.Font = new Font("Bahnschrift Light", 11, FontStyle.Regular);
                lbl.BackColor = idleColor;
                lbl.ForeColor = Color.Black;
                lbl.Margin = new Padding(1, 1, 1, 1);
                lbl.Cursor = Cursors.Hand;
                lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                lbl.MouseDown += new MouseEventHandler(lbl_MouseDown);
                lbl.MouseUp += new MouseEventHandler(lbl_MouseUp);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Visible = true;
                list.Controls.Add(lbl);
            }
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                label.BackColor = hoverColor;
                /*
                if (label.ForeColor != selectText)
                {
                    label.BackColor = hoverColor;
                }
                */
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                label.BackColor = idleColor;
                /*
                if (label.ForeColor != selectText)
                {
                    label.BackColor = idleColor;
                }
                */
            }
        }

        private void lbl_MouseDown(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;
            if (lbl.Text != "")
            {
                foreach (Control component in list.Controls)
                {
                    if (component.Text.Contains("> "))
                    {
                        //component.Text = component.Text.Remove(0, 2);
                        component.Text = component.Text.Replace("> ", "");
                    }

                    if (component is Label && component.Text != lbl.Text)
                    {
                        component.BackColor = idleColor;
                        component.ForeColor = idleText;
                    }
                }
                lbl.BackColor = hoverColor;

                string activeItem = lbl.Text;
                activeItem = "> " + activeItem;
                lbl.Text = activeItem;
                lbl.ForeColor = selectText;

            }
        }

        private void lbl_MouseUp(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
            }
        }
    }
}
