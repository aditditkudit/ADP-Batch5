using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TugasADO
{
    class Connector
    {
        private SqlConnection connection;

        public Connector()
        {
            try
            {
                string connectionString = @"Server=01-05-0035-0516;Database=TodoList;Trusted_Connection=True;";
                connection = new SqlConnection(connectionString);
                Console.WriteLine("Koneksi Berhasil");
            }
            catch(SqlException e)
            {
                Console.WriteLine("Gagal Konek \t {0}", e.Message);
            }
        }
        public SqlConnection Connection { get => connection;  }
    }

    class Controller
    {
        private string query;
        private SqlConnection connection;

        public Controller()
        {
            Connector connector = new Connector();
            this.connection = connector.Connection;
        }

        public string Query { get => query; set => query = value; }

        // Method Select
        public void viewAllList()
        {
            try
            {
                connection.Open();
                string query = "SELECT CASE WHEN STATUS = 1	THEN CONCAT([listTodo], '*') ELSE CONCAT([listTodo], '') END AS TODO_LIST FROM todolist ORDER BY STATUS DESC";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader["TODO_LIST"]);
                }
                connection.Close();
            }catch(SqlException e)
            {
                Console.WriteLine("Gagal Menampilkan TodoList" + e.Message);
            }
        }

        public void setPriority()
        {
            Console.WriteLine("Masukkan ID Untuk Di priority: ");
            int todolist_id = Convert.ToInt32(Console.ReadLine());
            try
            {
                connection.Open();
                string queryUpdate = "update todolist set status=1 where todoList_id=" + todolist_id;
                SqlCommand cmd = new SqlCommand(queryUpdate, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Set Priority Berhasil");
                connection.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine("Gagal melakukan Set Priority");
            }
        }

        public void addTodo()
        {
            Console.WriteLine("Masukkan Todo Untuk Di masukkan List: ");
            string listTodo = Console.ReadLine();
            try
            {
                connection.Open();                
                string queryInsert = "insert into todolist(listTodo) values(@listTodo)";
                SqlCommand cmd = new SqlCommand(queryInsert, connection);
                cmd.Parameters.AddWithValue("@listTodo", listTodo);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine("Menambah ToDo Gagal");
            }
        }

        public void deleteTodo()
        {
            Console.WriteLine("Masukkan ID Untuk Di priority: ");
            int todolist_id = Convert.ToInt32(Console.ReadLine());
            try
            {
                connection.Open();
                string queryDelete = "delete from todolist where todoList_id =" + todolist_id;
                SqlCommand cmd = new SqlCommand(queryDelete, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Delete Berhasil");
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void listTodoID()
        {
            try
            {
                connection.Open();
                string query = "SELECT todoList_id, CASE WHEN STATUS = 1	THEN CONCAT([listTodo], '*') ELSE CONCAT([listTodo], '') END AS TODO_LIST FROM todolist ORDER BY STATUS DESC";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}|{1}", reader["todoList_id"], reader["TODO_LIST"]);
                }
                connection.Close();
            }catch (SqlException e)
            {
                Console.WriteLine("Gagal Menampilkan TodoList" + e.Message);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Controller ctl = new Controller();
            int pilih;

            do
            {
                Console.WriteLine(" To Do List ");
                ctl.viewAllList();
                Console.WriteLine("==========================");
                Console.WriteLine("Menu Todo List");
                Console.WriteLine("1. Nambah Todo");
                Console.WriteLine("2. Set Priority Todo");
                Console.WriteLine("3. Hapus Todo");
                Console.WriteLine("4. Keluar");
                Console.WriteLine("Pilih Menu: ");
                pilih = Convert.ToInt32(Console.ReadLine());

                if (pilih == 1)
                {
                    
                    ctl.addTodo();
                    Console.Clear();
                }
                else if (pilih == 2)
                {
                    Console.WriteLine("ID|To Do");
                    ctl.listTodoID();
                    Console.WriteLine("==========================");
                    ctl.setPriority();
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (pilih == 3)
                {
                    Console.WriteLine("ID|To Do");
                    ctl.listTodoID();
                    Console.WriteLine("==========================");
                    ctl.deleteTodo();
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Pilihan Salah");
                }

            }
            while (pilih != 4);
        }
    }
}
