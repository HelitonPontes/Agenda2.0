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
    public partial class FrmPesquisar : Form
    {
        public FrmPesquisar()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = null;



        private string strCon = @"Password=1234;Persist Security Info=True;User ID=sa;Initial Catalog=BDAgenda;Data Source=HELITON\SQLEXPRESS";



        private string strSql = string.Empty;



        private void FrmPesquisar_Load(object sender, EventArgs e)
        {
            txtNomePesquisa.Enabled = false;
            txtRGPesquisa.Enabled = false;

            btnPesquisarAgenda.Enabled = false;

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

        private void btnNovoAgenda_Click(object sender, EventArgs e)
        {

            txtIDAgenda.Enabled = true;
            btnPesquisarAgenda.Enabled = true;

            txtNomePesquisa.Enabled = true;
            txtRGPesquisa.Enabled = true;

            txtNomePesquisa.Clear();
            txtRGPesquisa.Clear();


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

        private void btnPesquisarAgenda_Click(object sender, EventArgs e)
        {
            strSql = "Select * From TblAgenda where Nome = @PesquisaNome OR RG = @PesquisaRG";
        
            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@PesquisaNome", SqlDbType.VarChar).Value = txtNomePesquisa.Text;
            comando.Parameters.Add("@PesquisaRG", SqlDbType.VarChar).Value = txtRGPesquisa.Text;

            try
            {
                if (txtNomePesquisa.Text == string.Empty && txtRGPesquisa.Text == string.Empty)
                    MessageBox.Show("Digite Nome ou RG");



                sqlCon.Open();

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false)
                {
                    throw new Exception("Não esta Cadastrado");

                }

                dr.Read();

                txtNomeAgenda.Text = Convert.ToString(dr["Nome"]);
                txtRGAgenda.Text = Convert.ToString(dr["RG"]);
                mtxtCPFAgenda.Text = Convert.ToString(dr["CPF"]);
                txtEnderecoAgenda.Text = Convert.ToString(dr["Endereco"]);
                txtNumeroAgenda.Text = Convert.ToString(dr["Numero"]);
                txtBairroAgenda.Text = Convert.ToString(dr["Bairro"]);
                txtCidadeAgenda.Text = Convert.ToString(dr["Cidade"]);
                txtEmailAgenda.Text = Convert.ToString(dr["Email"]);
                mtxtTelefone1.Text = Convert.ToString(dr["Telefone1"]);
                mtxtTelefone2.Text = Convert.ToString(dr["Telefone2"]);
                mtxtTelefone3.Text = Convert.ToString(dr["Telefone3"]);
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
   
    }
}
