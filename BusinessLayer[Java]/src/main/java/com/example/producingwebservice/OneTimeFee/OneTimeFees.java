package com.example.producingwebservice.OneTimeFee;

import io.spring.guides.gs_producing_web_service.OneTimeFee;

public interface OneTimeFees
{
  OneTimeFee create(OneTimeFee oneTimeFee);
  OneTimeFee getOneTimeFee(String username, int eventId);
}
