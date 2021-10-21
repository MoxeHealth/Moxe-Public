package com.example.springboot.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

  @RestController
  @RequestMapping("item")
  public class ItemController {

    @RequestMapping(value = "/{id}", method = RequestMethod.GET)
    public ResponseEntity<?> Get(@PathVariable
    final Integer id) {
      throw new NotImplementedException();
    }

  }


