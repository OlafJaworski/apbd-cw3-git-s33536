namespace apbd_cw3_s33536.Mod.Sprzet;

public class Laptop : Item
{
    public int ramGB { get; set; }
    public string Procesor { get; set; }

    public Laptop(string name, int ramgb, string procesor) : base(name)
    {
        ramGB = ramgb;
        Procesor = procesor;
    }
}