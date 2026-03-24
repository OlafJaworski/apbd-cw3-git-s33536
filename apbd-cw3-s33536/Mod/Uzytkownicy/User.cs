namespace apbd_cw3_s33536.Mod.Uzytkownicy;

public abstract class  User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string fName { get; set; } 
    public string lName { get; set; }
    public abstract int maxWypo { get; }

    protected User(string fname, string lname)
    {
        fName = fname;
        lName = lname;
    }
}