package com.example.springboot.database;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.time.LocalDate;

public class SqliteDatabase {
  public static void createTables() {
    Connection conn = null;
    try {
      // db parameters
      String url = "jdbc:sqlite:identifier.sqlite";
      // create a connection to the database
      conn = DriverManager.getConnection(url);

      System.out.println("Connection to SQLite has been established.");

      Statement stmt = conn.createStatement();
      stmt.executeUpdate("DROP TABLE IF EXISTS CUSTOMER");
      stmt.executeUpdate("DROP TABLE IF EXISTS INVOICE");
      stmt.executeUpdate("DROP TABLE IF EXISTS 'ORDER'");
      stmt.executeUpdate("DROP TABLE IF EXISTS ITEM");

      stmt.executeUpdate(CreateCustomerTable());
      stmt.executeUpdate(InsertCustomerRecord(1,"Seattle Cider Company","Brewery"));
      stmt.executeUpdate(InsertCustomerRecord(2,"Cicatriz","Cafe"));
      stmt.executeUpdate(InsertCustomerRecord(3,"Second Harvest","Food Bank"));

      stmt.executeUpdate(CreateInvoiceTable());
      stmt.executeUpdate(InsertInvoiceRecord(1,1,-65,-48,-40));
      stmt.executeUpdate(InsertInvoiceRecord(2,1,-56,-48,-40));
      stmt.executeUpdate(InsertInvoiceRecord(3,1,-45,-38,-30));
      stmt.executeUpdate(InsertInvoiceRecord(4,2,-21,-15,null));
      stmt.executeUpdate(InsertInvoiceRecord(5,2,-10,null,null));
      stmt.executeUpdate(InsertInvoiceRecord(6,3,-13,null,null));

      stmt.executeUpdate(CreateOrderTable());
      stmt.executeUpdate(InsertOrderRecord(1,1,1,100));
      stmt.executeUpdate(InsertOrderRecord(2,1,2,15));
      stmt.executeUpdate(InsertOrderRecord(3,2,1,20));
      stmt.executeUpdate(InsertOrderRecord(4,2,2,20));
      stmt.executeUpdate(InsertOrderRecord(5,1,3,5));
      stmt.executeUpdate(InsertOrderRecord(6,4,1,500));
      stmt.executeUpdate(InsertOrderRecord(7,4,2,50));
      stmt.executeUpdate(InsertOrderRecord(8,5,1,20));
      stmt.executeUpdate(InsertOrderRecord(9,5,2,20));
      stmt.executeUpdate(InsertOrderRecord(10,3,2,20));
      stmt.executeUpdate(InsertOrderRecord(11,3,3,5));
      stmt.executeUpdate(InsertOrderRecord(12,3,1,500));
      stmt.executeUpdate(InsertOrderRecord(13,6,1,20));
      stmt.executeUpdate(InsertOrderRecord(14,6,2,20));
      stmt.executeUpdate(InsertOrderRecord(15,6,2,20));

      stmt.executeUpdate(CreateItemTable());
      stmt.executeUpdate(InsertItemRecord(1,"Apple","Produce","lbs", 1.63, 0.065));
      stmt.executeUpdate(InsertItemRecord(2,"Chocolate Bar","Candy","bar", 3.99, 0.065));
      stmt.executeUpdate(InsertItemRecord(3,"Huitlacoche","Canned","can", 27.99, 0.065));

      stmt.close();
      conn.close();

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
  }
  private static String CreateCustomerTable() {
    String sql =
        "CREATE TABLE CUSTOMER " +
            "(ID INT PRIMARY KEY     NOT NULL," +
            " NAME           TEXT    NOT NULL, " +
            " TYPE           TEXT    NOT NULL)" ;
    return sql
;
  }
  private static String InsertCustomerRecord(int id, String name, String type) {
    String sql =
        "INSERT INTO CUSTOMER(ID, NAME, TYPE) VALUES(" + id + ",'" + name + "','" + type + "')";
    return sql;
  }
  private static String CreateInvoiceTable() {
    String sql =
    "CREATE TABLE INVOICE " +
        "(ID INT PRIMARY KEY      NOT NULL," +
        " CUSTOMERID     INT      NOT NULL, " +
        " CREATED        DATE     NOT NULL, " +
        " PAID           DATE, " +
        " SHIPPED        DATE)";
    return sql;
  }
  private static String InsertInvoiceRecord(int id, int customerId, int created, Integer paid, Integer shipped)
      throws SQLException {

    Date createdDate = Date.valueOf(LocalDate.now().plusDays(created));

    Date paidDate = null;
    if (paid != null)
      paidDate = Date.valueOf(LocalDate.now().plusDays(paid));

    Date shippedDate = null;
    if (shipped != null)
      shippedDate = Date.valueOf(LocalDate.now().plusDays(shipped));
    String sql = "INSERT INTO INVOICE (ID, CUSTOMERID, CREATED, PAID, SHIPPED) VALUES ("+id+","+customerId+","+createdDate+","+paidDate+","+shippedDate+")";
    return sql;
  }

  private static String CreateOrderTable() {
    String sql =
        "CREATE TABLE 'ORDER' " +
            "(ID INT PRIMARY KEY    NOT NULL," +
            " INVOICEID     INT     NOT NULL, " +
            " ITEMID        INT     NOT NULL, " +
            " QUANTITY      INT     NOT NULL)";
    return sql;
  }
  private static String InsertOrderRecord(int id, int invoiceId, int itemId, int quantity)
      throws SQLException {
    String sql = "INSERT INTO 'ORDER' (ID, INVOICEID, ITEMID, QUANTITY) VALUES ("+id+","+invoiceId+","+itemId+","+quantity+")";
    return sql;
  }

  private static String CreateItemTable() {
    String sql =
        "CREATE TABLE ITEM " +
            "(ID INT PRIMARY KEY    NOT NULL," +
            " NAME      TEXT     NOT NULL, " +
            " TYPE      TEXT     NOT NULL, " +
            " UNIT      TEXT     NOT NULL, " +
            " PRICE     REAL     NOT NULL, " +
            " TAXES     REAL     NOT NULL)";

    return sql;
  }
  private static String InsertItemRecord(int id, String name, String type, String unit, double price, double taxes)
      throws SQLException {
    String sql = "INSERT INTO ITEM (ID, NAME, TYPE, UNIT, PRICE, TAXES) VALUES ("+id+",'"+name+"','"+type+"','"+unit+"',"+price+","+taxes+")";
    return sql;
  }
}
