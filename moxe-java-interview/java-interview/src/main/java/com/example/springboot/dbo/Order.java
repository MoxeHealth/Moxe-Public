package com.example.springboot.dbo;

public class Order {

  private int id;
  private int invoiceId;
  private int itemId;
  private int quantity;

  public int getId() {
    return id;
  }

  public void setId(int id) {
    this.id = id;
  }

  public int getInvoiceId() {
    return invoiceId;
  }

  public void setInvoiceId(int invoiceId) {
    this.invoiceId = invoiceId;
  }

  public int getItemId() {
    return itemId;
  }

  public void setItemId(int itemId) {
    this.itemId = itemId;
  }

  public int getQuantity() {
    return quantity;
  }

  public void setQuantity(int quantity) {
    this.quantity = quantity;
  }

  @Override
  public String toString() {
    return "Order{" +
        "id=" + id +
        ", invoiceId=" + invoiceId +
        ", itemId=" + itemId +
        ", quantity=" + quantity +
        '}';
  }
}
