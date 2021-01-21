function SortArrayBy2Criteria(arr) {

    let result = arr.sort((a, b) => a.localeCompare(b));
    result = result.sort((a, b) => a.length - b.length);
    return result.join('\n');
}

console.log(SortArrayBy2Criteria(['alpha', 'beta', 'gamma']));
console.log(SortArrayBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
console.log(SortArrayBy2Criteria(['test', 'Deny', 'omen', 'Default']));