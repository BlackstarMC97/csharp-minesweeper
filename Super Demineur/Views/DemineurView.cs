using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsMvc.Example.Controllers;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using WinformsMvc.Example.Models;

namespace WinformsMvc.Example.Views
{
    public partial class DemineurView : MetroForm, IView
    {
        public DemineurView()
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

        public static int maxBombes = 10;
        public static int nbreCasesClicked = 0;
        public static int Longueur = 9;
        public static int Largeur = 9;
        int top = 80;
        int left = 0;
        internal static CaseModel[,] listCases = new CaseModel[Longueur, Largeur];

        public enum Danger
        {
            Bombe = 1,
            Safe = 0
        }

        public enum EtatCase
        {
            Normal = 0,
            Revelé = 1,
            Marqué = 2,
            Indécise = 3
        }

        private void DemineurView_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            // Initialisation de la variable statique
            nbreCasesClicked = 0;

            left = (this.Width - 32 * Longueur) / 2;
            
            for (int i = 0; i < Longueur; i++)
            {
                for (int j = 0; j < Largeur; j++)
                {
                    MetroButton button = new MetroButton();
                    button.Height = 32;
                    button.Width = 32;

                    button.Cursor = Cursors.Hand;
                    button.BackgroundImage = Properties.Resources.texture_champ;

                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.MouseUp += new MouseEventHandler(anybutton_Click);

                    button.Left = left+i*button.Width;
                    button.Top = top+j*button.Height;

                    listCases[i, j] = new CaseModel(i,j);
                    listCases[i, j].Button = button;
                    listCases[i, j].ProbaMax = (double)maxBombes / (Largeur * Longueur);

                    this.Controls.Add(button);
                }
            }
            
            // Génération des bombes sur le terrain
            GenererBombes();
        }

        private void GenererBombes()
        {
            int nbre = 0;
            int premierAleatoire, deuxiemeAleatoire = 0;

            while (nbre < maxBombes)
            {
                premierAleatoire = new Random(DateTime.Now.Millisecond).Next(0, Longueur);
                deuxiemeAleatoire = new Random(DateTime.Now.Millisecond).Next(0, Largeur);

                if (listCases[premierAleatoire, deuxiemeAleatoire].Danger == (int)Danger.Safe)
                {
                    listCases[premierAleatoire, deuxiemeAleatoire].Danger = (int)Danger.Bombe;
                    nbre += 1;
                }
            }
        }

        private void InitialiserCases()
        {
            nbreCasesClicked = 0;
            metroLabel1.Text = "Nb = 0";
            metroTextBox1.Text = "0";
            metroTextBox2.Text = maxBombes.ToString();
            
            for (int i = 0; i < Longueur; i++)
            {
                for (int j = 0; j < Largeur; j++)
                {
                    listCases[i, j].Danger = (int)Danger.Safe;
                    listCases[i, j].Etat = (int)EtatCase.Normal;
                    listCases[i, j].Button.BackgroundImage = Properties.Resources.texture_champ;
                    listCases[i, j].Button.Text = "";
                    listCases[i, j].ProbaMax = (double)maxBombes / (Largeur * Longueur);
                }
            }
        }

        public void detruireBoutons()
        {
            for (int i = 0; i < Longueur; i++)
            {
                for (int j = 0; j < Largeur; j++)
                {
                    listCases[i, j].Button.BackgroundImage = null;
                }
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            //AppManager.Instance.Load<MenugameController>();
            MenugameView menuFenetre = new MenugameView();
            menuFenetre.Show();
            Form.Dispose();
        }

        public void cliquerGaucheCase(int x, int y)
        {
            // Le compte de l'horloge commence lorsqu'on découvre une case
            if (timer1.Enabled == false)
            {
                timer1.Start();
            }

            if (listCases[x, y].Etat == (int)EtatCase.Normal)
            {
                if (listCases[x, y].Danger == (int)Danger.Bombe)
                {
                    listCases[x, y].Button.BackgroundImage = Properties.Resources.bombes_explosifs_icone_9186_128;

                    // On arrête l'horloge
                    if (timer1.Enabled == true)
                    {
                        timer1.Stop();
                    }
                    revelerPlateau();
                    MessageBox.Show("Désolé, vous avez laissé exploser une bombe!", "Défaite");
                    detruireBoutons();

                    InitialiserCases();
                    GenererBombes();
                }
                else
                {
                    listCases[x, y].cocherCasesAdjacentes();

                    //MessageBox.Show("Case : X=" + x + ", Y=" + y + "; proba=" + listCases[x, y].ProbaMax.ToString());
                    listCases[x, y].modifierProbasVoisins();
                }
            }

            if (nbreCasesClicked == Longueur * Largeur - maxBombes)
            {
                // On arrête l'horloge
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                }
                revelerPlateau();
                MessageBox.Show("Gagné! Vous avez découvert toutes les bombes, bien joué, démineur!", "Victoire");

                InitialiserCases();
                GenererBombes();
            }
        }

        public void cliquerDroitCase(int x, int y)
        {
            switch (listCases[x, y].Etat)
            {
                case (int)EtatCase.Normal:
                    listCases[x, y].Button.BackgroundImage = Properties.Resources.drapeaubleu;
                    listCases[x, y].Etat = (int)EtatCase.Marqué;
                    metroTextBox2.Text = (int.Parse(metroTextBox2.Text) - 1).ToString();
                    break;

                case (int)EtatCase.Marqué:
                    listCases[x, y].Button.BackgroundImage = Properties.Resources.question_mark_1363011_640;
                    listCases[x, y].Etat = (int)EtatCase.Indécise;
                    metroTextBox2.Text = (int.Parse(metroTextBox2.Text) + 1).ToString();
                    break;

                case (int)EtatCase.Indécise:
                    listCases[x, y].Button.BackgroundImage = Properties.Resources.texture_champ;
                    listCases[x, y].Etat = (int)EtatCase.Normal;
                    break;
            }
        }

        public void poserDrapeauCase(int x, int y)
        {
            if (listCases[x, y].Etat == (int)EtatCase.Normal)
            {
                listCases[x, y].Button.BackgroundImage = Properties.Resources.drapeaubleu;
                listCases[x, y].Etat = (int)EtatCase.Marqué;
                metroTextBox2.Text = (int.Parse(metroTextBox2.Text) - 1).ToString();
            }
        }
        
        private void anybutton_Click(object sender, EventArgs e)
        {
            int x, y = 0;
            Button cb = (Button)sender;
            MouseEventArgs clic = (MouseEventArgs)e;
            
            x = (cb.Location.X - left)/cb.Width;
            y = (cb.Location.Y - top)/cb.Height;
            
            // Outil pour l'aide à la gestion de la grille
            metroButton2.Text = "X : " + x + "; Y : " + y;

            // On gère le clic gauche sur une de nos cases
            if (clic.Button == MouseButtons.Left)
            {
                // Le compte de l'horloge commence lorsqu'on découvre une case
                if (timer1.Enabled == false)
                {
                    timer1.Start();
                }

                if (listCases[x, y].Etat == (int)EtatCase.Normal)
                {
                    if (listCases[x, y].Danger == (int)Danger.Bombe)
                    {
                        listCases[x, y].Button.BackgroundImage = Properties.Resources.bombes_explosifs_icone_9186_128;

                        // On arrête l'horloge
                        if (timer1.Enabled == true)
                        {
                            timer1.Stop();
                        }
                        revelerPlateau();
                        MessageBox.Show("Désolé, vous avez laissé exploser une bombe!", "Défaite");
                        detruireBoutons();

                        InitialiserCases();
                        GenererBombes();
                    }
                    else
                    {
                        listCases[x, y].cocherCasesAdjacentes();
                        listCases[x, y].modifierProbasVoisins();
                    }
                }
            }
            // On gère le clic droit sur une de nos cases
            if (clic.Button == MouseButtons.Right)
            {
                switch (listCases[x, y].Etat)
                {
                    case (int)EtatCase.Normal :
                        listCases[x, y].Button.BackgroundImage = Properties.Resources.drapeaubleu;
                        listCases[x, y].Etat = (int)EtatCase.Marqué;
                        metroTextBox2.Text = (int.Parse(metroTextBox2.Text) - 1).ToString();
                    break;
                    
                    case (int)EtatCase.Marqué :
                        listCases[x, y].Button.BackgroundImage = Properties.Resources.question_mark_1363011_640;
                        listCases[x, y].Etat = (int)EtatCase.Indécise;
                        metroTextBox2.Text = (int.Parse(metroTextBox2.Text) + 1).ToString();
                    break;
                    
                    case (int)EtatCase.Indécise :
                        listCases[x, y].Button.BackgroundImage = Properties.Resources.texture_champ;
                        listCases[x, y].Etat = (int)EtatCase.Normal;
                    break;
                }
            }

            if (nbreCasesClicked == Longueur*Largeur - maxBombes)
            {
                // On arrête l'horloge
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                }
                revelerPlateau();
                MessageBox.Show("Gagné! Vous avez découvert toutes les bombes, bien joué, démineur!", "Victoire");
                
                InitialiserCases();
                GenererBombes();
            }
        }

        public void revelerPlateau()
        {
            for (int i = 0; i < Longueur; i++)
            {
                for (int j = 0; j < Largeur; j++)
                {
                    if (listCases[i, j].Danger == (int)Danger.Bombe)
                    {
                        listCases[i, j].Button.BackgroundImage = Properties.Resources.bombes_explosifs_icone_9186_128;
                    }
                    else
                    {
                        listCases[i, j].Button.BackgroundImage = null;
                        listCases[i, j].Button.Text = listCases[i, j].nbreCasesAdjacentesMinees().ToString();
                    }
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            revelerPlateau();
        }

        private void DemineurView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void resolutionIA_Click(object sender, EventArgs e)
        {
            metroLabel1.Text = "NB = " + nbreCasesClicked;
            if (nbreCasesClicked < 3)
            {
                int a = new Random(DateTime.Now.Millisecond).Next(0, Longueur);
                int b = new Random(DateTime.Now.Millisecond).Next(0, Largeur);

                while (a == b)
                {
                    a = new Random(DateTime.Now.Millisecond).Next(0, Longueur);
                    b = new Random(DateTime.Now.Millisecond).Next(0, Largeur);
                }

                cliquerGaucheCase(a, b);
                metroLabel1.Text = "NB = " + nbreCasesClicked;
            }
            else
            {
                for (int i = 0; i < Longueur; i++)
                {
                    for (int j = 0; j < Largeur; j++)
                    {
                        if(listCases[i, j].Etat == (int)EtatCase.Revelé)
                            listCases[i, j].modifierProbasVoisins();

                        if (listCases[i, j].ProbaMax == 1)
                        {
                            poserDrapeauCase(i, j);
                        }
                        if (listCases[i, j].ProbaMax == 0 && listCases[i, j].Etat == (int)EtatCase.Normal)
                        {
                            cliquerGaucheCase(i, j);
                        }
                    }
                }
                
                metroLabel1.Text = "NB = " + nbreCasesClicked;
            }
        }

        private void recommencerBtn_Click(object sender, EventArgs e)
        {
            InitialiserCases();
            GenererBombes();
        }

        private void decompteHorloge(object sender, EventArgs e)
        {
            metroTextBox1.Text = (int.Parse(metroTextBox1.Text) + 1).ToString();
        }
    }
}
