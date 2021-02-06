function solution(string) {
    let inputArr = [];
    let outputArr = [];
    inputArr = string;
    let propName, propValue;
    for (const item of inputArr) {
        if (item !== 'print') {
            [propName, propValue] = item.split(' ');
            if (propName === 'add') {
                outputArr.push(propValue);
            }
            if (propName === 'remove') {
                outputArr = outputArr.filter(x => x !== propValue);
            }
        } else {
            console.log(outputArr.join(','))
        }
    }
}

solution(['add hello', 'add again', 'remove hello', 'add again', 'remove again', 'add hello', 'print'])
solution(['add pesho', 'add george', 'add peter', 'remove peter', 'print'])