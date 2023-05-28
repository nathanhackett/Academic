const mongoose = require('mongoose');
// create a mongoose schema for a quotation
const mobilePhonesSchema = mongoose.Schema({
    Manufacturer: String,
    Model: String,
    Price: Number
    
}, {
    timestamps: true
});
// export the model to our app
module.exports = mongoose.model('mobilePhones', mobilePhonesSchema);