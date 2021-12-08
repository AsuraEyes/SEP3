package com.example.producingwebservice.demo_toBeRemovedLater;

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
    private Messages messageDAO;

    @Autowired
    public MessageEndpoint(MessageRepository messageRepository, Messages dao) {
      this.messageRepository = messageRepository;
      this.messageDAO = dao;
    }


  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "getMessageRequest")
  @ResponsePayload
  public GetMessageResponse getMessage(@RequestPayload GetMessageRequest request) {
    GetMessageResponse response = new GetMessageResponse();
    switch (request.getOperation()){
      case GET :
        response.setMessage(messageDAO.get(request.getId()));
        break;
      case POST:
        messageDAO.create(request.getMessage());
        break;
      case PATCH:
        messageDAO.patch(request.getMessage());
        break;
      case GETALL:
        response.setMessagesList(messageDAO.readAll());
        break;
      case DELETE:
        messageDAO.delete(request.getId());

    }


    return response;
  }
}
