package com.example.springboot.dbo;

public class Item {
  private int id;
  private String name;
  private String type;
  private String unit;
  private double price;
  private double taxes;

  public int getId() {
    return id;
  }

  public void setId(int id) {
    this.id = id;
  }

  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }

  public String getType() {
    return type;
  }

  public void setType(String type) {
    this.type = type;
  }

  public String getUnit() {
    return unit;
  }

  public void setUnit(String unit) {
    this.unit = unit;
  }

  public double getPrice() {
    return price;
  }

  public void setPrice(double price) {
    this.price = price;
  }

  public double getTaxes() {
    return taxes;
  }

  public void setTaxes(double taxes) {
    this.taxes = taxes;
  }
}
