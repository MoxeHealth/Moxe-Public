package com.example.springboot.controller;

import com.example.springboot.dbo.Invoice;
import com.example.springboot.service.impl.InvoiceServiceImpl;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("invoice")
public class InvoiceController {
  InvoiceServiceImpl invoiceService = new InvoiceServiceImpl();

  @RequestMapping(value = "/{id}", method = RequestMethod.GET)
  public ResponseEntity<?> Get(@PathVariable final Integer id)
  {
    Invoice invoice = invoiceService.Get(id);
    ResponseEntity response;

    if (invoice == null) {
      response = new ResponseEntity<>(HttpStatus.NOT_FOUND);
    } else {
      response = new ResponseEntity<>(invoice.toString(), HttpStatus.OK);
    }

    return response;
  }
}


