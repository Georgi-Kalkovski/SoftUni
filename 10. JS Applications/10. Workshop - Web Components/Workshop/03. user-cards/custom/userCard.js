import BaseComponent from './baseComponent.js';

class UserCard extends BaseComponent {
    static get observedAttributes() {
        return ['name', 'avatar']
    }

    constructor() {
        super();
        this.state = {
            showInfo: true,
            avatar: this.getAttribute('avatar'),
            name: this.getAttribute('name')
        };

        this.root.appendChild(
            this.render()
        )
    }

    toggleInfo = (e) => {
        const btn = e.target;
        this.state.showInfo = !this.state.showInfo;

        if (this.state.showInfo) {
            btn.textContent = 'Hide Info';

            this._update({ '.info p:nth-child(2)': { 'style.display': 'block' } });
            this._update({ '.info p:nth-child(3)': { 'style.display': 'block' } });
        } else {
            btn.textContent = 'Show Info';

            this._update({ '.info p:nth-child(2)': { 'style.display': 'none' } });
            this._update({ '.info p:nth-child(3)': { 'style.display': 'none' } });
        }
    }

    connectedCallback() {
        this.root.querySelector('.toggle-info-btn')
            .addEventListener('click', this.toggleInfo);
    }

    disconectedCallback() {
        this.root.querySelector('.toggle-info-btn')
            .removeEventListener();
    }

    attributeChangedCallback(attrName, oldVal, newVal) {
        console.log(`${attrName}'s value has been changed from ${oldVal} to ${newVal}`);
    }

    render() {
        const { avatar, name } = this.state;

        return this.html`
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
                <img src=${avatar} />
            </figure>
            <div class="info">
                <h3>${name}</h3>
                <p><slot name="email" /></p>
                <p><slot name="phone" /></p>

                <button class="toggle-info-btn">Toggle Info</button>
            </div>
        </div>
        `
    }
}

window.customElements.define('user-card', UserCard);