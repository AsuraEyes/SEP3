package com.example.producingwebservice;

import io.spring.guides.gs_producing_web_service.GetCountryRequest;
import io.spring.guides.gs_producing_web_service.GetCountryResponse;
import io.spring.guides.gs_producing_web_service.GetMessageRequest;
import io.spring.guides.gs_producing_web_service.GetMessageResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

  @Endpoint
  public class MessageEndpoint {
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    private MessageRepository messageRepository;

    @Autowired
    public MessageEndpoint(MessageRepository messageRepository) {
      this.messageRepository = messageRepository;
    }


  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "getMessageRequest")
  @ResponsePayload
  public GetMessageResponse getMessage(@RequestPayload GetMessageRequest request) {
    GetMessageResponse response = new GetMessageResponse();
    response.setMessage(messageRepository.get(request.getName()));

    return response;
  }
}
