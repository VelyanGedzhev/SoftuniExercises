import { deleteMemeById, getMemeById } from '../api/data.js';
import { html } from '../lip.js';
import { getUserData } from '../util.js';

const detailsTemplate = (meme, isOwner, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src="${meme.imageUrl}">
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${meme.description}</p>
             ${isOwner ? 
            html `<a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button @click=${onDelete} class="button danger">Delete</button>`
            : null}    
        </div>
    </div>
</section>`;

export async function detailsPage(context) {
    const memeId = context.params.id
    const meme = await getMemeById(memeId);

    const userData = getUserData();
    const isOwner = userData && meme._ownerId == userData.id;
    context.render(detailsTemplate(meme, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm('You are about the delete this meme!');

        if (choice) {
            await deleteMemeById(memeId);
            context.page.redirect('/memes');
        }
    }
}

