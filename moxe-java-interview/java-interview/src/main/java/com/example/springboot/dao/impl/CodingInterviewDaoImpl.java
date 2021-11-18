package com.example.springboot.dao.impl;


import com.example.springboot.dao.*;
import com.example.springboot.dbo.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.*;


public class CodingInterviewDaoImpl implements CodingInterviewDao {

  public Customer getCustomer(int id) {
    Customer customer = new Customer();
    Connection conn = null;

    try {
      // db parameters
      String url = "jdbc:sqlite:identifier.sqlite";
      // create a connection to the database
      conn = DriverManager.getConnection(url);
      String sql = "SELECT * FROM CUSTOMER WHERE ID ="+id+";";
      Statement statement = conn.createStatement();
      ResultSet customerResultSet = statement.executeQuery(sql);
      customer.setId(id);
      customer.setName(customerResultSet.getString("NAME"));
      customer.setType(customerResultSet.getString("TYPE"));

    } catch (SQLException e) {
      System.out.println(e.getMessage());
    } finally {
      try {
        if (conn != null) {
          conn.close();
        }
      } catch (SQLException ex) {
        System.out.println(ex.getMessage());
      }
    }
    return customer;
  }

  public Invoice getInvoice(int id) {
    Invoice invoice = new Invoice();
    Connection conn = null;
    try {
      // db parameters
      String url = "jdbc:sqlite:identifier.sqlite";
      // create a connection to the database
      conn = DriverManager.getConnection(url);
      String sql = "SELECT * FROM INVOICE WHERE ID ="+id+"";
      Statement statement = conn.createStatement();
      ResultSet invoiceResultSet = statement.executeQuery(sql);
      invoice.setId(id);
      invoice.setCustomerId(invoiceResultSet.getInt("CUSTOMERID"));
      invoice.setCreated(invoiceResultSet.getDate("CREATED"));
      invoice.setPaid(invoiceResultSet.getDate("PAID"));
      invoice.setShipped(invoiceResultSet.getDate("SHIPPED"));

    } catch (SQLException e) {
      System.out.println(e.getMessage());
    } finally {
      try {
        if (conn != null) {
          conn.close();
        }
      } catch (SQLException ex) {
        System.out.println(ex.getMessage());
      }
    }

    invoice.setOrders(getOrders(invoice.getId()));
    List<Item> items = new ArrayList<>();
    Map<String,Double> itemizedTotals = new HashMap<String, Double>();
    double subtotal = 0;
    double taxes = 0;
    for (Order order: invoice.getOrders())
    {
      Item item = getItem(order.getItemId());
      items.add(item);
      double orderTotal = item.getPrice()*order.getQuantity();
      double orderTaxes = item.getTaxes()*orderTotal;
      itemizedTotals.put(item.getName(),orderTotal);
      subtotal += orderTotal;
      taxes += orderTaxes;
    }
    invoice.setSubTotal(Math.round(subtotal*100.00)/100.00);
    invoice.setTaxes(Math.round(taxes*100.00)/100.00);
    invoice.setTotalPrice(Math.round((subtotal + taxes)*100.00)/100.00);

    return invoice;
  }

  public Item getItem(int id) {
    Item item = new Item();
    Connection conn = null;
    try {
      // db parameters
      String url = "jdbc:sqlite:identifier.sqlite";
      // create a connection to the database
      conn = DriverManager.getConnection(url);
      String sql = "SELECT * FROM ITEM WHERE ID ="+id+";";
      Statement statement = conn.createStatement();
      ResultSet itemResultSet = statement.executeQuery(sql);
      item.setId(id);
      item.setName(itemResultSet.getString("NAME"));
      item.setType(itemResultSet.getString("TYPE"));
      item.setUnit(itemResultSet.getString("UNIT"));
      item.setPrice(itemResultSet.getDouble("PRICE"));
      item.setTaxes(itemResultSet.getDouble("TAXES"));

    } catch (SQLException e) {
      System.out.println(e.getMessage());
    } finally {
      try {
        if (conn != null) {
          conn.close();
        }
      } catch (SQLException ex) {
        System.out.println(ex.getMessage());
      }
    }
    return item;
  }

  public ArrayList<Order> getOrders(int id) {
    ArrayList<Order> orders = new ArrayList<>();
    Connection conn = null;
    try {
      // db parameters
      String url = "jdbc:sqlite:identifier.sqlite";
      // create a connection to the database
      conn = DriverManager.getConnection(url);
      String sql = "SELECT * FROM 'ORDER' WHERE ID ="+id+";";
      Statement statement = conn.createStatement();
      ResultSet orderResultSet = statement.executeQuery(sql);
      while(orderResultSet.next()) {
        Order order = new Order();
        order.setInvoiceId(id);
        order.setId(orderResultSet.getInt("ID"));
        order.setItemId(orderResultSet.getInt("ITEMID"));
        order.setQuantity(orderResultSet.getInt("QUANTITY"));
        orders.add(order);
      }
    } catch (SQLException e) {
      System.out.println(e.getMessage());
    } finally {
      try {
        if (conn != null) {
          conn.close();
        }
      } catch (SQLException ex) {
        System.out.println(ex.getMessage());
      }
    }
    return orders;
  }
}

