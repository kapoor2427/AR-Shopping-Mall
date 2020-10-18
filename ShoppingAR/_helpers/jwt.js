const expressJwt = require('express-jwt');
const config = require('config.json');
const userService = require('../users/user.service');
// const productService = require('../users/user.service');

module.exports = jwt;

function jwt() {
    const secret = config.secret;
    return expressJwt({ secret, isRevoked }).unless({
        path: [
            // public routes that don't require authentication
            '/users/authenticate',
            '/users/register',
            // '/products/createProduct',
            // '/products/'
        ]
    });
}

async function isRevoked(req, payload, done) {
    const user = await userService.getById(payload.sub);
    //const product = await productService.getById(payload.sub);

    // revoke token if user no longer exists
    if (!user) {
        return done(true);
    }
    

    done();
};