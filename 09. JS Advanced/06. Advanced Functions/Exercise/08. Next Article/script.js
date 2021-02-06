function getArticleGenerator(articles) {
    let content = document.getElementById('content');
    
    return function showNext() {
        if(articles.length){
            let article = document.createElement('article')
            article.textContent = articles.shift();
            content.appendChild(article);    
        }
    }
}
