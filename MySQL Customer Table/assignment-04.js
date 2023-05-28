var mysql = require('mysql');

var con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "",
  port: "3306",
  database: "assignment-04"
});

con.connect(function(error) {
  if(error) {
    throw error;
  }else{
    console.log("Connected");
  }

  //--C(REATE)--
  //https://www.w3schools.com/nodejs/nodejs_mysql_create_table.asp
  //Table 1
  var sql = "CREATE TABLE Customer (CustID INT AUTO_INCREMENT PRIMARY KEY, Title TEXT(255), Forename TEXT(255), Surname TEXT(255), Mobile VARCHAR(255), Email_Address VARCHAR(255), AddressID VARCHAR(1))";
  con.query(sql, function (error, result) {
    if(error) {
      throw error;
    }else{
    console.log("Table created");
    }
  });
  //https://www.w3schools.com/nodejs/nodejs_mysql_insert.asp
  var sql = "INSERT INTO Customer (Title, Forename, Surname, Mobile, Email_Address, AddressID) VALUES ?";
  var values = [
    ['Ms', 'Joe', 'Mama', '1233675332', 'ndunne4@mail.com', '1'],
    ['Mx', 'Owen', 'Clarke', '1235934775', 'owenc26@mail.com', '2'],
    ['Mr', 'Ciaran', 'Anderson', '1239864226', 'ciarananderson1@mail.com', '3'],
    ['Mrs', 'Lauren', 'Casey', '1232574335', 'lauren.casey@mail.com', '4'],
    ['Miss', 'Michaela', 'Byrne', '1232938662', 'byrne.michaela@mail.com', '5'],
    ['Dr', 'James', 'Malone', '1233424664', 'j.malone11@mail.com', '6']
  ];
  con.query(sql, [values], function (error, result) {
    if(error) {
      throw error;
    }else{
      console.log("Records inserted: " + result.affectedRows);
    }
  });
  //Table 2
  var sql1 = "CREATE TABLE HomeAddress (AddressID INT AUTO_INCREMENT PRIMARY KEY, AddressLine1 VARCHAR(255), AddressLine2 VARCHAR(255), Town TEXT(255), CountyCity TEXT(255), Eircode VARCHAR(255))";
  con.query(sql1, function (error, result) {
    if(error) {
      throw error;
    }else{
      console.log("Table created");
    }
  });
  var sql1 = "INSERT INTO HomeAddress (AddressLine1, AddressLine2, Town, CountyCity, Eircode) VALUES ?";
  var values = [
    ['93 Abbeypark', 'Ballyfield', 'Naas', 'Kildare', 'W11 BK35'],
    ['28 Grangeview', 'Parkwest', 'Finglas', 'Dublin', 'D17 HK85'],
    ['2 The Drive', 'Headfort', 'Navan', 'Meath', 'M21 KD35'],
    ['49 Greenway', 'Ballinafad', 'Maynooth', 'Kildare', 'W45 BK35'],
    ['35 Loughnaree', 'Vartry Valley', 'Wicklow', 'Wicklow', 'W77 EP18'],
    ['6 Citypark', 'Citywest', 'Clondalkin', 'Dublin', 'D44 MR76']
  ];
  con.query(sql1, [values], function (error, result) {
    if(error) {
      throw error;
    }else{
      console.log("Records inserted: " + result.affectedRows);
    }
  });

  //Table 3
  var sql2 = "CREATE TABLE ShippingAddress (AddressID INT AUTO_INCREMENT PRIMARY KEY, AddressLine1 VARCHAR(255), AddressLine2 VARCHAR(255), Town TEXT(255), CountyCity TEXT(255), Eircode VARCHAR(255))";
  con.query(sql2, function (error, result) {
    if(error) {
      throw error;
    }else{
      console.log("Table created");
    }
  });
  var sql2 = "INSERT INTO ShippingAddress (AddressLine1, AddressLine2, Town, CountyCity, Eircode) VALUES ?";
  var values = [
    ['93 Abbeypark', 'Ballyfield', 'Naas', 'Kildare', 'W11 BK35'],
    ['28 Grangeview', 'Parkwest', 'Finglas', 'Dublin', 'D17 HK85'],
    ['2 The Drive', 'Headfort', 'Navan', 'Meath', 'M21 KD35'],
    ['49 Greenway', 'Ballinafad', 'Maynooth', 'Kildare', 'W45 BK35'],
    ['35 Loughnaree', 'Vartry Valley', 'Wicklow', 'Wicklow', 'W77 EP18'],
    ['6 Citypark', 'Citywest', 'Clondalkin', 'Dublin', 'D44 MR76']
  ];
  con.query(sql2, [values], function (error, result) {
    if(error) {
      throw error;
    }else{
      console.log("Records inserted: " + result.affectedRows);
    }
  });

  //--R(ETRIEVE)--
  //https://www.w3schools.com/nodejs/nodejs_mysql_select.asp
  con.query("SELECT * FROM Customer WHERE CustID = '2'", function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log(result);
    }
  });

  con.query("SELECT * FROM HomeAddress JOIN ShippingAddress ON HomeAddress.AddressID = ShippingAddress.AddressID AND HomeAddress.AddressID = '2'", function (error, result, fields) { //only returns HomeAddress details??
    if(error) {
      throw error;
    }else{
      console.log(result);
    }
  });

  con.query("SELECT * FROM ShippingAddress WHERE AddressID = '2'", function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log(result);
    }
  });

  //--U(PDATE)--
  //https://www.w3schools.com/nodejs/nodejs_mysql_update.asp
  //Table 1
  var sql = "UPDATE Customer SET Title = 'Ms' WHERE Title = 'Mrs'";
  con.query(sql, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Title records updated: " + result.affectedRows);
    }
  });
  var sql = "UPDATE Customer SET Mobile = '1234934776' WHERE Mobile = '1235934775'";
  con.query(sql, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Mobile records updated: " + result.affectedRows);
    }
  });
  var sql = "UPDATE Customer SET Email_Address = 'j.malone22@mail.com' WHERE Email_Address = 'j.malone11@mail.com'";
  con.query(sql, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Email records updated: " + result.affectedRows);
    }
  });

  //Table 2 & 3
  var sql1 = "UPDATE HomeAddress SET AddressLine1 = '21 The Drive' WHERE AddressLine1 = '2 The Drive'";
  con.query(sql1, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Address Records updated: " + result.affectedRows);
    }
  });
  var sql2 = "UPDATE ShippingAddress SET AddressLine1 = '21 The Drive' WHERE AddressLine1 = '2 The Drive'";
  con.query(sql2, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Address Records updated: " + result.affectedRows);
    }
  });
  var sql1 = "UPDATE HomeAddress SET Eircode = 'W76 EP18' WHERE Eircode = 'W77 EP18'";
  con.query(sql1, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Eircode Records updated: " + result.affectedRows);
    }
  });
  var sql2 = "UPDATE ShippingAddress SET Eircode = 'W76 EP18' WHERE Eircode = 'W77 EP18'";
  con.query(sql2, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("Eircode Records updated: " + result.affectedRows);
    }
  });

  //--D(ELETE)--
  //https://www.w3schools.com/nodejs/nodejs_mysql_delete.asp
  //Table 1
  var sql = "DELETE FROM Customer WHERE Email_Address = 'ciarananderson1@mail.com' AND Mobile = '1239864226' AND Forename = 'Ciaran'";
  con.query(sql, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("User records deleted: " + result.affectedRows);
    }
  });
  //Table 2 & 3
  var sql1 = "DELETE HomeAddress,ShippingAddress FROM HomeAddress INNER JOIN ShippingAddress WHERE HomeAddress.AddressID = ShippingAddress.AddressID AND HomeAddress.AddressID = '3'";
  con.query(sql1, function (error, result, fields) {
    if(error) {
      throw error;
    }else{
      console.log("User records deleted: " + result.affectedRows);
    }
  });
});

//I found the https://www.w3schools.com/nodejs/nodejs_mysql.asp tutorial very useful and informative for helping me create the database and implement SQL into my code
//My database consists of 3 tables (Customers, HomeAddress, ShippingAddress) where the second and last contain the same data, meaning I could make use of JOIN queries in my code
//Initially I thought I could order the CRUD functionality code by table but discovered in testing it must be ordered in order of each letter in CRUD
//My database is locally hosted with XAMPP (as I never received an email from remoteMySQL and was not able to use it)