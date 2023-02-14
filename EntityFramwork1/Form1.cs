using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramwork1
{
    public partial class Form1 : Form
    {
        Biblio contexte = new Biblio();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Liste des themes = requete Linq

            var query = from th in contexte.Themes
                        select th;
            contexte.Database.Log =
                    System.Console.Out.Write;

            comboBoxThemes.DataSource =
                query.ToList<Theme>();
            comboBoxThemes.DisplayMember = "IntituleTh";
            comboBoxThemes.ValueMember = "CodeTh";
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                string codeLivre = textBoxCode.Text.Trim();
                string titre = textBoxTitre.Text.Trim();
                string auteur = textBoxAuteur.Text.Trim();
                int nbExemplaire =
                    Convert.ToInt32(textBoxExemplaires.Text.Trim());
                int codeTh =
                    Convert.ToInt32(comboBoxThemes.SelectedValue.ToString());

                //Ajouter un nouveau livre
                //1. Creer un objet livre
                //2.Ajouter l'objet au contexte
                //3.validation

                contexte.Database.Log = 
                    System.Console.Out.Write;

                Livre livre = new Livre()
                {
                    CodeL = codeLivre,
                    Titre = titre,
                    Auteur = auteur,
                    NbExemplaires = nbExemplaire,
                    CodeTh = codeTh
                };

                //Attacher l'objet au contexte
                contexte.Livres.Add(livre);
                //valider
                contexte.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonChercher_Click(object sender, EventArgs e)
        {
            string codeLivre = textBoxCode.Text.Trim();
            if (codeLivre == "")
                return;

            var query = from livre in contexte.Livres
                        where livre.CodeL == codeLivre
                        select livre;

            Livre livreTrouver = query.FirstOrDefault();
            if (livreTrouver != null)
            {
                textBoxTitre.Text = livreTrouver.Titre;
                textBoxAuteur.Text = livreTrouver.Auteur;
                textBoxExemplaires.Text =
                    livreTrouver.NbExemplaires.ToString();
                comboBoxThemes.SelectedValue =
                    livreTrouver.CodeTh;
            }
            else
                MessageBox.Show("Code de livre inexistant!! ");
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            string codeLivre = textBoxCode.Text.Trim();
            if (codeLivre == "")
                return;
            try
            {
                var query = from livre in contexte.Livres
                            where livre.CodeL == codeLivre
                            select livre;

                Livre livreTrouver = query.FirstOrDefault();

                livreTrouver.Titre =
                    textBoxTitre.Text;
                livreTrouver.Auteur = textBoxAuteur.Text;
                livreTrouver.NbExemplaires =
                    Convert.ToInt32(textBoxExemplaires.Text);
                livreTrouver.CodeTh =
                    (int)comboBoxThemes.SelectedValue;

                contexte.SaveChanges();
                MessageBox.Show("Modification effectuée!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            string codeLivre = textBoxCode.Text.Trim();
            if (codeLivre == "")
                return;
            try
            {
                var query = from livre in contexte.Livres
                            where livre.CodeL == codeLivre
                            select livre;

                Livre livreTrouver = query.FirstOrDefault();

                contexte.Livres.Remove(livreTrouver);
                contexte.SaveChanges();
                MessageBox.Show("Suppression effectuée!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
