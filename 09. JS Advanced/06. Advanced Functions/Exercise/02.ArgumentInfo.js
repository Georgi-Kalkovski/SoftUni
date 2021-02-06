function ArgumentInfo(...params) {
    const typeCount = {}
    params.forEach(element => {
        if (!typeCount.hasOwnProperty(typeof element)) {
            typeCount[typeof element] = 0
        }
        typeCount[typeof element] += 1
        console.log(`${typeof element}: ${element}`)
    })
    let typeSorted = Object.entries(typeCount).sort((a, b) => b[1] - a[1]).reduce((a, b) => {
        a[b[0]] = b[1]
        return a
    }, {})
  
    for (let type in typeSorted) {
        console.log(`${type} = ${typeCount[type]}`);
    }
}

ArgumentInfo('cat', 42, function () { console.log('Hello world!'); })