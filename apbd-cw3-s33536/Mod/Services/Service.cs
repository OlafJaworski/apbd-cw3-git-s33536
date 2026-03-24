using apbd_cw3_s33536.Mod.Exceptions;
using apbd_cw3_s33536.Mod.Rent;
using apbd_cw3_s33536.Mod.Services;
using apbd_cw3_s33536.Mod.Uzytkownicy;
using apbd_cw3_s33536.Mod.Sprzet;

namespace apbd_cw3_s33536.Mod;

using apbd_cw3_s33536;

public class RentalService
{
    private readonly List<User> _users = new();
    private readonly List<Item> _items = new();
    private readonly List<Rental> _rentals = new();
    private readonly PenaltyCalc _penaltyCalc;
    
    public RentalService(PenaltyCalc penaltyCalc)
    {
        _penaltyCalc = penaltyCalc;
    }
    
    public void AddUser(User user) => _users.Add(user);
    public void AddItem(Item item) => _items.Add(item);
    
    public IEnumerable<Item> GetAllItems() => _items.AsReadOnly();

    public IEnumerable<Item> GetAvalibleItems() => _items.Where(i => i.Dostepny).ToList();

    public void MarkAsUnavailable(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null) item.Dostepny = false;
    }

    public IEnumerable<Rental> GetActiveRentalsForUser(User user)
    {
        return _rentals.Where(r => r.RentedBy.Id == user.Id && r.isActive ).ToList();
    }


    public IEnumerable<Rental> GetOverdueRentals(DateTime currentDate)
    {
        return _rentals.Where(r => r.isActive && r.DueDate < currentDate).ToList();
    }

    public Rental RentItem(User user, Item item, DateTime rentDate, int durationDays)
    {
        if (!item.Dostepny)
            throw new ItemNotAvailableException($"{item.Name} jest niedostepny");

        var activeRentalCount = GetActiveRentalsForUser(user).Count();
        if (activeRentalCount >= user.maxWypo)
            throw new UserLimitExceededException(($"{user.fName} osiagnal limit wypozyczania {user.maxWypo}"));

        var dueDate = rentDate.AddDays(durationDays);
        var rental = new Rental(user, item, rentDate, dueDate);

        item.Dostepny = false;
        _rentals.Add(rental);
        return rental;
    }

    public void ReturnItem(Guid rentalId, DateTime returnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId && r.isActive);
        if (rental == null)
            throw new RentalNotFoundException("Nie ma aktywnego wypozyczenia o tym id");

        decimal penalty = _penaltyCalc.CalculatePenalty(returnDate, rental.DueDate);
        rental.MarkAsReturned(returnDate, penalty);
        rental.RentedItem.Dostepny = true;

    }

    public void summaryRaport()
    {
        Console.WriteLine("\n====== Raport Podsumowujący ======");
        Console.WriteLine($"Liczba sprzetu {_items.Count}");
        Console.WriteLine($"Dostepny sprzet {GetAvalibleItems().Count()}");
        Console.WriteLine($"Liczba Uzytkownikop {_users.Count}");
        Console.WriteLine($"Liczba wypozyczen {_rentals.Count}");
        Console.WriteLine($"Aktywne wypozyczenia {_rentals.Count(r => r.isActive)}");
        Console.WriteLine($"Zarobione z kar {_rentals.Sum(r => r.Penalty)}");
    }
}