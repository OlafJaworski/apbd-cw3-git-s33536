namespace apbd_cw3_s33536.Mod.Uzytkownicy;

public class Student : User
{
    public override int maxWypo => 2;
    public string studentId { get; set; }
    
    public Student(string fname, string lname, string id) : base(fname, lname)
    {
        studentId = id;
        
    }
}