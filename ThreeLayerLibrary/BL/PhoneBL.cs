using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL;

public class PhoneBL
{
    private PhoneDAL idal = new PhoneDAL();
    public Phone GetItemById(int itemId)
    {
        return idal.GetItemById(itemId);
    }
    public List<Phone>? GetAllItem() {
        List<Phone> list = idal.GetAllItem();
        if(list.Count() == 0) return null;
        else return list;
    }
    public List<Phone>? SearchByPhoneInformation(string? phoneInformation)
    {
        if(phoneInformation == "") return idal.GetAllItem();
        else if(phoneInformation == null) {
            return null;
        } else {
            List<Phone> list = idal.Search(phoneInformation);
            if(list.Count() == 0) return null;
            else return idal.Search(phoneInformation);
        } 
    }
}