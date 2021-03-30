import * as api from './api.js';

api.settings.host = 'http://localhost:3030';
const host = api.settings.host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getItems() {
    return await api.get(host + '/data/memes?sortBy=_createdOn%20desc');
}

export async function getItem(id) {
    return await api.get(host + '/data/memes/' + id);
}

export async function getProfile(userId) {
    return await api.get(host + `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function addItem(item) {
    return await api.post(host + '/data/memes', item);
}

export async function editItem(id, item) {
    return await api.put(host + '/data/memes/' + id, item);
}

export async function deleteItem(id) {
    return await api.del(host + '/data/memes/' + id);
}