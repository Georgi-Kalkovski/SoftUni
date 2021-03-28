class BaseComponent extends HTMLElement {
    constructor() {
        super();

        this.root = this.attachShadow({ mode: 'closed' });
        this._update = this.updateTemplateFactory(this.root);
    }

    html(strs, ...exprs) {
        const myHtml = strs.reduce((acc, curr, index) => {
            const currentExpression = exprs[index];
            let result = acc + curr;
            if (currentExpression) {
                result += currentExpression;
            }
    
            return result;
        }, '');
    
        const template = document.createElement('template');
        template.innerHTML = myHtml;
    
        return template.content.cloneNode(true);
    }

    updateTemplateFactory(root) {
        return function (updates) {
            Object.entries(updates).forEach(([selector, changedProps]) => {
                let el = root.querySelector(selector);
                if (!el) {
                    return;
                }
    
                Object.keys(changedProps)
                    .forEach(prop => {
                        const allProps = prop.split('.');
    
                        if (allProps.length > 1) {
                            let currentObject = el[allProps[0]];
    
                            for (let i = 1; i < allProps.length; i++) {
                                let currentProp = allProps[i];
                                let tempObject = currentObject[currentProp];
    
                                if (typeof (tempObject) !== "object") {
                                    currentObject[currentProp] = changedProps[prop];
                                    break;
                                }
                            }
    
                        } else {
                            el[prop] = changedProps[prop];
                        }
                    })
            })
        }
    }
}

export default BaseComponent;