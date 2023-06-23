namespace Persistence;
public class Order{
    public int OrderID{get;set;}
    public int CustomerInf{get;set;}
    public int Seller{get;set;}
    public int Accountant{get;set;}
    public List<Phone> ListPhone{get;set;}
    public string PaymentMethod{get;set;}
    public DateTime ?OrderDate{get;set;}
    public decimal TotalDue{get;set;}
    public int ?Status{get;set;}
    public string ?Note{get;set;}
}