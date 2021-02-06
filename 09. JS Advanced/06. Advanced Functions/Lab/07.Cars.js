
function solve(input) {
    let obj = {}
    input.forEach(element => {
        let [action, objName, ...params] = element.split(' ')
        if (action == 'create' && params.length == 0) {
            obj[objName] = {}
        } else if (action == 'create' && params.length != 0) {
            obj[objName] = Object.create(obj[params[1]])
        } else if (action == 'set') {
            obj[objName][params[0]] = params[1]
        } else if (action == 'print') {
            print(obj[objName])
        }
    })
    function print(print) {
        let result = []
        for (let key in print) {
            result.push(`${key}:${print[key]}`)
        }
        console.log(result.join(', '))
    }
}


solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);


