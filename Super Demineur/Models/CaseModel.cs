using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsMvc.Example.Views;
using MetroFramework.Controls;

namespace WinformsMvc.Example.Models
{
    class CaseModel
    {
        private int _etat;
        private int _danger;
        private MetroButton _button;
        private int _x;
        private int _y;

        public CaseModel(int x, int y)
        {
            _etat = 0;
            _danger = 0;
            _button = new MetroButton();
            _x = x;
            _y = y;
        }

        public int Etat
        {
            get
            {
                return _etat;
            }
            set
            {
                _etat = value;
            }
        }

        public int Danger
        {
            get
            {
                return _danger;
            }
            set
            {
                _danger = value;
            }
        }

        public MetroButton Button
        {
            get
            {
                return _button;
            }
            set
            {
                _button = value;
            }
        }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool estAdjacent(CaseModel othercase)
        {
            if (othercase.X >= X - 1 && othercase.X <= X + 1 && othercase.Y >= Y - 1 && othercase.Y <= Y + 1)
            {
                if (othercase.X >= 0 && othercase.Y >= 0 && othercase.X < DemineurView.Longueur && othercase.Y < DemineurView.Largeur)
                {
                    if (!(othercase.X == X && othercase.Y == Y))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<CaseModel> casesAdjacentes()
        {
            List<CaseModel> resultat = new List<CaseModel>();
            for (int i = X - 1; i < X + 2; i++)
            {
                for (int j = Y - 1; j < Y + 2; j++)
                {
                    if (i >= 0 && j >= 0 && i < DemineurView.Longueur && j < DemineurView.Largeur)
                    {
                        if (!(i == X && j == Y))
                            resultat.Add(DemineurView.listCases[i,j]);
                    }
                }
            }

            return resultat;
        }

        public void cocherCasesAdjacentes()
        {
            if (Etat != (int)DemineurView.EtatCase.Revelé)
            {
                int nbreMinesVoisines = nbreCasesAdjacentesMinees();
                
                // On met à jour le bouton dans l'interface graphique
                Button.BackgroundImage = null;
                Button.Text = nbreCasesAdjacentesMinees().ToString();
                Etat = (int)DemineurView.EtatCase.Revelé;
                DemineurView.nbreCasesClicked += 1;

                if (nbreMinesVoisines == 0)
                {
                    foreach (CaseModel caseElement in casesAdjacentes())
                    {
                        caseElement.cocherCasesAdjacentes();
                    }
                }
            }
        }

        public int nbreCasesAdjacentes()
        {
            int resultat = 0;

            for (int i = X-1; i < X+2; i++)
            {
                for (int j = Y-1; j < Y+2; j++)
                {
                    if (i >= 0 && j >= 0 && i < DemineurView.Longueur && j < DemineurView.Largeur)
                    {
                        if(!(i == X &&  j == Y))
                            resultat += 1;
                    }
                }
            }

            return resultat;
        }

        public int nbreCasesAdjacentesMinees()
        {
            int resultat = 0;

            for (int i = X - 1; i < X + 2; i++)
            {
                for (int j = Y - 1; j < Y + 2; j++)
                {
                    if (i >= 0 && j >= 0 && i < DemineurView.Longueur && j < DemineurView.Largeur)
                    {
                        if (!(i == X && j == Y))
                        {
                            if(DemineurView.listCases[i,j].Danger == (int)DemineurView.Danger.Bombe)
                            {
                                resultat += 1;
                            }
                        }
                    }
                }
            }

            return resultat;
        }

    }
}
