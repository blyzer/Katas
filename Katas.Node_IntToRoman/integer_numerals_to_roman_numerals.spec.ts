import toRoman from './integer_numerals_to_roman_numerals'

describe('toRoman', () => {
    const testCases = [
        { arg: 1, expected: 'I' },
        { arg: 2, expected: 'II' },
        { arg: 3, expected: 'III' },
        { arg: 4, expected: 'IV' },
        { arg: 5, expected: 'V' },
        { arg: 7, expected: 'VII' },
        { arg: 9, expected: 'IX' },
        { arg: 11, expected: 'XI' },
        { arg: 14, expected: 'XIV' },
        { arg: 17, expected: 'XVII' },
        { arg: 21, expected: 'XXI' },
        { arg: 25, expected: 'XXV' },
        { arg: 27, expected: 'XXVII' },
        { arg: 31, expected: 'XXXI' },
        { arg: 34, expected: 'XXXIV' },
        { arg: 39, expected: 'XXXIX' },
        { arg: 40, expected: 'XL' },
        { arg: 41, expected: 'XLI' },
        { arg: 55, expected: 'LV' },
        { arg: 60, expected: 'LX' },
        { arg: 77, expected: 'LXXVII' },
        { arg: 89, expected: 'LXXXIX' },
        { arg: 91, expected: 'XCI' },
        { arg: 121, expected: 'CXXI' },
        { arg: 199, expected: 'CXCIX' },
        { arg: 247, expected: 'CCXLVII' },
        { arg: 362, expected: 'CCCLXII' },
        { arg: 427, expected: 'CDXXVII' },
        { arg: 679, expected: 'DCLXXIX' },
        { arg: 968, expected: 'CMLXVIII' },
        { arg: 1579, expected: 'MDLXXIX' },
        { arg: 3999, expected: 'MMMCMXCIX' },
        { arg: 4529, expected: 'MMMMDXXIX' },
    ];

    testCases.forEach((test) => {
        it('returns the roman number for ' + test.arg, () => {
            let number = toRoman(test.arg);

            expect(number).toEqual(test.expected);
        });
    });
});