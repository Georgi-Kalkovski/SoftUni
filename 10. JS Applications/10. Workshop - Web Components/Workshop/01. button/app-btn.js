import { html, render } from '../node_modules/lit-html/lit-html.js';

const btnTemplate = (ctx) =>  html`
    <style>
        .btn {
            padding: 0.5em 1em;
            border-radius: 0.5em;
            font-family: sans-serif;
            font-weight: bold;
            font-size: 1.2em;
            outline: none;
            cursor: pointer;
            box-shadow: 0 0 5px 0 rgba(0, 0, 0, 0.5);
            border: none;
        }
    
        .basic {
            color: rgb(0, 0, 0);
            background-color: rgb(255, 255, 255);
        }
    
        .primary {
            color: rgb(255, 255, 255);
            background-color: rgb(63, 81, 181);
        }
    
        .accent {
            color: rgb(255, 255, 255);
            background-color: rgb(255, 64, 129);
        }
    
        .warn {
            color: rgb(255, 255, 255);
            background-color: rgb(244, 67, 54);
        }
        </style>
        <button disabled=${ctx.isDisabled} class="btn ${ctx.type}">${ctx.text}</button>
`

class CustomButton extends HTMLElement {
    constructor() {
        super();
        this.state = {
            text: this.getAttribute('text'),
            type: this.getAttribute('type')
        }

        this.root = this.attachShadow({ mode: 'closed' });
        render(btnTemplate(this.state), this.root);
    }
}

customElements.define('app-button', CustomButton);