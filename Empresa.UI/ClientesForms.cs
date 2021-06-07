using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Empresa.DB;   
using empresa_models;
using System.Data.SqlClient;


namespace Empresa.UI
{
    public partial class ClientesForms : Form
    {
        public ClientesForms()
        {
            InitializeComponent();
        }
        private void ExibirGrid()
        {
            
            listaDataGridView1.Visible = true;
            listaDataGridView1.Dock = DockStyle.Fill; // filtra elementos
            fichaPanel.Visible = false;
            // Lista de botões
            novoButton.Visible = true;
            alterarButton.Visible = true;
            excluirButton.Visible = true;
            sairButton.Visible = true;
            voltarButton.Visible = false;
            confirmarAlterarButton.Visible = false;
            confirmarExclusãoButton.Visible = false;
            confirmarIncluirButton5.Visible = false;

            var db = new ClienteDb();
            listaDataGridView1.DataSource = db.Listar();
            listaDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listaDataGridView1.ReadOnly = false;
            listaDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listaDataGridView1.RowHeadersVisible = false;
            listaDataGridView1.EnableHeadersVisualStyles = false;
            listaDataGridView1.Columns["Id"].Width = 50; // diminui o tamanho da coluna do id
           
        }

        private void ClientesForms_Load(object sender, EventArgs e)
        {
            ExibirGrid();
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            ExibirFicha();
            confirmarAlterarButton.Visible = false;
            confirmarExclusãoButton.Visible = false;
            confirmarIncluirButton5.Visible = true;
            LimparFicha();
        }
        private void LimparFicha()
        {
            idTextBox.Clear();
            nomeTextBox.Clear();
            telefoneTextBox.Clear();
            emailTextBox.Clear();

            idTextBox.Focus();
        }
        private void ExibirFicha()
        {
            fichaPanel.Visible = true;
            fichaPanel.Dock = DockStyle.Fill;
            listaDataGridView1.Visible = false;
            // Lista de botões
            novoButton.Visible = false;
            alterarButton.Visible = false;
            excluirButton.Visible = false;
            sairButton.Visible = false;
            voltarButton.Visible = true;
            confirmarAlterarButton.Visible = false;
            confirmarExclusãoButton.Visible = false;
            confirmarIncluirButton5.Visible = true;
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            ExibirGrid();
        }

        private void confirmarIncluirButton5_Click(object sender, EventArgs e)
        {
            //Aqui instancia o objeto e capta os dados digitados pelo usuario
            var cliente = new Clientes();
            cliente.Id = Convert.ToInt32(idTextBox.Text);
            cliente.nome = nomeTextBox.Text;
            cliente.telefone = telefoneTextBox.Text;
            cliente.email = emailTextBox.Text;

            //Aqui instancia o objeto db para incluir no banco de dados 
            var db = new ClienteDb();
            db.Incluir(cliente);

            ExibirGrid();
        }

        private void alterarButton_Click(object sender, EventArgs e)
        {
            Clientes cliente = (Clientes)listaDataGridView1.CurrentRow.DataBoundItem; // retorna o item selecionado, ou seja o objeto desaejado
            idTextBox.Text = cliente.Id.ToString();
            nomeTextBox.Text = cliente.nome;
            emailTextBox.Text = cliente.email;
            telefoneTextBox.Text = cliente.telefone;
            ExibirFicha();
            confirmarAlterarButton.Visible = true;
            confirmarExclusãoButton.Visible = false;
            confirmarIncluirButton5.Visible = false;

           /* var db = new ClienteDb();
            db.Alterar(cliente);*/

            //ExibirGrid();
        }

        private void confirmarAlterarButton_Click(object sender, EventArgs e)
        {
            //Aqui instancia o objeto e capta os dados digitados pelo usuario
            var cliente = new Clientes();
            cliente.Id = Convert.ToInt32(idTextBox.Text);
            cliente.nome = nomeTextBox.Text;
            cliente.telefone = telefoneTextBox.Text;
            cliente.email = emailTextBox.Text;

            //Aqui instancia o objeto db para incluir no banco de dados 
            var db = new ClienteDb();
            db.Alterar(cliente);

            ExibirGrid();
        }

        private void confirmarExclusãoButton_Click(object sender, EventArgs e)
        {
            //Aqui instancia o objeto e capta os dados digitados pelo usuario
            var cliente = new Clientes();
            cliente.Id = Convert.ToInt32(idTextBox.Text);
            cliente.nome = nomeTextBox.Text;
            cliente.telefone = telefoneTextBox.Text;
            cliente.email = emailTextBox.Text;

            //Aqui instancia o objeto db para incluir no banco de dados 
            var db = new ClienteDb();
            db.Excluir(cliente.Id);

            ExibirGrid();
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            Clientes cliente = (Clientes)listaDataGridView1.CurrentRow.DataBoundItem; // retorna o item selecionado, ou seja o objeto desaejado
            idTextBox.Text = cliente.Id.ToString();
            nomeTextBox.Text = cliente.nome;
            emailTextBox.Text = cliente.email;
            telefoneTextBox.Text = cliente.telefone;
            ExibirFicha();
            confirmarAlterarButton.Visible = false;
            confirmarExclusãoButton.Visible = true;
            confirmarIncluirButton5.Visible = false;

        }
    }
}
