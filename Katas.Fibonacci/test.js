// Require the built in 'assertion' library
var assert = require("assert");
var FibonacciTest = require("../Katas.Fibonacci/fibonacci");

// Create a group of tests about Fibonacci
describe("fibonacc", function() {
    // A string explanation of what we're testing
    it("should return 21 when the value is 8", function(){
        // Our actual test: should equal to 21
     var result = fibonacci(8);
        assert.equal(result, 21);
    });
});