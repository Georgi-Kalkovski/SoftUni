import { page, render } from './lib.js';

import { getQuestionsByQuizId, getQuizById, logout as apiLogout } from './api/data.js';
import { browsePage } from './views/browse.js';
import { editorPage } from './views/editor/editor.js';
import { loginPage, registerPage } from './views/auth.js';
import { quizPage } from './views/quiz/quiz.js';

const cache = {};
const main = document.getElementById('content');
setUserNav();
document.getElementById('logoutBtn').addEventListener('click', logout);

page('/browse', decorateContext, browsePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/quiz/:id', decorateContext, getQuiz, quizPage);
page('/create', decorateContext, editorPage);
page('/edit/:id', decorateContext, editorPage);

page.start();


function getQuiz(ctx, next) {
    const quizId = ctx.params.id;
    if (cache[quizId] == undefined) {
        cache[quizId] = getQuizById(quizId).then(quiz => {
            const ownerId = quiz.owner.objectId;
            return getQuestionsByQuizId(quizId, ownerId).then(questions => {
                quiz.questions = questions;
                return quiz;
            });
        });
    }
    ctx.quiz = cache[quizId];
    
    next();
}

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

function setUserNav() {
    const userId = sessionStorage.getItem('userId');
    if (userId != null) {
        document.getElementById('user-nav').style.display = 'block';
        document.getElementById('guest-nav').style.display = 'none';
    } else {
        document.getElementById('user-nav').style.display = 'none';
        document.getElementById('guest-nav').style.display = 'block';
    }
}

async function logout() {
    await apiLogout();
    setUserNav();
    page.redirect('/');
}