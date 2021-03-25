import { html, render } from '../node_modules/lit-html/lit-html.js';
import { styleMap } from '../node_modules/lit-html/directives/style-map.js';


const carouselHTMLTemplate = (ctx) => html`
    <style>
        .carousel-container {
            max-width: 60rem;
            position: relative;
            margin: 0 auto;
        }
        
        .carousel-slide {
            display:none;
        }
        
        .carousel-slide>img {
            width: 100%;
            max-height: 500px
        }
        
        /* Next & previous buttons */
        
        .prev,
        .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            width: auto;
            margin-top: -22px;
            padding: 16px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            transition: 0.6s ease;
            border-radius: 0 3px 3px 0;
            user-select: none;
        }
        
        /* Position the "next button" to the right */
        
        .next {
            right: 0;
            border-radius: 3px 0 0 3px;
        }
        
        /* On hover, add a black background color with a little bit see-through */
        
        .prev:hover, .next:hover {
            background-color: rgba(0, 0, 0, 0.8);
        }
        
        /* Caption text */
        
        .caption-text {
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
            font-weight: bold;
            font-size: 1.5em;
        }
        
        /* Number text (1/3 etc) */
        
        .number-text {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }
        
        /* The dots/bullets/indicators */
        .carousel-controls > .dot {
            cursor: pointer;
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }
        
        .active,
        .dot:hover {
            background-color: #717171;
        }
        
        /* Fading animation */
        
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }
        
        @-webkit-keyframes fade {
            from {
                opacity: .4
            }
            to {
                opacity: 1
            }
        }
        
        @keyframes fade {
            from {
                opacity: .4
            }
            to {
                opacity: 1
            }
        }
    </style>
    <div class="carousel-container">
            ${ctx.articleData.map(([img, caption, isVisible], index) => {
                const styles = {
                    display: isVisible ? 'block' : 'none'
                };

                return html`
                    <article style=${styleMap(styles)} class="carousel-slide fade">
                        <p class="number-text">${index + 1} / ${ctx.articleData.length}</p>
                        <img src=${img} alt="Alt Image">
                        <p class="caption-text">${caption}</p>
                    </article>`
                 })
            }

            <a class="prev" @click=${ctx.handlePrev}>&#10094;</a>
            <a class="next" @click=${ctx.handleNext}>&#10095;</a>
        </div>

        <!-- The dots/circles -->
        <div class="carousel-controls" style="text-align:center">
            ${ctx.articleData.map((_, i) => html`
                <span class="dot" 
                    id=${i} 
                    @click=${ctx.handleSelect}></span>
            `)}
        </div>
`

class Carousel extends HTMLElement {
    constructor() {
        super();

        this.state = {
            articleData: this.articleData,
            currentIndex: 0,
            handleNext: this.handleNext,
            handlePrev: this.handlePrev,
            handleSelect: this.handleSelect
        }

        this.root = this.attachShadow({ mode: 'closed' });
        this._update();
    }

    get imageUrls() {
        return [...this.attributes]
            .filter(a => a.name.includes('image-url'))
            .map(a => a.value)
    }

    get captions() {
        return [...this.attributes]
            .filter(a => a.name.includes('caption'))
            .map(a => a.value)
    }

    get articleData() {
        return this.imageUrls
            .reduce((data, img, index) => {
                const elInfo = [img, this.captions[index], false];

                if (index === 0) {
                    elInfo[2] = true;
                }

                data.push(elInfo);
                return data;
            }, []);
    }

    handlePrev() {
        const { currentIndex, articleData } = this.state;

        if (currentIndex - 1 < 0) {
            this.state.currentIndex = articleData.length - 1;
        } else {
            this.state.currentIndex--;
        }

        this._updateArticles();
    }

    handleNext() {
        const { currentIndex, articleData } = this.state;

        // Change Index
        if (currentIndex + 1 >= articleData.length) {
            this.state.currentIndex = 0;
        } else {
            this.state.currentIndex++;
        }

        // Change Slideshow
        this._updateArticles();
    }

    handleSelect(e) {
        const index = Number(e.target.id);
        this.state.currentIndex = index;

        this._updateArticles();
    }

    _updateArticles() {
        this.state.articleData
            .forEach((data, index) => {
                if (this.state.currentIndex === index) {
                    data[2] = true;
                } else {
                    data[2] = false;
                }
            })

        this._update();
    }

    _update() {
        render(carouselHTMLTemplate(this.state), this.root, { eventContext: this });
    }
}

customElements.define('app-carousel', Carousel);