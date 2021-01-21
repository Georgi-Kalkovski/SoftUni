function AggregateElements(input) {

    Aggregate(input, 0, (a, b) => a + b);
    Aggregate(input, 0, (a, b) => a + 1 / b);
    Aggregate(input, '', (a, b) => a + b);

    function Aggregate(arr, initVal, func) {

        let result = initVal;

        for (let i = 0; i < arr.length; i++) {
            result = func(result, arr[i]);
        }

        console.log(result);
    }
}

AggregateElements([1, 2, 3]);
AggregateElements([2, 4, 8, 16]);