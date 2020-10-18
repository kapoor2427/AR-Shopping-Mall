const express = require('express');
const router = express.Router();
const orderService = require('./order.service');

// routes
router.post('/createOrder', createOrder);
router.get('/', getAll);
router.post('/placeOrder', placeOrder);
router.delete('/:id', _delete);

module.exports = router;

function placeOrder(req, res, next) {
    orderService.placeOrder(req.body)
    .then(() => res.json({"message": "order placed"}))
    .catch(err => next(err));
}

function createOrder(req, res, next) {
    orderService.create(req.body)
        .then(() => res.json({"message": "product added to cart"}))
        .catch(err => next(err));
}

function getAll(req, res, next) {
    orderService.getAll()
        .then(orders => res.json(orders))
        .catch(err => next(err));
}

function _delete(req, res, next) {
    orderService.delete(req.params.id)
        .then(() => res.json({"message":"order deleted"}))
        .catch(err => next(err));
}