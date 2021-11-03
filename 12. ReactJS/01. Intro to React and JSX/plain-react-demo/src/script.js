let rootElement = document.getElementById('root');

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

let reactElement = (<header>
    <h1>Hello JSX Modified</h1>
    <h2>The best framework in the world!</h2>

    <p>💕💕💕💕💕💕💕💕💕💕💕💕💕💕💕💕</p>
    <footer>All rights reserved &copy; </footer>
</header>);



ReactDOM.render(reactElement, rootElement);