import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllAlbums() {
    return api.get('/data/albums?sortBy=_createdOn%20desc&distinct=name');
}

export async function getAlbumById(id) {
    return api.get('/data/albums/' + id);
}

export async function createAlbum(album) {
    return api.post('/data/albums', album);
}

export async function editAlbum(id, book) {
    return api.put('/data/albums/' + id, book);
}

export async function deleteAlbum(id) {
    return api.del('/data/albums/' + id);
}

// export async function myBooks(userId) {
//     return api.get(`/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
// }