function RequestValidator(input) {

    let validMethod = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let validUri = /^[a-zA-Z0-9.]+$|^\*$/g;
    let validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let validMessage = /^[^<>\\&'"]*$/g;

    if (!validMethod.includes(input.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }
    if (!input.uri.match(validUri) || !input.hasOwnProperty('uri')) {
        throw new Error('Invalid request header: Invalid URI');
    }
    if (!validVersion.includes(input.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }
    if (!input.message.match(validMessage) || !input.hasOwnProperty('message')) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return input;
}

console.log(RequestValidator(`{
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  }
  `))
console.log(RequestValidator(`{
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
  }
  `))
console.log(RequestValidator(`{
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
  }
  `))