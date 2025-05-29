using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class FormGV : Form
    {
        private readonly string maGV;

        private UserControlTC tC = new UserControlTC();
        private UserControlDiem diem = new UserControlDiem();
        private UserControlCD cD = new UserControlCD();

        private NavigationButton navigationButton;
        private NavigationControl navigationControl;

        readonly Color btnDefaultColor = Color.FromKnownColor(KnownColor.ControlLight);
        readonly Color btnSelectedtColor = Color.FromKnownColor(KnownColor.ButtonHighlight);
        public FormGV(string maGV)
        {
            InitializeComponent();
            this.maGV = maGV;
            diem.maGV = this.maGV;
            cD.LoadAccount(this.maGV);
            InitializeNavigationButton();
            InitializeNavigationControl();
        }

        private void buttonDX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeNavigationControl()
        {
            List<UserControl> userControl = new List<UserControl>() { tC, diem, cD };

            navigationControl = new NavigationControl(userControl, panelContent);
            navigationControl.Display(0);
        }

        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>()
            { buttonTC, buttonSV, buttonCD };

            // create a NavigationButtons instance
            navigationButton = new NavigationButton(buttons, btnDefaultColor, btnSelectedtColor);
            // Make a default selected button
            navigationButton.Highlight(buttonTC);
        }

        private void buttonTC_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButton.Highlight(buttonTC);
        }

        private void buttonSV_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButton.Highlight(buttonSV);
        }

        private void buttonCD_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButton.Highlight(buttonCD);
        }
    }
}
