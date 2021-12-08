package dk.bookAndPlay.organizers;

import java.util.ArrayList;

public interface Organizers
{
  ArrayList<String> getOrganizerList(int eventId);
  void organize (int eventId, String username);
  void withdraw (int eventId, String username);
}
