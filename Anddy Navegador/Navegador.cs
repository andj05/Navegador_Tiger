using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Anddy_Navegador
{
    public partial class Tiger : Form
    {
        public Tiger()
        {
            InitializeComponent();
        }

        private void Tiger_Load(object sender, EventArgs e)
        {
            NavegadorA.ScriptErrorsSuppressed = true;
            SetBrowserFeatureControl();
            NavegadorA.Navigate("https://www.google.com");
        }

        private void SetBrowserFeatureControl()
        {
            string fileName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            using (var key = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
            {
                key.SetValue(fileName, 11001, RegistryValueKind.DWord);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NavegadorA.Navigate(URLNav.Text);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            NavegadorA.GoForward();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            NavegadorA.Navigate(URLNav.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NavegadorA.GoBack();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            NavegadorA.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            NavegadorA.Stop();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            NavegadorA.GoHome();
        }

        private void NavegadorA_NavigationError(object sender, WebBrowserNavigatedEventArgs e)
        {
            MessageBox.Show("Error al cargar la página.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.R:
                    NavegadorA.Refresh();
                    return true;
                case Keys.Control | Keys.H:
                    NavegadorA.GoHome();
                    return true;
                case Keys.Control | Keys.B:
                    NavegadorA.GoBack();
                    return true;
                case Keys.Control | Keys.F:
                    NavegadorA.GoForward();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
