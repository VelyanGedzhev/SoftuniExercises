import { notify } from '../notify.js';
import { clearUserData, getUserData, setUserData } from '../util.js';

const hostname = 'http://localhost:3030';

async function request(url, options) {
    try {
        const respone = await fetch(hostname + url, options);

        if (respone.ok == false) {
            const error = await respone.json();
            throw new Error(error.message);
        }

        // if (respone.status == 204) {
        //     return respone;
        // } else {
        //     return respone.json();
        // }

        try {
            return await respone.json();
        } catch (error) {
            return respone;
        }

    } catch (err) {
        notify(err.message);
        throw err;
    }
}

function createOptions(method = 'get', data) {
    const options = {
        method,
        headers: {}
    };

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userData = getUserData();

    if (userData) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('post', data));
}

export async function put(url, data) {
    return request(url, createOptions('put', data));
}

export async function del(url, data) {
    return request(url, createOptions('delete'));
}

export async function login(email, password) {
    const result = await post('/users/login', {email, password});

    const userData = {
        username: result.username,
        email: result.email,
        id: result._id,
        gender: result.gender,
        token: result.accessToken
    };

    setUserData(userData);

    return result;
}

export async function register(username, email, password, gender) {
    const result = await post('/users/register', {username, email, password, gender});

    const userData = {
        username: result.username,
        email: result.email,
        id: result._id,
        gender: result.gender,
        token: result.accessToken
    };

    setUserData(userData);

    return result;
}

export async function logout() {
    get('/users/logout');
    clearUserData();
}