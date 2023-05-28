const mobilePhones = require('../models/mobilePhones.model.js');

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
    const mPhones = new mobilePhones({
        Manufacturer: req.body.Manufacturer,
        Model: req.body.Model,
        Price: req.body.Price
    });
    // Save Quotation in the database
    mPhones.save()
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
    mobilePhones.find()
    .then(mPhones => {
        res.send(mPhones);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Quotations."
        });
    });
};


// Find a single note with a noteId
exports.findOne = (req, res) => {
    mobilePhones.findById(req.params._Id)
    .then(mPhones => {
        if(!mPhones) {
            return res.status(404).send({
                message: "mPhones not found with id " + req.params._Id
            });
        }
        res.send(mPhones);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "mPhones not found with id " + req.params._Id
            });
        }
        return res.status(500).send({
            message: "Error retrieving mPhones with id " + req.params._Id
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
    mobilePhones.findByIdAndUpdate(req.params._Id, {
        Manufacturer: req.body.Manufacturer,
        Model: req.body.Model,
        Price: req.body.Price
    },  { $set: req.body }, // $set - modify only the supplied fields
        { new: true }) // "new: true" return updated object
    .then(mPhones => {
        if(!mPhones) {
            return res.status(404).send({
                message: "mPhones not found with id " + req.params._Id
            });
        }
        res.send(mPhones);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "mPhones not found with id " + req.params._Id
            });
        }
        return res.status(500).send({
            message: "Error updating mPhones with id " + req.params._Id
        });
    });
};


// Update a Quotation identified by the quotationId in the request
exports.updateQuote = (req, res) => {
    // Validate Request
    // if(!req.body.mPhones) {
    //     return res.status(400).send({
    //         message: "Quotation content cannot be empty"
    //     });
    // }
    // Find the Quotation and update it with the request body
    mobilePhones.findByIdAndUpdate(req.params._Id, {
        Manufacturer: req.body.Manufacturer,
        Model: req.body.Model,
        Price: req.body.Price
    },
        { new: true }) // "new: true" return updated object
    .then(mPhones => {
        if(!mPhones) {
            return res.status(404).send({
                message: "Quotation not found with id " + req.params._Id
            });
        }
        res.send(mPhones);
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
    mobilePhones.findByIdAndRemove(req.params._Id)
    .then(mPhones => {
        if(!mPhones) {
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
    mobilePhones.find()
    .then(mPhones => {
        res.render('onlineMobilePhoneStore_view',{
            results: mPhones
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
    mobilePhones.find({ quotation: new RegExp(search,"ig")})
    .then(mPhones => {
        res.render('onlineMobilePhoneStore_view',{
            results: mPhones
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
    mobilePhones.find({ author: new RegExp(search,"ig")})
    .then(mPhones => {
        res.render('onlineMobilePhoneStore_view',{
            results: mPhones
        });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Quotations."
        });
    });
};