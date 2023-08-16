using System.Data.SqlClient;

RunProgram();

void RunProgram()
{
    Console.Write("Connection string: ");
    string connectionString = Console.ReadLine();
    
    SqlConnection connection = new SqlConnection(connectionString);
    
    try {
        //open the connection

        connection.Open();

            Console.Write("Table name (enter to skip): ");
            string tableName = Console.ReadLine();

        if (string.IsNullOrEmpty(tableName))
        {
            return;
        }

        string sql = $"SELECT TOP 1 * FROM {tableName}";
        SqlCommand command = new SqlCommand(sql, connection);

        //execute the command

        SqlDataReader reader = command.ExecuteReader();


        //read the results

        while (reader.Read())
        {
            // print number of columns
            Console.WriteLine("\nNumber of columns: {0}\n\n", reader.FieldCount);

            // print column names
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
            }
        }

    }
    catch (Exception e)
    {
        Console.WriteLine($"\n\n\n=====================\n\n >>> {e.Message}\n\n=====================\n\n");
    }
    finally
    {
        // close the connection
        connection.Close();
    }
}
