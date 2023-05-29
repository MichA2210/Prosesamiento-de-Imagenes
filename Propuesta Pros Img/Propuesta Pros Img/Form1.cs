namespace Propuesta_Pros_Img
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //customizeDesignd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Images());
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            openChildForm(new Video());
        }

        private void btnCam_Click(object sender, EventArgs e)
        {
            openChildForm(new VideoCap());
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
