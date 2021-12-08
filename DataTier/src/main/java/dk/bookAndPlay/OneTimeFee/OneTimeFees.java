package dk.bookAndPlay.OneTimeFee;

import dk.bookandplay.web_service.OneTimeFee;

import java.util.List;

public interface OneTimeFees
{
  OneTimeFee create(OneTimeFee oneTimeFee);
  OneTimeFee getOneTimeFee(String username, int eventId);
  List<OneTimeFee> getOneTimeFeeList(String username);
}
