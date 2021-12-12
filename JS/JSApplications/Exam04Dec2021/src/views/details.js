import { html } from '../lip.js';
import { deleteAlbum, getAlbumById } from '../api/data.js'
import { getUserData } from '../util.js';

const detailsTemplate = (album, isOwner, onDelete) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src="${album.imgUrl}">
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre: ${album.genre}</h4>
                <h4>Price: $${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>Description: ${album.description}</p>
            </div>
            <div class="actionBtn">
                ${albumControlsTemplate(album, isOwner, onDelete)}
            </div>
        </div>
    </div>
</section>`;

//
const albumControlsTemplate = (album, isOwner, onDelete) => {
    if (isOwner) {
        return html `
        <a class="button" href="/edit/${album._id}">Edit</a>
        <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`;
    } else {
        return null; 
    }
}

export async function detailsPage(ctx) {
    const album = await getAlbumById(ctx.params.id);

    const userData = getUserData();
    const isOwner = userData && userData.id == album._ownerId;

    ctx.render(detailsTemplate(album, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete ${album.title}`);

        if (choice) {
            await deleteAlbum(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
}

