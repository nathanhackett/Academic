var MongoClient = require('mongodb').MongoClient;
var url = "mongodb+srv://db_as5NH:db1_as5@clusternh-nn52k.mongodb.net/test";
//database username: db_as5NH
//database password: db1_as5

//OS: Windows 10
//Browser Used: Google Chrome v81.0.4044.122 (Official Build) (64-bit)

//https://www.w3schools.com/nodejs/nodejs_mongodb_createcollection.asp
MongoClient.connect(url, function(error, db) {
    //-----(C)REATE-----
    //https://www.w3schools.com/nodejs/nodejs_mongodb_createcollection.asp

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.createCollection("Customers", function(error, res) {
    // if (error) throw error;
    //   console.log("Customers collection created!");
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.createCollection("HomeAddress", function(error, res) {
    // if (error) throw error;
    //   console.log("HomeAddress collection created!");
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.createCollection("ShippingAddress", function(error, res) {
    // if (error) throw error;
    //   console.log("ShippingAddress collection created!");
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.createCollection("mobilePhones", function(error, res) {
    // if (error) throw error;
    //   console.log("Mobile Phones collection created!");
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.createCollection("orderDetails", function(error, res) {
    // if (error) throw error;
    //   console.log("Order Details collection created!");
    //   db.close();
    // });

    //https://www.w3schools.com/nodejs/nodejs_mongodb_insert.asp

    if (error) throw error;
    var dbo = db.db("assignment5");
    var myobj = [
      { _id: 1, Title: 'Ms', Firstname: 'Niamh', Surname: 'Dunne', Mobile: '1233675332', Email_Address: 'ndunne4@mail.com'},
      { _id: 2, Title: 'Mx', Firstname: 'Owen', Surname: 'Clarke', Mobile: '1235934775', Email_Address: 'owenc26@mail.com'},
      { _id: 3, Title: 'Mr', Firstname: 'Ciaran', Surname: 'Anderson', Mobile: '1239864226', Email_Address: 'ciarananderson1@mail.com'},
      { _id: 4, Title: 'Mrs', Firstname: 'Lauren', Surname: 'Casey', Mobile: '1232574335', Email_Address: 'lauren.casey@mail.com'},
      { _id: 5, Title: 'Miss', Firstname: 'Michaela', Surname: 'Byrne', Mobile: '1232938662', Email_Address: 'byrne.michaela@mail.com'},
      { _id: 6, Title: 'Dr', Firstname: 'James', Surname: 'Malone', Mobile: '1233424664', Email_Address: 'j.malone11@mail.com'}
    ];
  dbo.collection("Customers").insertMany(myobj, function(error, res) {
    if (error) throw error;
    console.log(res.insertedCount + " Customer Details Records Inserted");
    db.close();
  });

  if (error) throw error;
    var dbo = db.db("assignment5");
    var myobj = [
      { _id: 1, AddressLine1: '93 Abbeypark', AddressLine2: 'Ballyfield', Town: 'Naas', CountyCity: 'Kildare', Eircode: 'W11 BK35'},
      { _id: 2, AddressLine1: '28 Grangeview', AddressLine2: 'Parkwest', Town: 'Finglas', CountyCity: 'Dublin', Eircode: 'D17 HK85'},
      { _id: 3, AddressLine1: '2 The Drive', AddressLine2: 'Headfort', Town: 'Navan', CountyCity: 'Meath', Eircode: 'M21 KD35'},
      { _id: 4, AddressLine1: '49 Greenway', AddressLine2: 'Ballinafad', Town: 'Maynooth', CountyCity: 'Kildare', Eircode: 'W45 BK35'},
      { _id: 5, AddressLine1: '35 Loughnaree', AddressLine2: 'Vartry Valley', Town: 'Wicklow', CountyCity: 'Wicklow', Eircode: 'W77 EP18'},
      { _id: 6, AddressLine1: '6 Citypark', AddressLine2: 'Citywest', Town: 'Clondalkin', CountyCity: 'Dublin', Eircode: 'D44 MR76'}
    ];
  dbo.collection("HomeAddress").insertMany(myobj, function(error, res) {
    if (error) throw error;
    console.log(res.insertedCount + " Home Address Records Inserted");
    db.close();
  });

    if (error) throw error;
    var dbo = db.db("assignment5");
    var myobj = [
      { _id: 1, AddressLine1: '93 Abbeypark', AddressLine2: 'Ballyfield', Town: 'Naas', CountyCity: 'Kildare', Eircode: 'W11 BK35'},
      { _id: 2, AddressLine1: '28 Grangeview', AddressLine2: 'Parkwest', Town: 'Finglas', CountyCity: 'Dublin', Eircode: 'D17 HK85'},
      { _id: 3, AddressLine1: '2 The Drive', AddressLine2: 'Headfort', Town: 'Navan', CountyCity: 'Meath', Eircode: 'M21 KD35'},
      { _id: 4, AddressLine1: '49 Greenway', AddressLine2: 'Ballinafad', Town: 'Maynooth', CountyCity: 'Kildare', Eircode: 'W45 BK35'},
      { _id: 5, AddressLine1: '35 Loughnaree', AddressLine2: 'Vartry Valley', Town: 'Wicklow', CountyCity: 'Wicklow', Eircode: 'W77 EP18'},
      { _id: 6, AddressLine1: '6 Citypark', AddressLine2: 'Citywest', Town: 'Clondalkin', CountyCity: 'Dublin', Eircode: 'D44 MR76'}
    ];
  dbo.collection("ShippingAddress").insertMany(myobj, function(error, res) {
    if (error) throw error;
    console.log(res.insertedCount + " Shipping Address Records Inserted");
    db.close();
  });

  if (error) throw error;
    var dbo = db.db("assignment5");
    var myobj = [
      { _id: 1, Maunfacturer: 'Apple', Model: 'iPhone XR', Price: '€749.99'},
      { _id: 2, Maunfacturer: 'Apple', Model: 'iPhone 11', Price: '€899.99'},
      { _id: 3, Maunfacturer: 'Apple', Model: 'iPhone XS', Price: '€699.99'},
      { _id: 4, Maunfacturer: 'Samsung', Model: 'Galaxy S10+', Price: '€999.99'},
      { _id: 5, Maunfacturer: 'Samsung', Model: 'Galaxy S10e', Price: '€499.99'},
      { _id: 6, Maunfacturer: 'Samsung', Model: 'Galaxy S9', Price: '€449.99'},
      { _id: 7, Maunfacturer: 'Huawei', Model: 'P40 Pro', Price: '€1149.99'},
      { _id: 8, Maunfacturer: 'Huawei', Model: 'P30 Pro', Price: '€599.99'},
      { _id: 9, Maunfacturer: 'Nokia', Model: '7 Plus', Price: '€249.99'},
      { _id: 10, Maunfacturer: 'Nokia', Model: '7.2', Price: '€299.99'}
    ];
  dbo.collection("mobilePhones").insertMany(myobj, function(error, res) {
    if (error) throw error;
    console.log(res.insertedCount + " Online Mobile Phone Store listings Inserted");
    db.close();
  });

  if (error) throw error;
    var dbo = db.db("assignment5");

    //--Attempt to insert using a query, doesn't work--

    // var query = { _id: 1 };
    // dbo.collection("Customers").find(query).toArray(function(error, result) {
    //   if (error) throw error;
    //   console.log(result);
    // var myobj = [
    //   { Name: result , Phones_Purchased: 'mobilePhones: 5', Quantity: '1'},
    // ];

    var myobj = [
      { _id: 1, Name: 'CustomersID: 1' , Phones_Purchased: 'mobilePhonesID: 5,6', Quantity: '2', OrderNo: '#01'},
      { _id: 2, Name: 'CustomersID: 4' , Phones_Purchased: 'mobilePhonesID: 2', Quantity: '1', OrderNo: '#01'},
      { _id: 3, Name: 'CustomersID: 1' , Phones_Purchased: 'mobilePhonesID: 8', Quantity: '1', OrderNo: '#02'},
      { _id: 4, Name: 'CustomersID: 5' , Phones_Purchased: 'mobilePhonesID: 7', Quantity: '1', OrderNo: '#01'},
      { _id: 5, Name: 'CustomersID: 2' , Phones_Purchased: 'mobilePhonesID: 5', Quantity: '1', OrderNo: '#01'},
      { _id: 6, Name: 'CustomersID: 6' , Phones_Purchased: 'mobilePhonesID: 9,10', Quantity: '2', OrderNo: '#01'}
    ];
    dbo.collection("orderDetails").insertMany(myobj, function(error, res) {
      if (error) throw error;
      console.log(res.insertedCount + " Order Details Records Inserted");
      db.close();
    });


    //-----(R)ETRIEVE / SEARCH-----
    //https://www.w3schools.com/nodejs/nodejs_mongodb_query.asp
    if (error) throw error;
    var dbo = db.db("assignment5");
    var query = { Firstname: 'James', Mobile: '1233424664', Email_Address: 'j.malone11@mail.com' };
    dbo.collection("Customers").find(query).toArray(function(error, result) {
      if (error) throw error;
      console.log("CUSTOMER DETAILS SEARCH: Dr James Malone");
      console.log(result);
      db.close();
    });

    if (error) throw error;
    var dbo = db.db("assignment5");
    var query = { Eircode: 'D44 MR76' };
    dbo.collection("HomeAddress").find(query).toArray(function(error, result) {
      if (error) throw error;
      console.log("CUSTOMER HOME ADDRESS SEARCH: 6 City Park, Citywest");
      console.log(result);
      db.close();
    });

    if (error) throw error;
    var dbo = db.db("assignment5");
    var query = { Eircode: 'D44 MR76' };
    dbo.collection("ShippingAddress").find(query).toArray(function(error, result) {
      if (error) throw error;
      console.log("CUSTOMER SHIPPING ADDRESS SEARCH: 6 City Park, Citywest");
      console.log(result);
      db.close();
    });

    if (error) throw error;
    var dbo = db.db("assignment5");
    var query = { Model: 'iPhone 11' };
    dbo.collection("mobilePhones").find(query).toArray(function(error, result) {
      if (error) throw error;
      console.log("ONLINE MOBILE PHONE STORE LISTING SEARCH: iPhone 11");
      console.log(result);
      db.close();
    });

    if (error) throw error;
    var dbo = db.db("assignment5");
    var query = { Name: 'CustomersID: 1' };
    dbo.collection("orderDetails").find(query).toArray(function(error, result) {
      if (error) throw error;
      console.log("CUSTOMER ORDER DETAILS SEARCH: Niamh Dunne");
      console.log(result);
      db.close();
    });


    //-----(U)PDATE-----
    //https://www.w3schools.com/nodejs/nodejs_mongodb_update.asp
    //Update records for a customer with specified email, phone and name
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Title: "Mr", Mobile: "1239864226", Email_Address: "ciarananderson1@mail.com" };
    var newvalues = { $set: { Title: "Dr" , Mobile: "1239864336", Email_Address: "andersonciaran1@mail.com" }};
    dbo.collection("Customers").updateOne(myquery, newvalues, function(error, res) {
      if (error) throw error;
      console.log(res.result.nModified + " customer details document(s) updated");
      db.close();
    });
    //Update same customer's Address
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { AddressLine1: '2 The Drive' };
    var newvalues = {$set: { AddressLine1: '12 The Drive' }};
    dbo.collection("HomeAddress").updateOne(myquery, newvalues, function(error, res) {
      if (error) throw error;
      console.log(res.result.nModified + " home address document(s) updated");
      db.close();
    });

    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { AddressLine1: '2 The Drive' };
    var newvalues = { $set: { AddressLine1: '12 The Drive' }};
    dbo.collection("ShippingAddress").updateOne(myquery, newvalues, function(error, res) {
      if (error) throw error;
      console.log(res.result.nModified + " shipping address document(s) updated");
      db.close();
    });
    //Update phone purchase details
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Model: 'Galaxy S9', Price: '€449.99' };
    var newvalues = { $set: { Model: 'Galaxy S9+', Price: '€849.99' }};
    dbo.collection("mobilePhones").updateOne(myquery, newvalues, function(error, res) {
      if (error) throw error;
      console.log(res.result.nModified + " online mobile phone store listing(s) updated");
      db.close();
    });
    //Update same customer's order details
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { _id: 2, Name: 'CustomersID: 4' };
    var newvalues = {$set: { _id: 2, Name: 'CustomersID: 3' }};
    dbo.collection("orderDetails").updateOne(myquery, newvalues, function(error, res) {
      if (error) throw error;
      console.log(res.result.nModified + " customer order document(s) updated");
      db.close();
    });


    //-----(D)ELETE-----
    //https://www.w3schools.com/nodejs/nodejs_mongodb_delete.asp
    //Delete all records for a customer with specified email, phone and name
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Email_Address : "byrne.michaela@mail.com" , Mobile: "1232938662" , Firstname: "Michaela"};
    dbo.collection("Customers").deleteOne(myquery, function(error, obj) {
      if (error) throw error;
      console.log(obj.result.n + " customer document(s) deleted");
      db.close();
    });
    //Delete same customer's addresses
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Eircode: 'W77 EP18' };
    dbo.collection("HomeAddress").deleteOne(myquery, function(error, obj) {
      if (error) throw error;
      console.log(obj.result.n + " home address document(s) deleted");
      db.close();
    });
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Eircode: 'W77 EP18' };
    dbo.collection("ShippingAddress").deleteOne(myquery, function(error, obj) {
      if (error) throw error;
      console.log(obj.result.n + " shipping address document(s) deleted");
      db.close();
    });
    //Delete one phone from the mobilePhones list
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Model: 'Galaxy S9+' };
    dbo.collection("mobilePhones").deleteOne(myquery, function(error, obj) {
      if (error) throw error;
      console.log(obj.result.n + " online mobile phone store listing(s) deleted");
      db.close();
    });
    //Delete one purchase record matching that of deleted customer 
    if (error) throw error;
    var dbo = db.db("assignment5");
    var myquery = { Name: 'CustomersID: 5', Phones_Purchased: 'mobilePhonesID: 7' };
    dbo.collection("orderDetails").deleteOne(myquery, function(error, obj) {
      if (error) throw error;
      console.log(obj.result.n + " customer order document(s) deleted");
      db.close();
    });


    //--Data Dump--
    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.collection("Customers").find({}).toArray(function(error, result) {
    //   if (error) throw error;
    //   console.log(result);
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.collection("HomeAddress").find({}).toArray(function(error, result) {
    //   if (error) throw error;
    //   console.log(result);
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.collection("ShippingAddress").find({}).toArray(function(error, result) {
    //   if (error) throw error;
    //   console.log(result);
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.collection("mobilePhones").find({}).toArray(function(error, result) {
    //   if (error) throw error;
    //   console.log(result);
    //   db.close();
    // });

    // if (error) throw error;
    // var dbo = db.db("assignment5");
    // dbo.collection("orderDetails").find({}).toArray(function(error, result) {
    //   if (error) throw error;
    //   console.log(result);
    //   db.close();
    // });
});

//My modelling approach for this database design is a normalised model
//The normalised model can be more dedious to code and reference between
//but I find that it is better structured and more clearly laid out making
//it easier to locate specific collections over a denormalised model
//Using this approach emphasised the dependence of one function on the
//variable names being correct in order to execute
//This approach also meant one function could only be used on one collection
//so there are many similar blocks of the same function type 