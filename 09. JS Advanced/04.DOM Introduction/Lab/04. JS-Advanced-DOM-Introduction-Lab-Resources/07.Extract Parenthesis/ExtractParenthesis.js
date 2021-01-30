  function extract(input) {
    let content = document.getElementById(input).textContent;
    let regexp = /\(([^)]+)\)/g;
    let result = [];

    let match = regexp.exec(content);
    while (match) {
        result.push(match[1]);
        match = regexp.exec(content);
    }

    return result.join('; ');
}