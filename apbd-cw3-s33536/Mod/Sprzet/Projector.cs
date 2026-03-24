namespace apbd_cw3_s33536.Mod.Sprzet;

public class Projector : Item
{
    public string Res { get; set; }
    public int Lumen { get; set; }
    
    public Projector(string name, string res, int lumen) : base(name)
    {
        Res = res;
        Lumen = lumen;
    }
}