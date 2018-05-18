<Query Kind="Program" />

void Main()
{
	String cnctInfo = @"Data Source=127.0.0.1;Initial Catalog=pubs;Connect Timeout=3;Persist Security Info=True;User ID=sa;Password=dev01";
	SqlConnection sqlConnection = new SqlConnection(cnctInfo);
	sqlConnection.Open();
	System.Data.SqlClient.SqlCommand sqlCommand = new SqlCommand();
	sqlCommand.Connection = sqlConnection;
	sqlCommand.CommandText = "Select * from jobs";
	SqlDataReader sdr = sqlCommand.ExecuteReader (CommandBehavior.CloseConnection) ;
	
	while (sdr.Read() == true) {
		short jobID = ((short)sdr["job_id"]);
		string jobDesc = (string)sdr["job_desc"];
		Console.WriteLine(string.Format("{0} / {1} / \r\n", jobID, jobDesc.Trim()));
	}
	
 	sqlConnection.Close();
}

// Define other methods and classes here
