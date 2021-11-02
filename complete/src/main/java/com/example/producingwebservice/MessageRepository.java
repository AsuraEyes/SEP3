package com.example.producingwebservice;

import io.spring.guides.gs_producing_web_service.Country;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;

@Component
public class MessageRepository
{
  private String title;
  private String body;

  @PostConstruct
  public void initData()
  {
    title = "Hello";
    body = "World";
  }

  public String get(String request)
  {
    return title + " " + body;
  }
}
