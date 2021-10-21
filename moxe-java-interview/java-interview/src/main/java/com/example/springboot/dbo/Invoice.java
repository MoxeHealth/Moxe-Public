package com.example.springboot.dbo;

import java.sql.Date;
import java.util.ArrayList;
import java.util.HashMap;

public class Invoice {

  private int id;
  private int customerId;
  private Date created;
  private Date paid;
  private Date shipped;
  private HashMap<String, Double> itemizedTotals;
  private double subTotal;
  private double taxes;
  private double totalPrice;
  private ArrayList<Order> orders;

  public int getId() {
    return id;
  }

  public void setId(int id) {
    this.id = id;
  }

  public int getCustomerId() {
    return customerId;
  }

  public void setCustomerId(int customerId) {
    this.customerId = customerId;
  }

  public Date getCreated() {
    return created;
  }

  public void setCreated(Date created) {
    this.created = created;
  }

  public Date getPaid() {
    return paid;
  }

  public void setPaid(Date paid) {
    this.paid = paid;
  }

  public Date getShipped() {
    return shipped;
  }

  public void setShipped(Date shipped) {
    this.shipped = shipped;
  }

  public HashMap<String, Double> getItemizedTotals() {
    return itemizedTotals;
  }

  public void setItemizedTotals(HashMap<String, Double> itemizedTotals) {
    this.itemizedTotals = itemizedTotals;
  }

  public double getSubTotal() {
    return subTotal;
  }

  public void setSubTotal(double subTotal) {
    this.subTotal = subTotal;
  }

  public double getTaxes() {
    return taxes;
  }

  public void setTaxes(double taxes) {
    this.taxes = taxes;
  }

  public double getTotalPrice() {
    return totalPrice;
  }

  public void setTotalPrice(double totalPrice) {
    this.totalPrice = totalPrice;
  }

  public ArrayList<Order> getOrders() {
    return orders;
  }

  public void setOrders(ArrayList<Order> orders) {
    this.orders = orders;
  }

  @Override
  public String toString() {
    return "Invoice{" +
        "id=" + id +
        ", customerId=" + customerId +
        ", created=" + created +
        ", paid=" + paid +
        ", shipped=" + shipped +
        ", itemizedTotals=" + itemizedTotals +
        ", subTotal=" + subTotal +
        ", taxes=" + taxes +
        ", totalPrice=" + totalPrice +
        ", orders=" + orders +
        '}';
  }
}


