import * as api from './api.js'

const host = 'http://localhost:3030';
api.settings.host = host;

export async function getIdeas(){
   return await api.get(host + '/data/ideas?select=_id%2Ctitle%2Cimg&amp;sortBy=_createdOn%20desc')
}