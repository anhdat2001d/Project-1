using Persistence;
using MySqlConnector;
namespace DAL{
public class OrderDAL{
    private  static MySqlConnection connection = DbConfig.GetConnection();
    private  static string query = "";
    public  static Order GetOrder(MySqlDataReader reader){
        Order output = new Order();
        output.OrderID = reader.GetInt32("Order_ID");
        output.CustomerInf = reader.GetInt32("Customer_ID");
        output.Seller = reader.GetInt32("Seller_ID");
        output.Accountant = reader.GetInt32("Accountant_ID");
        output.OrderDate = reader.GetDateTime("Order_Date");
        output.Status = reader.GetInt32("Order_Status");
        output.PaymentMethod = reader.GetString("Paymentmethod");
        output.ListPhone = GetItemsInOrderByID(reader.GetInt32("Order_ID"));
        return output;
    }
    public  static Order GetOrderByID(int id){
        Order output = new Order();
        try{
            query = @"select Order_ID, Customer_ID, Seller_ID, Accountant_ID, Order_Date, Order_Status, Paymentmethod
            from orders where order_id = @id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){
                output = GetOrder(reader);
            }
            reader.Close();
        }catch(MySqlException ex){
            Console.Write(ex.Message);
        }
        return output;
    }
    public static List<Phone> GetItemsInOrderByID(int id){
        List<Phone> output = new List<Phone>();
        try{
            query = @"select p.phone_id, p.Phone_Name, p.Brand, p.Price, p.Platform , p.status
            from phones p inner join orderdetails od on p.phone_id = od.phone_id
            inner join orders o on o.order_id = od.order_id
            where o.order_id = @id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
                output.Add(PhoneDAL.GetItem(reader));
            }
            reader.Close();
        }catch{}
        return output;
    }
    public  static List<Order> GetOrderUnpaidInDay(){
        List<Order> output = new List<Order>();
        try{
            query = @"select * from orders where order_status = '1';";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
                output.Add(GetOrder(reader));
            }
            reader.Close();
        }catch{}
        return output;
    }
    public  static List<Order> GetOrderPaidInDay(){
        List<Order> output = new List<Order>();
        try{
            query = @"select * from orders where order_status = '2';";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
                output.Add(GetOrder(reader));
            }
            reader.Close();
        }catch{}
        return output;
    }
    public  static List<Order> GetOrderExportInDay(){
        List<Order> output = new List<Order>();
        try{
            query = @"select * from orders where order_status = '3';";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
                output.Add(GetOrder(reader));
            }
            reader.Close();
        }catch{}
        return output;
    }
    public  static bool CreateOrder(Order order){
        bool result = false;
        int countphone = 0;
        int phoneid = 0;
        int countPhoneNotOrderYet = 0;
        MySqlTransaction ?tr = null;
        try{
            //Bat dau transaction
            tr = connection.BeginTransaction();
            MySqlCommand command = new MySqlCommand(connection, tr);
            //Thuc thi Insert order vao DB
            query = @"insert into orders(customer_id, seller_id, accountant_id, paymentmethod) 
            value (@cusid, @sellerid, @accid, @paymentmethod);";
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@cusid", order.CustomerInf);
                    command.Parameters.AddWithValue("@sellerid", order.Seller);
                    command.Parameters.AddWithValue("@accid", order.Accountant);
                    command.Parameters.AddWithValue("@paymentmethod", order.PaymentMethod);
                    command.ExecuteNonQuery();
                    //Chon ra order vua insert vao DB
                    query = @"select Order_ID from orders order by Order_ID desc limit 1; ";
                    command.CommandText = query;
                    MySqlDataReader reader = command.ExecuteReader();
                    //Lay ra id
                    if(reader.Read()){
                        order.OrderID = reader.GetInt32("Order_ID");
                    }
                    reader.Close();
                    //Kiem tra cac mat hang co trong Cart
            foreach(var phone in order.ListPhone){
                try{
                    query = @"select phone_id from phones where phone_name = @name 
                    and brand = @brand and price = @price and platform = @platform and  status = '1';";
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", phone.PhoneName);
                    command.Parameters.AddWithValue("@brand", phone.Brand);
                    command.Parameters.AddWithValue("@price", phone.Price);
                    command.Parameters.AddWithValue("@platform", phone.Platform);
                    reader = command.ExecuteReader();
                    while(reader.Read()){
                        phoneid = reader.GetInt32("Phone_ID");
                        countPhoneNotOrderYet++;
                    }
                    reader.Close();
                    // check So luong trong DB
                    if(countPhoneNotOrderYet > 0){
                        // Neu So luong dien thoai(chua ban) trong DB>0 thi thuc hien insert nhu sau
                    query = @"insert into orderdetails(order_id, phone_id) value(@orderid, @phoneid);";
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@orderid", order.OrderID);
                    command.Parameters.AddWithValue("@phoneid", phoneid);
                    command.ExecuteNonQuery();
                    countphone++;
                    }
                    else{
                        //Neu so luong dien thoai(chua ban) ==0 thoat vong lap 
                        result = false;
                        break;
                    }
                }catch(MySqlException ex){
                    Console.WriteLine(ex.Message);
                }
                }
                if(countphone == order.ListPhone.Count() && order.ListPhone.Count()>0)result = true;
                else{
                    result = false;
                }
                if(result == true){
                    tr.Commit();
                }
                else tr.Rollback();

            }catch(MySqlException ex){
                try{
                    if(tr!= null)
                    tr.Rollback();
                    result = false;
                }catch(MySqlException ex1){
                    Console.WriteLine(ex1.Message);
                }
                Console.WriteLine(ex.Message);
            }

            return result;

        }
    }
}
