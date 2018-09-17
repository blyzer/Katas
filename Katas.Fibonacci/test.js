// Require the built in 'assertion' library
var assert = require("assert");
var mocha = require("./node_modules/mocha/lib/mocha");
var it = mocha.it;
var describe = mocha.describe;
var fibonacciMod = require("./fibonacci");

// Create a group of tests about Fibonacci
describe("fibonacci", function () {
    // A string explanation of what we're testing
    it("should return 21 when the value is 8", function (){
        // Our actual test: should equal to 21
        var result = fibonacciMod.fibonacci(8, null);
        assert.equal(result, 21);
    });
});