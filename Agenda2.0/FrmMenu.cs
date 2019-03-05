using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda2._0
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = null;

       
        //private string strCon = @"Data Source=HELITON\SQLEXPRESS;Initial Catalog=BDAgenda;Persist Security Info=True;User ID=sa;Password=1234";

        private string strCon = @"Password=1234;Persist Security Info=True;User ID=sa;Initial Catalog=BDAgenda;Data Source=HELITON\SQLEXPRESS";



        private string strSql = string.Empty;


        private void FrmMenu_Load(object sender, EventArgs e)
        {
            btnAtualizarAgenda.Enabled = false;
            btnInserirAgenda.Enabled = false;
            btnPesquisarAgenda.Enabled = false;
            btnPesquisarAgenda.Enabled = false;
            btnDeletarAgenda.Enabled = false;

            txtNomeAgenda.Enabled = false;
            txtIDAgenda.Enabled = false;
            txtRGAgenda.Enabled = false;
            mtxtCPFAgenda.Enabled = false;
            txtEmailAgenda.Enabled = false;
            txtEnderecoAgenda.Enabled = false;
            txtNumeroAgenda.Enabled = false;
            txtBairroAgenda.Enabled = false;
            txtCidadeAgenda.Enabled = false;
            mtxtTelefone1.Enabled = false;
            mtxtTelefone2.Enabled = false;
            mtxtTelefone3.Enabled = false;


    }

    private void btnSairAgenda_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            FrmTestar frm = new FrmTestar();
            frm.ShowDialog();
        }

        private void btnNovoAgenda_Click(object sender, EventArgs e)
        {
            btnAtualizarAgenda.Enabled = true;
            btnInserirAgenda.Enabled = true;
            txtIDAgenda.Enabled = true;
            btnPesquisarAgenda.Enabled = true;
            btnPesquisarAgenda.Enabled = true;
            btnDeletarAgenda.Enabled = true;

            txtNomeAgenda.Enabled = true;
            txtRGAgenda.Enabled = true;
            mtxtCPFAgenda.Enabled = true;
            txtEmailAgenda.Enabled = true;
            txtEnderecoAgenda.Enabled = true;
            txtNumeroAgenda.Enabled = true;
            txtBairroAgenda.Enabled = true;
            txtCidadeAgenda.Enabled = true;
            mtxtTelefone1.Enabled = true;
            mtxtTelefone2.Enabled = true;
            mtxtTelefone3.Enabled = true;

            txtNomeAgenda.Clear();
            txtRGAgenda.Clear();
            txtIDAgenda.Clear();
            mtxtCPFAgenda.Clear();
            txtEmailAgenda.Clear();
            txtEnderecoAgenda.Clear();
            txtNumeroAgenda.Clear();
            txtBairroAgenda.Clear();
            txtCidadeAgenda.Clear();
            mtxtTelefone1.Clear();
            mtxtTelefone2.Clear();
            mtxtTelefone3.Clear();



          

        }





        private void btnInserirAgenda_Click(object sender, EventArgs e)
        {

           
           


            strSql = "Insert into TblAgenda (Nome, RG, CPF, Endereco, Numero, Bairro, Cidade, Email, Telefone1, Telefone2," +
                    "Telefone3) values (@Nome, @RG, @CPF, @Endereco, @Numero, @BAirro,@Cidade, @Email, @Telefone1, @Telefone2," +
                    "@Telefone3)";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNomeAgenda.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txtRGAgenda.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = mtxtCPFAgenda.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEnderecoAgenda.Text;
            if (txtNumeroAgenda.Text == string.Empty)
            {
                MessageBox.Show("Digite o Numero");
            }
            else
            {



                comando.Parameters.Add("@Numero", SqlDbType.Int).Value = int.Parse(txtNumeroAgenda.Text);
                comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairroAgenda.Text;
                comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidadeAgenda.Text;
                comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmailAgenda.Text;
                comando.Parameters.Add("@Telefone1", SqlDbType.VarChar).Value = mtxtTelefone1.Text;
                comando.Parameters.Add("@Telefone2", SqlDbType.VarChar).Value = mtxtTelefone2.Text;
                comando.Parameters.Add("@Telefone3", SqlDbType.VarChar).Value = mtxtTelefone3.Text;
                //comando.Parameters.Add("@DataCadastro", SqlDbType.VarChar).Value = txtNomeAgenda.Text;

            }

            try
            {
                sqlCon.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com Sucesso");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }


        }

        private void btnPesquisarAgenda_Click(object sender, EventArgs e)
        {
            FrmPesquisar frm = new FrmPesquisar();
            frm.ShowDialog();
        }
    }
}
 
