window.addEventListener('load', solve);

function solve() {
    const genre = document.getElementById('genre');
    const songName = document.getElementById('name');
    const author = document.getElementById('author');
    const date = document.getElementById('date');
    const addButton = document.getElementById('add-btn');
    const songsCollection = document.getElementsByClassName('all-hits-container')[0];
    const savedSongs = document.getElementsByClassName('saved-container')[0];
    const likes = document.querySelector('#total-likes p')

    addButton.addEventListener('click', addSong);
    

    function addSong (e) {
        e.preventDefault();

        if (genre.value == '' ||
        songName.value == '' ||
        author.value == '' ||
        date.value == '') {
            return;
        }

        const songDiv = document.createElement('div');
        songDiv.classList.add("hits-info");

        songDiv.innerHTML = `
        <img src="./static/img/img.png">
        <h2>Genre: ${genre.value}</h2>
        <h2>Name: ${songName.value}</h2>
        <h2>Author: ${author.value}</h2>
        <h3>Date: ${date.value}</h3>`;

        // <button class="save-btn">Save song</button>
        // <button class="like-btn">Like song</button>
        // <button class="delete-btn">Delete</button>

        saveBtn = document.createElement('button');
        saveBtn.textContent = 'Save song';
        saveBtn.classList.add("save-btn");
        saveBtn.addEventListener('click', saveSong);

        likeBtn = document.createElement('button');
        likeBtn.textContent = 'Like song';
        likeBtn.classList.add("like-btn");
        likeBtn.addEventListener('click', likeSong);

        deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.classList.add("delete-btn");
        deleteBtn.addEventListener('click', deleteSong);

        songDiv.appendChild(saveBtn);
        songDiv.appendChild(likeBtn);
        songDiv.appendChild(deleteBtn);

        songsCollection.appendChild(songDiv);

        genre.value = '';
        songName.value = '';
        author.value = '';
        date.value = '';
        
    }

    function saveSong(e) {
        e.preventDefault();

        const songToMove = e.target.parentNode;
        likeBtn = songToMove.getElementsByClassName('like-btn')[0];
        saveBtn = songToMove.getElementsByClassName('save-btn')[0];

        saveBtn.remove();
        likeBtn.remove();

        savedSongs.appendChild(songToMove);
    }

    function likeSong(e) {
        e.preventDefault();

        currentLikes = Number(likes.textContent.split(' ')[2]);
        likes.textContent = `Total Likes: ${currentLikes + 1}`;
    }

    function deleteSong(e) {
        e.preventDefault();

        const songToMove = e.target.parentNode;
        songToMove.remove();
    }
}