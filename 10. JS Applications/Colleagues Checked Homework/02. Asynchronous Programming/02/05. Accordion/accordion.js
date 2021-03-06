function solution() {
    const articleIds = [];
    const articleObjs = [];

    getInitialData();
    // since there is a delay from the server a time out is set to compensate
    // if for some reason app isn't working change value 300 to 600
    setTimeout(() => {getArticleObjs()}, 100);
    setTimeout(() => {createArticles()}, 300)

    // function will make a request to get all the ids and store them in an array
    async function getInitialData() {
        for (let num = 0; num < 4; num++) {
            let url = `http://localhost:3030/jsonstore/advanced/articles/list/${num}`;
            let request = await fetch(url);
            let ids = await request.json();
            articleIds.push(ids._id);
        }
    }

    // function will make several request to the server to get all the data needed
    // and store it in an array
    async function getArticleObjs() {
        for (let id of articleIds) {
            let url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
            let request = await fetch(url);
            let articles = await request.json();
            articleObjs.push(articles)
        }
    }

    // function will generate all the needed html elements and fill them with
    // the required data
    function createArticles() {
        let section = document.getElementById("main")
        for (let article of articleObjs) {
            let mainDiv = document.createElement('div');
            mainDiv.classList.add("accordion");
            let headDiv = document.createElement('div');
            headDiv.classList.add("head");
            let span = document.createElement('span');
            span.textContent = article.title;
            headDiv.appendChild(span);
            let btn = document.createElement("button");
            btn.textContent = "More";
            btn.classList.add("button")
            btn.id = article._id;
            btn.addEventListener("click", (e) => {
                let div = e.target.parentNode.parentNode.childNodes[1];
                let isVisible = div.style.display === 'none';
                div.style.display = isVisible ? 'block' : 'none';
                btn.textContent = !isVisible ? 'More' : 'Less';
            })
            headDiv.appendChild(btn);
            let extraDiv = document.createElement('div');
            extraDiv.classList.add("extra");
            extraDiv.style.display = 'none'
            let p = document.createElement('p');
            p.textContent = article.content;
            extraDiv.appendChild(p);
            mainDiv.appendChild(headDiv);
            mainDiv.appendChild(extraDiv);
            section.appendChild(mainDiv);
        }
    }
}

solution();
