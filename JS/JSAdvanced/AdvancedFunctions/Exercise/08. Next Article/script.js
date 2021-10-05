function getArticleGenerator(articles) {
    const articlesArr = articles;
    const result = document.getElementById('content');

    return () => {
        if (articlesArr.length != 0) {
            const article = document.createElement('article');
            article.textContent = articlesArr.shift();
            result.appendChild(article);
        }
    }
}
