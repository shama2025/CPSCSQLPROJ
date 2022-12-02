namespace SQLFRONTEND
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 NextForm = new Form2();
            NextForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 NextForm = new Form3();
            NextForm.Show();
        }
    }
}