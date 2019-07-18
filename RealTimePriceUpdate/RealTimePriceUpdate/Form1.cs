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

namespace RealTimePriceUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialization();
            //LoadData();
        }
        string connectionString = @"Data Source=LSGMRLR9V51M9L\SQLEXPRESS;Initial Catalog=RealTimeDB;Integrated Security=True";
        string queueName = "";
        SqlConnection SqlConnection;
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        SqlCommand command;
        void Initialization()
        {
            // Create a dependency connection.
            SqlDependency.Start(connectionString);
            InitiateSqlDependency();
            timerGarbageCollector.Start();
            //LoadGridView();
        }
        DataTable table;
        void InitiateSqlDependency()
        {
            // Assume connection is an open SqlConnection.
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
            // Create a new SqlCommand object.
           command = new SqlCommand(
                "SELECT Symbol, Price, Name FROM dbo.StockQuote",
                SqlConnection);
            
                // Create a dependency and associate it with the SqlCommand.
                SqlDependency dependency = new SqlDependency(command);
                // Maintain the reference in a class member.

                // Subscribe to the SqlDependency event.
                dependency.OnChange += new
                   OnChangeEventHandler(OnDependencyChange);

            // Execute the command.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Process the DataReader.
                table = new DataTable();
                table.Load(reader);
                Console.Out.WriteLine("Row count:"+ table.Rows.Count);
            }
            MethodInvoker methodInvokerDelegate = delegate ()
            { LoadGridView(); };

            //This will be true if Current thread is not UI thread.
            if (this.InvokeRequired)
                this.Invoke(methodInvokerDelegate);
            else
                methodInvokerDelegate();


        }

        // Handler method
        void OnDependencyChange(object sender,
           SqlNotificationEventArgs e)
        {
            // Handle the event (for example, invalidate this cache entry).
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= OnDependencyChange;
            InitiateSqlDependency();
        }
        
        void StopDependency()
        {
            // Release the dependency.
            SqlDependency.Stop(connectionString, queueName);
        }
        public void LoadGridView()
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
           
            if (dataGridView1.Columns.Count <= 0)
            {
                dataGridView1.Columns.Add("Symbol", "Symbol");
                dataGridView1.Columns.Add("Price", "Price");
                dataGridView1.Columns.Add("Name", "Name");
            }
            foreach (DataRow dr in table.Rows)
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDependency();
        }

        private void timerGarbageCollector_Tick(object sender, EventArgs e)
        {
            //Console.Out.WriteLine("Before collect:" + GC.GetTotalMemory(false));               
            //GC.Collect();
            //Console.Out.WriteLine("After collect:" + GC.GetTotalMemory(false));
        }
    }
}
