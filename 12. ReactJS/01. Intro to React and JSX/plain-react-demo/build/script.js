var rootElement = document.getElementById('root');

/*

Example 1 - React without JSX
-----------------------------
let reactElement = React.createElement('h1', {}, 'Hello React!');

Example 2 - React without JSX
-----------------------------
let reactElement = React.createElement(
    'header',
    { className: 'site-header' },
    React.createElement('h1', { id: 'main-heading'}, 'Hello React'),
    React.createElement('h2', {}, 'The best framework in the world!')
);

INSTALLING JSX TO A PROJECT
---------------------------
Step 1: Run npm init -y (if it fails, here’s a fix)
Step 2: Run npm install babel-cli@6 babel-preset-react-app@3

COMMAND FOR TURNING JS TO JSX
-----------------------------
npx babel --watch src --out-dir . --presets react-app/prod
*/

var reactElement = React.createElement(
    'header',
    null,
    React.createElement(
        'h1',
        null,
        'Hello JSX Modified'
    ),
    React.createElement(
        'h2',
        null,
        'The best framework in the world!'
    ),
    React.createElement(
        'p',
        null,
        '\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95\uD83D\uDC95'
    ),
    React.createElement(
        'footer',
        null,
        'All rights reserved \xA9 '
    )
);

ReactDOM.render(reactElement, rootElement);