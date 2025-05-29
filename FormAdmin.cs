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
    public partial class FormAdmin : Form
    {
        UserControlTC tC = new UserControlTC();
        UserControlSV sV = new UserControlSV();
        UserControlGV gV = new UserControlGV();
        UserControlLH lH = new UserControlLH();
        UserControlMH mH = new UserControlMH();
        UserControlKhoa khoa = new UserControlKhoa();
        UserControlTK tK = new UserControlTK();

        NavigationControl navigationControl;
        NavigationButton navigationButton;

        readonly Color btnDefaultColor = Color.FromKnownColor(KnownColor.ControlLight);
        readonly Color btnSelectedtColor = Color.FromKnownColor(KnownColor.ButtonHighlight);
        public FormAdmin()
        {
            InitializeComponent();
            InitializeNavigationButton();
            InitializeNavigationControl();
        }

        private void InitializeNavigationControl()
        {
            List<UserControl> userControl = new List<UserControl>()
            { tC, sV, gV, lH, mH, khoa, tK };

            navigationControl = new NavigationControl(userControl, panelContent);
            navigationControl.Display(0);
        }

        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>()
            { buttonTC, buttonSV, buttonGV, buttonLH, buttonMH, buttonKhoa, buttonTK };

            navigationButton = new NavigationButton(buttons, btnDefaultColor, btnSelectedtColor);
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
            sV.UserControlSV_Load(null, EventArgs.Empty);
        }

        private void buttonGV_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButton.Highlight(buttonGV);
            gV.UserControlGV_Load(null, EventArgs.Empty);
        }

        private void buttonLH_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButton.Highlight(buttonLH);
            lH.UserControlLH_Load(null, EventArgs.Empty);
        }

        private void buttonMH_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButton.Highlight(buttonMH);
            mH.UserControlMH_Load(null, EventArgs.Empty);
        }

        private void buttonKhoa_Click(object sender, EventArgs e)
        {
            navigationControl.Display(5);
            navigationButton.Highlight(buttonKhoa);
            khoa.UserControlKhoa_Load(null, EventArgs.Empty);
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            navigationControl.Display(6);
            navigationButton.Highlight(buttonTK);
            tK.UserControlTK_Load(null, EventArgs.Empty);
        }

        private void buttonDX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
