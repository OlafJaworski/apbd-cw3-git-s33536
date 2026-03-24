namespace apbd_cw3_s33536.Mod.Services;

public class DefPenaltyCalc : PenaltyCalc
{
    private readonly decimal _dailyPenalty;

    public DefPenaltyCalc(decimal dailyPenalty = 10.0m)
    {
        _dailyPenalty = dailyPenalty;
    }

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <=  dueDate) return 0;
        
        var dayslate = (returnDate - dueDate).Days;
        return dayslate *  _dailyPenalty;
    }
}