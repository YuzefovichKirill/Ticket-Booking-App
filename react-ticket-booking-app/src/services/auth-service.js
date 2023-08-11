import { UserManager } from 'oidc-client'
import environment from '../environments/environment'

const settings = {
    authority: environment.AuthorityUrl,
    client_id: environment.clientId,
    redirect_uri: environment.clientUrl + 'signin-callback',
    scope: 'openid profile TicketBookingAPI roles',
    response_type: 'code',
    post_logout_redirect_uri: environment.clientUrl + 'signout-callback'
}

const userManager = new UserManager(settings);

export function login() {
    return userManager.signinRedirect();
}

export function finishLogin() {
    return userManager.signinRedirectCallback();
}

export function logout() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect();
}

export function finishLogout() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
}

export function isAuthenticated() {
    return checkUser(userManager.getUser())
}

export function checkUser(user) {
    return !!user && !user.expired;
}

export function getAccessToken() {
    return this.UserManager.getUser()
        .then(user => {
            return !!user && user.expired ? user.access_token : null;
        })
}
