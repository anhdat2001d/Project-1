using MySqlConnector;
using Persistence;
namespace DAL;
public class StaffDAL{
    private MySqlConnection connection = DbConfig.GetConnection();
    private string query = "";
    public Staff Login(Staff staff){
        Staff output = new Staff();
        int count = 0;
        try{
            string query = @"select * from staffs where staff_name = @name and user_name = @username and password = @password ;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", staff.StaffName);
            command.Parameters.AddWithValue("@username", staff.UserName);
            command.Parameters.AddWithValue("@password", staff.Password);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){
                output = GetStaff(reader);
                count++;
            }
        }
        catch{}
        return output;
    }
    public Staff GetStaff(MySqlDataReader reader){
        Staff output = new Staff();
        output.StaffID = reader.GetInt32("Staff_ID");
        output.StaffName = reader.GetString("Staff_Name");
        output.UserName = reader.GetString("User_Name");
        output.Password = reader.GetString("Password");
        output.Address = reader.GetString("Address");
        output.TitleID = reader.GetInt32("Title_ID");
        return output;
    }
}