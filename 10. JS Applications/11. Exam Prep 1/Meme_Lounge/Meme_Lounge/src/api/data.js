import * as api from './api.js';

api.settings.host = 'http://localhost:3030';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

// Application-specific requests
export async function getMemes() {
     return await api.get(host + '/data/memes?sortBy=_createOn%20desc');
}

export async function createMemes(meme) {
     return await api.post(host + '/data/memes', meme);
}
