const db = require('_helpers/db');
const Product = db.Product;
const config = require('config.json');
module.exports = {
    getAll,
    getById,
    create,
    update,
    delete: _delete,
};

async function getAll() {
    return await Product.find().select('-hash');
}

async function getById(id) {
    return await Product.findById(id).select('-hash');
}


async function create(productParam) {
    // validate
    // if (await Product.findOne({ productName: productParam.productName })) {
    //     throw 'Username "' + productParam.productName + '" is already taken';
    // }
    const product = new Product(productParam);
    // save product
    await product.save();
}

async function update(id, productParam) {
    const product = await Product.findById(id);

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
    Object.assign(product, productParam);

    await product.save();
}

async function _delete(id) {
    await Product.findByIdAndRemove(id);
}