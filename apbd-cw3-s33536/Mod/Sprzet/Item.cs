namespace apbd_cw3_s33536.Mod.Sprzet;

public abstract class Item
{
    public Guid Id { get;} = Guid.NewGuid();
    public string Name { get; set; }
    public bool Dostepny { get; set; } = true;

    protected Item(string name)
        {
        Name = name;
        }
}