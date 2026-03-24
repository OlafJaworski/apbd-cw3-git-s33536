namespace apbd_cw3_s33536.Mod.Sprzet;

public class Camera : Item
{
    public int Megapixel { get; set; }
    public bool maObiektyw { get; set; }

    public Camera(string name, int megapixel, bool maobiektyw) : base(name)
    {
        Megapixel = megapixel;
        maObiektyw = maobiektyw;
    }
}