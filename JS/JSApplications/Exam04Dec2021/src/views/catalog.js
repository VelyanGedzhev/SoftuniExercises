import { html } from '../lip.js';
import { getAllAlbums } from '../api/data.js'
import { getUserData } from '../util.js';

const catalogTemplate = (albums, userData) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${
        albums.length == 0 
        ? html`<p>No Albums in Catalog!</p>`
        : userData
            ? html `<ul class="other-books-list">${albums.map(albumPreview)}</ul>`
            : html `<ul class="other-books-list">${albums.map(albumPreviewGuest)}</ul>`
    }

</section>`;

const albumPreview = (album) => html`    
<div class="card-box">
    <img src="${album.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}s</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        <div class="btn-group">
        <a href="/details/${album._id}" id="details">Details</a>
        
        </div>
    </div>
</div>`;

const albumPreviewGuest = (album) => html`    
<div class="card-box">
    <img src="${album.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}s</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
    </div>
</div>`;

export async function catalogPage(ctx) {
    const albums = await getAllAlbums();
    const userData = getUserData();

    ctx.render(catalogTemplate(albums, userData));
}
