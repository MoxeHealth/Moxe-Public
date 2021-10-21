package com.example.springboot.controller;

import com.example.springboot.database.SqliteDatabase;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("initialize")
public class InitializeController
{
  @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<?> initialzeDatabase()
    {
      String message = "Coding Interview successfully started!\n";

      SqliteDatabase database = new SqliteDatabase();
      database.createTables();
      {
        message += "\nDatabase initialized with:\n\t{typeof(Customer).FullName} {db.Customers.Count()}\n\t{typeof(Invoice).FullName} {db.Invoices.Count()}\n\t{typeof(Item).FullName} {db.Items.Count()}\n\t{typeof(Order).FullName} {db.Invoices.Sum(x => x.Orders.Count)}";
      }

      return new ResponseEntity<String>(message, HttpStatus.OK);
    }
  }


