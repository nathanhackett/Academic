const orderDetails = require('../models/orderDetails.model.js');

// Default message for /
exports.root= (req, res) => {
        console.log("My Quotations App. Use the app to manage your favourite quotations!")
        return res.status(200).send({
        message: "My Quotations App. Use the app to manage your favourite quotations!"
    });
};


exports.create = (req, res) => {
    //Validate the request
    // if(!req.body.content) {
    //     return res.status(400).send({
    //         message: "Quotation content cannot be empty!"
    //     });
    // }
    //Create a new Quotation (using schema)
    const oDetails = new orderDetails({
        Name: req.body.Name,
        Phones_Purchased: req.body.Phones_Purchased,
        Quantity: req.body.Quantity,
        OrderNo: req.body.OrderNo
    });
    // Save Quotation in the database
    oDetails.save()
    .then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while creating the Quotation."
        });
    });
};


//Retrieve and return all notes from the database.
exports.findAll = (req, res) => {
    orderDetails.find()
    .then(oDetails => {
        res.send(oDetails);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Quotations."
        });
    });
};


// Find a single note with a noteId
exports.findOne = (req, res) => {
    orderDetails.findById(req.params._Id)
    .then(oDetails => {
        if(!oDetails) {
            return res.status(404).send({
                message: "oDetails not found with id " + req.params._Id
            });
        }
        res.send(oDetails);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "oDetails not found with id " + req.params._Id
            });
        }
        return res.status(500).send({
            message: "Error retrieving oDetails with id " + req.params._Id
        });
    });
};


// Update a Quotation identified by the noteId in the request
exports.update = (req, res) => {
    // Validate Request
    // if(!req.body.content) {
    //     return res.status(400).send({
    //         message: "Quotation content cannot be empty"
    //     });
    // }
    // Find the Quotation and update it with the request body
    orderDetails.findByIdAndUpdate(req.params._Id, {
        Name: req.body.Name,
        Phones_Purchased: req.body.Phones_Purchased,
        Quantity: req.body.Quantity,
        OrderNo: req.body.OrderNo
    },  { $set: req.body }, // $set - modify only the supplied fields
        { new: true }) // "new: true" return updated object
    .then(oDetails => {
        if(!oDetails) {
            return res.status(404).send({
                message: "oDetails not found with id " + req.params._Id
            });
        }
        res.send(oDetails);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "oDetails not found with id " + req.params._Id
            });
        }
        return res.status(500).send({
            message: "Error updating oDetails with id " + req.params._Id
        });
    });
};


// Update a Quotation identified by the quotationId in the request
exports.updateQuote = (req, res) => {
    // Validate Request
    // if(!req.body.oDetails) {
    //     return res.status(400).send({
    //         message: "Quotation content cannot be empty"
    //     });
    // }
    // Find the Quotation and update it with the request body
    orderDetails.findByIdAndUpdate(req.params._Id, {
        Name: req.body.Name,
        Phones_Purchased: req.body.Phones_Purchased,
        Quantity: req.body.Quantity,
        OrderNo: req.body.OrderNo
    },
        { new: true }) // "new: true" return updated object
    .then(oDetails => {
        if(!oDetails) {
            return res.status(404).send({
                message: "Quotation not found with id " + req.params._Id
            });
        }
        res.send(oDetails);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Quotation not found with id " + req.params._Id
            });
        }
        return res.status(500).send({
            message: "Error updating Quotation with id " + req.params._Id
        });
    });
};


// Delete a note with the specified noteId in the request
exports.delete = (req, res) => {
    orderDetails.findByIdAndRemove(req.params._Id)
    .then(oDetails => {
        if(!oDetails) {
            return res.status(404).send({
                message: "Quotation not found with id " + req.params._Id
            });
        }
        res.send({message: "Quotation deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Quotation not found with id " + req.params._Id
            });
        }
        return res.status(500).send({
            message: "Could not delete Quotation with id " + req.params._Id
        });
    });
};


/* == USER INTERFACE ADDITIONS == */
// Default message for / (get)
exports.root = (req, res) => {
    orderDetails.find()
    .then(mPhones => {
        res.render('quotationonlineMobilePhoneStore_views_view',{
            results: oDetails
        });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Quotations."
        });
    });
};
// search for quotations, matching string on quote field
exports.searchQuotation = (req, res) => {
    var search = req.params.s;
    console.log("Searching Quotations: "+search)
    orderDetails.find({ quotation: new RegExp(search,"ig")})
    .then(mPhones => {
        res.render('onlineMobilePhoneStore_view',{
            results: oDetails
        });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Quotations."
        });
    });
};
// search for quotations, matching string on author field
exports.searchAuthor = (req, res) => {
    var search = req.params.s;
    console.log("Searching Authors: "+search)
    orderDetails.find({ author: new RegExp(search,"ig")})
    .then(mPhones => {
        res.render('onlineMobilePhoneStore_view',{
            results: oDetails
        });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Quotations."
        });
    });
};