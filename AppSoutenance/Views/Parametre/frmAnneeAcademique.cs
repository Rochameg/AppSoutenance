using AppSoutenance.Models;


namespace AppSoutenance.Views.Parametre
{
    public partial class frmAnneeAcademique : Form
    {
        public frmAnneeAcademique()
        {
            InitializeComponent();
        }

        BdSenSoutenanceContext db = new BdSenSoutenanceContext();




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            dgAnneAcademique.DataSource = db.anneeAcademiques.ToList();
        }

        public void Effacer()
        {
            txtAnneeAcademiqueText.Clear();
            txtAnneeAcademiqueVal.Clear();
            dgAnneAcademique.DataSource = db.anneeAcademiques.ToList();
            txtAnneeAcademiqueText.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnneeAcademique anneeAcademique = new AnneeAcademique()
            {
                LibelleAnneeAcademique = txtAnneeAcademiqueText.Text,
                AnneeAcademiqueVal = int.Parse(txtAnneeAcademiqueVal.Text)

            };

            db.anneeAcademiques.Add(anneeAcademique);
            db.SaveChanges();
            Effacer();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgAnneAcademique.CurrentRow.Cells[0].Value.ToString());
            AnneeAcademique anneeAcademique = db.anneeAcademiques.Find(id);
            anneeAcademique.LibelleAnneeAcademique = txtAnneeAcademiqueText.Text;
            anneeAcademique.AnneeAcademiqueVal = int.Parse(txtAnneeAcademiqueVal.Text);
            db.SaveChanges();
            Effacer();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgAnneAcademique.CurrentRow.Cells[0].Value.ToString());
            AnneeAcademique anneeAcademique = db.anneeAcademiques.Find(id);
            db.anneeAcademiques.Remove(anneeAcademique);
            db.SaveChanges();
            Effacer();
        }

        /*private void btnSelect_Click(object sender, EventArgs e)
        {
            txtAnneeAcademiqueText.Text = dgAnneAcademique.CurrentRow.Cells[1].Value.ToString();
            txtAnneeAcademiqueVal.Text = dgAnneAcademique.CurrentRow.Cells[2].Value.ToString();

        }*/

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgAnneAcademique.CurrentRow == null)
                return;

            if (dgAnneAcademique.CurrentRow.Cells.Count < 3)
                return;

            txtAnneeAcademiqueText.Text =
                dgAnneAcademique.CurrentRow.Cells[1].Value?.ToString();

            txtAnneeAcademiqueVal.Text =
                dgAnneAcademique.CurrentRow.Cells[2].Value?.ToString();
        }

    }
}

    
