import { html, render } from '../node_modules/lit-html/lit-html.js';

const sliderHTMLTemplate = (ctx) => html`
<style>
    .slider-container {
        font-family: 'Montserrat', sans-serif;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: space-between;
        height: 100px;
    }

    .slider-percentage-value {
        font-weight: bold;
        text-align: center;
        margin: 1em 0;
    }

    .slider {
        -webkit-appearance: none;
        width: 100%;
        height: 15px;
        border-radius: 5px;
        background: #d3d3d3;
        outline: none;
        opacity: 0.7;
        -webkit-transition: .2s;
        transition: opacity .2s;
        margin: 0 1em;
    }

    .slider::-webkit-slider-thumb {
        -webkit-appearance: none;
        appearance: none;
        width: 25px;
        height: 25px;
        border-radius: 50%;
        background: #4CAF50;
        cursor: pointer;
    }

    .slider::-moz-range-thumb {
        width: 25px;
        height: 25px;
        border-radius: 50%;
        background: #4CAF50;
        cursor: pointer;
    }
</style>
<div class="slider-container">
    <input class="slider" type="range"
        @input=${ctx.sliderInputHandler}
        value="${ctx.value}" 
        step="${ctx.step}" />
    <div class="slider-end">
        Percentage: <span class="slider-percentage-value">${ctx.percentage}</span>
    </div>
</div>
`
class Slider extends HTMLElement {
    constructor() {
        super()

        this.state = {
            step: this.step,
            value: this.value,
            percentage: this.percentage,
            sliderInputHandler: this.sliderInputHandler
        }

        this.root = this.attachShadow({ mode: 'closed' });

        this._update();
    }


    get step() {
        return this.getAttribute('step') || '0.1';
    }

    get value() {
        if (this.isInverted) {
            return 100 - Number(this.getAttribute('slider-value') || '0')
        }

        return this.getAttribute('slider-value') || '0';
    }

    get percentage() {
        let calcPercentage = Number(this.value) / 100 * 100;

        if (this.isInverted) {
            calcPercentage = (100 - Number(this.value)) / 100 * 100
        }

        return `${calcPercentage.toFixed(2)} %`
    }

    get isInverted() {
        return this.hasAttribute('invert');
    }

    sliderInputHandler(e) {
        this.state.value = e.target.value;
        let percentage = Number(this.state.value) / 100 * 100;

        if (this.isInverted) {
            percentage = (100 - Number(this.state.value)) / 100 * 100
        }

        this.state.percentage = `${percentage.toFixed(2)} %`

        this._update();
    }

    _update() {
        render(sliderHTMLTemplate(this.state), this.root, { eventContext: this });
    }
}

customElements.define('app-slider', Slider);