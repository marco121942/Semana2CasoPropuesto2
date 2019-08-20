using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana02CasoPropuesto2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Marco"].ConnectionString);

        private void Form1_Load(object sender, System.EventArgs e)
        {
            ListarPedidos();
        }
        private void ListarPedidos()
        {
            using (SqlCommand cmd = new SqlCommand("usp_listar_pedidos", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "pedidos");
                        dataGridView1.DataSource = df.Tables["pedidos"];
                    }
                }
            }
        }
        private void listarDetalleProducto()
        {
            int codigo;
            codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            using (SqlCommand cmd = new SqlCommand("usp_Detalle_pedido", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idPedido", codigo);
                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "Detalles");
                        dataGridView2.DataSource = df.Tables["Detalles"];
                    }
                }
            }
        }

        private void DataGridView1_DoubleClick(object sender, System.EventArgs e)
        {
            listarDetalleProducto();
        }
    }
}
