'use strict';
// Require the built in 'assertion' library
var assert = require("assert").assert;
var mocha = require('../Katas.Fibonacci/node_modules/mocha/lib/mocha');
var it = mocha.it;
var describe = mocha.describe;
var fibonacciTest = require("../Katas.Fibonacci/fibonacci");

// Create a group of tests about Fibonacci
describe("fibonacci", function () {
    // A string explanation of what we're testing
    it("should return 21 when the value is 8", function(){
        // Our actual test: should equal to 21
        var result = fibonacciTest (8);
        assert.equal(result, 21);
    });
});