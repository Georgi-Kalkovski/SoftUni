import * as api from './api.js';

api.settings.host = 'http://localhost:3030'

export async function getItems() {
    return await api.get(api.settings.host + '/data/catalog')
}

export async function getItem(id) {
    return await api.get(api.settings.host + '/data/catalog/' + id)
}

export async function getItemsByOwner(userId) {
    return await api.get(api.settings.host + `/data/catalog?where=_ownerId%3D%22${userId}%22`);
}

export async function deleteItem(id) {
    return await api.del(api.settings.host + '/data/catalog/' + id)
}

export async function addItem(item) {
    return await api.post(api.settings.host + `/data/catalog`, item);
}

export async function editItem(id, item) {
    return await api.put(api.settings.host + `/data/catalog/` + id, item);
}