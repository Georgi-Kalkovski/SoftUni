import { html, render } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';

const UUIDGeneratorBrowser = () =>
    ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))).toString(16)
    );

const editableListTemplate = (ctx) => html`
    <style>
        .container {
            max-width: 500px;
            margin: 50px auto;
            border-radius: 20px;
            border: solid 8px #2c3033;
            background: white;
            box-shadow: 0 0 0px 1px rgba(255, 255, 255, .4), 0 0 0px 3px #2c3033;
        }

        .editable-list-header {
            margin: 0;
            border-radius: 10px 10px 0 0px;
            background-image: linear-gradient(#687480 0%, #3b4755 100%);
            font: bold 18px/50px arial;
            text-align: center;
            color: white;
            box-shadow: inset 0 -2px 3px 2px rgba(0, 0, 0, .4), 0 2px 2px 2px rgba(0, 0, 0, .4);
        }
        .editable-list {
            padding-left: 0;
        }
        .editable-list>li,
        .editable-list-add-container {
            display: flex;
            align-items: center;
        }

        .editable-list>li {
            justify-content: space-between;
            padding: 0 1em;
        }

        .editable-list-add-container {
            justify-content: space-evenly;
        }

        .editable-list>li:nth-child(odd) {
            background-color: rgb(229, 229, 234);
        }

        .editable-list>li:nth-child(even) {
            background-color: rgb(255, 255, 255);
        }

        .editable-list-add-container>label {
            font-weight: bold;
            text-transform: uppercase;
        }

        .icon {
            background: none;
            border: none;
            cursor: pointer;
            font-size: 1.8rem;
            outline: none;
        }
    </style>
    <article class="container">
    <h1 class="editable-list-header">${ctx.listTitle}</h1>

    <ul class="editable-list">
        ${repeat(ctx.listItems, UUIDGeneratorBrowser, (item, index) => html`
            <li>
                <p class="editable-list-item-value">${item}</p>
                <button @click=${ctx.deleteItemHandler} data-target=${index} class="editable-list-remove-item icon">
                    &ominus;
                </button>
            </li>
        `)}
    </ul>

    <div class="editable-list-add-container">
        <label>${ctx.addItemText}</label>
        <input @input=${ctx.addItemInputHandler} .value=${ctx.addItemValue} class="add-new-list-item-input" type="text" />
        <button @click=${ctx.addItemClickHandler} class="editable-list-add-item icon">&oplus;</button>
    </div>
</article>
`

class EditableList extends HTMLElement {
    constructor() {
        super();

        this.state = {
            listTitle: this.title,
            listItems: this.items,
            addItemText: this.addItemText,
            addItemValue: '',
            addItemInputHandler: this.addItemInputHandler,
            addItemClickHandler: this.addItemClickHandler,
            deleteItemHandler: this.deleteItemHandler
        }

        this.root = this.attachShadow({ mode: 'closed' });
        this._update();
    }

    get title() {
        return this.getAttribute('title') || '';
    }

    get items() {
        let items = [];

        [...this.attributes].forEach(attr => {
            if (attr.name.includes('list-item')) {
                items = items.concat(attr.value);
            }
        });

        return items;
    }

    get addItemText() {
        return this.getAttribute('add-item-text') || '';
    }

    addItemInputHandler(e) {
        const value = e.target.value;

        this.state.addItemValue = value;
    }

    addItemClickHandler() {
        if (this.state.addItemValue !== '') {
            this.state.listItems = this.state.listItems
                .concat(this.state.addItemValue);
            this.state.addItemValue = '';
            this.root.querySelector('.add-new-list-item-input').value = '';

            this._update();
        }
    }

    deleteItemHandler(e) {
        const itemIndex = Number(e.target.getAttribute('data-target'));

        if (itemIndex >= 0 && itemIndex < this.state.listItems.length) {
            this.state.listItems.splice(itemIndex, 1);
            this._update();
        }
    }

    _update() {
        render(editableListTemplate(this.state), this.root, { eventContext: this });
    }
}

customElements.define('app-editable-list', EditableList);