package dk.bookAndPlay.monthlyFee;

import dk.bookandplay.web_service.MonthlyFee;

import java.text.ParseException;
import java.util.List;

public interface MonthlyFees
{
    MonthlyFee getMonthlyFee(String username);
    MonthlyFee create(MonthlyFee monthlyFee) throws ParseException;
    List<MonthlyFee> getMonthlyFeeList(String username);
    void updateMonthlyFee(MonthlyFee monthlyFee);
}
