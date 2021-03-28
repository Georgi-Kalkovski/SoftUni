import * as api from './api.js';


const host = 'https://parseapi.back4app.com';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

// Implement application-specific requests
function createPointer(name, id) {
    return {
        __type: 'Pointer',
        className: name,
        objectId: id
    };
}

function addOwner(object) {
    const userId = sessionStorage.getItem('userId');
    const result = Object.assign({}, object);
    result.owner = createPointer('_User', userId);
    return result;
}


// Quiz Collection
export async function getQuizes() {
    return (await api.get(host + '/classes/Quiz')).results;
}

export async function getQuizById(id) {
    return await api.get(host + '/classes/Quiz/' + id + '?include=owner');
}

export async function createQuiz(quiz) {
    const body = addOwner(quiz);
    return await api.post(host + '/classes/Quiz', body);
}

export async function updateQuiz(id, quiz) {
    return await api.put(host + '/classes/Quiz/' + id, quiz);
}

export async function deleteQuiz(id) {
    return await api.del(host + '/classes/Quiz/' + id);
}

// Question Collection
export async function getQuestionsByQuizId(quizId, ownerId) {
    const query = JSON.stringify({
        quiz: createPointer('Quiz', quizId),
        owner: createPointer('_User', ownerId)
    });
    const response = await api.get(host + '/classes/Question?where=' + encodeURIComponent(query));
    return response.results;
}

export async function createQuestion(quizId, question) {
    const body = addOwner(question);
    body.quiz = createPointer('Quiz', quizId);
    return await api.post(host + '/classes/Question', body);
}

export async function updateQuestion(id, question) {
    return await api.put(host + '/classes/Question/' + id, question);
}

export async function deleteQuestion(id) {
    return await api.del(host + '/classes/Question/' + id);
}


// Solution Collection
export async function getSolutionsByUserId(userId) {
    const query = JSON.stringify({ owner: createPointer('_User', userId) });
    const response  = await api.get(host + '/classes/Solution?where=' + encodeURIComponent(query));
    return response.results;
}

export async function getSolutionsByQuizId(quizId) {
    const query = JSON.stringify({ owner: createPointer('Quiz', quizId) });
    const response  = await api.get(host + '/classes/Solution?where=' + encodeURIComponent(query));
    return response.results;
}

export async function submitSolution(quizId, solution) {
    const body = addOwner(solution);
    body.quiz = createPointer('Quiz', quizId);
    return await api.post(host + '/classes/Solution', body);
}