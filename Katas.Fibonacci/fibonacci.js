"use strict";

/**
 * @param {number} number
 * @returns The 'n'th number in the Fibonacci sequence.
 */
function fibonacci(number, memory) {
    memory = memory || {};

    if (memory[number]) {
        return memory[number];
    }

    if (number <= 2) {
        return 1;
    }

    return memory[number] = fibonacci(number - 1, memory) + fibonacci(number - 2, memory);
}

//console.log(fibonacci(30));