using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using WinformsMvc.Example.Controllers;

namespace WinformsMvc.Example.Views
{
    public partial class ReglesjeuView : MetroForm, IView
    {
        public ReglesjeuView()
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

        private void ReglesjeuView_Load(object sender, EventArgs e)
        {

        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            //AppManager.Instance.Load<MenugameController>();
            MenugameView menuFenetre = new MenugameView();
            menuFenetre.Show();
            Form.Dispose();
        }

        private void ReglesjeuView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
