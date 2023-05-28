module.exports = (app) => {
    const orderDetails = require('../controllers/orderDetails.controllers.js');
    /* == USER INTERFACE ADDITIONS == */
    // Default message for /
    app.get('/', orderDetails.root);

    // Create a new Quotation
    app.post('/orderDetails', orderDetails.create);
    // Retrieve all Quotations
    app.get('/orderDetails', orderDetails.findAll);
    // Retrieve a single Quotation specified by quotationId
    app.get('/orderDetails/:_Id', orderDetails.findOne);
    // Update a Quotation specified by quotationId
    app.put('/orderDetails/:_Id', orderDetails.update);
    // Delete a Quotation specified by quotationId
    app.delete('/orderDetails/:_Id', orderDetails.delete);

    /* == USER INTERFACE ADDITIONS == */
    // Search for Quotations matching s
    app.get('/quotation/:s', orderDetails.searchQuotation);
    app.get('/author/:s', orderDetails.searchAuthor);
}