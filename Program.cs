using System;
using MySql.Data.MySqlClient;

namespace SelectStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;database=employees;password=root";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to database ....");
                conn.Open();

                string sql = "Select employees.emp_no , employees.first_name , employees.last_name , titles.title , dept_emp.emp_no , dept_emp.dept_no , departments.dept_name from employees.employees Left join employees.titles on titles.emp_no = employees.emp_no join employees.dept_emp  on dept_emp.emp_no  = employees.emp_no left join employees.departments on dept_emp.dept_no  =  departments.dept_no";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                Console.WriteLine($"EMP_No\tFirst_Name,Last_name\tTitle\tdepartments");
                while (rdr.Read())
                {
                    string emp_no = rdr.GetString(0);
                    string first_name = rdr.GetString(1);
                    string last_name = rdr.GetString(2);
                    string title = rdr.GetString(3);
                    string dept_name = rdr.GetString(6);
                    Console.WriteLine($"  {emp_no}\t{first_name},{last_name}\t\t{title}\t{dept_name}");

                }
                rdr.Close();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            Console.WriteLine("Connection closed ....");

            //Console.Read();

        }
    }
}

