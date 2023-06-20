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
    public List<Phone> GetAll()
    {
        return idal.GetItems(ItemFilter.GET_ALL, new Phone());
    }
    public List<Phone> GetByName(string itemName)
    {
        return idal.GetItems(ItemFilter.FILTER_BY_ITEM_NAME, new Phone { });
    }

}