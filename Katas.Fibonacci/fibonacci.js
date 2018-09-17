function fibonacciMod() {
    "use strict";
    /**
     * @param {number} number
     * @returns The n's number in the Fibonacci sequence.
     */
    function fibonacci(number, memory) {
        memory = memory || {};

        if (memory[number]) {
            return memory[number];
        }

        if (number <= 2) {
            return 1;
        }

        memory[number] = fibonacci(number - 1, memory) + fibonacci(number - 2, memory);

        return memory[number];
    }

    return {
        fibonacci
    };
}

module.exports = fibonacciMod();