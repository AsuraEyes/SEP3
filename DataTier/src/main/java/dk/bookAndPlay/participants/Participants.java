package dk.bookAndPlay.participants;

import java.util.ArrayList;

public interface Participants
{
  ArrayList<String> getParticipantList(int eventId);
  void join (int eventId, String username);
  void withdraw (int eventId, String username);
}
