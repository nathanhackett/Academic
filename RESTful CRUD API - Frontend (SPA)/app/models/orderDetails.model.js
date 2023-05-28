const mongoose = require('mongoose');
// create a mongoose schema for a quotation
const orderDetailsSchema = mongoose.Schema({
    Name: String,
    Phones_Purchased: String,
    Quantity: Number,
    OrderNo: String
}, {
    timestamps: true
});
// export the model to our app
module.exports = mongoose.model('orderDetails', orderDetailsSchema);