export default function toRoman(num: number): string {
    let numbers = {
        1: 'I',
        4: 'IV',
        5: 'V',
        9: 'IX',
        10: 'X',
        40: 'XL',
        50: 'L',
        90: 'XC',
        100: 'C',
        400: 'CD',
        500: 'D',
        900: 'CM',
        1000: 'M'
    },
        exceptions = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 5, 1];

    if (numbers[num]) {
        return numbers[num];
    }

    return getRomanNum(numbers, exceptions, num);
}

function getRomanNum(numbers: Object, exceptions: any[], num: number): string {
    let ronum = '';

    exceptions.forEach((item) => {
        if (num > item && ronum === '') {
            if (numbers[num - item] !== undefined) {
                ronum = numbers[item] + numbers[num - item];
            } else {
                ronum = numbers[item];
                ronum += getRomanNum(numbers, exceptions, num - item);
            }
        }
    });

    return ronum;
}