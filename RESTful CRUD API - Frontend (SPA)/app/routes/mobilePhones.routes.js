module.exports = (app) => {
    const mobilePhones = require('../controllers/mobilePhones.controllers.js');
    /* == USER INTERFACE ADDITIONS == */
    // Default message for /
    app.get('/', mobilePhones.root);

    // Create a new Quotation
    app.post('/mobilePhones', mobilePhones.create);
    // Retrieve all Quotations
    app.get('/mobilePhones', mobilePhones.findAll);
    // Retrieve a single Quotation specified by quotationId
    app.get('/mobilePhones/:_Id', mobilePhones.findOne);
    // Update a Quotation specified by quotationId
    app.put('/mobilePhones/:_Id', mobilePhones.update);
    // Delete a Quotation specified by quotationId
    app.delete('/mobilePhones/:_Id', mobilePhones.delete);

    /* == USER INTERFACE ADDITIONS == */
    // Search for Quotations matching s
    app.get('/quotation/:s', mobilePhones.searchQuotation);
    app.get('/author/:s', mobilePhones.searchAuthor);
}