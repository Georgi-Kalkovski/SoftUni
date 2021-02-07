function RequestValidator(input) {

    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriRegex = /^[a-zA-Z0-9.]+$|^\*$/g;
    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let message = /^[^<>\\&'"]*$/g;

    if (!validMethods.includes(input.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!input.hasOwnProperty('uri') || !input.uri.match(uriRegex)) {
        throw new Error("Invalid request header: Invalid URI");
    }

    if (!validVersions.includes(input.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!input.hasOwnProperty('message') || !input.message.match(message)) {
        throw new Error("Invalid request header: Invalid Message");
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