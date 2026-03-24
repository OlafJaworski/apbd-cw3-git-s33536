using apbd_cw3_s33536.Mod;
using apbd_cw3_s33536.Mod.Sprzet;
using apbd_cw3_s33536.Mod.Uzytkownicy;
using apbd_cw3_s33536.Mod.Services;
using apbd_cw3_s33536.Mod.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        var penaltyCalc = new DefPenaltyCalc(10m);
        var rentalService = new RentalService(penaltyCalc);




        var lap1 = new Laptop("Macbook", 16, "M1");
        var lap2 = new Laptop("Thinkpad", 2, "Intel core duo");
        var cam1 = new Camera("Instax", 7, false);
        var proj1 = new Projector("idk", "360p", 3000);

        rentalService.AddItem(lap1);
        rentalService.AddItem(lap2);
        rentalService.AddItem(cam1);
        rentalService.AddItem(proj1);

        var student1 = new Student("Ala", "Makota", "s12345");
        var pracownik1 = new Pracownik("Matt", "Patt", "Skibidi");
        
        rentalService.AddUser(student1);
        rentalService.AddUser(pracownik1);

        var dzisiaj = DateTime.Now;
        var rental1 = rentalService.RentItem(student1,lap1, dzisiaj,7);
        var rental2 = rentalService.RentItem(pracownik1, cam1,dzisiaj,3);
        var rental3 = rentalService.RentItem(student1, proj1, dzisiaj, 6);
        
        //Niepoprawne operacje
        var rental4 = rentalService.RentItem(pracownik1,lap1, dzisiaj,7); // Laptop zajety
        var rental5 = rentalService.RentItem(student1, lap2, dzisiaj, 7); // limit wypozyczen


        
        rentalService.ReturnItem(rental1.Id,dzisiaj.AddDays(5));
        rentalService.ReturnItem(rental2.Id,dzisiaj.AddDays(10));
        
        rentalService.summaryRaport();



    }
    
    
    
    
}