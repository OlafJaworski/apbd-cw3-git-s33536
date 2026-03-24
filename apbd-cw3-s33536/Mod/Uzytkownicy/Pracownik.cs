namespace apbd_cw3_s33536.Mod.Uzytkownicy;

public class Pracownik : User
{
    public string Dept { get; set; }

    public override int maxWypo => 5;

    public Pracownik(string fname, string lname, string dept) : base(fname, lname)
    {
        Dept = dept;
    }
}