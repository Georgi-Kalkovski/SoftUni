import createApi from './api.js';

const api = createApi(null, null, (msg) => alert(msg));


export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function getIdeas() {
    return await api.get('data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
}

export async function getDetails(id) {
    return await api.get('data/ideas/' + id);
}

export async function createIdea(idea) {
    return await api.post('data/ideas', idea);
}

export async function deleteIdea(id) {
    return await api.delete('data/ideas/' + id);
}