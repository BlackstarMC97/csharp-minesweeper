using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsMvc.Example.Controllers;
using MetroFramework;
using MetroFramework.Forms;

namespace WinformsMvc.Example.Views
{
    public partial class MenugameView : MetroForm, IView
    {
        public MenugameView()
        {
            InitializeComponent();
        }

        public Form Form
        {
            get
            {
                return this;
            }
        }

        public string Title
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }

        private void MenugameView_Load(object sender, EventArgs e)
        {
            
        }

        private void rulesTile_Click(object sender, EventArgs e)
        {

        }

        private void optionsTile_Click(object sender, EventArgs e)
        {

        }

        int compteur = 0;

        private void newgameTile_Click(object sender, EventArgs e)
        {
            metroProgressSpinner1.Visible = true;
            metroLabel1.Visible = true;
            timer1.Start();
            
            //AppManager.Instance.Load<DemineurController>();
        }

        void Loading()
        {
            
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Voulez vous vraiment quitter cette application?", "Quitter l'application", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 170) == DialogResult.Yes)
                Application.ExitThread();    
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(compteur == 40)
            {
                timer1.Stop();
                AppManager.Instance.Load<DemineurController>();
            }
            else
            {
                compteur += 1;
            }
        }
    }
}
