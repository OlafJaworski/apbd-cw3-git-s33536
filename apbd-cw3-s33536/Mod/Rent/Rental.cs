using apbd_cw3_s33536.Mod.Sprzet;
using apbd_cw3_s33536.Mod.Uzytkownicy;
namespace apbd_cw3_s33536.Mod.Rent;

public class Rental
{
    public Guid Id { get;} =  Guid.NewGuid();
    public User RentedBy { get; }
    public Item RentedItem { get; }
    public DateTime RentDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    public bool isActive => ReturnDate == null;

    public Rental(User rentedby, Item renteditem, DateTime rentdate, DateTime duedate)
    {
        RentedBy = rentedby;
        RentedItem = renteditem;
        RentDate = rentdate;
        DueDate = duedate;
    }
    
    public void MarkAsReturned(DateTime returndate, decimal penalty)
    {
        ReturnDate = returndate;
        Penalty = penalty;
    }

    
}