const db = require('_helpers/db');
const Order = db.Order;
const config = require('config.json');
module.exports = {
    getAll,
    create,
    placeOrder,
    delete: _delete,
};

async function getAll() {
    return await Order.find().select('-hash');
}


async function create(orderParam) {
    // validate
    // if (await Order.findOne({ orderName: orderParam.orderName })) {
    //     // throw 'Username "' + productParam.productName + '" is already taken';
    //     //increament the quantity
    // }
    const order = new Order(orderParam);
    // save product
    await order.save();
}

async function placeOrder(id, orderParam) {
    //const order = await Order.findById(id);

    // // validate
    // if (!user) throw 'User not found';
    // if (user.username !== userParam.username && await User.findOne({ username: userParam.username })) {
    //     throw 'Username "' + userParam.username + '" is already taken';
    // }

    // hash password if it was entered
    // if (userParam.password) {
    //     userParam.hash = bcrypt.hashSync(userParam.password, 10);
    // }

    // copy userParam properties to user
    // Object.assign(product, productParam);

    // await product.save();
}

async function _delete(id) {
    await Order.findByIdAndRemove(id);
}