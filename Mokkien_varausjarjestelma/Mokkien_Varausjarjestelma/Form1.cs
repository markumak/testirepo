using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mokkien_Varausjarjestelma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Näyttöjen avaaminen päävalikosta

        // Hallintanäyttö
        private void mokitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MokkienHallintaForm mokitForm = new MokkienHallintaForm();
            mokitForm.Show();
        }
        // Hallintanäyttö
        private void toimintaalueetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToimintaAlueidenHallintaForm toimintaAlueetForm = new ToimintaAlueidenHallintaForm();
            toimintaAlueetForm.Show();
        }
        // Hallintanäyttö
        private void asiakkaatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsiakkaidenHallintaForm asiakkaatForm = new AsiakkaidenHallintaForm();
            asiakkaatForm.Show();
        }
        // Hallintanäyttö
        private void majoitusvarauksetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MajoitusvaraustenHallintaForm majoitusvarauksetForm = new MajoitusvaraustenHallintaForm();
            majoitusvarauksetForm.Show();
        }
        // Hallintanäyttö
        private void palvelutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PalveluidenHallintaForm palvelutForm = new PalveluidenHallintaForm();
            palvelutForm.Show();
        }
        // Raportointi näyttö
        private void raportointiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RaportointiForm raportitForm = new RaportointiForm();
            raportitForm.Show();
        }
        // Laskujen hallinta ja seuranta näyttö
        private void laskujenHallintaJaSeurantaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaskutusForm laskutForm = new LaskutusForm();
            laskutForm.Show();
        }
    }
}
