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
}