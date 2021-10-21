package com.example.springboot.dao;

import com.example.springboot.dbo.*;


public interface CodingInterviewDao {

  Customer getCustomer(int id);
  Invoice getInvoice(int id);
  Item getItem(int id);

}
