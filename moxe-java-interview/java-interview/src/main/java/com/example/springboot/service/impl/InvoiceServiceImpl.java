package com.example.springboot.service.impl;

import com.example.springboot.dao.impl.CodingInterviewDaoImpl;
import com.example.springboot.dbo.Invoice;
import com.example.springboot.service.*;


public class InvoiceServiceImpl implements InvoiceService {
    CodingInterviewDaoImpl dao = new CodingInterviewDaoImpl();
    public Invoice Get(int id)
    {
      return dao.getInvoice(id);
    }
  }
