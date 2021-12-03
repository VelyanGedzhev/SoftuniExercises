import { register } from '../api/data.js';
import { html } from '../lip.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="register">
    <form @submit=${onSubmit} id="register-form" action="" method="">
        <fieldset>
            <legend>Register Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>`;

export async function registerPage(ctx) {
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);

        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        const confirmPassword = formData.get('confirm-pass').trim();;

        if (email == '' || password == '' || confirmPassword == '') {
            return alert('Invalid registration data!');
        }

        if (password != confirmPassword) {
            return alert('Passwords doesn\'t match!');
        }

        await register(email, password);

        ctx.updateUserNav();
        ctx.page.redirect('/');
    }
}