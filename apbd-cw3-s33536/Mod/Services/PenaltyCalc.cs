namespace apbd_cw3_s33536.Mod.Services;

public interface PenaltyCalc
{
    decimal CalculatePenalty(DateTime dueDate, DateTime returnDate);
}