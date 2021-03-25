import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { styleMap } from '../../node_modules/lit-html/directives/style-map.js'

const userCardTemplate = (ctx) => {
    const displayStyles = {
        display: ctx.showInfo ? 'block' : 'none'
    }

    return html`
        <style>
        .user-card {
            display:flex;
            font-family: 'Arial', sans-serif;
            background-color: #EEE;
            border-bottom: 5px solid darkorchid;
            width: 100%;
        }

        .user-card img {
            width: 200px;
            height: 200px;
            border: 1px solid darkorchid;
        }

        .info {
            display:flex;
            flex-direction: column;
        }

        .info h3 {
            font-weight: bold;
            margin-top: 1em;
            text-align: center;
        }

        .info button {
            outline: none;
            border: none;
            cursor: pointer;
            background-color: darkorchid;
            color: white;
            padding: 0.5em 1em;
        }

        @media only screen and ( max-width: 500px ) {
            .user-card {
                flex-direction: column;
                margin-bottom: 1em;
            }

            .user-card figure,
            .info button {
                align-self: center;
            }

            .info button {
                margin-bottom: 1em;
            }

            .info p {
                padding-left: 1em;
            }
        }
        </style>
        <div class="user-card">
        <figure>
            <img src=${ctx.avatar} />
        </figure>
        <div class="info">
            <h3>${ctx.name}</h3>
            <div style=${styleMap(displayStyles)}>
                <p><slot name="email" /></p>
                <p><slot name="phone" /></p>
            </div>

            <button @click=${ctx.toggleInfoHandler} class="toggle-info-btn">Toggle Info</button>
        </div>
        </div>
    `
}

class UserCard extends HTMLElement {
    constructor() {
        super();
        this.state = {
            showInfo: true,
            avatar: this.getAttribute('avatar'),
            name: this.getAttribute('name'),
            toggleInfoHandler: this.toggleInfoHandler
        };

        this.root = this.attachShadow({ mode: 'closed' });
        
        render(userCardTemplate(this.state), this.root, { eventContext: this });
    }

    toggleInfoHandler(e) {
        const btn = e.target;
        this.state.showInfo = !this.state.showInfo;

        if (this.state.showInfo) {
            btn.textContent = 'Hide Info';
        } else {
            btn.textContent = 'Show Info';
        }

        this._update();
    }

    _update() {
        render(userCardTemplate(this.state), this.root, { eventContext: this });
    }
}

customElements.define('user-card', UserCard);